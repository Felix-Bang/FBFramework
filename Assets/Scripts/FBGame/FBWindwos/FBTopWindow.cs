// Felix-Bang：FBTopWindow
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
	public class FBTopWindow : FBWindow
    {


		#region Unity


		void Start () 
		{
			
		}
	
		void Update () 
		{
			
		}
        #endregion


        #region Methods
        //------------------ override -----------------------
        protected override void InitWindowOnAwake()
        {
            WindowType.F_existType = FBUIExistType.Fixed;
        }

        #endregion
    }//Class End
}
