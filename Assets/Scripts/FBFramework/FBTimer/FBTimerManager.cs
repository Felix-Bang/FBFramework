// Felix-Bang：FBTimerManager
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
// Describe：定时系统管理器（1、支持时间定时，帧定时；2、定时任务可取消、可循环、可替换；3、使用简单，调用方便）
// CreateTime：2019/02/09

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FelixBang
{
	public class FBTimerManager : FBSingleton<FBTimerManager> 
	{
        #region Fields/Properties
        private FBTimer f_timer;
        #endregion

        #region Unity
        void Start()
        {
            f_timer = new FBTimer();
            f_timer.SetLogAction(info => Debug.Log(info));
        }

        void Update()
        {
            f_timer.Update();
        }
        #endregion

        #region Time Methods

        /// <summary>
        /// 添加TimeTask
        /// </summary>
        /// <param name="callback">任务</param>
        /// <param name="delay">延迟时间</param>
        /// <param name="repeat">重复次数</param>
        /// <param name="unit">时间单位</param>
        /// <returns></returns>
        public int AddTimeTask(Action callback, float delay, uint repeat = 1, FBTimeUnit unit = FBTimeUnit.Millisecond)
        {
            return f_timer.AddTimeTask(callback, delay, repeat, unit);
        }

        /// <summary>
        /// 移除TimeTask
        /// </summary>
        /// <param name="id">Task ID</param>
        /// <returns></returns>
        public bool RemoveTimeTask(int id)
        {
            return f_timer.RemoveTimeTask(id);
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
        public bool ReplaceTimeTask(int id,Action callback, float delay, uint repeat = 1, FBTimeUnit unit = FBTimeUnit.Millisecond)
        {
            return f_timer.ReplaceTimeTask(id, callback, delay, repeat, unit);
        }

        #endregion

        #region Frame Methods

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
            return f_timer.AddFrameTask(callback, delay, repeat);
        }

        /// <summary>
        /// 移除TimeTask
        /// </summary>
        /// <param name="id">Task ID</param>
        /// <returns></returns>
        public bool RemoveFrameTask(int id)
        {
            return f_timer.RemoveFrameTask(id);
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
            return f_timer.ReplaceFrameTask(id, callback, delay, repeat);
        }
        #endregion
    }//Class End
}
