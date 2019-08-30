using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;

namespace xiangmu4
{
    class HalconTool : Control
    {
        #region 字段
        /// <summary>
        /// 低阈值
        /// </summary>
        private int _ThresholdMin;
        /// <summary>
        /// 高阈值
        /// </summary>
        private int _ThresholdMax;
        /// <summary>
        /// 面积最小
        /// </summary>
        private int _AreaMin;
        /// <summary>
        /// 面积最大
        /// </summary>
        private int _AreaMax;



        #endregion
        #region 属性
       
      
        #endregion
        #region 方法
        /// <summary>
        /// 二值化的方法
        /// </summary>
        /// <param name="hv_image">输入的图像</param>
        /// <param name="trackBarMin">低阈值的滚动条</param>
        /// <param name="trackBarMax">高阈值的滚动条</param>
        /// <param name="MinFlag">指示该方法是否是低阈值在滚动</param>
        /// <param name="tbox">返回另一个阈值的读数</param>
        /// <param name="MinThreshold">低阈值</param>
        /// <param name="MaxThreshold">高阈值</param>
        /// <returns>返回bool类型对应的 阈值数值</returns>
        public string Threshold(HObject hv_image, TrackBar trackBarMin, TrackBar trackBarMax, bool MinFlag,TextBox tbox,  out int MinThreshold, out int MaxThreshold)
        {
             HObject ThresholdRoi;
             string value;
             HOperatorSet.SetColor(HDevWindowStack.GetActive(), "red");

            if (MinFlag)
            {
                value = trackBarMin.Value.ToString();               
                MinThreshold = trackBarMin.Value;
                MaxThreshold = trackBarMax.Value;
                if (MinThreshold > MaxThreshold)
                {
                    trackBarMin.Value = MinThreshold;
                    trackBarMax.Value = MinThreshold;
                    MaxThreshold = MinThreshold;
                    tbox.Text = MinThreshold.ToString(); ;
                }

            }
            else
            {
                value = trackBarMax.Value.ToString();
                MinThreshold = trackBarMin.Value;
                MaxThreshold = trackBarMax.Value;
                if (MinThreshold > MaxThreshold)
                {
                    trackBarMin.Value = MaxThreshold;
                    trackBarMax.Value = MaxThreshold;
                    MinThreshold = MaxThreshold;
                    tbox.Text = MaxThreshold.ToString(); ;
                }

            }
            _ThresholdMin = MinThreshold;
            _ThresholdMax = MaxThreshold;
            if (HDevWindowStack.IsOpen())
            {
                HOperatorSet.SetDraw(HDevWindowStack.GetActive(), "fill");
            }

            HOperatorSet.Threshold(hv_image, out ThresholdRoi, MinThreshold, MaxThreshold);
            //halcon code    显示图片
            HOperatorSet.DispObj(hv_image, HDevWindowStack.GetActive());
            //halcon code   显示区域
            HOperatorSet.DispObj(ThresholdRoi, HDevWindowStack.GetActive());
            ThresholdRoi.Dispose();
            return value;
        }

        /// <summary>
        /// 面积选择的方法
        /// </summary>
        /// <param name="hv_image">输入的图像</param>
        /// <param name="trackBarMin">低阈值的滚动条</param>
        /// <param name="trackBarMax">高阈值的滚动条</param>
        /// <param name="MinFlag">指示该方法是否是低阈值在滚动</param>
        /// <param name="tbox">返回另一个阈值的读数</param>
        /// <param name="MinArea">输出的低阈值对应的面积</param>
        /// <param name="MaxArea">输出的高阈值对应的面积</param>
        /// <returns></returns>

