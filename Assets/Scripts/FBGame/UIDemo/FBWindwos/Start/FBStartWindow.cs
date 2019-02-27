// Felix-Bang：FBStartWindow
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

namespace FelixBang
{
	public class FBStartWindow : FBWindow
    {
        #region Fields/Properties
        private GameObject f_startOption;
        private GameObject f_options;
        private FBSelectWindow f_selctView;
        #endregion

        #region Unity
        void Start () 
		{
            RegisterButtonClickEvent("Start_Btn", obj => OnStartBtnClick(obj));
            RegisterButtonClickEvent("Options_Btn", obj => OnOptionsBtnClick(obj));
            RegisterButtonClickEvent("Quit_Btn", obj => OnQuitBtnClick(obj));
        }
        #endregion

        #region Methods
        protected override void InitWindowOnAwake()
        {
            WindowName = FBWindowConst.F_window_start;
        }

        private void OnStartBtnClick(GameObject obj)
        {
            SwitchWindow(FBWindowConst.F_window_startOption);
        }

        private void OnOptionsBtnClick(object obj)
        {
            SwitchWindow(FBWindowConst.F_window_options);
        }

        private void OnQuitBtnClick(object obj)
        {
            SwitchWindow(FBWindowConst.F_window_login);
        }

        //private void SwitchWindow(string nextWindow)
        //{
        //    FBWindowManager.Instance.ShowWindow(nextWindow);
        //    FBWindowManager.Instance.CloseWindow(WindowName);
        //}
        #endregion
    }//Class End
}
