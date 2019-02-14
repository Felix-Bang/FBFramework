//  Felix-Bang：FBWindowManager
//　　 へ　　　　　／|
//　　/＼7　　　 ∠＿/
//　 /　│　　 ／　／
//　│　Z ＿,＜　／　　 /`ヽ
//　│　　　　　ヽ　　 /　　〉
//　 Y　　　　　`　 /　　/
//　ｲ●　､　●　　⊂⊃〈　　/
//　()　 へ　　　　|　＼〈
//　　>ｰ ､_　 ィ　 │ ／／
//　 / へ　　 /　ﾉ＜| ＼＼
//　 ヽ_ﾉ　　(_／　 │／／
//　　7　　　　　　　|／
//　　＞―r￣￣`ｰ―＿
// Describe：Realize most function about UI.
// CreateTime：2018/12/20

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FelixBang;

namespace FelixBang
{
	public class FBWindowManager : FBSingleton<FBWindowManager>
	{
        #region Delegates/Action
        #endregion

        #region Fields/Properties
        private Dictionary<string, string> f_windowPaths_dic = new Dictionary<string, string>();
        private Dictionary<string, FBWindow> f_allWinodws_dic = new Dictionary<string, FBWindow>();
        private Dictionary<string, FBWindow> f_currentShowWindows_dic = new Dictionary<string, FBWindow>();
        private Stack<FBWindow> f_currentShowWindows_stack = new Stack<FBWindow>();
        
        //画布
        private Transform f_canvasTrans;
        //全屏节点
        private Transform f_normalTrans;
        //固定显示
        private Transform f_fixedTrans;
        //弹出节点
        private Transform f_popupTrans;

        public Transform CanvasTrans
        {
            get { return f_canvasTrans; }
        }

        public Camera UICamera
        {
            get { return f_canvasTrans.GetComponentInChildren<Camera>(); }
        }

        #endregion

        #region Unity

        private void Awake()
        {
            InitWindowNodes();
            InitWindowPathDate();
        }

        void Start()
        {
            if (f_canvasTrans != null)
            {
                FBMaskManager maskManager = FBMaskManager.Instance;
                maskManager.transform.SetParent(transform.parent);
            }
        }
        #endregion

        #region Method

