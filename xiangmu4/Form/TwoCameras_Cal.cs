using HalconDotNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xiangmu4
{
    public partial class TwoCameras_Cal : Form
    {
        #region 标定变量 TextBox 
        public static List<TextBox> Camera1_CalRobotPoints = new List<TextBox>();
        public static List<TextBox> Camera1_CalPicturePoints = new List<TextBox>();
        public static List<TextBox> Camera2_CalRobotPoints = new List<TextBox>();
        public static List<TextBox> Camera2_CalPicturePoints = new List<TextBox>();
        #endregion
        #region 标定halcon变量
        HTuple homMat2d_2 = null, homMat2d_1 = null;
        #endregion


        public TwoCameras_Cal()
        {
            InitializeComponent();
            GenCalTextbox();
        }

        #region 生成tbox
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
                    tbox.Name = "tbox_Camera1_RobotCal_" + j + 1 + "_" + i + 1;
                    groupBox_CalRobotCamera1.Controls.Add(tbox);

                    Camera1_CalRobotPoints.Add(tbox);
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
                    tbox.Name = "tbox_Camera1_PictureCal_" + j + 1 + "_" + i + 1;
                    groupBox_CalPictureCamera1.Controls.Add(tbox);

                    Camera1_CalPicturePoints.Add(tbox);
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
                    tbox.Location = new Point(6 + 95 * i, 49 + j * 38);
                    tbox.Name = "tbox_Camera2_RobotCal_" + j + 1 + "_" + i + 1;
                    groupBox_CalRobotCamera2.Controls.Add(tbox);

                    Camera2_CalRobotPoints.Add(tbox);
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
                    tbox.Name = "tbox_Camera2_PictureCal_" + j + 1 + "_" + i + 1;
                     groupBox_CalPictureCamera2.Controls.Add(tbox);

                    Camera2_CalPicturePoints.Add(tbox);
                }
            }
        }
        #endregion

        private void TwoCameras_Cal_Load(object sender, EventArgs e)
        {
            //GenCalTextbox();
        }

        private void btn_TwoCamerasCal_Click(object sender, EventArgs e)
        {
            //相机1的坐标
            HTuple hv_CalRow_1 = new HTuple(), hv_CalColumn_1 = new HTuple(), hv_RobotY_1 = new HTuple(), hv_RobotX_1 = new HTuple(), homMat2d_1 = null;
            //相机2的坐标
            HTuple hv_CalRow_2 = new HTuple(), hv_CalColumn_2 = new HTuple(), hv_RobotY_2 = new HTuple(), hv_RobotX_2 = new HTuple(), homMat2d_2 = null;
            #region 开始标定的前提是九点的像素 和  实际机器坐标都有了
            //开始标定的前提是九点的像素 和  实际机器坐标都有了
            foreach (var item in TwoCameras_Cal.Camera1_CalRobotPoints)
            {
                if (item.Text == "")
                {
                    MessageBox.Show(item.Name + "没有填写");
                    return;
                }

            }
            foreach (var item in TwoCameras_Cal.Camera1_CalPicturePoints)
            {
                if (item.Text == "")
                {
                    MessageBox.Show(item.Name + "没有填写");
                    return;
                }

            }
            foreach (var item in TwoCameras_Cal.Camera2_CalRobotPoints)
            {
                if (item.Text == "")
                {
                    MessageBox.Show(item.Name + "没有填写");
                    return;
                }

            }
            foreach (var item in TwoCameras_Cal.Camera2_CalPicturePoints)
            {
                if (item.Text == "")
                {
                    MessageBox.Show(item.Name + "没有填写");
                    return;
                }
            }
            #endregion
            try
            {
                try
                {
                    //将textbox 集合中的值转化为 HTUPLE
                    for (int i = 0; i < TwoCameras_Cal.Camera1_CalPicturePoints.Count(); i++)
                    {
                        hv_CalRow_1[i] = Convert.ToDouble(TwoCameras_Cal.Camera1_CalPicturePoints[i].Text);
                        hv_CalColumn_1[i] = Convert.ToDouble(TwoCameras_Cal.Camera1_CalPicturePoints[9 + i].Text);
                        //
                        hv_RobotX_1[i] = Convert.ToDouble(TwoCameras_Cal.Camera1_CalRobotPoints[i].Text);
                        hv_RobotY_1[i] = Convert.ToDouble(TwoCameras_Cal.Camera1_CalRobotPoints[9 + i].Text);
                    }
                    HOperatorSet.VectorToHomMat2d(hv_CalRow_1, hv_CalColumn_1, hv_RobotY_1, hv_RobotX_1, out homMat2d_1);
                    if (homMat2d_1 != null) MessageBox.Show("坐标转化成功");
                    else throw new MyException("相机1坐标转化失败");
                }
                catch (Exception)
                {
                    MessageBox.Show("相机1坐标转化失败");
                }
                try
                {
                    //将textbox 集合中的值转化为 HTUPLE
                    for (int i = 0; i < TwoCameras_Cal.Camera2_CalPicturePoints.Count(); i++)
                    {
                        hv_CalRow_2[i] = Convert.ToDouble(TwoCameras_Cal.Camera2_CalPicturePoints[i].Text);
                        hv_CalColumn_2[i] = Convert.ToDouble(TwoCameras_Cal.Camera2_CalPicturePoints[9 + i].Text);
                        //
                        hv_RobotX_2[i] = Convert.ToDouble(TwoCameras_Cal.Camera2_CalRobotPoints[i].Text);
                        hv_RobotY_2[i] = Convert.ToDouble(TwoCameras_Cal.Camera2_CalRobotPoints[9 + i].Text);
                    }
                    HOperatorSet.VectorToHomMat2d(hv_CalRow_2, hv_CalColumn_2, hv_RobotY_2, hv_RobotX_2, out homMat2d_2);
                    if (homMat2d_2 != null) MessageBox.Show("坐标转化成功");
                    else throw new MyException("相机2坐标转化失败");
                }
                catch (Exception)
                {
                    MessageBox.Show("相机2坐标转化失败");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_TwCamerasFileSaves_Click(object sender, EventArgs e)
        {
            try
            {
                if (homMat2d_1 == null) throw new MyException("相机1 转换的坐标文件为空");
                if (homMat2d_2 == null) throw new MyException("相机2 转换的坐标文件为空");

                //相机1的标定文件
                HOperatorSet.WriteTuple(homMat2d_1, System.AppDomain.CurrentDomain.BaseDirectory + "Cal_Camera_1.tup");
                //相机2的标定文件
                HOperatorSet.WriteTuple(homMat2d_2, System.AppDomain.CurrentDomain.BaseDirectory + "Cal_Camera_2.tup");
            }
            catch (MyException myex)
            {
                MessageBox.Show(myex.ToString());
            }
           
        }
    }
}
