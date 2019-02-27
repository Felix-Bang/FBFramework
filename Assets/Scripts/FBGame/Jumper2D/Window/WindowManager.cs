// Felix-Bang：WindowManager
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

namespace FelixBang.Jumper
{
	public class WindowManager : FBSingleton<WindowManager> 
	{
        #region Delegates/Action
        #endregion

        #region Fields/Properties
        private Dictionary<WindowID, BaseWindow> f_window_dic = new Dictionary<WindowID, BaseWindow>();
        #endregion

        #region Methods
        public void InitWindowDic(Transform trans)
        {
            BaseWindow[] windows = trans.GetComponentsInChildren<BaseWindow>();
            if (windows.Length > 0)
            {
                foreach (BaseWindow window in windows)
                {
                    window.OnHide();
                    f_window_dic.Add(window.ID, window);
                }
            }
        }

        public void ShowWindow(WindowID id)
        {
            if (f_window_dic.ContainsKey(id))
                f_window_dic[id].OnShow();

        }

        public void HideWindow(WindowID id)
        {
            if (f_window_dic.ContainsKey(id))
                f_window_dic[id].OnHide();
        }
		#endregion
	}//Class End
}
