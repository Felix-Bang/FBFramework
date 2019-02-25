// Felix-Bang：OptionsWindow
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
	public class FBOptionsWindow : FBWindow 
	{
        #region Unity
		void Start () 
		{
            RegisterButtonClickEvent("Game_Btn", obj => OnGameBtnClick(obj));
            RegisterButtonClickEvent("Control_Btn", obj => OnControlBtnClick(obj));
            RegisterButtonClickEvent("Gfx_Btn", obj => OnGfxBtnClick(obj));
            RegisterButtonClickEvent("Back_Btn", obj => OnBackBtnClick(obj));
        }
        #endregion

        #region Methods
        protected override void InitWindowOnAwake()
        {
            WindowName = FBWindowConst.F_window_options;
        }

        private void OnGameBtnClick(object obj)
        {

        }

        private void OnControlBtnClick(object obj)
        {

        }

        private void OnGfxBtnClick(object obj)
        {

        }

        private void OnBackBtnClick(object obj)
        {
            SwitchWindow(FBWindowConst.F_window_start);
        }
        #endregion
    }//Class End
}
