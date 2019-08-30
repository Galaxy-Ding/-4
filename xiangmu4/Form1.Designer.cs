namespace xiangmu4
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripbtn_Tcp = new System.Windows.Forms.ToolStripButton();
            this.toolStripbtn_Cal = new System.Windows.Forms.ToolStripButton();
            this.toolStripbtn_AutoGrab = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripbtn_DoubleCamera = new System.Windows.Forms.ToolStripButton();
            this.toolStripbtn_Bond = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图像来源ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.菜单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripbtn_Tcp,
            this.toolStripbtn_Cal,
            this.toolStripbtn_AutoGrab,
            this.toolStripSeparator1,
            this.toolStripbtn_DoubleCamera,
            this.toolStripbtn_Bond});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1055, 88);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripbtn_Tcp
            // 
            this.toolStripbtn_Tcp.BackColor = System.Drawing.Color.WhiteSmoke;
            this.toolStripbtn_Tcp.Image = ((System.Drawing.Image)(resources.GetObject("toolStripbtn_Tcp.Image")));
            this.toolStripbtn_Tcp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripbtn_Tcp.ImageTransparentColor = System.Drawing.Color.MediumSlateBlue;
            this.toolStripbtn_Tcp.Name = "toolStripbtn_Tcp";
            this.toolStripbtn_Tcp.Size = new System.Drawing.Size(68, 85);
            this.toolStripbtn_Tcp.Text = "通信";
            this.toolStripbtn_Tcp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripbtn_Tcp.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripbtn_Cal
            // 
            this.toolStripbtn_Cal.BackColor = System.Drawing.Color.WhiteSmoke;
            this.toolStripbtn_Cal.Image = ((System.Drawing.Image)(resources.GetObject("toolStripbtn_Cal.Image")));
            this.toolStripbtn_Cal.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripbtn_Cal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripbtn_Cal.Name = "toolStripbtn_Cal";
            this.toolStripbtn_Cal.Size = new System.Drawing.Size(68, 85);
            this.toolStripbtn_Cal.Text = "九点标定";
            this.toolStripbtn_Cal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripbtn_Cal.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripbtn_AutoGrab
            // 
            this.toolStripbtn_AutoGrab.BackColor = System.Drawing.Color.WhiteSmoke;
            this.toolStripbtn_AutoGrab.Image = ((System.Drawing.Image)(resources.GetObject("toolStripbtn_AutoGrab.Image")));
            this.toolStripbtn_AutoGrab.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripbtn_AutoGrab.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripbtn_AutoGrab.Name = "toolStripbtn_AutoGrab";
            this.toolStripbtn_AutoGrab.Size = new System.Drawing.Size(68, 85);
            this.toolStripbtn_AutoGrab.Text = "自动抓取";
            this.toolStripbtn_AutoGrab.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripbtn_AutoGrab.Click += new System.EventHandler(this.toolStripbtn_AutoGrab_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 88);
            // 
            // toolStripbtn_DoubleCamera
            // 
            this.toolStripbtn_DoubleCamera.BackColor = System.Drawing.Color.WhiteSmoke;
            this.toolStripbtn_DoubleCamera.Image = ((System.Drawing.Image)(resources.GetObject("toolStripbtn_DoubleCamera.Image")));
            this.toolStripbtn_DoubleCamera.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripbtn_DoubleCamera.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripbtn_DoubleCamera.Name = "toolStripbtn_DoubleCamera";
            this.toolStripbtn_DoubleCamera.Size = new System.Drawing.Size(68, 85);
            this.toolStripbtn_DoubleCamera.Text = "双相机";
            this.toolStripbtn_DoubleCamera.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripbtn_DoubleCamera.Click += new System.EventHandler(this.toolStripbtn_DoubleCamera_Click);
            // 
            // toolStripbtn_Bond
            // 
            this.toolStripbtn_Bond.Image = ((System.Drawing.Image)(resources.GetObject("toolStripbtn_Bond.Image")));
            this.toolStripbtn_Bond.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripbtn_Bond.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripbtn_Bond.Name = "toolStripbtn_Bond";
            this.toolStripbtn_Bond.Size = new System.Drawing.Size(68, 85);
            this.toolStripbtn_Bond.Text = "对位贴合";
            this.toolStripbtn_Bond.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripbtn_Bond.Click += new System.EventHandler(this.toolStripbtn_Bond_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.图像来源ToolStripMenuItem,
            this.菜单ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1055, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 图像来源ToolStripMenuItem
            // 
            this.图像来源ToolStripMenuItem.Name = "图像来源ToolStripMenuItem";
            this.图像来源ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.图像来源ToolStripMenuItem.Text = "图像来源";
            // 
            // 菜单ToolStripMenuItem
            // 
            this.菜单ToolStripMenuItem.Name = "菜单ToolStripMenuItem";
            this.菜单ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.菜单ToolStripMenuItem.Text = "菜单";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(1, 115);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1056, 531);
            this.panel1.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 644);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Epson";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripbtn_Tcp;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripButton toolStripbtn_Cal;
        private System.Windows.Forms.ToolStripButton toolStripbtn_AutoGrab;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripbtn_DoubleCamera;
        private System.Windows.Forms.ToolStripButton toolStripbtn_Bond;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 图像来源ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 菜单ToolStripMenuItem;
    }
}

