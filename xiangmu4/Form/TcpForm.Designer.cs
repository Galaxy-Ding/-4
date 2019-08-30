namespace xiangmu4
{
    partial class TcpForm
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
            this.tbox_Send = new System.Windows.Forms.TextBox();
            this.listbox_Receive = new System.Windows.Forms.ListBox();
            this.btn_Send = new System.Windows.Forms.Button();
            this.btn_Server_Stop = new System.Windows.Forms.Button();
            this.btn_vari = new System.Windows.Forms.Button();
            this.btn_File = new System.Windows.Forms.Button();
            this.btn_Server_Start = new System.Windows.Forms.Button();
            this.tbox_IP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.listBox_Client = new System.Windows.Forms.ListBox();
            this.tbox_Port = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.listBox_Message = new System.Windows.Forms.ListBox();
            this.checkBox_HexOrStringReceive = new System.Windows.Forms.CheckBox();
            this.checkBox_HexOrStringSend = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // tbox_Send
            // 
            this.tbox_Send.Location = new System.Drawing.Point(12, 348);
            this.tbox_Send.Multiline = true;
            this.tbox_Send.Name = "tbox_Send";
            this.tbox_Send.Size = new System.Drawing.Size(469, 90);
            this.tbox_Send.TabIndex = 17;
            // 
            // listbox_Receive
            // 
            this.listbox_Receive.FormattingEnabled = true;
            this.listbox_Receive.ItemHeight = 12;
            this.listbox_Receive.Location = new System.Drawing.Point(12, 98);
            this.listbox_Receive.Name = "listbox_Receive";
            this.listbox_Receive.Size = new System.Drawing.Size(469, 208);
            this.listbox_Receive.TabIndex = 15;
            // 
            // btn_Send
            // 
            this.btn_Send.Font = new System.Drawing.Font("隶书", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Send.ForeColor = System.Drawing.Color.Chocolate;
            this.btn_Send.Location = new System.Drawing.Point(531, 348);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(257, 90);
            this.btn_Send.TabIndex = 9;
            this.btn_Send.Text = "发送";
            this.btn_Send.UseVisualStyleBackColor = true;
            this.btn_Send.Click += new System.EventHandler(this.btn_Send_Click);
            // 
            // btn_Server_Stop
            // 
            this.btn_Server_Stop.Font = new System.Drawing.Font("隶书", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Server_Stop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_Server_Stop.Location = new System.Drawing.Point(648, 22);
            this.btn_Server_Stop.Name = "btn_Server_Stop";
            this.btn_Server_Stop.Size = new System.Drawing.Size(120, 36);
            this.btn_Server_Stop.TabIndex = 10;
            this.btn_Server_Stop.Text = "停止服务";
            this.btn_Server_Stop.UseVisualStyleBackColor = true;
            this.btn_Server_Stop.Click += new System.EventHandler(this.btn_Server_Stop_Click);
            // 
            // btn_vari
            // 
            this.btn_vari.Font = new System.Drawing.Font("隶书", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_vari.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.btn_vari.Location = new System.Drawing.Point(668, 293);
            this.btn_vari.Name = "btn_vari";
            this.btn_vari.Size = new System.Drawing.Size(120, 47);
            this.btn_vari.TabIndex = 12;
            this.btn_vari.Text = "震动";
            this.btn_vari.UseVisualStyleBackColor = true;
            // 
            // btn_File
            // 
            this.btn_File.Font = new System.Drawing.Font("隶书", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_File.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.btn_File.Location = new System.Drawing.Point(531, 293);
            this.btn_File.Name = "btn_File";
            this.btn_File.Size = new System.Drawing.Size(120, 47);
            this.btn_File.TabIndex = 13;
            this.btn_File.Text = "发送文件";
            this.btn_File.UseVisualStyleBackColor = true;
            // 
            // btn_Server_Start
            // 
            this.btn_Server_Start.Font = new System.Drawing.Font("隶书", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Server_Start.ForeColor = System.Drawing.Color.Green;
            this.btn_Server_Start.Location = new System.Drawing.Point(522, 22);
            this.btn_Server_Start.Name = "btn_Server_Start";
            this.btn_Server_Start.Size = new System.Drawing.Size(120, 36);
            this.btn_Server_Start.TabIndex = 14;
            this.btn_Server_Start.Text = "启动服务";
            this.btn_Server_Start.UseVisualStyleBackColor = true;
            this.btn_Server_Start.Click += new System.EventHandler(this.btn_Server_Start_Click);
            // 
            // tbox_IP
            // 
            this.tbox_IP.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbox_IP.Location = new System.Drawing.Point(108, 27);
            this.tbox_IP.Name = "tbox_IP";
            this.tbox_IP.Size = new System.Drawing.Size(142, 26);
            this.tbox_IP.TabIndex = 8;
            this.tbox_IP.Text = "127.0.0.1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 26);
            this.label1.TabIndex = 7;
            this.label1.Text = "服务器IP：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 26);
            this.label2.TabIndex = 7;
            this.label2.Text = "接受信息";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(12, 314);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 26);
            this.label3.TabIndex = 7;
            this.label3.Text = "发送信息";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(526, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 26);
            this.label4.TabIndex = 7;
            this.label4.Text = "接入的客户";
            // 
            // listBox_Client
            // 
            this.listBox_Client.FormattingEnabled = true;
            this.listBox_Client.ItemHeight = 12;
            this.listBox_Client.Location = new System.Drawing.Point(531, 100);
            this.listBox_Client.Name = "listBox_Client";
            this.listBox_Client.Size = new System.Drawing.Size(257, 76);
            this.listBox_Client.TabIndex = 15;
            // 
            // tbox_Port
            // 
            this.tbox_Port.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbox_Port.Location = new System.Drawing.Point(361, 27);
            this.tbox_Port.Name = "tbox_Port";
            this.tbox_Port.Size = new System.Drawing.Size(76, 26);
            this.tbox_Port.TabIndex = 8;
            this.tbox_Port.Text = "3000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(310, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 26);
            this.label5.TabIndex = 7;
            this.label5.Text = "端口";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(526, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 26);
            this.label6.TabIndex = 7;
            this.label6.Text = "消息";
            // 
            // listBox_Message
            // 
            this.listBox_Message.FormattingEnabled = true;
            this.listBox_Message.ItemHeight = 12;
            this.listBox_Message.Location = new System.Drawing.Point(531, 211);
            this.listBox_Message.Name = "listBox_Message";
            this.listBox_Message.Size = new System.Drawing.Size(257, 76);
            this.listBox_Message.TabIndex = 15;
            // 
            // checkBox_HexOrStringReceive
            // 
            this.checkBox_HexOrStringReceive.AutoSize = true;
            this.checkBox_HexOrStringReceive.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox_HexOrStringReceive.ForeColor = System.Drawing.Color.Bisque;
            this.checkBox_HexOrStringReceive.Location = new System.Drawing.Point(352, 72);
            this.checkBox_HexOrStringReceive.Name = "checkBox_HexOrStringReceive";
            this.checkBox_HexOrStringReceive.Size = new System.Drawing.Size(129, 20);
            this.checkBox_HexOrStringReceive.TabIndex = 18;
            this.checkBox_HexOrStringReceive.Text = "十六进制显示";
            this.checkBox_HexOrStringReceive.UseVisualStyleBackColor = true;
            // 
            // checkBox_HexOrStringSend
            // 
            this.checkBox_HexOrStringSend.AutoSize = true;
            this.checkBox_HexOrStringSend.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox_HexOrStringSend.ForeColor = System.Drawing.Color.Bisque;
            this.checkBox_HexOrStringSend.Location = new System.Drawing.Point(352, 322);
            this.checkBox_HexOrStringSend.Name = "checkBox_HexOrStringSend";
            this.checkBox_HexOrStringSend.Size = new System.Drawing.Size(129, 20);
            this.checkBox_HexOrStringSend.TabIndex = 18;
            this.checkBox_HexOrStringSend.Text = "十六进制发送";
            this.checkBox_HexOrStringSend.UseVisualStyleBackColor = true;
            // 
            // TcpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.checkBox_HexOrStringSend);
            this.Controls.Add(this.checkBox_HexOrStringReceive);
            this.Controls.Add(this.tbox_Send);
            this.Controls.Add(this.listBox_Message);
            this.Controls.Add(this.listBox_Client);
            this.Controls.Add(this.listbox_Receive);
            this.Controls.Add(this.btn_Send);
            this.Controls.Add(this.btn_Server_Stop);
            this.Controls.Add(this.btn_vari);
            this.Controls.Add(this.btn_File);
            this.Controls.Add(this.btn_Server_Start);
            this.Controls.Add(this.tbox_Port);
            this.Controls.Add(this.tbox_IP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TcpForm";
            this.Text = "TcpForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TcpForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbox_Send;
        private System.Windows.Forms.ListBox listbox_Receive;
        private System.Windows.Forms.Button btn_Send;
        private System.Windows.Forms.Button btn_Server_Stop;
        private System.Windows.Forms.Button btn_vari;
        private System.Windows.Forms.Button btn_File;
        private System.Windows.Forms.Button btn_Server_Start;
        private System.Windows.Forms.TextBox tbox_IP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBox_Client;
        private System.Windows.Forms.TextBox tbox_Port;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox listBox_Message;
        private SocketHelper.AxTcpServer axTcpServer1;
        private System.Windows.Forms.CheckBox checkBox_HexOrStringReceive;
        private System.Windows.Forms.CheckBox checkBox_HexOrStringSend;
    }
}