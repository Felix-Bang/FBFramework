// Felix-Bang：BaseWindow
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
using UnityEngine.Events;
using UnityEngine.UI;

namespace FelixBang.Jumper
{
	public class BaseWindow : MonoBehaviour 
	{
        #region Delegates/Action
        #endregion

        #region Fields/Properties
        public WindowID ID = WindowID.Invalid;
        private CanvasGroup f_canvasGroup;
		#endregion

		#region Unity
		void Awake () 
		{
            f_canvasGroup = GetComponent<CanvasGroup>();
            InitOnAwake();

        }
        #endregion

        #region Interface
        #endregion

        #region Methods
        public virtual void InitOnAwake(){}

        protected Button RegistButtonClick(string btnName, UnityAction callback)
        {
            Button btn = FBFindUtility.GetChildComponent<Button>(transform, btnName);
            btn.onClick.AddListener(callback);
            return btn;
        }

        public void OnShow()
        {
            f_canvasGroup.alpha = 1;
            f_canvasGroup.blocksRaycasts = true;
            f_canvasGroup.interactable = true;
            OnShowHandle();
        }

        public void OnHide()
        {
            f_canvasGroup.alpha = 0;
            f_canvasGroup.blocksRaycasts = false;
            f_canvasGroup.interactable = false;
            OnHideHandle();
        }

        public virtual void OnShowHandle(){ }

        public virtual void OnHideHandle() { }

        
        #endregion
    }//Class End
}
