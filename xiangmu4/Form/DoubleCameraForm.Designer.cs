namespace xiangmu4
{
    partial class DoubleCameraForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("双采集");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("双标定");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("双识别");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("双相机", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panel_DoubleCamera = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.treeView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView1.ForeColor = System.Drawing.SystemColors.Window;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Photo";
            treeNode1.SelectedImageIndex = -2;
            treeNode1.Text = "双采集";
            treeNode2.Name = "DoubleCameraCal";
            treeNode2.Text = "双标定";
            treeNode3.Name = "双CameraFind";
            treeNode3.Text = "双识别";
            treeNode4.Name = "DoubleCamera";
            treeNode4.NodeFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            treeNode4.Text = "双相机";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4});
            this.treeView1.Size = new System.Drawing.Size(116, 529);
            this.treeView1.TabIndex = 1;
         
            this.treeView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseDown);
            // 
            // panel_DoubleCamera
            // 
            this.panel_DoubleCamera.Location = new System.Drawing.Point(114, 0);
            this.panel_DoubleCamera.Name = "panel_DoubleCamera";
            this.panel_DoubleCamera.Size = new System.Drawing.Size(958, 529);
            this.panel_DoubleCamera.TabIndex = 2;
            // 
            // DoubleCameraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1073, 529);
            this.Controls.Add(this.panel_DoubleCamera);
            this.Controls.Add(this.treeView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DoubleCameraForm";
            this.Text = "DoubleCameraForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel panel_DoubleCamera;
    }
}