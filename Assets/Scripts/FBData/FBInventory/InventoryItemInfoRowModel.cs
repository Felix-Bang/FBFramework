// Felix-Bang：InfoRow
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
	public class InventoryItemInfoRowModel
    {
        #region Delegates/Action
        #endregion

        #region Fields/Properties
        public string Title { get; private set; }

        public Color TitleColor { get; private set; }

        public string Content { get; private set; }

        public Color ContentColor { get; private set; }
        #endregion

        #region Constructor
        public InventoryItemInfoRowModel() { }

        public InventoryItemInfoRowModel(string title,Color color):this(title,string.Empty,color,Color.white)
        { }

        public InventoryItemInfoRowModel(string title, string content) : this(title, content, Color.white, Color.white)
        { }

        public InventoryItemInfoRowModel(string title, string text, Color titleColor, Color textColor)
        {
            Title = title;
            Content = text;
            TitleColor = titleColor;
            ContentColor = textColor;
        }
        #endregion
	}//Class End
}
