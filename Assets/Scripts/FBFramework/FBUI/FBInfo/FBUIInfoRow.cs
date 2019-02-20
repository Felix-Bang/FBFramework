// Felix-Bang：FBUIInfoRow
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
using UnityEngine.UI;

namespace FelixBang
{
	public class FBUIInfoRow : MonoBehaviour,IFBPoolable 
	{
        #region Fields/Properties
        private Text f_titleText;
        private Text f_contentText;
        private bool f_isInit = false;
        #endregion

        #region Interface
        public void ResetStateForPool()
        {
            //Item has no specific states,no need to reset
        }
        #endregion

        #region Methods
        public void DrawRow(FBInfoRowModel row)
        {
            if (!f_isInit)
                InitWidgets();

            f_titleText.text = row.Title;
            f_titleText.color = row.TitleColor;
            f_contentText.text = row.Content;
            f_contentText.color = row.ContentColor;
        }

        private void InitWidgets()
        {
            f_titleText = FBFindUtility.GetChildComponent<Text>(transform, "Title_Text");
            f_contentText = FBFindUtility.GetChildComponent<Text>(transform, "Content_Text");
            f_isInit = true;
        }
        #endregion
    }//Class End
}
