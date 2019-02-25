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
        private FBScrollView f_scrollView;
        private List<FBLevelModel> f_level_list = new List<FBLevelModel>();

        private int f_taskId;
		#endregion

		#region Unity

		void Start () 
		{
            f_scrollView = FBFindUtility.GetChildComponent<FBScrollView>(transform, "Scroll_Panel");

            FBLevelModel level01 = new FBLevelModel
            {
                ID = 0,
                Name = "New York",
                Describe = "Declaration of Independence ratified by the provincial congress of New York in July, 1776 makes the final division of patriots and loyalists.",
                Level = 1,
                IsLock = false,
                SpriteName = "lv_1"
            };

            FBLevelModel level02 = new FBLevelModel
            {
                ID = 1,
                Name = "Beijing",
                Describe = "Beijing is indicated on the map by a red star.",
                Level = 2,
                IsLock = true,
                SpriteName = "lv_2"
            };

            FBLevelModel level03 = new FBLevelModel
            {
                ID = 2,
                Name = "Bangkok",
                Describe = "Bangkok Airways",
                Level = 3,
                IsLock = true,
                SpriteName = "lv_3"
            };

            FBLevelModel level04 = new FBLevelModel
            {
                ID = 3,
                Name = "Bombay",
                Describe = "孟买，印度马哈拉施特拉邦首府，是印度最大的海港和重要交通枢纽，素有印度“西部门户”之称。",
                Level = 4,
                IsLock = true,
                SpriteName = "lv_4"
            };

       

            f_level_list.Add(level01);
            f_level_list.Add(level02);
            f_level_list.Add(level03);
            f_level_list.Add(level04);
       

            f_scrollView.InitListView(f_level_list.Count, OnGetItemByIndex);

            RegisterButtonClickEvent("Close_Btn", obj => OnCloseBtnClick(obj));


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
            //WindowType.F_showModel = FBUIShowModel.HideOther;
            WindowName = FBWindowConst.F_window_select;
        }

        private void OnCloseBtnClick(object obj)
        {
            //FBWindowManager.Instance.CloseWindow(FBWindowConst.F_window_select);
            SwitchWindow(FBWindowConst.F_window_start);
        }

        private FBScrollViewItem OnGetItemByIndex(FBScrollView view, int index)
        {
            if (index < 0 || index > f_level_list.Count)
                return null;

            FBLevelModel model = OnGetLevelByIndex(index);
            if (model == null)
                return null;

            FBScrollViewItem item = f_scrollView.NewListViewItem("Level_Pfb");

            FBUILevel level = item.GetComponent<FBUILevel>();
            if (item.IsInitHandlerCalled == false)
            {
                item.IsInitHandlerCalled = true;
                level.Init();
            }

            level.SetLevelData(model, index);
            return item;
        }

        private FBLevelModel OnGetLevelByIndex(int index)
        {
            if (index < 0 || index > f_level_list.Count)
                return null;

            return f_level_list[index];
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
