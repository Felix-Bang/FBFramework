// Felix-Bang：FBMoreWindow
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
using UnityEngine.UI;


namespace FelixBang
{
	public class FBMoreWindow : FBWindow
	{
        public Text F_contentText;

		#region Unity

        void Start () 
		{
            RegisterButtonClickEvent("Close_Button", p => CloseWindow("MoreWindow"));
		}
        #endregion

        #region Methods

        //------------------ override -----------------------
        protected override void InitWindowOnAwake()
        {
            SetWindowType();
            ReceiveMessages();
        }

        //------------------ private -----------------------
        private void SetWindowType()
        {
            WindowType.F_existType = FBUIExistType.Popup;
            WindowType.F_lucency = FBUILucency.LowLucency;
            WindowType.F_showModel = FBUIShowModel.ReverseSwitch;
        }

        private void ReceiveMessages()
        {
            ReceiveMessage("More", p =>
            {
                if (p.Key.Equals("UI") || p.Key.Equals("Framework") || p.Key.Equals("DesignPattern"))
                {
                    F_contentText.text = p.Value.ToString();
                }
            });
        }
        #endregion
    }//Class End
}
