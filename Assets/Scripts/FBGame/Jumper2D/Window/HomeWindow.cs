// Felix-Bang：HomeWindow
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
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace FelixBang.Jumper
{
	public class HomeWindow : BaseWindow 
	{
		#region Unity
		void Start () 
		{
            RegistButtonClick("Start_Btn", OnStartBtnClick);
            RegistButtonClick("Shop_Btn", OnShopBtnClick);
            RegistButtonClick("Rank_Btn", OnRankBtnClick);
            RegistButtonClick("Sound_Btn", OnSoundBtnClick);
        }
        #endregion

        #region Methods
        public override void InitOnAwake()
        {
            base.InitOnAwake();
            ID = WindowID.Home;
        }


        private void OnStartBtnClick()
        {
            WindowManager.Instance.ShowWindow(WindowID.Game);
            WindowManager.Instance.HideWindow(ID);
        }

        private void OnShopBtnClick()
        {
            Debug.Log("Shop");
        }

        private void OnRankBtnClick()
        {
            Debug.Log("Rank");
        }

        private void OnSoundBtnClick()
        {
            Debug.Log("Sound");
        }
        #endregion
    }//Class End
}
