// Felix-Bang：NoticeRowModel
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
	public class NoticeRowModel
	{
        #region Delegates/Action
        #endregion

        #region Fields/Properties
        public string Title;
        public string Message;
        public DateTime CreatTime;
        public Color TextColor = Color.white;
        public NoticeDuration Duration = NoticeDuration.Short;

        #endregion

        #region Constructor
        public NoticeRowModel() { }

        public NoticeRowModel(string title, string message, NoticeDuration duration)
            :this(title, message, DateTime.Now, Color.white, duration)
        {}

        public NoticeRowModel(string title, string message, Color color, NoticeDuration duration)
          : this(title, message, DateTime.Now, color, duration)
        {}

        public NoticeRowModel(string title,string message,DateTime dateTime, Color color, NoticeDuration duration)
        {
            Title = title;
            Message = message;
            CreatTime = dateTime;
            TextColor = color;
        }
        #endregion

        #region Methods
        public void Show(System.Object[] param)
        {
            
        }
		#endregion
	}//Class End

    public enum NoticeDuration
    {
        Short = 2,
        Medium = 4,
        Long = 6,
        ExtraLong = 8
    }
}
