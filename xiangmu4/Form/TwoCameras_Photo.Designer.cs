namespace xiangmu4
{
    partial class TwoCameras_Photo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TwoCameras_Photo));
            this.pictureBox_TwoCamera = new System.Windows.Forms.PictureBox();
            this.btn_TwoCameras_Snap = new System.Windows.Forms.Button();
            this.btn_CameraSwitch = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbox_TwoCameras_MinAreaSelector = new System.Windows.Forms.TextBox();
            this.tbox_TwoCameras_MaxThreshold = new System.Windows.Forms.TextBox();
            this.trackBar_TwoCameras_MinAreaSelector = new System.Windows.Forms.TrackBar();
            this.tbox_TwoCameras_MaxAreaSelector = new System.Windows.Forms.TextBox();
            this.trackBar_TwoCameras_MaxThresold = new System.Windows.Forms.TrackBar();
            this.trackBar_TwoCameras_MaxAreaSelector = new System.Windows.Forms.TrackBar();
            this.tbox_TwoCameras_MinThreshold = new System.Windows.Forms.TextBox();
            this.trackBar_TwoCameras_MinThresold = new System.Windows.Forms.TrackBar();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_TwoCameras_ExtractNinePoints = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label_CameraNo = new System.Windows.Forms.Label();
            this.label_Camera1Status = new System.Windows.Forms.Label();
            this.label_Camera2Status = new System.Windows.Forms.Label();
            this.btn_CurrentCameraPhoto = new System.Windows.Forms.Button();
            this.btn_OpenTwoCameras = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_TwoCamera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_TwoCameras_MinAreaSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_TwoCameras_MaxThresold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_TwoCameras_MaxAreaSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_TwoCameras_MinThresold)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_TwoCamera
            // 
            this.pictureBox_TwoCamera.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox_TwoCamera.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox_TwoCamera.BackgroundImage")));
            this.pictureBox_TwoCamera.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_TwoCamera.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox_TwoCamera.InitialImage")));
            this.pictureBox_TwoCamera.Location = new System.Drawing.Point(276, 12);
            this.pictureBox_TwoCamera.Name = "pictureBox_TwoCamera";
            this.pictureBox_TwoCamera.Size = new System.Drawing.Size(603, 402);
            this.pictureBox_TwoCamera.TabIndex = 0;
            this.pictureBox_TwoCamera.TabStop = false;
            // 
            // btn_TwoCameras_Snap
            // 
            this.btn_TwoCameras_Snap.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_TwoCameras_Snap.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btn_TwoCameras_Snap.Location = new System.Drawing.Point(145, 410);
            this.btn_TwoCameras_Snap.Name = "btn_TwoCameras_Snap";
            this.btn_TwoCameras_Snap.Size = new System.Drawing.Size(127, 47);
            this.btn_TwoCameras_Snap.TabIndex = 10;
            this.btn_TwoCameras_Snap.Text = "当前相机截图";
            this.btn_TwoCameras_Snap.UseVisualStyleBackColor = true;
            this.btn_TwoCameras_Snap.Click += new System.EventHandler(this.btn_TwoCameras_Snap_Click);
            // 
            // btn_CameraSwitch
            // 
            this.btn_CameraSwitch.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_CameraSwitch.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btn_CameraSwitch.Location = new System.Drawing.Point(767, 420);
            this.btn_CameraSwitch.Name = "btn_CameraSwitch";
            this.btn_CameraSwitch.Size = new System.Drawing.Size(95, 47);
            this.btn_CameraSwitch.TabIndex = 10;
            this.btn_CameraSwitch.Text = "相机切换";
            this.btn_CameraSwitch.UseVisualStyleBackColor = true;
            this.btn_CameraSwitch.Click += new System.EventHandler(this.btn_CameraSwitch_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Cyan;
            this.label4.Location = new System.Drawing.Point(33, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 16);
            this.label4.TabIndex = 20;
            this.label4.Text = "高阈值";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Cyan;
            this.label3.Location = new System.Drawing.Point(33, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 16);
            this.label3.TabIndex = 21;
            this.label3.Text = "低阈值";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Cyan;
            this.label2.Location = new System.Drawing.Point(16, 325);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 22;
            this.label2.Text = "最大面积";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Cyan;
            this.label1.Location = new System.Drawing.Point(16, 255);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "最小面积";
            // 
            // tbox_TwoCameras_MinAreaSelector
            // 
            this.tbox_TwoCameras_MinAreaSelector.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbox_TwoCameras_MinAreaSelector.Location = new System.Drawing.Point(118, 251);
            this.tbox_TwoCameras_MinAreaSelector.Name = "tbox_TwoCameras_MinAreaSelector";
            this.tbox_TwoCameras_MinAreaSelector.Size = new System.Drawing.Size(57, 26);
            this.tbox_TwoCameras_MinAreaSelector.TabIndex = 16;
            // 
            // tbox_TwoCameras_MaxThreshold
            // 
            this.tbox_TwoCameras_MaxThreshold.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbox_TwoCameras_MaxThreshold.Location = new System.Drawing.Point(118, 114);
            this.tbox_TwoCameras_MaxThreshold.Name = "tbox_TwoCameras_MaxThreshold";
            this.tbox_TwoCameras_MaxThreshold.Size = new System.Drawing.Size(57, 26);
            this.tbox_TwoCameras_MaxThreshold.TabIndex = 17;
            // 
            // trackBar_TwoCameras_MinAreaSelector
            // 
            this.trackBar_TwoCameras_MinAreaSelector.Location = new System.Drawing.Point(19, 282);
            this.trackBar_TwoCameras_MinAreaSelector.Name = "trackBar_TwoCameras_MinAreaSelector";
            this.trackBar_TwoCameras_MinAreaSelector.Size = new System.Drawing.Size(238, 45);
            this.trackBar_TwoCameras_MinAreaSelector.TabIndex = 12;
            this.trackBar_TwoCameras_MinAreaSelector.Scroll += new System.EventHandler(this.trackBar_TwoCameras_MinAreaSelector_Scroll);
            // 
            // tbox_TwoCameras_MaxAreaSelector
            // 
            this.tbox_TwoCameras_MaxAreaSelector.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbox_TwoCameras_MaxAreaSelector.Location = new System.Drawing.Point(118, 321);
            this.tbox_TwoCameras_MaxAreaSelector.Name = "tbox_TwoCameras_MaxAreaSelector";
            this.tbox_TwoCameras_MaxAreaSelector.Size = new System.Drawing.Size(57, 26);
            this.tbox_TwoCameras_MaxAreaSelector.TabIndex = 18;
            // 
            // trackBar_TwoCameras_MaxThresold
            // 
            this.trackBar_TwoCameras_MaxThresold.Location = new System.Drawing.Point(19, 148);
            this.trackBar_TwoCameras_MaxThresold.Name = "trackBar_TwoCameras_MaxThresold";
            this.trackBar_TwoCameras_MaxThresold.Size = new System.Drawing.Size(238, 45);
            this.trackBar_TwoCameras_MaxThresold.TabIndex = 13;
            this.trackBar_TwoCameras_MaxThresold.Scroll += new System.EventHandler(this.trackBar_TwoCameras_MaxThresold_Scroll);
            // 
            // trackBar_TwoCameras_MaxAreaSelector
            // 
            this.trackBar_TwoCameras_MaxAreaSelector.Location = new System.Drawing.Point(19, 359);
            this.trackBar_TwoCameras_MaxAreaSelector.Name = "trackBar_TwoCameras_MaxAreaSelector";
            this.trackBar_TwoCameras_MaxAreaSelector.Size = new System.Drawing.Size(238, 45);
            this.trackBar_TwoCameras_MaxAreaSelector.TabIndex = 14;
            this.trackBar_TwoCameras_MaxAreaSelector.Scroll += new System.EventHandler(this.trackBar_TwoCameras_MaxAreaSelector_Scroll);
            // 
            // tbox_TwoCameras_MinThreshold
            // 
            this.tbox_TwoCameras_MinThreshold.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbox_TwoCameras_MinThreshold.Location = new System.Drawing.Point(118, 44);
            this.tbox_TwoCameras_MinThreshold.Name = "tbox_TwoCameras_MinThreshold";
            this.tbox_TwoCameras_MinThreshold.Size = new System.Drawing.Size(57, 26);
            this.tbox_TwoCameras_MinThreshold.TabIndex = 19;
            // 
            // trackBar_TwoCameras_MinThresold
            // 
            this.trackBar_TwoCameras_MinThresold.Location = new System.Drawing.Point(19, 75);
            this.trackBar_TwoCameras_MinThresold.Name = "trackBar_TwoCameras_MinThresold";
            this.trackBar_TwoCameras_MinThresold.Size = new System.Drawing.Size(238, 45);
            this.trackBar_TwoCameras_MinThresold.TabIndex = 15;
            this.trackBar_TwoCameras_MinThresold.Scroll += new System.EventHandler(this.trackBar_TwoCameras_MinThresold_Scroll);
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Enabled = false;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.DarkGray;
            this.button2.Location = new System.Drawing.Point(118, 188);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 40);
            this.button2.TabIndex = 24;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btn_TwoCameras_ExtractNinePoints
            // 
            this.btn_TwoCameras_ExtractNinePoints.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_TwoCameras_ExtractNinePoints.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btn_TwoCameras_ExtractNinePoints.Location = new System.Drawing.Point(80, 463);
            this.btn_TwoCameras_ExtractNinePoints.Name = "btn_TwoCameras_ExtractNinePoints";
            this.btn_TwoCameras_ExtractNinePoints.Size = new System.Drawing.Size(95, 47);
            this.btn_TwoCameras_ExtractNinePoints.TabIndex = 25;
            this.btn_TwoCameras_ExtractNinePoints.Text = "提取九点";
            this.btn_TwoCameras_ExtractNinePoints.UseVisualStyleBackColor = true;
            this.btn_TwoCameras_ExtractNinePoints.Click += new System.EventHandler(this.btn_TwoCameras_ExtractNinePoints_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.DarkBlue;
            this.label5.Location = new System.Drawing.Point(553, 435);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 16);
            this.label5.TabIndex = 23;
            this.label5.Text = "当前显示相机";
            // 
            // label_CameraNo
            // 
            this.label_CameraNo.AutoSize = true;
            this.label_CameraNo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_CameraNo.ForeColor = System.Drawing.Color.DarkOrchid;
            this.label_CameraNo.Location = new System.Drawing.Point(668, 435);
            this.label_CameraNo.Name = "label_CameraNo";
            this.label_CameraNo.Size = new System.Drawing.Size(17, 16);
            this.label_CameraNo.TabIndex = 23;
            this.label_CameraNo.Text = "0";
            // 
            // label_Camera1Status
            // 
            this.label_Camera1Status.AutoSize = true;
            this.label_Camera1Status.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Camera1Status.ForeColor = System.Drawing.Color.DarkBlue;
            this.label_Camera1Status.Location = new System.Drawing.Point(553, 487);
            this.label_Camera1Status.Name = "label_Camera1Status";
            this.label_Camera1Status.Size = new System.Drawing.Size(68, 16);
            this.label_Camera1Status.TabIndex = 23;
            this.label_Camera1Status.Text = "相机1：";
            // 
            // label_Camera2Status
            // 
            this.label_Camera2Status.AutoSize = true;
            this.label_Camera2Status.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Camera2Status.ForeColor = System.Drawing.Color.DarkBlue;
            this.label_Camera2Status.Location = new System.Drawing.Point(749, 487);
            this.label_Camera2Status.Name = "label_Camera2Status";
            this.label_Camera2Status.Size = new System.Drawing.Size(68, 16);
            this.label_Camera2Status.TabIndex = 23;
            this.label_Camera2Status.Text = "相机2：";
            // 
            // btn_CurrentCameraPhoto
            // 
            this.btn_CurrentCameraPhoto.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_CurrentCameraPhoto.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btn_CurrentCameraPhoto.Location = new System.Drawing.Point(12, 410);
            this.btn_CurrentCameraPhoto.Name = "btn_CurrentCameraPhoto";
            this.btn_CurrentCameraPhoto.Size = new System.Drawing.Size(127, 47);
            this.btn_CurrentCameraPhoto.TabIndex = 10;
            this.btn_CurrentCameraPhoto.Text = "当前相机采集";
            this.btn_CurrentCameraPhoto.UseVisualStyleBackColor = true;
            this.btn_CurrentCameraPhoto.Click += new System.EventHandler(this.btn_CurrentCameraPhoto_Click);
            // 
            // btn_OpenTwoCameras
            // 
            this.btn_OpenTwoCameras.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_OpenTwoCameras.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btn_OpenTwoCameras.Location = new System.Drawing.Point(359, 420);
            this.btn_OpenTwoCameras.Name = "btn_OpenTwoCameras";
            this.btn_OpenTwoCameras.Size = new System.Drawing.Size(127, 47);
            this.btn_OpenTwoCameras.TabIndex = 10;
            this.btn_OpenTwoCameras.Text = "打开两相机";
            this.btn_OpenTwoCameras.UseVisualStyleBackColor = true;
            this.btn_OpenTwoCameras.Click += new System.EventHandler(this.btn_OpenTwoCameras_Click);
            // 
            // TwoCameras_Photo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(891, 512);
            this.Controls.Add(this.btn_TwoCameras_ExtractNinePoints);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_CameraNo);
            this.Controls.Add(this.label_Camera2Status);
            this.Controls.Add(this.label_Camera1Status);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbox_TwoCameras_MinAreaSelector);
            this.Controls.Add(this.tbox_TwoCameras_MaxThreshold);
            this.Controls.Add(this.trackBar_TwoCameras_MinAreaSelector);
            this.Controls.Add(this.tbox_TwoCameras_MaxAreaSelector);
            this.Controls.Add(this.trackBar_TwoCameras_MaxThresold);
            this.Controls.Add(this.trackBar_TwoCameras_MaxAreaSelector);
            this.Controls.Add(this.tbox_TwoCameras_MinThreshold);
            this.Controls.Add(this.trackBar_TwoCameras_MinThresold);
            this.Controls.Add(this.btn_CameraSwitch);
            this.Controls.Add(this.btn_OpenTwoCameras);
            this.Controls.Add(this.btn_CurrentCameraPhoto);
            this.Controls.Add(this.btn_TwoCameras_Snap);
            this.Controls.Add(this.pictureBox_TwoCamera);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TwoCameras_Photo";
            this.Text = "TwoCameras_Photo";
            this.Load += new System.EventHandler(this.TwoCameras_Photo_Load);
           // this.Click += new System.EventHandler(this.TwoCameras_Photo_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_TwoCamera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_TwoCameras_MinAreaSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_TwoCameras_MaxThresold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_TwoCameras_MaxAreaSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_TwoCameras_MinThresold)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_TwoCamera;
        private System.Windows.Forms.Button btn_TwoCameras_Snap;
        private System.Windows.Forms.Button btn_CameraSwitch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbox_TwoCameras_MinAreaSelector;
        private System.Windows.Forms.TextBox tbox_TwoCameras_MaxThreshold;
        private System.Windows.Forms.TrackBar trackBar_TwoCameras_MinAreaSelector;
        private System.Windows.Forms.TextBox tbox_TwoCameras_MaxAreaSelector;
        private System.Windows.Forms.TrackBar trackBar_TwoCameras_MaxThresold;
        private System.Windows.Forms.TrackBar trackBar_TwoCameras_MaxAreaSelector;
        private System.Windows.Forms.TextBox tbox_TwoCameras_MinThreshold;
        private System.Windows.Forms.TrackBar trackBar_TwoCameras_MinThresold;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_TwoCameras_ExtractNinePoints;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_CameraNo;
        private System.Windows.Forms.Label label_Camera1Status;
        private System.Windows.Forms.Label label_Camera2Status;
        private System.Windows.Forms.Button btn_CurrentCameraPhoto;
        private System.Windows.Forms.Button btn_OpenTwoCameras;
    }
}