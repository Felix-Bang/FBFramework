// Felix-Bang：FBMainWindow
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
	public class FBMainWindow : FBWindow
    {
		#region Unity

		void Start () 
		{
            RegisterButtonClickEvent("Knapsack_Button", p => FBInventoryManager.Instance.SwitchKnapsackDisplay());
            RegisterButtonClickEvent("Chest_Button", p => FBInventoryManager.Instance.SwitchChestDisplay());
            RegisterButtonClickEvent("Vendor_Button", p => FBInventoryManager.Instance.SwitchVendorDisplay());
            RegisterButtonClickEvent("Intro_Button", p => OpenWindow(FBWindowConst.F_window_intro));
		}

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
