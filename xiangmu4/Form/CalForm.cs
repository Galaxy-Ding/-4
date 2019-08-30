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
    public partial class CalForm : Form
    {

        #region 相机变量
        protected IntPtr m_Grabber = IntPtr.Zero;
        protected CameraHandle m_hCamera = 0;
        protected ColorPalette m_GrayPal;
        protected pfnCameraGrabberFrameCallback m_FrameCallback;
        protected tSdkCameraDevInfo m_DevInfo;
        #endregion
        #region 九点标定tbox数据
        List<TextBox> CalRobotPoints = new List<TextBox>();
        List<TextBox> CalPicturePoints = new List<TextBox>();
        #endregion
        #region halcon变量
        HObject hv_image;
        HTuple hv_WindowHandle;
        int MinThreshold, MaxThreshold, MinArea, MaxArea;
        HalconTool hvTool= new HalconTool();
        #endregion

        public CalForm()
        {
           
            InitializeComponent();
            
            HOperatorSet.OpenWindow(0, 0, pictureBox_CalibrationCamera.Width, pictureBox_CalibrationCamera.Height, pictureBox_CalibrationCamera.Handle, "visible", "", out hv_WindowHandle);
            HDevWindowStack.Push(hv_WindowHandle);
            HOperatorSet.SetColor(HDevWindowStack.GetActive(), "red");
            m_FrameCallback = new pfnCameraGrabberFrameCallback(CameraGrabberFrameCallback);
        }
                
        private void btn_CameraOperator_Click(object sender, EventArgs e)
        {
            if (m_Grabber != IntPtr.Zero)
                MvApi.CameraGrabber_StartLive(m_Grabber);
        }
        private void CameraGrabberFrameCallback(
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
                Image.Palette = m_GrayPal;
            }
            //hv_image = BitmapToHImage(Image);
            HOperatorSet.GenImageInterleaved(out hv_image, new HTuple(pFrameBuffer), "bgr", w, h, new HTuple(-1), "byte", w, h, 0, 0, -1, 0);

            HOperatorSet.GetImageSize(hv_image, out Width, out Height);

            if (HDevWindowStack.IsOpen())
            {
                HOperatorSet.SetPart(HDevWindowStack.GetActive(), 0, 0, Height, Width);
            }


            if (HDevWindowStack.IsOpen())
            {
                HOperatorSet.DispObj(hv_image, HDevWindowStack.GetActive());
            }
            //this.Invoke((EventHandler)delegate
            //{
            //    pictureBox_CalibrationCamera.Image = Image;
            //    pictureBox_CalibrationCamera.Refresh();
            //});

        }
        private void InitCamera()
        {
            CameraSdkStatus status = 0;

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
                status = MvApi.CameraGrabber_Create(out m_Grabber, ref DevList[0]);
            }
            else //选择哪个相机
            {
                status = MvApi.CameraGrabber_CreateFromDevicePage(out m_Grabber);
            }

            if (status == 0)
            {
                //获得相机的描述信息
                MvApi.CameraGrabber_GetCameraDevInfo(m_Grabber, out m_DevInfo);
                //获得相机的句柄
                MvApi.CameraGrabber_GetCameraHandle(m_Grabber, out m_hCamera);
                //sheshe设置相机配置窗口的启动页面
                MvApi.CameraCreateSettingPage(m_hCamera, this.Handle, m_DevInfo.acFriendlyName, null, (IntPtr)0, 0);
                //设置RGB回调函数
                MvApi.CameraGrabber_SetRGBCallback(m_Grabber, m_FrameCallback, IntPtr.Zero);
                tSdkCameraCapbility cap;
                //黑白相机设置ISP输出灰度图像
                //彩色相机ISP默认输出BGR24图像

                //获得相机特性
                MvApi.CameraGetCapability(m_hCamera, out cap);
                //表示该型号相机是否为黑白相机,如果是黑白相机，则颜色相关的功能都无法调节
                if (cap.sIspCapacity.bMonoSensor != 0)
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
                MessageBox.Show(String.Format("打开相机失败，原因：{0}", status));
            }


        }

        private void CalForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MvApi.CameraGrabber_Destroy(m_Grabber);
          
        }

        private void CalForm_Load(object sender, EventArgs e)
        {
            InitCamera();
            #region 九点标定tbox生成
            var task1 = Task.Factory.StartNew(() =>
            {
                GenCalTextbox();
            });
            #endregion
            #region Threshold
            //阈值条 
            trackBar_MinThresold.Minimum = 0;
            trackBar_MinThresold.Maximum = 255;
            trackBar_MinThresold.Value = 0;
            tbox_MinThreshold.Text = trackBar_MinThresold.Value.ToString();
            trackBar_MaxThresold.Minimum = 0;
            trackBar_MaxThresold.Maximum = 255;
            trackBar_MaxThresold.Value = 255;
            tbox_MaxThreshold.Text = trackBar_MaxThresold.Value.ToString();
            //面积筛选
            trackBar_MinAreaSelector.Minimum = 0;
            trackBar_MinAreaSelector.Maximum = 90255;
            trackBar_MinAreaSelector.Value = 0;
            tbox_MinAreaSelector.Text = trackBar_MinAreaSelector.Value.ToString();
            trackBar_MaxAreaSelector.Minimum = 0;
            trackBar_MaxAreaSelector.Maximum = 190255;
            trackBar_MaxAreaSelector.Value = 190255;
            tbox_MaxAreaSelector.Text = trackBar_MaxAreaSelector.Value.ToString();
            #endregion
        }

        private void GenCalTextbox()
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    TextBox tbox = new TextBox();
                    tbox.Text = "";
                    tbox.Size = new Size(76, 26);
                    tbox.Margin = new System.Windows.Forms.Padding(0);
                    tbox.Location = new Point(6 + 95 * i, 49 + j * 38);
                    tbox.Name = "tbox_RobotCal_" + j + 1 + "_" + i + 1;
                    Invoke(new MethodInvoker(() => groupBox_RobotNinePoints.Controls.Add(tbox)));
                  
                    CalRobotPoints.Add(tbox);
                }
            }
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    TextBox tbox = new TextBox();
                    tbox.Text = "";
                    tbox.Size = new Size(76, 26);
                    tbox.Margin = new System.Windows.Forms.Padding(0);
                    tbox.Location = new Point(10 + 95 * i, 49 + j * 38);
                    tbox.Name = "tbox_PictureCal_" + j + 1 + "_" + i + 1;
                    Invoke(new MethodInvoker(() => groupBox_PictureNinePoints.Controls.Add(tbox)));
                   
                    CalPicturePoints.Add(tbox);
                }
            }
        }

        private void btn_GrabPhoto_Click(object sender, EventArgs e)
        {
            if (m_Grabber != IntPtr.Zero)
                MvApi.CameraGrabber_StopLive(m_Grabber);
        }        
        public static HObject BitmapToHImage(Bitmap SrcImage)
        {
            HObject Hobj;
            HOperatorSet.GenEmptyObj(out Hobj);

            Point po = new Point(0, 0);
            Size so = new Size(SrcImage.Width, SrcImage.Height);//template.Width, template.Height
            Rectangle ro = new Rectangle(po, so);

            Bitmap DstImage = new Bitmap(SrcImage.Width, SrcImage.Height, PixelFormat.Format8bppIndexed);
            DstImage = SrcImage.Clone(ro, PixelFormat.Format8bppIndexed);

            int width = DstImage.Width;
            int height = DstImage.Height;

            Rectangle rect = new Rectangle(0, 0, width, height);
            System.Drawing.Imaging.BitmapData dstBmpData =
                DstImage.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);//pImage.PixelFormat
            int PixelSize = Bitmap.GetPixelFormatSize(dstBmpData.PixelFormat) / 8;
            int stride = dstBmpData.Stride;

            //重点在此
            unsafe
            {
                int count = height * width;
                byte[] data = new byte[count];
                byte* bptr = (byte*)dstBmpData.Scan0;
                fixed (byte* pData = data)
                {
                    for (int i = 0; i < height; i++)
                        for (int j = 0; j < width; j++)
                        {
                            data[i * width + j] = bptr[i * stride + j];
                        }
                    HOperatorSet.GenImage1(out Hobj, "byte", width, height, new IntPtr(pData));
                }
            }

            DstImage.UnlockBits(dstBmpData);

            return Hobj;
        }

       

        private void btn_ExtractNinePoints_Click(object sender, EventArgs e)
        {
            HObject Region, ho_ConnectedRegions, ho_SelectedRegions, ho_SortedRegions, ho_ObjectSelected=null;
            HTuple hv_Area, hv_CalRow = new HTuple(), hv_CalColumn = new HTuple(), hv_Number;

            double[] XCalPixelArray = new double[9];
            double[] YCalPixelArray = new double[9];

           
            HOperatorSet.SetColor(HDevWindowStack.GetActive(), "red");
            if (hv_image == null)
            {
                MessageBox.Show("hv_image");
                return;
            }
            HOperatorSet.Threshold(hv_image, out Region, MinThreshold, MaxThreshold);
            HOperatorSet.Connection(Region, out ho_ConnectedRegions);
            HOperatorSet.SelectShape(ho_ConnectedRegions, out ho_SelectedRegions, "area",
    "and", MinArea, MaxArea);
            try
            {
                
                HOperatorSet.SortRegion(ho_SelectedRegions, out ho_SortedRegions, "character",
                    "true", "row");

                HOperatorSet.AreaCenter(ho_SortedRegions, out hv_Area, out hv_CalRow, out hv_CalColumn);

                HOperatorSet.CountObj(ho_SortedRegions, out hv_Number);
                HTuple end_val9 = hv_Number;

                HTuple step_val9 = 1;

                if (hv_Number != 9)
                {
                    MessageBox.Show("提取的点不等于9" + "目前拥有的值是：" + hv_Number);
                    return;
                }
                if (HDevWindowStack.IsOpen())
                {
                    //清除窗口图片与信息
                    HOperatorSet.ClearWindow(HDevWindowStack.GetActive());
                    //显示图片
                    HOperatorSet.DispObj(hv_image, HDevWindowStack.GetActive());
                    HOperatorSet.DispObj(ho_SortedRegions, HDevWindowStack.GetActive());
                }
                for (int i = 1; i < hv_Number+1; i++)
                {
                    HOperatorSet.SelectObj(ho_SortedRegions, out ho_ObjectSelected, i);
                    HOperatorSet.SetColor(HDevWindowStack.GetActive(), "green");
                    //HOperatorSet.AreaCenter(ho_ObjectSelected, out hv_Area, out hv_Row, out hv_Column);
                    HOperatorSet.DispCross(200000, hv_CalRow[i - 1], hv_CalColumn[i - 1], new HTuple(16), new HTuple(0));                    
                    disp_message(200000, i, "image", hv_CalRow[i - 1], hv_CalColumn[i - 1], "black", "true");

                    CalPicturePoints[i - 1].Text = hv_CalRow[i - 1].D.ToString();
                    CalPicturePoints[9+i - 1].Text = hv_CalColumn[i - 1].D.ToString();
                }               
               
                //释放
                Region.Dispose();
                ho_ConnectedRegions.Dispose();
                ho_SelectedRegions.Dispose();
                ho_SortedRegions.Dispose();
                ho_ObjectSelected.Dispose();
                //for (int i = 1; i < 10; i++)
                //{
                //    string Xname = "tbox_CalColumn" + i;
                //    string Yname = "tbox_CalRow" + i;
                //    GetControlObject<TextBox>(Xname).Text = Convert.ToString(XCalPixelArray[i - 1]);
                //    GetControlObject<TextBox>(Yname).Text = Convert.ToString(YCalPixelArray[i - 1]);

                //}

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_Calibration_Click(object sender, EventArgs e)
        {
            HTuple hv_CalRow = new HTuple(), hv_CalColumn = new HTuple(), hv_RobotY = new HTuple(), hv_RobotX = new HTuple(), homMat2d=null;
            //开始标定的前提是九点的像素 和  实际坐标都有了
            foreach (var item in CalRobotPoints)
            {
                if (item.Text=="")
                {
                    MessageBox.Show(item.Name+"没有填写" );
                    return;
                }
             
            }
           
            foreach (var item in CalPicturePoints)
            {
                if (item.Text == "")
                {
                    MessageBox.Show(item.Name + "没有填写");
                    return;
                }

            }          
            
            try
            {
                try
                {
                    //将textbox 集合中的值转化为 HTUPLE
                    for (int i = 0; i < 9; i++)
                    {
                        hv_CalRow[i] = Convert.ToDouble(CalPicturePoints[i].Text);
                        hv_CalColumn[i] = Convert.ToDouble(CalPicturePoints[9+i].Text);
                        //
                        hv_RobotX[i] = Convert.ToDouble(CalRobotPoints[i].Text);
                        hv_RobotY[i] = Convert.ToDouble(CalRobotPoints[9+i].Text);
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("坐标转化失败");                }
               
              
                HOperatorSet.VectorToHomMat2d(hv_CalRow, hv_CalColumn, hv_RobotY, hv_RobotX, out homMat2d);
                if (homMat2d!=null) MessageBox.Show("坐标转化成功");
               

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

       

        private void btn_SaveCalibrateResults_Click(object sender, EventArgs e)
        {

        }

        private void trackBar_MinThresold_Scroll(object sender, EventArgs e)
        {
           
            tbox_MinThreshold.Text= hvTool.Threshold(hv_image, trackBar_MinThresold, trackBar_MaxThresold, true,tbox_MaxThreshold,out  MinThreshold, out MaxThreshold);           
        }
        private void trackBar_MaxThresold_Scroll(object sender, EventArgs e)
        {

            tbox_MaxThreshold.Text = hvTool.Threshold(hv_image, trackBar_MinThresold, trackBar_MaxThresold, false, tbox_MinThreshold, out MinThreshold, out MaxThreshold);

        }

        private void trackBar_MinAreaSelector_Scroll(object sender, EventArgs e)
        {
           tbox_MinAreaSelector.Text= hvTool.AreaShape(hv_image, trackBar_MinAreaSelector, trackBar_MaxAreaSelector,true,tbox_MaxAreaSelector,out MinArea,out MaxArea);   
        }
        private void trackBar_MaxAreaSelector_Scroll(object sender, EventArgs e)
        {
            tbox_MaxAreaSelector.Text = hvTool.AreaShape(hv_image, trackBar_MinAreaSelector, trackBar_MaxAreaSelector, false, tbox_MinAreaSelector, out MinArea, out MaxArea);
        }

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
