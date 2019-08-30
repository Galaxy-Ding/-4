using HalconDotNet;
using MVSDK;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CameraHandle = System.Int32;

namespace xiangmu4
{


    public partial class TwoCameras_Photo : Form
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
        HTuple hv_WindowHandle;
        int MinThreshold_1, MaxThreshold_1, MinArea_1, MaxArea_1;
        int MinThreshold_2, MaxThreshold_2, MinArea_2, MaxArea_2;
        HalconTool hv_tool_1 = new HalconTool();
        HalconTool hv_tool_2 = new HalconTool();
        #endregion

       
        public TwoCameras_Photo()
        {
            InitializeComponent();
            HOperatorSet.OpenWindow(0, 0, pictureBox_TwoCamera.Width, pictureBox_TwoCamera.Height, pictureBox_TwoCamera.Handle, "visible", "", out hv_WindowHandle);
           
            HOperatorSet.SetColor(HDevWindowStack.GetActive(), "red");
            m_FrameCallback_1 = new pfnCameraGrabberFrameCallback(CameraGrabberFrameCallback_1);
            m_FrameCallback_2 = new pfnCameraGrabberFrameCallback(CameraGrabberFrameCallback_2);
        }
        /// <summary>
        /// 打开两个相机 即初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OpenTwoCameras_Click(object sender, EventArgs e)
        {
            //初始化相机
            InitCamera();
            label_CameraNo.Text = "1";
            if (m_Grabber_1 != IntPtr.Zero)
                MvApi.CameraGrabber_StartLive(m_Grabber_1);
        }

        private void TwoCameras_Photo_Load(object sender, EventArgs e)
        {
            

            //阈值
            #region Threshold
            //阈值条 
            trackBar_TwoCameras_MinThresold.Minimum = 0;
            trackBar_TwoCameras_MinThresold.Maximum = 255;
            trackBar_TwoCameras_MinThresold.Value = 0;
            tbox_TwoCameras_MinThreshold.Text = trackBar_TwoCameras_MinThresold.Value.ToString();
            trackBar_TwoCameras_MaxThresold.Minimum = 0;
            trackBar_TwoCameras_MaxThresold.Maximum = 255;
            trackBar_TwoCameras_MaxThresold.Value = 255;
            tbox_TwoCameras_MaxThreshold.Text = trackBar_TwoCameras_MaxThresold.Value.ToString();
            //面积筛选
            trackBar_TwoCameras_MinAreaSelector.Minimum = 0;
            trackBar_TwoCameras_MinAreaSelector.Maximum = 190255;
            trackBar_TwoCameras_MinAreaSelector.Value = 0;
            tbox_TwoCameras_MinAreaSelector.Text = trackBar_TwoCameras_MinAreaSelector.Value.ToString();
            trackBar_TwoCameras_MaxAreaSelector.Minimum = 0;
            trackBar_TwoCameras_MaxAreaSelector.Maximum = 190255;
            trackBar_TwoCameras_MaxAreaSelector.Value = 190255;
            tbox_TwoCameras_MaxAreaSelector.Text = trackBar_TwoCameras_MaxAreaSelector.Value.ToString();
            #endregion

        }

       
        #region 提取九点坐标
        private void btn_TwoCameras_ExtractNinePoints_Click(object sender, EventArgs e)
        {
            HDevWindowStack.GetActive();
            HOperatorSet.SetColor(HDevWindowStack.GetActive(), "green");
          
            
            if (label_CameraNo.Text == "1")
            {
                HTuple pictureRow = new HTuple(), pictureCol = new HTuple();
                hv_tool_1.SortRegions(hv_image_1, TwoCameras_Cal.Camera1_CalPicturePoints);
                for (int i = 1; i < 10; i++)
                {
                    pictureRow[i - 1] = Convert.ToDouble(TwoCameras_Cal.Camera1_CalPicturePoints[i - 1].Text);
                    pictureCol[i - 1] = Convert.ToDouble(TwoCameras_Cal.Camera1_CalPicturePoints[9 + i - 1].Text);
                }
                for (int i = 0; i < 9; i++)
                {
                    HOperatorSet.DispCross(HDevWindowStack.GetActive(), pictureRow[i], pictureCol[i], new HTuple(16), new HTuple(45));
                    disp_message(HDevWindowStack.GetActive(), i+1, "image", pictureRow[i], pictureCol[i], "black", "true");

                }

            }
            else if (label_CameraNo.Text == "2")
            {
                hv_tool_2.SortRegions(hv_image_2,  TwoCameras_Cal.Camera2_CalPicturePoints);
            }

        }
        #endregion

