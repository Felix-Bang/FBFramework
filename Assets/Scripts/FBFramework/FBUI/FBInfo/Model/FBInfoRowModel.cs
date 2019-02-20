// Felix-Bang：FBInfoRowModel
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
// CreateTime：2019/02/17

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FelixBang
{
	public class FBInfoRowModel
    {
        #region Fields/Properties

        public string Title { get; private set; }

        public Color TitleColor { get; private set; }

        public string Content { get; private set; }

        public Color ContentColor { get; private set; }

        #endregion

        #region Constructor
        public FBInfoRowModel() { }

        public FBInfoRowModel(string title,Color color):this(title,string.Empty,color,Color.white)
        { }

        public FBInfoRowModel(string title, string content) : this(title, content, Color.white, Color.white)
        { }

        public FBInfoRowModel(string title, string content, Color titleColor, Color contentColor)
        {
            Title = title;
            Content = content;
            TitleColor = titleColor;
            ContentColor = contentColor;
        }
        #endregion
	}//Class End
}
