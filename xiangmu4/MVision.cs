using MVSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using CameraHandle = System.Int32;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using HalconDotNet;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Concurrent;



#region 说明
/* 简介：MIndvision.cs 的进一步封装，因为线程内返回值比较难弄，所以封装的类需要用异步回调来取图
 * 功能介绍：该类主要对MIndvision.cs简单封装，需传入picturebox给构造函数，用于绑定显示的窗口；* 
 * 
 * 
 * 1、设置属性：
 * __PhotoOnceFlag 用于开启和线程采集的标志位
 * 
 *
 * 
 * 2、启动相机关闭相机
 * ①：初始化相机
 * ②：开始采集（此时是连续采集）
 * ②：再次点击只采集一张
 * ③：相机关闭

  */
#endregion

namespace xiangmu4
{
    public class MVision
    {
        #region 构造函数

        public  MVision(PictureBox pictureBox)
        {
            _picturebox = pictureBox;
        }
        #endregion
        #region 相机字段
        /// <summary>
        /// 0为连续采集，1软触发，2 硬出发
        /// </summary>
        private int _TriggerModel;
        protected IntPtr m_Grabber = IntPtr.Zero;
        protected CameraHandle m_hCamera = 0;
        protected ColorPalette m_GrayPal;
        protected pfnCameraGrabberFrameCallback m_FrameCallback;
        protected tSdkCameraDevInfo m_DevInfo;
        /// <summary>
        /// 传入的picturbox 用于初始化相机
        /// </summary>
        private PictureBox _picturebox;
        /// <summary>
        /// 相机的状态
        /// </summary>
        CameraSdkStatus _status;
        /// <summary>
        /// 设备列表数组
        /// </summary>
        tSdkCameraDevInfo[] _tCameraDevInfoList;
        /// <summary>
        /// 定义相机的句柄
        /// </summary>
        protected CameraHandle _m_hCamera = 0;
        private bool clearFlage=false;
        //public static pfnCameraSetCallbackFunction CameraSetCallbackFunction;  
        /// <summary>
        /// // 相机特性描述
        /// </summary>
        protected tSdkCameraCapbility _tCameraCapability;  // 相机特性描述
        List<HObject> _image = new List<HObject>();
        Task t1;
        CancellationTokenSource cts = new CancellationTokenSource();




        #endregion
        #region  属性
        public IntPtr Grabber
        {
            get { return m_Grabber; }
            
        }
       
        #endregion

        #region 方法

        /// <summary>
        /// 初始化显示窗口
        /// </summary>
        private void InitWindow()
        {
            MvApi.CameraDisplayInit(m_hCamera, _picturebox.Handle);
            MvApi.CameraSetDisplaySize(m_hCamera, _picturebox.Width, _picturebox.Height);
        }



        /// <summary>
        /// 初始化相机
        /// </summary>
        public void InitCamera()
        {
            _status = 0;
            InitWindow();
           
            MvApi.CameraEnumerateDevice(out _tCameraDevInfoList);
            int NumDev = (_tCameraDevInfoList != null ? _tCameraDevInfoList.Length : 0);
            if (NumDev < 1)
            {
                MessageBox.Show("未扫描到相机");
                return;
            }
            else if (NumDev == 1)
            {
                _status = MvApi.CameraGrabber_Create(out m_Grabber, ref _tCameraDevInfoList[0]);
            }
            else
            {
                _status = MvApi.CameraGrabber_CreateFromDevicePage(out m_Grabber);
            }

            if (_status == 0)
            {
                //回调函数的定义
                m_FrameCallback = new pfnCameraGrabberFrameCallback(CameraGrabberFrameCallback);
                //获得相机的描述信息
                MvApi.CameraGrabber_GetCameraDevInfo(m_Grabber, out m_DevInfo);
                //获得相机的句柄
                MvApi.CameraGrabber_GetCameraHandle(m_Grabber, out _m_hCamera);
                //sheshe设置相机配置窗口的启动页面
                //MvApi.CameraCreateSettingPage(_m_hCamera, this.Control.Handle, m_DevInfo.acFriendlyName, null, (IntPtr)0, 0);
                //设置RGB回调函数
                MvApi.CameraGrabber_SetRGBCallback(m_Grabber, m_FrameCallback, IntPtr.Zero);
                tSdkCameraCapbility cap;
                //黑白相机设置ISP输出灰度图像
                //彩色相机ISP默认输出BGR24图像

                //获得相机特性
                MvApi.CameraGetCapability(m_hCamera, out _tCameraCapability);
                //表示该型号相机是否为黑白相机,如果是黑白相机，则颜色相关的功能都无法调节
                if (_tCameraCapability.sIspCapacity.bMonoSensor != 0)
                {
                    MvApi.CameraSetIspOutFormat(m_hCamera, (uint)MVSDK.emImageFormat.CAMERA_MEDIA_TYPE_MONO8);
                    //创建灰度调色板
                    Bitmap Image = new Bitmap(1, 1, PixelFormat.Format8bppIndexed);
                    m_GrayPal = Image.Palette;
                    for (int Y = 0; Y < m_GrayPal.Entries.Length; Y++)
                        m_GrayPal.Entries[Y] = Color.FromArgb(255, Y, Y, Y);
                }
                //设置vflip，由于sdk输出的数据默认是从底部到顶部，打开flip后就可以直接转成bitmap
                MvApi.CameraSetMirror(m_hCamera, 1, 1);
                // MvApi.CameraGrabber_StartLive(m_Grabber);

               

            }
            else
            {
                MessageBox.Show(String.Format("打开相机失败，原因：{0}", _status));
            }


        }

