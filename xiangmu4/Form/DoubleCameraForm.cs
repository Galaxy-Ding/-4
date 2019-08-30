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
    public partial class DoubleCameraForm : Form
    {
        public DoubleCameraForm()
        {
            InitializeComponent();
            //
            TwoCameras_Photo = new TwoCameras_Photo();
            TwoCameras_Photo.Dock = DockStyle.Fill;
            TwoCameras_Photo.TopLevel = false;
            TwoCameras_Photo.Parent = this.panel_DoubleCamera;
            TwoCameras_Photo.SetBounds(0, 0, this.panel_DoubleCamera.Width, this.panel_DoubleCamera.Height);
            //
            TwoCameras_Cal = new TwoCameras_Cal();
            TwoCameras_Cal.Dock = DockStyle.Fill;
            TwoCameras_Cal.TopLevel = false;
            TwoCameras_Cal.Parent = this.panel_DoubleCamera;
            TwoCameras_Cal.SetBounds(0, 0, this.panel_DoubleCamera.Width, this.panel_DoubleCamera.Height);
            //
            TwoCameras_Find = new TwoCameras_Find();
            TwoCameras_Find.Dock = DockStyle.Fill;
            TwoCameras_Find.TopLevel = false;
            TwoCameras_Find.Parent = this.panel_DoubleCamera;
            TwoCameras_Find.SetBounds(0, 0, this.panel_DoubleCamera.Width, this.panel_DoubleCamera.Height);

        }
        TwoCameras_Photo TwoCameras_Photo;
        TwoCameras_Cal TwoCameras_Cal;
        TwoCameras_Find TwoCameras_Find;
        

        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            treeView1.SelectedNode = treeView1.GetNodeAt(e.X, e.Y);
            if (treeView1.SelectedNode != null)
            {

                if (treeView1.SelectedNode.Text.ToString() == "双采集")
                {
                    this.panel_DoubleCamera.Controls.Clear();
                    this.panel_DoubleCamera.Controls.Add(TwoCameras_Photo);
                    TwoCameras_Photo.Show();
                }

                if (treeView1.SelectedNode.Text.ToString() == "双标定")
                {
                    this.panel_DoubleCamera.Controls.Clear();
                    this.panel_DoubleCamera.Controls.Add(TwoCameras_Cal);
                    TwoCameras_Cal.Show();
                }

                if (treeView1.SelectedNode.Text.ToString() == "双识别")
                {
                    this.panel_DoubleCamera.Controls.Clear();
                    this.panel_DoubleCamera.Controls.Add(TwoCameras_Find);
                    TwoCameras_Find.Show();
                }
               



            }
        }

        
    }
}
