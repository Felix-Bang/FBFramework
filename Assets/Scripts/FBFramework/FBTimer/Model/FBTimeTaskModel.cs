// Felix-Bang：FBTimeTaskModel
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
// Describe：时间任务Model
// CreateTime：2019/02/09

using System;

namespace FelixBang
{
	public class FBTimeTaskModel : FBModel
    {
        #region Fields/Properties
        /// <summary> 具体任务 </summary>
        public int ID { get; set; }
        /// <summary> 具体任务 </summary>
        public Action Callback { get; set; }
        /// <summary> 执行任务的目标时间 </summary>
        public double DestTime { get; set; }
        /// <summary> 延迟执行时间 </summary>
        public double DelayTime { get; set; }
        /// <summary> 循环次数 </summary>
        public uint Repeat { get; set; }
        #endregion

        #region Constructor
        public FBTimeTaskModel() { }

        public FBTimeTaskModel(int id, Action callback, double dest, uint repeat, double delay)
        {
            ID = id;
            Callback = callback;
            DestTime = dest;  //毫秒
            Repeat = repeat;
            DelayTime = delay;
        }
        #endregion
    }//Class End
}
