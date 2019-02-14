// Felix-Bang：FBServer
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
    public class FBSocketState
    {
        public Socket socket;
        public byte[] buffer;

        public FBSocketState(Socket tmpSocket)
        {
            buffer = new byte[1024];
            socket = tmpSocket;
        }

        public void BeginReceive()
        {
            socket.BeginReceive(buffer, 0, 1024, SocketFlags.None, ReceiveCallback, this);
        }

        private void ReceiveCallback(IAsyncResult result)
        {
            //从客户端接收的数据量
            int length = socket.EndReceive(result);
            string tmpStr = Encoding.Default.GetString(buffer, 0, length);
            FBDebug.Log("Server Receive Mess:  " + tmpStr);

            BeginSend(tmpStr);
        }

        public void BeginSend(string sendStr)
        {
            byte[] data = Encoding.Default.GetBytes(sendStr);
            socket.BeginSend(data, 0, data.Length, SocketFlags.None, SendCallback, this);
        }

        private void SendCallback(IAsyncResult result)
        {
            int byteSend = socket.EndSend(result);
            FBDebug.Log("Server Byte send count " + byteSend);
        }
    }


	public class FBServer : MonoBehaviour 
	{
        #region Delegates/Action

        #endregion

        #region Fields/Properties
        private Socket f_socket;
        private bool f_isRunning=true;
        private List<FBSocketState> f_sockets;
        #endregion

        #region
        void Start()
        {

            IntialSocket();
        }

        void Update()
        {
            if(f_sockets.Count>0)
            {
                for (int i = 0,max= f_sockets.Count; i < max; i++)
                {
                    f_sockets[i].BeginReceive();
                }
            }
        }

        void OnApplicationQuit()
        {
            f_socket.Shutdown(SocketShutdown.Both);
            f_socket.Close();
        }
        #endregion


        #region Methods
        public void IntialSocket()
        {
            //端口：                             协议族    端口号：1024-49151
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 18010);
            //参数：协议族（IPV4/IPV6） 类型（字节流/数据报） 协议（TCP/UDP）
            f_socket = new Socket(endPoint.AddressFamily,SocketType.Stream,ProtocolType.Tcp);
            //将socket与网卡、端口号进行绑定
            f_socket.Bind(endPoint);
            //服务端特有，用来监听客户端连接请求（可接收连接请求的数量）
            f_socket.Listen(100);

            f_sockets = new List<FBSocketState>();

            Thread tmpThread = new Thread(ListenReceive);
            tmpThread.Start();
        }

        /// <summary> 接收 </summary>
        private void ListenReceive()
        {
            while (f_isRunning)
            {
                try
                {
                    f_socket.BeginAccept(new AsyncCallback(AcceptCallback),f_socket);
                }
                catch
                { }

                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// 启动一个独立现场调用
        /// </summary>
        /// <param name="result"></param>
        private void AcceptCallback(IAsyncResult result)
        {
            //得到一个连接请求
            Socket listener = (Socket)result.AsyncState;
            //堵塞 知道客户端有连接请求过来
            Socket clientSocket = listener.EndAccept(result);
            FBSocketState state = new FBSocketState(clientSocket);

            f_sockets.Add(state);
        }


       
		#endregion
	}//Class End
}