        public string AreaShape(HObject hv_image, TrackBar trackBarMin, TrackBar trackBarMax, bool MinFlag, TextBox tbox,out int MinArea,out int MaxArea)
        {
            HObject Region, ho_ConnectedRegions=null, ho_SelectedRegions=null;
            HOperatorSet.SetColor(HDevWindowStack.GetActive(), "red");
            ////分为 面积区域的选择  和  threshold 选择
            HOperatorSet.Threshold(hv_image, out Region, _ThresholdMin, _ThresholdMax);
            string value;
           
            MinArea = trackBarMin.Value;
            MaxArea = trackBarMax.Value;



            if (MinFlag)
            {
                value = trackBarMin.Value.ToString();
                if (MinArea > MaxArea)
                {
                    trackBarMax.Value = MinArea;
                    trackBarMin.Value = MinArea;
                    MaxArea = MinArea;
                    tbox.Text = MinArea.ToString();
                }

            }
            else
            {
                value = trackBarMax.Value.ToString();
                if (MinArea > MaxArea)
                {
                    trackBarMax.Value = MaxArea;
                    trackBarMin.Value = MaxArea;
                    MinArea = MaxArea;
                    tbox.Text = MaxArea.ToString();
                }
            }
            //存储合适的面积大小
            _AreaMin = MinArea;
            _AreaMax = MaxArea;

            if (HDevWindowStack.IsOpen())
            {
                HOperatorSet.SetDraw(HDevWindowStack.GetActive(), "fill");
                //HOperatorSet.Rgb1ToGray(halcon_image, out ho_GrayImage);
                HOperatorSet.Connection(Region, out ho_ConnectedRegions);
                HOperatorSet.SelectShape(ho_ConnectedRegions, out ho_SelectedRegions, "area",
        "and", MinArea, MaxArea);
                //halcon code    显示图片
                HOperatorSet.DispObj(hv_image, HDevWindowStack.GetActive());
                //halcon code   显示区域
                HOperatorSet.DispObj(ho_SelectedRegions, HDevWindowStack.GetActive());
               
            }
            //释放
            ho_SelectedRegions.Dispose();
            ho_ConnectedRegions.Dispose();
            Region.Dispose();
            return value;

        }


        public void SortRegions(HObject hv_image,  List<TextBox> calPicturePoints)
        {
            HObject Region, ho_ConnectedRegions, ho_SelectedRegions, ho_SortedRegions=null, ho_ObjectSelected = null;
            HTuple hv_Area, hv_CalRow = new HTuple(), hv_CalColumn = new HTuple(), hv_Number;
           // calPicturePoints = null;
            double[] XCalPixelArray = new double[9];
            double[] YCalPixelArray = new double[9];
            
            HOperatorSet.SetColor(HDevWindowStack.GetActive(), "red");
            try
            {
                if (hv_image == null)
                {
                    throw new MyException("hv_image bucunza不存在哟");
                }
            }
            catch (MyException ex)
            {
                MessageBox.Show(ex.ToString());

            }
          
            HOperatorSet.Threshold(hv_image, out Region, _ThresholdMin, _ThresholdMax);
            HOperatorSet.Connection(Region, out ho_ConnectedRegions);
            HOperatorSet.SelectShape(ho_ConnectedRegions, out ho_SelectedRegions, "area",
    "and", _AreaMin, _AreaMax);
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
                    throw new MyException("提取的点不等于9" + "目前拥有的值是：" + hv_Number);
                }
                if (HDevWindowStack.IsOpen())
                {
                    //清除窗口图片与信息
                    HOperatorSet.ClearWindow(HDevWindowStack.GetActive());
                    //显示图片
                    HOperatorSet.DispObj(hv_image, HDevWindowStack.GetActive());
                    HOperatorSet.DispObj(ho_SortedRegions, HDevWindowStack.GetActive());
                }
                else
                {

                    throw new MyException("窗体没有打开");
                }
                for (int i = 1; i < hv_Number + 1; i++)
                {
                    HOperatorSet.SelectObj(ho_SortedRegions, out ho_ObjectSelected, i);
                    HOperatorSet.SetColor(HDevWindowStack.GetActive(), "green");
                    //HOperatorSet.AreaCenter(ho_ObjectSelected, out hv_Area, out hv_Row, out hv_Column);
                    HOperatorSet.DispCross(200000, hv_CalRow[i - 1], hv_CalColumn[i - 1], new HTuple(16), new HTuple(0));
                    disp_message(200000, i, "image", hv_CalRow[i - 1], hv_CalColumn[i - 1], "black", "true");
                    calPicturePoints[i - 1].Text = hv_CalRow[i - 1].D.ToString();
                    calPicturePoints[9 + i - 1].Text = hv_CalColumn[i - 1].D.ToString();
                }

            }
            catch (MyException aex)
            {
                MessageBox.Show(aex.ToString());
            }
            finally
            {
                //释放
                if (Region != null) Region.Dispose();
                if (ho_ConnectedRegions != null) ho_ConnectedRegions.Dispose();
                if (ho_SelectedRegions != null) ho_SelectedRegions.Dispose();
                if (ho_SortedRegions != null) ho_SortedRegions.Dispose();
                if (ho_ObjectSelected!=null) ho_ObjectSelected.Dispose();


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
