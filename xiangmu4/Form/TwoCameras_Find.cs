using HalconDotNet;
using MVSDK;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CameraHandle = System.Int32;
namespace xiangmu4
{
    public partial class TwoCameras_Find : Form
    {
        #region 相机变量
        protected IntPtr m_Grabber_1 = IntPtr.Zero, m_Grabber_2 = IntPtr.Zero;
        protected CameraHandle m_hCamera_1 = 0, m_hCamera_2 = 0;
        protected ColorPalette m_GrayPal_1, m_GrayPal_2;
        protected pfnCameraGrabberFrameCallback m_FrameCallback_1, m_FrameCallback_2;
        protected tSdkCameraDevInfo m_DevInfo_1, m_DevInfo_2;
        private bool CameraSwitch = false;
        #endregion
        #region halcon变量
        HObject hv_image_1, hv_image_2;
        HTuple hv_WindowHandle_1, hv_WindowHandle_2;
        int MinThreshold_1, MaxThreshold_1, MinArea_1, MaxArea_1;

       

        int MinThreshold_2, MaxThreshold_2, MinArea_2, MaxArea_2;

        HalconTool hv_tool_1 = new HalconTool();
        HalconTool hv_tool_2 = new HalconTool();
        #endregion

        public TwoCameras_Find()
        {
            InitializeComponent();
            HOperatorSet.OpenWindow(0, 0, pictureBox_TwoCamera_Find_1.Width, pictureBox_TwoCamera_Find_1.Height, pictureBox_TwoCamera_Find_1.Handle, "visible", "", out hv_WindowHandle_1);
            
            HOperatorSet.OpenWindow(0, 0, pictureBox_TwoCamera_Find_2.Width, pictureBox_TwoCamera_Find_2.Height, pictureBox_TwoCamera_Find_2.Handle, "visible", "", out hv_WindowHandle_2);
            
            HOperatorSet.SetColor(HDevWindowStack.GetActive(), "red");
            m_FrameCallback_1 = new pfnCameraGrabberFrameCallback(CameraGrabberFrameCallback_1);
            m_FrameCallback_2 = new pfnCameraGrabberFrameCallback(CameraGrabberFrameCallback_2);
        }





        private void btn_TwoCameras_Find_Photos_Click(object sender, EventArgs e)
        {
            if (m_Grabber_1 != IntPtr.Zero || m_Grabber_2 != IntPtr.Zero)
            {
                HDevWindowStack.Push(hv_WindowHandle_1);
                
                HDevWindowStack.Push(hv_WindowHandle_2);
                MvApi.CameraGrabber_StartLive(m_Grabber_2);
                MvApi.CameraGrabber_StartLive(m_Grabber_1);               
            }

        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (m_Grabber_1 != IntPtr.Zero)
                MvApi.CameraGrabber_StopLive(m_Grabber_1);
            if (m_Grabber_2 != IntPtr.Zero)
                MvApi.CameraGrabber_StopLive(m_Grabber_2);
        }

        /// <summary>
        /// 初始化相继 两个
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OpenTwoCameras_Click(object sender, EventArgs e)
        {
            //思考如果打开两个相机了，怎么确保再次打开返回
            //初始化相机
            InitCamera();
        }


        #region  两个相机的回调函数
        #region 相机1的回调函数
        private void CameraGrabberFrameCallback_1(
IntPtr Grabber,
IntPtr pFrameBuffer,
ref tSdkFrameHead pFrameHead,
IntPtr Context)
        {
            HTuple Height, Width;
            //hv_image.Dispose();
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
                Image.Palette = m_GrayPal_1;
            }
            //hv_image = BitmapToHImage(Image);
            HOperatorSet.GenImageInterleaved(out hv_image_1, new HTuple(pFrameBuffer), "bgr", w, h, new HTuple(-1), "byte", w, h, 0, 0, -1, 0);

            HOperatorSet.GetImageSize(hv_image_1, out Width, out Height);

            if (HDevWindowStack.IsOpen())
            {
                HOperatorSet.SetPart(hv_WindowHandle_1, 0, 0, Height, Width);
                HOperatorSet.DispObj(hv_image_1, hv_WindowHandle_1);
            }
            //this.Invoke((EventHandler)delegate
            //{
            //    pictureBox_CalibrationCamera.Image = Image;
            //    pictureBox_CalibrationCamera.Refresh();
            //});

        }
        #endregion
        #region 相机2的回调函数
        private void CameraGrabberFrameCallback_2(
IntPtr Grabber,
IntPtr pFrameBuffer,
ref tSdkFrameHead pFrameHead,
IntPtr Context)
        {
            HTuple Height, Width;
            //hv_image.Dispose();
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
                Image.Palette = m_GrayPal_2;
            }
            //hv_image = BitmapToHImage(Image);
            HOperatorSet.GenImageInterleaved(out hv_image_2, new HTuple(pFrameBuffer), "bgr", w, h, new HTuple(-1), "byte", w, h, 0, 0, -1, 0);

            HOperatorSet.GetImageSize(hv_image_2, out Width, out Height);

