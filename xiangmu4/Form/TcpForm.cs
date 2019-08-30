using SocketHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xiangmu4
{
    public partial class TcpForm : Form
    {

        public TcpForm()
        {
            InitializeComponent();
        }
       
        private void btn_Server_Start_Click(object sender, EventArgs e)
        {
            axTcpServer1.ServerPort = int.Parse(tbox_Port.Text);
            axTcpServer1.ServerIp = tbox_IP.Text;
            axTcpServer1.Start();
        }
        private void btn_Server_Stop_Click(object sender, EventArgs e)
        {
            axTcpServer1.Stop();
        }


















        private void GetClientCount(int count)
        {
            try
            {
                label4.Text = (string.Format("接入的客户端数量：{0}", count));
            }
            catch
            {
            }
        }
        /// <summary>
        /// 接收数据
        /// </summary>
        /// <param name="temp"></param>
        /// <param name="dataBytes"></param>
        private void ReceviceByteData(Socket temp, byte[] dataBytes)
        {
            try
            {
                string msg = "";
                if (checkBox_HexOrStringReceive.Checked)
                {
                    msg = IntegerOrString.HexByteArrayToString(dataBytes);
                }
                else
                {
                    msg = Encoding.Default.GetString(dataBytes);
                }
                string ip = ((IPEndPoint)temp.RemoteEndPoint).Address.ToString();
                string port = ((IPEndPoint)temp.RemoteEndPoint).Port.ToString();

                Invoke(new MethodInvoker(() => listbox_Receive.Items.Add(string.Format("IP：{0}-端口：{1}=>{2}发来消息：{3}", ip, port, DateTime.Now.ToString("HH:mm:ss"), msg))));
               
            }
            catch
            {
            }

        }
        /// <summary>
        /// 状态返回数据
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="state"></param>
        private void StateInfoData(string msg, SocketState state)
        {
            try
            {
                Invoke(new MethodInvoker(() => listBox_Message.Items.Add(string.Format("状态消息：{0}", msg))));
                
            }
            catch
            {
            }
        }
        /// <summary>
        /// 错误返回数据
        /// </summary>
        /// <param name="msg"></param>
        private void ErrorMsgData(string msg)
        {
            try
            {
                Invoke(new MethodInvoker(() => listBox_Message.Items.Add(string.Format("错误消息：{0}", msg))));
              
            }
            catch
            {
            }
        }
        /// <summary>
        /// 客户端上线通知
        /// </summary>
        /// <param name="temp"></param>
        private void AddClient(Socket temp)
        {
            try
            {
                string ip = ((IPEndPoint)temp.RemoteEndPoint).Address.ToString();
                string port = ((IPEndPoint)temp.RemoteEndPoint).Port.ToString();
                Invoke(new MethodInvoker(() => listBox_Client.Items.Add(string.Format("{0}:{1}", ip, port))));
               
            }
            catch
            {
            }
        }
        /// <summary>
        /// 客户端下线通知
        /// </summary>
        /// <param name="temp"></param>
        private void DelClient(Socket temp)
        {
            try
            {
                string ip = ((IPEndPoint)temp.RemoteEndPoint).Address.ToString();
                string port = ((IPEndPoint)temp.RemoteEndPoint).Port.ToString();
                Invoke(new MethodInvoker(() => listBox_Client.Items.Remove(string.Format("{0}:{1}", ip, port))));
               
            }
            catch
            {
            }
        }

        private void btn_Send_Click(object sender, EventArgs e)
        {
            if (listBox_Client.SelectedItem != null)
            {
                try
                {
                    byte[] senddata;
                    if (checkBox_HexOrStringSend.Checked)
                    {
                        senddata = IntegerOrString.StringToHexByteArray(tbox_Send.Text);
                    }
                    else
                    {
                        senddata = Encoding.Default.GetBytes(tbox_Send.Text);
                    }
                    string[] strArr = listBox_Client.Items[listBox_Client.SelectedIndex].ToString().Split(':');
                    axTcpServer1.SendData(strArr[0], int.Parse(strArr[1]), senddata);
                }
                catch
                {
                }
            }
        }

        private void TcpForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (axTcpServer1 != null)
                axTcpServer1.Stop();
        }
    }
}
