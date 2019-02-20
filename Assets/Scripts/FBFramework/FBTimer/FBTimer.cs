// Felix-Bang：FBTimer
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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FelixBang
{
    public class FBTimer
    {
        #region Fields/Properties
        private static readonly string f_obj = "lock";
        private int f_id;
        private DateTime f_startDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
        private Action<string> f_log_Action;

        private double f_nowTime;
        private List<FBTimeTaskModel> f_timeTask_list = new List<FBTimeTaskModel>();
        private List<FBTimeTaskModel> f_tmpTimeTask_list = new List<FBTimeTaskModel>();

        private int f_frameCount;
        private List<FBFrameTaskModel> f_frameTask_list = new List<FBFrameTaskModel>();
        private List<FBFrameTaskModel> f_tmpframeTask_list = new List<FBFrameTaskModel>();

        private List<int> f_id_list = new List<int>();
        private List<int> f_recycleId_list = new List<int>();
        #endregion

        #region Constructor
        public FBTimer()
        {
            f_id = 0;
            f_log_Action = null;
            f_timeTask_list.Clear();
            f_tmpTimeTask_list.Clear();
            f_frameCount = 0;
            f_frameTask_list.Clear();
            f_tmpframeTask_list.Clear();
            f_id_list.Clear();
            f_recycleId_list.Clear();
        }
        #endregion

        public void SetLogAction(Action<string> logAction)
        {
            f_log_Action = logAction;
        }


        public void Update()
        {
            ExecuteTimeTasks();
            ExecuteFrameTasks();

            if (f_recycleId_list.Count > 0)
                RecyleId();
        }
      

        #region Time Methods
        /// <summary> 执行TimeTask </summary>
        private void ExecuteTimeTasks()
        {
            //将缓存的任务添加到任务列表
            if (f_tmpTimeTask_list.Count > 0)
            {
                for (int i = 0; i < f_tmpTimeTask_list.Count; i++)
                    f_timeTask_list.Add(f_tmpTimeTask_list[i]);

                f_tmpTimeTask_list.Clear();
            }

            for (int i = 0; i < f_timeTask_list.Count; i++)
            {
                FBTimeTaskModel task = f_timeTask_list[i];

                f_nowTime = GetUTCMS();

                if (f_nowTime.CompareTo(task.DestTime) < 0)
                    continue;
                else
                {
                    try
                    {
                        if (task.Callback != null)
                            task.Callback();
                    }
                    catch (Exception e)
                    {
                        FBDebugLog(e.Message);
                    }

                    //移除已完成任务
                    if (task.Repeat == 1)
                    {
                        f_timeTask_list.RemoveAt(i);
                        i--;

                        f_recycleId_list.Add(task.ID);
                    }
                    else
                    {
                        if (task.Repeat != 0)
                            task.Repeat -= 1;

                        task.DestTime += task.DelayTime;
                    }
                }
            }
        }

        /// <summary>
        /// 添加TimeTask
        /// </summary>
        /// <param name="callback">任务</param>
        /// <param name="delay">延迟时间</param>
        /// <param name="repeat">重复次数</param>
        /// <param name="unit">时间单位</param>
        /// <returns></returns>
        public int AddTimeTask(Action callback, double delay, uint repeat = 1, FBTimeUnit unit = FBTimeUnit.Millisecond)
        {
            f_nowTime = GetUTCMS();
            FBTimeTaskModel task = new FBTimeTaskModel(GetNewId(), callback, f_nowTime+delay, repeat, delay);
            f_tmpTimeTask_list.Add(task);
            f_id_list.Add(f_id);
            return f_id;
        }

        /// <summary>
        /// 移除TimeTask
        /// </summary>
        /// <param name="id">Task ID</param>
        /// <returns></returns>
        public bool RemoveTimeTask(int id)
        {
            bool exist = false;

            for (int i = 0, iMax = f_timeTask_list.Count; i < iMax; i++)
            {
                if (f_timeTask_list[i].ID == id)
                {
                    f_timeTask_list.RemoveAt(i);
                    exist = true;
                    break;
                }
            }

            if (!exist)
            {
                for (int i = 0, iMax = f_tmpTimeTask_list.Count; i < iMax; i++)
                {
                    if (f_tmpTimeTask_list[i].ID == id)
                    {
                        f_tmpTimeTask_list.RemoveAt(i);
                        exist = true;
                        break;
                    }
                }
            }

            if (exist)
            {
                for (int j = 0, jMax = f_id_list.Count; j < jMax; j++)
                {
                    if (f_id_list[j] == id)
                    {
                        f_id_list.RemoveAt(j);
                        break;
                    }
                }
            }

            return exist;
        }

        /// <summary>
        /// 替换任务
        /// </summary>
        /// <param name="id">要替换的Task的ID</param>
        /// <param name="callback">新任务</param>
        /// <param name="delay">延迟时间</param>
        /// <param name="repeat">重复次数</param>
        /// <param name="unit">时间单位</param>
        /// <returns></returns>
        public bool ReplaceTimeTask(int id, Action callback, float delay, uint repeat = 1, FBTimeUnit unit = FBTimeUnit.Millisecond)
        {
            f_nowTime = GetUTCMS();
            FBTimeTaskModel task = new FBTimeTaskModel(id, callback, f_nowTime + delay, repeat, delay);

            bool isReplace = false;
            for (int i = 0, iMax = f_timeTask_list.Count; i < iMax; i++)
            {
                if (f_timeTask_list[i].ID == id)
                {
                    f_timeTask_list[i] = task;
                    isReplace = true;
                    break;
                }
            }

            if (!isReplace)
            {
                for (int i = 0, iMax = f_tmpTimeTask_list.Count; i < iMax; i++)
                {
                    if (f_tmpTimeTask_list[i].ID == id)
                    {
                        f_tmpTimeTask_list[i] = task;
                        isReplace = true;
                        break;
                    }
                }
            }

            return isReplace;
        }

        #endregion

        #region Frame Methods
        /// <summary> 执行TimeTask </summary>
        private void ExecuteFrameTasks()
        {
            //将缓存的任务添加到任务列表
            if (f_tmpframeTask_list.Count > 0)
            {
                for (int i = 0; i < f_tmpframeTask_list.Count; i++)
                    f_frameTask_list.Add(f_tmpframeTask_list[i]);

                f_tmpframeTask_list.Clear();
            }

            f_frameCount += 1;
            for (int i = 0; i < f_frameTask_list.Count; i++)
            {
                FBFrameTaskModel task = f_frameTask_list[i];

                if (f_frameCount < task.DestFrame)
                    continue;
                else
                {
                    try
                    {
                        if (task.Callback != null)
                            task.Callback();
                    }
                    catch (Exception e)
                    {
                        FBDebugLog(e.Message);
                    }

                    //移除已完成任务
                    if (task.Repeat == 1)
                    {
                        f_frameTask_list.RemoveAt(i);
                        i--;

                        f_recycleId_list.Add(task.ID);
                    }
                    else
                    {
                        if (task.Repeat != 0)
                            task.Repeat -= 1;

                        task.DestFrame += task.DelayFrame;
                    }
                }
            }
        }

        /// <summary>
        /// 添加FrameTask
        /// </summary>
        /// <param name="callback">任务</param>
        /// <param name="delay">延迟时间</param>
        /// <param name="repeat">重复次数</param>
        /// <param name="unit">时间单位</param>
        /// <returns></returns>
        public int AddFrameTask(Action callback, int delay, uint repeat = 1)
        {
            int destFrame = f_frameCount + delay;
            FBFrameTaskModel task = new FBFrameTaskModel(GetNewId(), callback, destFrame, repeat, delay);
            f_tmpframeTask_list.Add(task);
            f_id_list.Add(f_id);
            return f_id;
        }

        /// <summary>
        /// 移除TimeTask
        /// </summary>
        /// <param name="id">Task ID</param>
        /// <returns></returns>
        public bool RemoveFrameTask(int id)
        {
            bool exist = false;

            for (int i = 0, iMax = f_frameTask_list.Count; i < iMax; i++)
            {
                if (f_frameTask_list[i].ID == id)
                {
                    f_frameTask_list.RemoveAt(i);
                    exist = true;
                    break;
                }
            }

            if (!exist)
            {
                for (int i = 0, iMax = f_tmpframeTask_list.Count; i < iMax; i++)
                {
                    if (f_tmpframeTask_list[i].ID == id)
                    {
                        f_tmpframeTask_list.RemoveAt(i);
                        exist = true;
                        break;
                    }
                }
            }

            if (exist)
            {
                for (int j = 0, jMax = f_id_list.Count; j < jMax; j++)
                {
                    if (f_id_list[j] == id)
                    {
                        f_id_list.RemoveAt(j);
                        break;
                    }
                }
            }

            return exist;
        }

        /// <summary>
        /// 替换任务
        /// </summary>
        /// <param name="id">要替换的Task的ID</param>
        /// <param name="callback">新任务</param>
        /// <param name="delay">延迟时间</param>
        /// <param name="repeat">重复次数</param>
        /// <param name="unit">时间单位</param>
        /// <returns></returns>
        public bool ReplaceFrameTask(int id, Action callback, int delay, uint repeat = 1)
        {

            int destFrame = f_frameCount + delay;
            FBFrameTaskModel task = new FBFrameTaskModel(id, callback, destFrame, repeat, delay);

            bool isReplace = false;
            for (int i = 0, iMax = f_frameTask_list.Count; i < iMax; i++)
            {
                if (f_frameTask_list[i].ID == id)
                {
                    f_frameTask_list[i] = task;
                    isReplace = true;
                    break;
                }
            }

            if (!isReplace)
            {
                for (int i = 0, iMax = f_tmpframeTask_list.Count; i < iMax; i++)
                {
                    if (f_tmpframeTask_list[i].ID == id)
                    {
                        f_tmpframeTask_list[i] = task;
                        isReplace = true;
                        break;
                    }
                }
            }

            return isReplace;
        }

        #endregion

        #region Methods
      

        private void FBDebugLog(string info)
        {
            if (f_log_Action != null)
                f_log_Action(info);
        }

        private int GetNewId()
        {
            lock (f_obj)
            {
                f_id += 1;

                while (true)
                {
                    if (f_id == int.MaxValue)
                        f_id = 0;

                    bool isUsed = false;
                    for (int i = 0; i < f_id_list.Count; i++)
                    {
                        if (f_id == f_id_list[i])
                        {
                            isUsed = true;
                            break;
                        }
                    }

                    if (!isUsed)
                        break;
                    else
                        f_id += 1;
                }
            }

            return f_id;
        }

        private void RecyleId()
        {
            for (int i = 0, iMax = f_recycleId_list.Count; i < iMax; i++)
            {
                int id = f_recycleId_list[i];
                for (int j = 0, jMax = f_id_list.Count; j < jMax; j++)
                {
                    if (f_id_list[j] == id)
                    {
                        f_id_list.RemoveAt(j);
                        break;
                    }
                }
            }

            f_recycleId_list.Clear();
        }

        private double GetUTCMS()
        {
            //                         世界时间
            TimeSpan timeSpan = DateTime.UtcNow - f_startDateTime;
            return timeSpan.TotalMilliseconds;
        }
        #endregion
    }//Class End
}
