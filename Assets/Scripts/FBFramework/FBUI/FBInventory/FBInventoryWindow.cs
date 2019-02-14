// Felix-Bang：FBInventoryWindow
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
	public class FBInventoryWindow : FBWindow 
	{
		#region Unity
	
	    protected virtual void Start () 
		{
            FBInventoryManager.Instance.InitInventoryUI(transform);
        }
        #endregion

        #region Methods

        protected override void InitWindowOnAwake()
        {
            WindowType.F_existType = FBUIExistType.Popup;
            WindowType.F_lucency = FBUILucency.Penetrate;
        }
        #endregion
    }//Class End
}
