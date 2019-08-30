namespace xiangmu4
{
    partial class CalForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalForm));
            this.btn_GrabPhoto = new System.Windows.Forms.Button();
            this.btn_ExtractNinePoints = new System.Windows.Forms.Button();
            this.btn_Calibration = new System.Windows.Forms.Button();
            this.btn_SaveCalibrateResults = new System.Windows.Forms.Button();
            this.btn_jiantou = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox_Camera = new System.Windows.Forms.GroupBox();
            this.pictureBox_CalibrationCamera = new System.Windows.Forms.PictureBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.btn_CameraOperator = new System.Windows.Forms.Button();
            this.groupBox_RobotNinePoints = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox_PictureNinePoints = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.trackBar_MinThresold = new System.Windows.Forms.TrackBar();
            this.tbox_MinThreshold = new System.Windows.Forms.TextBox();
            this.trackBar_MaxThresold = new System.Windows.Forms.TrackBar();
            this.tbox_MaxThreshold = new System.Windows.Forms.TextBox();
            this.trackBar_MaxAreaSelector = new System.Windows.Forms.TrackBar();
            this.tbox_MaxAreaSelector = new System.Windows.Forms.TextBox();
            this.trackBar_MinAreaSelector = new System.Windows.Forms.TrackBar();
            this.tbox_MinAreaSelector = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox_Camera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_CalibrationCamera)).BeginInit();
            this.groupBox_RobotNinePoints.SuspendLayout();
            this.groupBox_PictureNinePoints.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_MinThresold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_MaxThresold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_MaxAreaSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_MinAreaSelector)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_GrabPhoto
            // 
            this.btn_GrabPhoto.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_GrabPhoto.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btn_GrabPhoto.Location = new System.Drawing.Point(13, 28);
            this.btn_GrabPhoto.Name = "btn_GrabPhoto";
            this.btn_GrabPhoto.Size = new System.Drawing.Size(95, 47);
            this.btn_GrabPhoto.TabIndex = 0;
            this.btn_GrabPhoto.Text = "抓图";
            this.btn_GrabPhoto.UseVisualStyleBackColor = true;
            this.btn_GrabPhoto.Click += new System.EventHandler(this.btn_GrabPhoto_Click);
            // 
            // btn_ExtractNinePoints
            // 
            this.btn_ExtractNinePoints.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ExtractNinePoints.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btn_ExtractNinePoints.Location = new System.Drawing.Point(13, 148);
            this.btn_ExtractNinePoints.Name = "btn_ExtractNinePoints";
            this.btn_ExtractNinePoints.Size = new System.Drawing.Size(95, 47);
            this.btn_ExtractNinePoints.TabIndex = 0;
            this.btn_ExtractNinePoints.Text = "提取九点";
            this.btn_ExtractNinePoints.UseVisualStyleBackColor = true;
            this.btn_ExtractNinePoints.Click += new System.EventHandler(this.btn_ExtractNinePoints_Click);
            // 
            // btn_Calibration
            // 
            this.btn_Calibration.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Calibration.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btn_Calibration.Location = new System.Drawing.Point(13, 268);
            this.btn_Calibration.Name = "btn_Calibration";
            this.btn_Calibration.Size = new System.Drawing.Size(95, 47);
            this.btn_Calibration.TabIndex = 0;
            this.btn_Calibration.Text = "标定";
            this.btn_Calibration.UseVisualStyleBackColor = true;
            this.btn_Calibration.Click += new System.EventHandler(this.btn_Calibration_Click);
            // 
            // btn_SaveCalibrateResults
            // 
            this.btn_SaveCalibrateResults.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_SaveCalibrateResults.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btn_SaveCalibrateResults.Location = new System.Drawing.Point(13, 383);
            this.btn_SaveCalibrateResults.Name = "btn_SaveCalibrateResults";
            this.btn_SaveCalibrateResults.Size = new System.Drawing.Size(95, 47);
            this.btn_SaveCalibrateResults.TabIndex = 0;
            this.btn_SaveCalibrateResults.Text = "保存标定结果";
            this.btn_SaveCalibrateResults.UseVisualStyleBackColor = true;
            this.btn_SaveCalibrateResults.Click += new System.EventHandler(this.btn_SaveCalibrateResults_Click);
            // 
            // btn_jiantou
            // 
            this.btn_jiantou.BackColor = System.Drawing.Color.DarkGray;
            this.btn_jiantou.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_jiantou.BackgroundImage")));
            this.btn_jiantou.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_jiantou.Enabled = false;
            this.btn_jiantou.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_jiantou.ForeColor = System.Drawing.Color.DarkGray;
            this.btn_jiantou.Location = new System.Drawing.Point(41, 92);
            this.btn_jiantou.Name = "btn_jiantou";
            this.btn_jiantou.Size = new System.Drawing.Size(40, 40);
            this.btn_jiantou.TabIndex = 1;
            this.btn_jiantou.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.Enabled = false;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.Color.DarkGray;
            this.button4.Location = new System.Drawing.Point(41, 214);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(40, 40);
            this.button4.TabIndex = 1;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button5.BackgroundImage")));
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.Enabled = false;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ForeColor = System.Drawing.Color.DarkGray;
            this.button5.Location = new System.Drawing.Point(41, 331);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(40, 40);
            this.button5.TabIndex = 1;
            this.button5.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton1.ForeColor = System.Drawing.Color.Coral;
            this.radioButton1.Location = new System.Drawing.Point(371, 399);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(69, 24);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.Text = "正拍";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // groupBox_Camera
            // 
            this.groupBox_Camera.Controls.Add(this.pictureBox_CalibrationCamera);
            this.groupBox_Camera.Controls.Add(this.radioButton2);
            this.groupBox_Camera.Controls.Add(this.radioButton1);
            this.groupBox_Camera.Controls.Add(this.button5);
            this.groupBox_Camera.Controls.Add(this.button4);
            this.groupBox_Camera.Controls.Add(this.btn_jiantou);
            this.groupBox_Camera.Controls.Add(this.btn_CameraOperator);
            this.groupBox_Camera.Controls.Add(this.btn_SaveCalibrateResults);
            this.groupBox_Camera.Controls.Add(this.btn_Calibration);
            this.groupBox_Camera.Controls.Add(this.btn_ExtractNinePoints);
            this.groupBox_Camera.Controls.Add(this.btn_GrabPhoto);
            this.groupBox_Camera.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox_Camera.ForeColor = System.Drawing.Color.Coral;
            this.groupBox_Camera.Location = new System.Drawing.Point(419, 12);
            this.groupBox_Camera.Name = "groupBox_Camera";
            this.groupBox_Camera.Size = new System.Drawing.Size(609, 436);
            this.groupBox_Camera.TabIndex = 3;
            this.groupBox_Camera.TabStop = false;
            this.groupBox_Camera.Text = "相机参数设定";
            // 
            // pictureBox_CalibrationCamera
            // 
            this.pictureBox_CalibrationCamera.BackColor = System.Drawing.Color.Ivory;
            this.pictureBox_CalibrationCamera.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox_CalibrationCamera.BackgroundImage")));
            this.pictureBox_CalibrationCamera.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_CalibrationCamera.Location = new System.Drawing.Point(114, 28);
            this.pictureBox_CalibrationCamera.Name = "pictureBox_CalibrationCamera";
            this.pictureBox_CalibrationCamera.Size = new System.Drawing.Size(456, 355);
            this.pictureBox_CalibrationCamera.TabIndex = 3;
            this.pictureBox_CalibrationCamera.TabStop = false;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton2.ForeColor = System.Drawing.Color.Coral;
            this.radioButton2.Location = new System.Drawing.Point(501, 399);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(69, 24);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.Text = "斜拍";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // btn_CameraOperator
            // 
            this.btn_CameraOperator.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_CameraOperator.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btn_CameraOperator.Location = new System.Drawing.Point(217, 383);
            this.btn_CameraOperator.Name = "btn_CameraOperator";
            this.btn_CameraOperator.Size = new System.Drawing.Size(101, 47);
            this.btn_CameraOperator.TabIndex = 0;
            this.btn_CameraOperator.Text = "打开相机";
            this.btn_CameraOperator.UseVisualStyleBackColor = true;
            this.btn_CameraOperator.Click += new System.EventHandler(this.btn_CameraOperator_Click);
            // 
            // groupBox_RobotNinePoints
            // 
            this.groupBox_RobotNinePoints.Controls.Add(this.label6);
            this.groupBox_RobotNinePoints.Controls.Add(this.label5);
            this.groupBox_RobotNinePoints.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox_RobotNinePoints.ForeColor = System.Drawing.Color.Coral;
            this.groupBox_RobotNinePoints.Location = new System.Drawing.Point(13, 12);
            this.groupBox_RobotNinePoints.Name = "groupBox_RobotNinePoints";
            this.groupBox_RobotNinePoints.Size = new System.Drawing.Size(195, 435);
            this.groupBox_RobotNinePoints.TabIndex = 4;
            this.groupBox_RobotNinePoints.TabStop = false;
            this.groupBox_RobotNinePoints.Text = "机械手九个点的坐标";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.Honeydew;
            this.label6.Location = new System.Drawing.Point(112, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "Y坐标";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Honeydew;
            this.label5.Location = new System.Drawing.Point(18, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "X坐标";
            // 
            // groupBox_PictureNinePoints
            // 
            this.groupBox_PictureNinePoints.Controls.Add(this.label8);
            this.groupBox_PictureNinePoints.Controls.Add(this.label7);
            this.groupBox_PictureNinePoints.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox_PictureNinePoints.ForeColor = System.Drawing.Color.Coral;
            this.groupBox_PictureNinePoints.Location = new System.Drawing.Point(214, 13);
            this.groupBox_PictureNinePoints.Name = "groupBox_PictureNinePoints";
            this.groupBox_PictureNinePoints.Size = new System.Drawing.Size(195, 435);
            this.groupBox_PictureNinePoints.TabIndex = 4;
            this.groupBox_PictureNinePoints.TabStop = false;
            this.groupBox_PictureNinePoints.Text = "图片的九点坐标";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.Honeydew;
            this.label8.Location = new System.Drawing.Point(115, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 16);
            this.label8.TabIndex = 7;
            this.label8.Text = "Column";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.Honeydew;
            this.label7.Location = new System.Drawing.Point(21, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 16);
            this.label7.TabIndex = 7;
            this.label7.Text = "Row";
            // 
            // trackBar_MinThresold
            // 
            this.trackBar_MinThresold.Location = new System.Drawing.Point(579, 454);
            this.trackBar_MinThresold.Name = "trackBar_MinThresold";
            this.trackBar_MinThresold.Size = new System.Drawing.Size(263, 45);
            this.trackBar_MinThresold.TabIndex = 5;
            this.trackBar_MinThresold.Scroll += new System.EventHandler(this.trackBar_MinThresold_Scroll);
            // 
            // tbox_MinThreshold
            // 
            this.tbox_MinThreshold.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbox_MinThreshold.Location = new System.Drawing.Point(865, 454);
            this.tbox_MinThreshold.Name = "tbox_MinThreshold";
            this.tbox_MinThreshold.Size = new System.Drawing.Size(57, 26);
            this.tbox_MinThreshold.TabIndex = 6;
            // 
            // trackBar_MaxThresold
            // 
            this.trackBar_MaxThresold.Location = new System.Drawing.Point(579, 486);
            this.trackBar_MaxThresold.Name = "trackBar_MaxThresold";
            this.trackBar_MaxThresold.Size = new System.Drawing.Size(263, 45);
            this.trackBar_MaxThresold.TabIndex = 5;
            this.trackBar_MaxThresold.Scroll += new System.EventHandler(this.trackBar_MaxThresold_Scroll);
            // 
            // tbox_MaxThreshold
            // 
            this.tbox_MaxThreshold.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbox_MaxThreshold.Location = new System.Drawing.Point(865, 487);
            this.tbox_MaxThreshold.Name = "tbox_MaxThreshold";
            this.tbox_MaxThreshold.Size = new System.Drawing.Size(57, 26);
            this.tbox_MaxThreshold.TabIndex = 6;
            // 
            // trackBar_MaxAreaSelector
            // 
            this.trackBar_MaxAreaSelector.Location = new System.Drawing.Point(128, 486);
            this.trackBar_MaxAreaSelector.Name = "trackBar_MaxAreaSelector";
            this.trackBar_MaxAreaSelector.Size = new System.Drawing.Size(263, 45);
            this.trackBar_MaxAreaSelector.TabIndex = 5;
            this.trackBar_MaxAreaSelector.Scroll += new System.EventHandler(this.trackBar_MaxAreaSelector_Scroll);
            // 
            // tbox_MaxAreaSelector
            // 
            this.tbox_MaxAreaSelector.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbox_MaxAreaSelector.Location = new System.Drawing.Point(397, 491);
            this.tbox_MaxAreaSelector.Name = "tbox_MaxAreaSelector";
            this.tbox_MaxAreaSelector.Size = new System.Drawing.Size(57, 26);
            this.tbox_MaxAreaSelector.TabIndex = 6;
            // 
            // trackBar_MinAreaSelector
            // 
            this.trackBar_MinAreaSelector.Location = new System.Drawing.Point(128, 448);
            this.trackBar_MinAreaSelector.Name = "trackBar_MinAreaSelector";
            this.trackBar_MinAreaSelector.Size = new System.Drawing.Size(263, 45);
            this.trackBar_MinAreaSelector.TabIndex = 5;
            this.trackBar_MinAreaSelector.Scroll += new System.EventHandler(this.trackBar_MinAreaSelector_Scroll);
            // 
            // tbox_MinAreaSelector
            // 
            this.tbox_MinAreaSelector.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbox_MinAreaSelector.Location = new System.Drawing.Point(397, 454);
            this.tbox_MinAreaSelector.Name = "tbox_MinAreaSelector";
            this.tbox_MinAreaSelector.Size = new System.Drawing.Size(57, 26);
            this.tbox_MinAreaSelector.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Cyan;
            this.label1.Location = new System.Drawing.Point(46, 450);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "最小面积";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Cyan;
            this.label2.Location = new System.Drawing.Point(46, 491);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "最大面积";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Cyan;
            this.label3.Location = new System.Drawing.Point(514, 454);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "低阈值";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Cyan;
            this.label4.Location = new System.Drawing.Point(514, 495);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "高阈值";
            // 
            // CalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1001, 529);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbox_MinAreaSelector);
            this.Controls.Add(this.tbox_MaxThreshold);
            this.Controls.Add(this.trackBar_MinAreaSelector);
            this.Controls.Add(this.tbox_MaxAreaSelector);
            this.Controls.Add(this.trackBar_MaxThresold);
            this.Controls.Add(this.trackBar_MaxAreaSelector);
            this.Controls.Add(this.tbox_MinThreshold);
            this.Controls.Add(this.trackBar_MinThresold);
            this.Controls.Add(this.groupBox_PictureNinePoints);
            this.Controls.Add(this.groupBox_RobotNinePoints);
            this.Controls.Add(this.groupBox_Camera);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CalForm";
            this.Text = "CalForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CalForm_FormClosed);
            this.Load += new System.EventHandler(this.CalForm_Load);
            this.groupBox_Camera.ResumeLayout(false);
            this.groupBox_Camera.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_CalibrationCamera)).EndInit();
            this.groupBox_RobotNinePoints.ResumeLayout(false);
            this.groupBox_RobotNinePoints.PerformLayout();
            this.groupBox_PictureNinePoints.ResumeLayout(false);
            this.groupBox_PictureNinePoints.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_MinThresold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_MaxThresold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_MaxAreaSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_MinAreaSelector)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_GrabPhoto;
        private System.Windows.Forms.Button btn_ExtractNinePoints;
        private System.Windows.Forms.Button btn_Calibration;
        private System.Windows.Forms.Button btn_SaveCalibrateResults;
        private System.Windows.Forms.Button btn_jiantou;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.GroupBox groupBox_Camera;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Button btn_CameraOperator;
        private System.Windows.Forms.PictureBox pictureBox_CalibrationCamera;
        private System.Windows.Forms.GroupBox groupBox_RobotNinePoints;
        private System.Windows.Forms.GroupBox groupBox_PictureNinePoints;
        private System.Windows.Forms.TrackBar trackBar_MinThresold;
        private System.Windows.Forms.TextBox tbox_MinThreshold;
        private System.Windows.Forms.TrackBar trackBar_MaxThresold;
        private System.Windows.Forms.TextBox tbox_MaxThreshold;
        private System.Windows.Forms.TrackBar trackBar_MaxAreaSelector;
        private System.Windows.Forms.TextBox tbox_MaxAreaSelector;
        private System.Windows.Forms.TrackBar trackBar_MinAreaSelector;
        private System.Windows.Forms.TextBox tbox_MinAreaSelector;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}