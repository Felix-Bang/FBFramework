// Felix-Bang：FBSelectWindow
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


namespace FelixBang
{
	public class FBSelectWindow : FBWindow 
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
            RegisterButtonClickEvent("Confirm_Button", p =>
            {
                OpenWindow(FBWindowConst.F_window_main);
                OpenWindow(FBWindowConst.F_window_top);
                OpenWindow(FBWindowConst.F_window_inventory);
            });

            RegisterButtonClickEvent("Close_Button", p =>CloseWindow(FBWindowConst.F_window_select));
		}
	
		void Update () 
		{
			
		}
        #endregion

        #region Interface
        #endregion

        #region Methods
        //------------------ override -----------------------
        protected override void InitWindowOnAwake()
        {
            WindowType.F_showModel = FBUIShowModel.HideOther;
        }

        #endregion
    }//Class End
}