        #region  滚动条 包括 二值化  面积筛选
        #region 二值化
        #region 低阈值二值化
        private void trackBar_TwoCameras_MinThresold_Scroll(object sender, EventArgs e)
        {
            if (label_CameraNo.Text=="1")
            {
                tbox_TwoCameras_MinThreshold.Text= hv_tool_1.Threshold(hv_image_1, trackBar_TwoCameras_MinThresold, trackBar_TwoCameras_MaxThresold,true,tbox_TwoCameras_MaxThreshold, out MinThreshold_1,out  MaxThreshold_1);
            }
            else if (label_CameraNo.Text == "2")
            {
                tbox_TwoCameras_MinThreshold.Text= hv_tool_2.Threshold(hv_image_2, trackBar_TwoCameras_MinThresold, trackBar_TwoCameras_MaxThresold, true, tbox_TwoCameras_MaxThreshold, out MinThreshold_2, out MaxThreshold_2);
            }
           
        }
                #endregion
                #region 高阈值二值化
        private void trackBar_TwoCameras_MaxThresold_Scroll(object sender, EventArgs e)
        {
            if (label_CameraNo.Text == "1")
            {
                tbox_TwoCameras_MaxThreshold.Text=hv_tool_1.Threshold(hv_image_1, trackBar_TwoCameras_MinThresold, trackBar_TwoCameras_MaxThresold, false, tbox_TwoCameras_MinThreshold, out MinThreshold_1, out MaxThreshold_1);
            }
            else if (label_CameraNo.Text == "2")
            {
                tbox_TwoCameras_MaxThreshold.Text= hv_tool_2.Threshold(hv_image_2, trackBar_TwoCameras_MinThresold, trackBar_TwoCameras_MaxThresold, false, tbox_TwoCameras_MinThreshold, out MinThreshold_2, out MaxThreshold_2);
            }
        }
        #endregion
        #endregion
            #region 面积筛选
                #region 最小面积筛选
        private void trackBar_TwoCameras_MinAreaSelector_Scroll(object sender, EventArgs e)
        {
            if (label_CameraNo.Text == "1")
            {
                tbox_TwoCameras_MinAreaSelector.Text= hv_tool_1.AreaShape(hv_image_1, trackBar_TwoCameras_MinAreaSelector, trackBar_TwoCameras_MaxAreaSelector, true, tbox_TwoCameras_MaxAreaSelector, out MinArea_1, out MaxArea_1);
            }
            else if (label_CameraNo.Text == "2")
            {
                tbox_TwoCameras_MinAreaSelector.Text = hv_tool_2.AreaShape(hv_image_2, trackBar_TwoCameras_MinAreaSelector, trackBar_TwoCameras_MaxAreaSelector, true, tbox_TwoCameras_MaxAreaSelector, out MinArea_2, out MaxArea_2);
            }
        }
                 #endregion
                #region 最大面积筛选
        private void trackBar_TwoCameras_MaxAreaSelector_Scroll(object sender, EventArgs e)
        {
            if (label_CameraNo.Text == "1")
            {
                tbox_TwoCameras_MaxAreaSelector.Text = hv_tool_1.AreaShape(hv_image_1, trackBar_TwoCameras_MinAreaSelector, trackBar_TwoCameras_MaxAreaSelector, false, tbox_TwoCameras_MinAreaSelector, out MinArea_1, out MaxArea_1);
            }
            else if (label_CameraNo.Text == "2")
            {
                tbox_TwoCameras_MaxAreaSelector.Text = hv_tool_2.AreaShape(hv_image_2, trackBar_TwoCameras_MinAreaSelector, trackBar_TwoCameras_MaxAreaSelector, false, tbox_TwoCameras_MinAreaSelector, out MinArea_2, out MaxArea_2);
            }
        }
        #endregion
            #endregion
        #endregion
        #region  当前相机开始采集
        private void btn_CurrentCameraPhoto_Click(object sender, EventArgs e)
        {
            HDevWindowStack.Push(hv_WindowHandle);
            if (m_Grabber_1 != IntPtr.Zero || m_Grabber_2 != IntPtr.Zero)
            {
                if (label_CameraNo.Text == "2")
                {
                    MvApi.CameraGrabber_StartLive(m_Grabber_2);
                }
                else
                {
                    MvApi.CameraGrabber_StartLive(m_Grabber_1);
                }
            }
        }
        #endregion
        #region 停止采集

