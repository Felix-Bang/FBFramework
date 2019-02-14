// Felix-Bang：FBClient
//　　 へ　　　　　／|
//　　/＼7　　　 ∠＿/
//　 /　│　　 ／　／
//　/　Z ＿,＜　／　　 /`ヽ
//  │　　　　　ヽ　　 /　　〉
//　 Y　　　　　`　 /　　/
//　ｲ●　､　●　　⊂⊃〈　　/
//　()　 へ　　　　|　＼〈
//　　>ｰ ､_　 ィ　 │ ／／
//　 / へ　　 /　ﾉ＜| ＼＼
//　 ヽ_ﾉ　　(_／　 │／／
//　　7　　　　　　　|／
//　　＞―r￣￣`ｰ―＿/
// Describe：
// CreateTime：

using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

namespace FelixBang
{
	public class FBClient : MonoBehaviour 
	{
        #region Delegates/Action
        #endregion

        #region Fields/Properties
        private Socket f_socket;
        public byte[] buffer = new byte[1024];
        #endregion

        #region Constructor
        #endregion

        #region Unity
        void Awake () 
		{
			
		}

		void Start () 
		{
            IntialSocket();
		}
	
		void Update () 
		{
            if (Input.GetMouseButtonDown(0))
            {
                BeginSend("Felix");
            }

            BeginReceive();
		}
        #endregion

        #region Interface
        #endregion

        #region Methods
        public void IntialSocket()
        {
            //服务端地址： 
            string id01 = "192.168.16.122";
            string id02 = "192.168.16.254";
            IPAddress ipAddress = IPAddress.Parse(id01);
            IPEndPoint endPoint = new IPEndPoint(ipAddress, 18010);

            f_socket = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);

            f_socket.BeginConnect(endPoint, new AsyncCallback(ConnectCallback), f_socket);
        }

        public void ConnectCallback(IAsyncResult result)
        {
            f_socket.EndConnect(result);
            FBDebug.Log("Connect Success!");
        }


    

        public void BeginReceive()
        {
            //
            f_socket.BeginReceive(buffer, 0, 1024, SocketFlags.None, ReceiveCallback, this);
        }

        private void ReceiveCallback(IAsyncResult result)
        {
            //从客户端接收的数据量
            int length = f_socket.EndReceive(result);
            string tmpStr = Encoding.Default.GetString(buffer, 0, length);
            FBDebug.Log("Client Receive Mess:  " + tmpStr);

            BeginSend(tmpStr);
        }

        public void BeginSend(string sendStr)
        {
            byte[] data = Encoding.Default.GetBytes(sendStr);
            f_socket.BeginSend(data, 0, data.Length, SocketFlags.None, SendCallback, this);
        }

        private void SendCallback(IAsyncResult result)
        {
            int byteSend = f_socket.EndSend(result);
            FBDebug.Log("Client Byte send count " + byteSend);
        }

        #endregion
    }//Class End
}
