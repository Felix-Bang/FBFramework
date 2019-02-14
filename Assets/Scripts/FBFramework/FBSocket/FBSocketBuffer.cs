// Felix-Bang：FBSocketBuffer
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FelixBang
{
	public class FBSocketBuffer
	{
        #region Delegates/Action
        #endregion

        #region Fields/Properties
        private byte[] f_headByte;
        private byte f_headLength = 6;
        private byte[] f_allReceiveData;
        private int f_currentReceiveLength;
        private int f_allDataLength;
        #endregion

        #region Constructor
        public FBSocketBuffer(byte tmpHeadLength)
        {
            f_headLength = tmpHeadLength;
            f_headByte = new byte[f_headLength];

        }
        #endregion

        #region Unity
        void Awake () 
		{
			
		}

		void Start () 
		{
			
		}
	
		void Update () 
		{
			
		}
		#endregion

		#region Interface
		#endregion
		
		#region Methods
        public void ReceiveByte(byte[] receiveByte,int realLength)
        {
            if (realLength == 0) return;

            if (f_currentReceiveLength < f_headLength)
            {

            }
        }

        private void ReceiveHead(byte[] receiveByte)
        {

        }
		#endregion
	}//Class End
}
