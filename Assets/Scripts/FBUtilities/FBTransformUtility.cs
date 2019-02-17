// Felix-Bang：FBTransformUtility
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
	public class FBTransformUtility
	{
		#region Delegates/Action
		#endregion

		#region Fields/Properties
		#endregion

		#region Constructor
		#endregion

		#region Unity
		void Awake () 
		{
			
		}

		void Start () 
		{
			
		}
	
		void Update () 
		{
			
		}
        #endregion

        #region Interface
        #endregion

        #region Methods
        public static void ResetTRS(Transform trans)
        {
            trans.localPosition = Vector3.zero;
            trans.localRotation = Quaternion.identity;
            trans.localScale = Vector3.one;
        }

        public static void ResetRectTRS(Transform trans)
        {
            ResetTRS(trans);

            RectTransform rectTrans = trans.GetComponent<RectTransform>();
            if (rectTrans != null)
            {
                rectTrans.anchoredPosition = Vector2.zero;
            }
        }
		#endregion
	}//Class End
}
