// Felix-Bang：FBFrameTaskModel
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
// Describe：帧任务Model
// CreateTime：2019/02/09

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FelixBang
{
	public class FBFrameTaskModel : FBModel
	{
        #region Fields/Properties
        /// <summary> 具体任务 </summary>
        public int ID { get; set; }
        /// <summary> 具体任务 </summary>
        public Action Callback { get; set; }
        /// <summary> 执行任务的目标时间 </summary>
        public int DestFrame { get; set; }
        /// <summary> 延迟执行时间 </summary>
        public int DelayFrame { get; set; }
        /// <summary> 循环次数 </summary>
        public uint Repeat { get; set; }
        #endregion

        #region Constructor
        public FBFrameTaskModel() { }

        public FBFrameTaskModel(int id, Action callback, int dest, uint repeat, int delay)
        {
            ID = id;
            Callback = callback;
            DestFrame = dest;  //毫秒
            Repeat = repeat;
            DelayFrame = delay;
        }
        #endregion
    }//Class End
}