        private void btn_TwoCameras_Snap_Click(object sender, EventArgs e)
        {
            HDevWindowStack.Push(hv_WindowHandle);
            if (m_Grabber_1 != IntPtr.Zero)
                MvApi.CameraGrabber_StopLive(m_Grabber_1);
            if (m_Grabber_2 != IntPtr.Zero)
                MvApi.CameraGrabber_StopLive(m_Grabber_2);
        }
        #endregion
        #region 切换相机显示
        private void btn_CameraSwitch_Click(object sender, EventArgs e)
        {
            HDevWindowStack.Push(hv_WindowHandle);
            if (m_Grabber_1 != IntPtr.Zero || m_Grabber_2 != IntPtr.Zero)
            {
                if (CameraSwitch)
                {
                    label_CameraNo.Text = "2";
                    if (m_Grabber_1 != IntPtr.Zero)
                        MvApi.CameraGrabber_StopLive(m_Grabber_1);

                    if (m_Grabber_2 != IntPtr.Zero)
                        MvApi.CameraGrabber_StartLive(m_Grabber_2);
                    CameraSwitch = false;
                }
                else
                {
                    label_CameraNo.Text = "1";
                    if (m_Grabber_2 != IntPtr.Zero)
                        MvApi.CameraGrabber_StopLive(m_Grabber_2);

                    if (m_Grabber_1 != IntPtr.Zero)
                        MvApi.CameraGrabber_StartLive(m_Grabber_1);
                    CameraSwitch = true;

                }
            }
        }
        #endregion
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
                HOperatorSet.SetPart(HDevWindowStack.GetActive(), 0, 0, Height, Width);
                HOperatorSet.DispObj(hv_image_1, HDevWindowStack.GetActive());
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
                HOperatorSet.SetPart(HDevWindowStack.GetActive(), 0, 0, Height, Width);
                HOperatorSet.DispObj(hv_image_2, HDevWindowStack.GetActive());
            }         

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
                label_Camera1Status.Text = "相机1：初始化成功";
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
                label_Camera2Status.Text = "相机2：初始化成功";

            }
            else
            {
                MessageBox.Show(String.Format("打开相机失败，原因：{0}", _status_2));
            }


        }

        #endregion
        #region disp_message
        public void disp_message(HTuple hv_WindowHandle, HTuple hv_String, HTuple hv_CoordSystem,
  HTuple hv_Row, HTuple hv_Column, HTuple hv_Color, HTuple hv_Box)
        {



            // Local iconic variables 

            // Local control variables 

            HTuple hv_GenParamName = null, hv_GenParamValue = null;
            HTuple hv_Color_COPY_INP_TMP = hv_Color.Clone();
            HTuple hv_Column_COPY_INP_TMP = hv_Column.Clone();
            HTuple hv_CoordSystem_COPY_INP_TMP = hv_CoordSystem.Clone();
            HTuple hv_Row_COPY_INP_TMP = hv_Row.Clone();

            // Initialize local and output iconic variables 
            //This procedure displays text in a graphics window.
            //
            //Input parameters:
            //WindowHandle: The WindowHandle of the graphics window, where
            //   the message should be displayed
            //String: A tuple of strings containing the text message to be displayed
            //CoordSystem: If set to 'window', the text position is given
            //   with respect to the window coordinate system.
            //   If set to 'image', image coordinates are used.
            //   (This may be useful in zoomed images.)
            //Row: The row coordinate of the desired text position
            //   A tuple of values is allowed to display text at different
            //   positions.
            //Column: The column coordinate of the desired text position
            //   A tuple of values is allowed to display text at different
            //   positions.
            //Color: defines the color of the text as string.
            //   If set to [], '' or 'auto' the currently set color is used.
            //   If a tuple of strings is passed, the colors are used cyclically...
            //   - if |Row| == |Column| == 1: for each new textline
            //   = else for each text position.
            //Box: If Box[0] is set to 'true', the text is written within an orange box.
            //     If set to' false', no box is displayed.
            //     If set to a color string (e.g. 'white', '#FF00CC', etc.),
            //       the text is written in a box of that color.
            //     An optional second value for Box (Box[1]) controls if a shadow is displayed:
            //       'true' -> display a shadow in a default color
            //       'false' -> display no shadow
            //       otherwise -> use given string as color string for the shadow color
            //
            //It is possible to display multiple text strings in a single call.
            //In this case, some restrictions apply:
            //- Multiple text positions can be defined by specifying a tuple
            //  with multiple Row and/or Column coordinates, i.e.:
            //  - |Row| == n, |Column| == n
            //  - |Row| == n, |Column| == 1
            //  - |Row| == 1, |Column| == n
            //- If |Row| == |Column| == 1,
            //  each element of String is display in a new textline.
            //- If multiple positions or specified, the number of Strings
            //  must match the number of positions, i.e.:
            //  - Either |String| == n (each string is displayed at the
            //                          corresponding position),
            //  - or     |String| == 1 (The string is displayed n times).
            //
            //
            //Convert the parameters for disp_text.
            if ((int)((new HTuple(hv_Row_COPY_INP_TMP.TupleEqual(new HTuple()))).TupleOr(
                new HTuple(hv_Column_COPY_INP_TMP.TupleEqual(new HTuple())))) != 0)
            {

                return;
            }
            if ((int)(new HTuple(hv_Row_COPY_INP_TMP.TupleEqual(-1))) != 0)
            {
                hv_Row_COPY_INP_TMP = 12;
            }
            if ((int)(new HTuple(hv_Column_COPY_INP_TMP.TupleEqual(-1))) != 0)
            {
                hv_Column_COPY_INP_TMP = 12;
            }
            //
            //Convert the parameter Box to generic parameters.
            hv_GenParamName = new HTuple();
            hv_GenParamValue = new HTuple();
            if ((int)(new HTuple((new HTuple(hv_Box.TupleLength())).TupleGreater(0))) != 0)
            {
                if ((int)(new HTuple(((hv_Box.TupleSelect(0))).TupleEqual("false"))) != 0)
                {
                    //Display no box
                    hv_GenParamName = hv_GenParamName.TupleConcat("box");
                    hv_GenParamValue = hv_GenParamValue.TupleConcat("false");
                }
                else if ((int)(new HTuple(((hv_Box.TupleSelect(0))).TupleNotEqual("true"))) != 0)
                {
                    //Set a color other than the default.
                    hv_GenParamName = hv_GenParamName.TupleConcat("box_color");
                    hv_GenParamValue = hv_GenParamValue.TupleConcat(hv_Box.TupleSelect(0));
                }
            }
            if ((int)(new HTuple((new HTuple(hv_Box.TupleLength())).TupleGreater(1))) != 0)
            {
                if ((int)(new HTuple(((hv_Box.TupleSelect(1))).TupleEqual("false"))) != 0)
                {
                    //Display no shadow.
                    hv_GenParamName = hv_GenParamName.TupleConcat("shadow");
                    hv_GenParamValue = hv_GenParamValue.TupleConcat("false");
                }
                else if ((int)(new HTuple(((hv_Box.TupleSelect(1))).TupleNotEqual("true"))) != 0)
                {
                    //Set a shadow color other than the default.
                    hv_GenParamName = hv_GenParamName.TupleConcat("shadow_color");
                    hv_GenParamValue = hv_GenParamValue.TupleConcat(hv_Box.TupleSelect(1));
                }
            }
            //Restore default CoordSystem behavior.
            if ((int)(new HTuple(hv_CoordSystem_COPY_INP_TMP.TupleNotEqual("window"))) != 0)
            {
                hv_CoordSystem_COPY_INP_TMP = "image";
            }
            //
            if ((int)(new HTuple(hv_Color_COPY_INP_TMP.TupleEqual(""))) != 0)
            {
                //disp_text does not accept an empty string for Color.
                hv_Color_COPY_INP_TMP = new HTuple();
            }
            //
            HOperatorSet.DispText(hv_WindowHandle, hv_String, hv_CoordSystem_COPY_INP_TMP,
                hv_Row_COPY_INP_TMP, hv_Column_COPY_INP_TMP, hv_Color_COPY_INP_TMP, hv_GenParamName,
                hv_GenParamValue);

            return;
        }

        #endregion
    }
}
