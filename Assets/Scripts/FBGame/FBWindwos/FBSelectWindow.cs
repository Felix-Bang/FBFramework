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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FelixBang
{
	public class FBSelectWindow : FBWindow 
	{
        #region Fields/Properties
        private int f_taskId;
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

            RegisterButtonClickEvent("AddTask_Button", p => AddTask());
            RegisterButtonClickEvent("RemoveTask_Button", p => RemoveTask(f_taskId));
            RegisterButtonClickEvent("ReplaceTask_Button", p => ReplaceTask(f_taskId));

            RegisterButtonClickEvent("Close_Button", p => CloseWindow(FBWindowConst.F_window_select));
		}

        void Update () 
		{
			
		}
        #endregion



        #region Methods
        //------------------ override -----------------------
        protected override void InitWindowOnAwake()
        {
            WindowType.F_showModel = FBUIShowModel.HideOther;
        }

        private void AddTask()
        {
            f_taskId = FBTimerManager.Instance.AddTimeTask(() => Debug.Log("TimerTest A"), 500, 0);

            //f_taskId = FBTimerManager.Instance.AddFrameTask(() => Debug.Log("FrameTest A"), 50, 0);
        }

        private void RemoveTask(int id)
        {
            bool isSuccess = FBTimerManager.Instance.RemoveTimeTask(id);
            //bool isSuccess = FBTimerManager.Instance.RemoveFrameTask(id);
            if (isSuccess)
                FBDebug.Log("Remove Task Success!");
        }

        private void ReplaceTask(int id)
        {
            bool isSuccess = FBTimerManager.Instance.ReplaceTimeTask(id, () => Debug.Log("TimerReplaceTest B"), 2000, 3);
            //bool isSuccess = FBTimerManager.Instance.ReplaceFrameTask(id, () => Debug.Log("FrameReplaceTest B"), 100, 3);
            if (isSuccess)
                FBDebug.Log("Replace Task Success!");
        }

        #endregion
    }//Class End
}