        /// <summary>
        /// 显示（打开）窗口
        /// </summary>
        /// <param name="windowName"></param>
        public void ShowWindow(string windowName)
        {
            if (string.IsNullOrEmpty(windowName)) return;

            FBWindow baseWindow=null;
            f_allWinodws_dic.TryGetValue(windowName, out baseWindow);
            if (baseWindow == null)
                baseWindow = LoadWindowToAllDic(windowName);

            if (baseWindow == null) return;

            if (baseWindow.WindowType.F_isClearStackData)
                ClearStackArray();

            switch (baseWindow.WindowType.F_showModel)
            {
                case FBUIShowModel.Normal:
                    ShowNormalWidnow(windowName);
                    break;
                case FBUIShowModel.ReverseSwitch:
                    ShowReverseSwitchWindow(windowName);
                    break;
                case FBUIShowModel.HideOther:
                    ShowHideOtherWindow(windowName);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 关闭（返回）窗口
        /// </summary>
        /// <param name="windowName"></param>
        public void CloseWindow(string windowName)
        {
            if (string.IsNullOrEmpty(windowName)) return;

            FBWindow window;
            f_allWinodws_dic.TryGetValue(windowName, out window);
            if (window == null) return;
            switch(window.WindowType.F_showModel) 
            {
                case FBUIShowModel.Normal:
                    HideNormalWindow(windowName);
                    break;
                case FBUIShowModel.ReverseSwitch:
                    HideReverseSwitchWindow();
                    break;
                case FBUIShowModel.HideOther:
                    HideHideOtherWindow(windowName);
                    break;
                default:
                    break;
            }     
        }

        
        /// <summary> 初始化窗口节点 </summary>
        private void InitWindowNodes()
        {
            GameObject canvasPrefab= Resources.Load<GameObject>(FBWindowDefine.F_path_canvas);
            GameObject canvas = GameObject.Instantiate<GameObject>(canvasPrefab);

            f_canvasTrans = GameObject.FindGameObjectWithTag(FBWindowDefine.F_tag_canvas).transform;
            f_normalTrans = FBFindUtility.FindChildByName(f_canvasTrans, FBWindowDefine.F_node_normal).transform;
            f_fixedTrans = FBFindUtility.FindChildByName(f_canvasTrans, FBWindowDefine.F_node_fixed).transform;
            f_popupTrans = FBFindUtility.FindChildByName(f_canvasTrans, FBWindowDefine.F_node_popup).transform;
        }

        private void InitWindowPathDate()
        {
            IFBConfig config = new FBJsonConfigController(FBWindowDefine.F_path_windows);

            if (config != null)
                f_windowPaths_dic = config.ConfigFiles_Dic;
        }

        /// <summary>
        /// 加载Window
        /// </summary>
        /// <param name="windowName"></param>
        /// <returns></returns>
        private FBWindow LoadWindowToAllDic(string windowName)
        {
            string windowPath = string.Empty;
            GameObject windowPrefab = null;
            FBWindow baseWindow = null;

            f_windowPaths_dic.TryGetValue(windowName, out windowPath);
            if (string.IsNullOrEmpty(windowPath))
            {
                FBDebug.LogError(string.Format("The path of {0} prefab is invalid!",windowName));
                return null;
            }

            GameObject prefab = Resources.Load<GameObject>(windowPath);
            windowPrefab = GameObject.Instantiate<GameObject>(prefab);

            if (f_canvasTrans != null && windowPrefab != null)
            {
                baseWindow = windowPrefab.GetComponent<FBWindow>();

                if (baseWindow == null)
                {
                    FBDebug.LogError("The Component on " + windowName + " is Missing!");
                    return null;
                }

                switch (baseWindow.WindowType.F_existType)
                {
                    case FBUIExistType.Normal:
                        windowPrefab.transform.SetParent(f_normalTrans, false);
                        break;
                    case FBUIExistType.Fixed:
                        windowPrefab.transform.SetParent(f_fixedTrans, false);
                        break;
                    case FBUIExistType.Popup:
                        windowPrefab.transform.SetParent(f_popupTrans, false);
                        break;
                }

                windowPrefab.SetActive(false);
                f_allWinodws_dic.Add(windowName, baseWindow);
                return baseWindow;
            }
            else
            {
                FBDebug.LogError("f_canvasTrans is not init or the windowPrefab is null");
                return null;
            }
        }

        /// <summary>
        /// 从当前显示列表中加载界面
        /// </summary>
        /// <param name="windowName"></param>
        private void ShowNormalWidnow(string windowName)
        {
            FBWindow window = null;
            FBWindow windowFromAll = null;

            f_currentShowWindows_dic.TryGetValue(windowName, out window);
            if (window != null) return;

            f_allWinodws_dic.TryGetValue(windowName,out windowFromAll);
            if (windowFromAll != null)
            {
                f_currentShowWindows_dic.Add(windowName, windowFromAll);
                windowFromAll.Display();
            }
        }

        private void ShowReverseSwitchWindow(string windowName)
        {
            FBWindow window = null;
            //判断栈中是否有其他窗体，有则冻结处理
            if (f_currentShowWindows_stack.Count > 0)
            {
                FBWindow topWindow = f_currentShowWindows_stack.Peek();
                topWindow.Freeze();
            }
            //判断“f_allWinodws_dic”是否有目标窗口，有则处理
            f_allWinodws_dic.TryGetValue(windowName, out window);
            if (window != null)
            {
                window.Display();
                //目标窗口入栈
                f_currentShowWindows_stack.Push(window);
            }
            else
                FBDebug.LogError(windowName+ " is null");
        }

        /// <summary>
        /// (“隐藏其他”属性)打开窗体，且隐藏其他窗体
        /// </summary>
        /// <param name="windowName">打开的指定窗体名称</param>
        private void ShowHideOtherWindow(string windowName)
        {
            FBWindow targrtWindow;                         
            FBWindow targrtWindowFromALL;  
            
            if (string.IsNullOrEmpty(windowName)) return;

            f_currentShowWindows_dic.TryGetValue(windowName, out targrtWindow);
            if (targrtWindow != null) return;

            //把“正在显示集合”与“栈集合”中所有窗体都隐藏。
            foreach (FBWindow window in f_currentShowWindows_dic.Values)
                window.Hide();

            foreach (FBWindow window in f_currentShowWindows_stack)
                window.Hide();

            //把当前窗体加入到“正在显示窗体”集合中，且做显示处理。
            f_allWinodws_dic.TryGetValue(windowName, out targrtWindowFromALL);
            if (targrtWindowFromALL != null)
            {
                f_currentShowWindows_dic.Add(windowName, targrtWindowFromALL);
                //窗体显示
                targrtWindowFromALL.Display();
            }
        }


        private void HideNormalWindow(string windowName)
        {
            FBWindow window = null;
            f_currentShowWindows_dic.TryGetValue(windowName, out window);
            if (window == null) return;
            window.Hide();
            f_currentShowWindows_dic.Remove(windowName);
        }

        //（“反向切换”属性）窗体的出栈逻辑
        private void HideReverseSwitchWindow()
        {
            if (f_currentShowWindows_stack.Count == 1)
            {
                FBWindow topWindow = f_currentShowWindows_stack.Pop();
                //做隐藏处理
                topWindow.Hide();
            }
            else if (f_currentShowWindows_stack.Count >= 2)
            {
                //出栈处理
                FBWindow topWindow = f_currentShowWindows_stack.Pop();
                //做隐藏处理
                topWindow.Hide();
                //出栈后，下一个窗体做“重新显示”处理。
                FBWindow nextWindow = f_currentShowWindows_stack.Peek();
                nextWindow.Redisplay();
            }
        }

        /// <summary>
        /// (“隐藏其他”属性)关闭窗体，且显示其他窗体
        /// </summary>
        /// <param name="windowName">打开的指定窗体名称</param>
        private void HideHideOtherWindow(string windowName)
        {
            FBWindow targetWindow;            

            if (string.IsNullOrEmpty(windowName)) return;

            f_currentShowWindows_dic.TryGetValue(windowName, out targetWindow);
            if (targetWindow == null) return;

            //当前窗体隐藏状态，且“正在显示”集合中，移除本窗体
            targetWindow.Hide();
            f_currentShowWindows_dic.Remove(windowName);

            //把“正在显示集合”与“栈集合”中所有窗体都定义重新显示状态。
            foreach (FBWindow window in f_currentShowWindows_dic.Values)
                window.Redisplay();

            foreach (FBWindow window in f_currentShowWindows_stack)
                window.Redisplay();
        }

        /// <summary>
        /// 是否清空“栈集合”中得数据
        /// </summary>
        /// <returns></returns>
        private bool ClearStackArray()
        {
            if (f_currentShowWindows_stack != null && f_currentShowWindows_stack.Count >= 1)
            {
                //清空栈集合
                f_currentShowWindows_stack.Clear();
                return true;
            }

            return false;
        }

        #endregion
    }
}
