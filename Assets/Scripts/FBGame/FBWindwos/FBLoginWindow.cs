// Felix-Bang：FBLoginWindow
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
// CreateTime：2019/1/21

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace FelixBang
{
	public class FBLoginWindow : FBWindow
    {

        #region Delegates/Action
        #endregion

        #region Fields/Properties
        
        #endregion

        #region Constructor
        #endregion

        #region Unity

        void Start () 
		{
            RegisterButtonClickEvent("Login_Button", p => OpenWindow(FBWindowConst.F_window_select));
        }
        #endregion

        #region Interface
        #endregion

        #region Methods
        protected override void InitWindowOnAwake()
        {
            
        }

        
        #endregion
    }//Class End
}