        private void CameraGrabberFrameCallback(IntPtr Grabber,IntPtr pFrameBuffer,ref tSdkFrameHead pFrameHead,IntPtr Context)
        {
            HObject hv_Image=null;
            GC.Collect();//强制进行即时垃圾回收，防止内存溢出

            int w = pFrameHead.iWidth;
            int h = pFrameHead.iHeight;

            //判断格式是否为黑白类型
            Boolean gray = (pFrameHead.uiMediaType ==
                (uint)MVSDK.emImageFormat.CAMERA_MEDIA_TYPE_MONO8);

            Bitmap Image = new Bitmap(w, h,
                gray ? w : w * 3,
                gray ? PixelFormat.Format8bppIndexed : PixelFormat.Format24bppRgb,
                pFrameBuffer);

            if (gray)
            {
                Image.Palette = m_GrayPal;
            }
            HOperatorSet.GenImageInterleaved(out hv_Image, new HTuple(pFrameBuffer), "bgr", w, h, new HTuple(-1), "byte", pFrameHead.iWidth, pFrameHead.iHeight, 0, 0, -1, 0);
            //HDevelopExport(hv_Image);
            
            _image.Add(hv_Image);
          
            hv_Image.Dispose();
        }

       
        public void  CameraStart()
        {
            if (m_Grabber != IntPtr.Zero)
                MvApi.CameraGrabber_StartLive(m_Grabber);
            try
            {
                var ct = cts.Token;
                t1 = new Task(() => {  ClearList(ct);  }, ct);
            }
            catch (MyException ex)
            {

                MessageBox.Show("task" + ex.ToString());
            }
            if (t1.Status == TaskStatus.Canceled)
            {
                t1.Start();
                clearFlage = true;
            }
        }
        public void CameraStop()
        {
            if (m_Grabber != IntPtr.Zero)
                MvApi.CameraGrabber_StopLive(m_Grabber);
            if (t1.Status != TaskStatus.Canceled)
            {
                cts.Cancel();
                clearFlage = false;
            }
           
        }




        /// <summary>
        /// 相机触发模式设置
        /// </summary>
        /// <param name="trigger">相机触发模式</param>0为连续采集，1软触发，2 硬出发
        public void PhotoTrigger(int trigger)
        {
            //CameraSetTriggerMode(_m_hCamera, trigger);
        }
        /// <summary>
        /// 运行清楚堆栈底部
        /// </summary>
        private void ClearList(CancellationToken ct)
        {
            while (clearFlage)
            {
                int num = _image.Count();
                if (num > 30) _image.RemoveRange(0, num - 1);
                ct.ThrowIfCancellationRequested();
            }
               
        }
        public HObject GetImage()
        {
            int n = _image.Count();
      
            return _image[n];
        }


        #endregion

        #region copy
        #endregion
    }
}