            if (HDevWindowStack.IsOpen())
            {
                HOperatorSet.SetPart(hv_WindowHandle_2, 0, 0, Height, Width);
                HOperatorSet.DispObj(hv_image_2, hv_WindowHandle_2);
            }
            //this.Invoke((EventHandler)delegate
            //{
            //    pictureBox_CalibrationCamera.Image = Image;
            //    pictureBox_CalibrationCamera.Refresh();
            //});

        }
        #endregion
        #endregion
        #region 初始化相机
        private void InitCamera()
        {
            CameraSdkStatus status = CameraSdkStatus.CAMERA_STATUS_USER_CANCEL;
            CameraSdkStatus _status_1 = CameraSdkStatus.CAMERA_STATUS_USER_CANCEL;
            CameraSdkStatus _status_2 = CameraSdkStatus.CAMERA_STATUS_USER_CANCEL;
            tSdkCameraDevInfo[] DevList;
            MvApi.CameraEnumerateDevice(out DevList);
            int NumDev = (DevList != null ? DevList.Length : 0);
            if (NumDev < 1)
            {
                MessageBox.Show("未扫描到相机");
                return;
            }
            else if (NumDev == 1)
            {
                _status_1 = MvApi.CameraGrabber_Create(out m_Grabber_1, ref DevList[0]);
            }
            else if (NumDev == 2)
            {
                _status_1 = MvApi.CameraGrabber_Create(out m_Grabber_1, ref DevList[0]);
                _status_2 = MvApi.CameraGrabber_Create(out m_Grabber_2, ref DevList[1]);
            }
            else //选择哪个相机
            {
                status = MvApi.CameraGrabber_CreateFromDevicePage(out m_Grabber_1);
            }

            if (_status_1 == 0)
            {
                //获得相机的描述信息
                MvApi.CameraGrabber_GetCameraDevInfo(m_Grabber_1, out m_DevInfo_1);
                //获得相机的句柄
                MvApi.CameraGrabber_GetCameraHandle(m_Grabber_1, out m_hCamera_1);
                //sheshe设置相机配置窗口的启动页面
                MvApi.CameraCreateSettingPage(m_hCamera_1, this.Handle, m_DevInfo_1.acFriendlyName, null, (IntPtr)0, 0);
                //设置RGB回调函数
                MvApi.CameraGrabber_SetRGBCallback(m_Grabber_1, m_FrameCallback_1, IntPtr.Zero);
                tSdkCameraCapbility cap_1;
                //黑白相机设置ISP输出灰度图像
                //彩色相机ISP默认输出BGR24图像

                //获得相机特性
                MvApi.CameraGetCapability(m_hCamera_1, out cap_1);
                //表示该型号相机是否为黑白相机,如果是黑白相机，则颜色相关的功能都无法调节
                if (cap_1.sIspCapacity.bMonoSensor != 0)
                {
                    MvApi.CameraSetIspOutFormat(m_hCamera_1, (uint)MVSDK.emImageFormat.CAMERA_MEDIA_TYPE_MONO8);
                    //创建灰度调色板
                    Bitmap Image = new Bitmap(1, 1, PixelFormat.Format8bppIndexed);
                    m_GrayPal_1 = Image.Palette;
                    for (int Y = 0; Y < m_GrayPal_1.Entries.Length; Y++)
                        m_GrayPal_1.Entries[Y] = Color.FromArgb(255, Y, Y, Y);
                }
                //设置vflip，由于sdk输出的数据默认是从底部到顶部，打开flip后就可以直接转成bitmap
                MvApi.CameraSetMirror(m_hCamera_1, 1, 1);
                // MvApi.CameraGrabber_StartLive(m_Grabber);
               // label_Camera1Status.Text = "相机1：初始化成功";
            }
            else
            {
                MessageBox.Show(String.Format("打开相机失败，原因：{0}", _status_1));
            }
            if (_status_2 == 0)
            {
                //获得相机的描述信息
                MvApi.CameraGrabber_GetCameraDevInfo(m_Grabber_2, out m_DevInfo_2);
                //获得相机的句柄
                MvApi.CameraGrabber_GetCameraHandle(m_Grabber_2, out m_hCamera_2);
                //sheshe设置相机配置窗口的启动页面
                MvApi.CameraCreateSettingPage(m_hCamera_2, this.Handle, m_DevInfo_2.acFriendlyName, null, (IntPtr)0, 0);
                //设置RGB回调函数
                MvApi.CameraGrabber_SetRGBCallback(m_Grabber_2, m_FrameCallback_2, IntPtr.Zero);
                tSdkCameraCapbility cap_2;
                //黑白相机设置ISP输出灰度图像
                //彩色相机ISP默认输出BGR24图像

                //获得相机特性
                MvApi.CameraGetCapability(m_hCamera_2, out cap_2);
                //表示该型号相机是否为黑白相机,如果是黑白相机，则颜色相关的功能都无法调节
                if (cap_2.sIspCapacity.bMonoSensor != 0)
                {
                    MvApi.CameraSetIspOutFormat(m_hCamera_2, (uint)MVSDK.emImageFormat.CAMERA_MEDIA_TYPE_MONO8);
                    //创建灰度调色板
                    Bitmap Image = new Bitmap(1, 1, PixelFormat.Format8bppIndexed);
                    m_GrayPal_2 = Image.Palette;
                    for (int Y = 0; Y < m_GrayPal_2.Entries.Length; Y++)
                        m_GrayPal_2.Entries[Y] = Color.FromArgb(255, Y, Y, Y);
                }
                //设置vflip，由于sdk输出的数据默认是从底部到顶部，打开flip后就可以直接转成bitmap
                MvApi.CameraSetMirror(m_hCamera_2, 1, 1);
                // MvApi.CameraGrabber_StartLive(m_Grabber);
              //label_Camera2Status.Text = "相机2：初始化成功";

            }
            else
            {
                MessageBox.Show(String.Format("打开相机失败，原因：{0}", _status_2));
            }


        }

        #endregion

    }
}
