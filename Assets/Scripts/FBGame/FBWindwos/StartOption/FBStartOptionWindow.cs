// Felix-Bang：FBStartOption
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
	public class FBStartOptionWindow : FBWindow 
	{
        #region Unity
		void Start () 
		{
            RegisterButtonClickEvent("New_Btn", obj => OnNewBtnClick(obj));
            RegisterButtonClickEvent("Continue_Btn", obj => OnContinueBtnClick(obj));
            RegisterButtonClickEvent("Back_Btn", obj => OnBackBtnClick(obj));
        }
        #endregion

        #region Methods
        protected override void InitWindowOnAwake()
        {
            WindowName = FBWindowConst.F_window_startOption;
        }

        private void OnNewBtnClick(object obj)
        {
            SwitchWindow(FBWindowConst.F_window_select);
        }

        private void OnContinueBtnClick(object obj)
        {

        }

        private void OnBackBtnClick(object obj)
        {
          
            SwitchWindow(FBWindowConst.F_window_start);
        }


        #endregion
    }//Class End
}
