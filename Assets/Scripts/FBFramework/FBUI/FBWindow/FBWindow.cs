//  Felix-Bang：FBWindow
//　　 へ　　　　　／|
//　　/＼7　　　 ∠＿/
//　 /　│　　 ／　／
//　 │　Z ＿,＜　／　　 /`ヽ
//　│　　　　　ヽ　　 /　　〉
//　 Y　　　　　`　 /　　/
//　ｲ●　､　●　　⊂⊃〈　　/
//　()　 へ　　　　|　＼〈
//　　>ｰ ､_　 ィ　 │ ／／
//　 / へ　　 /　ﾉ＜| ＼＼
//　 ヽ_ﾉ　　(_／　 │／／
//　　7　　　　　　|／
//　　＞―r￣￣`ｰ―＿
// Describe：The base class for UIForms。
// CreateTime：2018/12/20

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FelixBang
{
    public abstract class FBWindow : MonoBehaviour
    {
        #region Fields/Properties
        /// <summary> 窗体类型 </summary>
        private FBWindowType f_windowType = new FBWindowType();

        public FBWindowType WindowType
        {
            get { return f_windowType; }
            set { f_windowType = value; }
        }

        public bool F_hideOnStart = true;
        public bool F_resetPositionOnStart = false;
        
        #endregion

        #region Unity
        void Awake()
        {
            InitWindowOnAwake();
        }

        /// <summary>
        /// Unity Awake
        /// </summary>
        protected abstract void InitWindowOnAwake();
        #endregion Unity


        #region Method

        /// <summary> 显示 </summary>
        public virtual void Display()
        {
            gameObject.SetActive(true);
            if (f_windowType.F_existType == FBUIExistType.Popup)
                FBMaskManager.Instance.FBShowMask(gameObject, f_windowType.F_lucency);
        }

        /// <summary> 隐藏 </summary>
        public virtual void Hide()
        {
            gameObject.SetActive(false);
            if (f_windowType.F_existType == FBUIExistType.Popup)
                FBMaskManager.Instance.FBHideMask();
        }

        /// <summary> 重新显示 </summary>
        public virtual void Redisplay()
        {
            gameObject.SetActive(true);
            if (f_windowType.F_existType == FBUIExistType.Popup)
                FBMaskManager.Instance.FBShowMask(gameObject, f_windowType.F_lucency);
        }

        /// <summary> 冻结 </summary>
        public virtual void Freeze()
        {
            gameObject.SetActive(true);
        }

        protected void RegisterButtonClickEvent(string buttonName, EventListener.FBVoidDelegate handler)
        {
            GameObject btn = FBFindUtility.FindChildByName(transform, buttonName);
            if (btn != null)
                EventListener.Get(btn).OnClickDel = handler;
        }

        protected void OpenWindow(string windowName)
        {
            FBWindowManager.Instance.ShowWindow(windowName);
        }

        protected void CloseWindow(string windowName)
        {
            FBWindowManager.Instance.CloseWindow(windowName);
        }

        protected void SendMessage(string type,string messageName,object message)
        {
            FBMessageKVModel kv = new FBMessageKVModel(messageName, message);
            FBMessageCenter.SendMessage(type, kv);
        }

        protected void ReceiveMessage(string type, FBMessageCenter.MessageDeliveryDel handler)
        {
            FBMessageCenter.RegisterMessage(type, handler);
        }

        #endregion
    }
}
