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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        TcpForm tcpform;
        CalForm calform;
        GrabForm GrabForm;
        DoubleCameraForm DoubleCameraForm;
        Bond Bond;


        private void MainForm_Load(object sender, EventArgs e)
        {
            tcpform = new TcpForm();
            tcpform.Dock = DockStyle.Fill;
            tcpform.TopLevel = false;
            tcpform.Parent = this.panel1;
            tcpform.SetBounds(0, 0, this.panel1.Width, this.panel1.Height);

            calform = new CalForm();
            calform.Dock = DockStyle.Fill;
            calform.TopLevel = false;
            calform.Parent = this.panel1;
            calform.SetBounds(0, 0, this.panel1.Width, this.panel1.Height);

            // 
            DoubleCameraForm = new DoubleCameraForm();
            DoubleCameraForm.Dock = DockStyle.Fill;
            DoubleCameraForm.TopLevel = false;
            DoubleCameraForm.Parent = this.panel1;
            DoubleCameraForm.SetBounds(0, 0, this.panel1.Width, this.panel1.Height);

            GrabForm = new GrabForm();
            GrabForm.Dock = DockStyle.Fill;
            GrabForm.TopLevel = false;
            GrabForm.Parent = this.panel1;
            GrabForm.SetBounds(0, 0, this.panel1.Width, this.panel1.Height);

            Bond = new Bond();
            Bond.Dock = DockStyle.Fill;
            Bond.TopLevel = false;
            Bond.Parent = this.panel1;
            Bond.SetBounds(0, 0, this.panel1.Width, this.panel1.Height);

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(tcpform);
            tcpform.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(calform);
            calform.Show();
        }

        private void toolStripbtn_Bond_Click(object sender, EventArgs e)
        {

            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(Bond);
            Bond.Show();

        }

        private void toolStripbtn_DoubleCamera_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(DoubleCameraForm);
            DoubleCameraForm.Show();
        }

        private void toolStripbtn_AutoGrab_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(GrabForm);
            GrabForm.Show();
        }
    }
}
