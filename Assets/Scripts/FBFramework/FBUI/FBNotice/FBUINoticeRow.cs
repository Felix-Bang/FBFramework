// Felix-Bang：FBUINoticeRow
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
	public class FBUINoticeRow : MonoBehaviour ,IFBPoolable
	{
        #region Fields/Properties

        private Text f_titleText;
        private Text f_messageText;
        private Text f_timeText;

        private float f_showTime;
        private DateTime f_dateTime;

        private bool f_isHiding = false;  //In the progress of hiding
        private bool f_isInitWidgets = false;
		#endregion

		#region Unity
		void Start () 
		{
           
        }
        #endregion

        #region Interface
        public void ResetStateForPool()
        {
            f_isHiding = false;
        }
        #endregion

        #region Methods
        private void InitWidgets()
        {
            f_titleText = FBFindUtility.GetChildComponent<Text>(transform, "Title_Text");
            f_messageText = FBFindUtility.GetChildComponent<Text>(transform, "Notice_Text");
            f_timeText = FBFindUtility.GetChildComponent<Text>(transform, "Time_Text");

            f_isInitWidgets = true;
        }

        public void Repaint(NoticeRowModel notice)
        {
            if (!f_isInitWidgets)
                InitWidgets();

            f_showTime = (int)notice.Duration;
            f_dateTime = notice.CreatTime;

            if (string.IsNullOrEmpty(notice.Title))
            {
                if (f_titleText != null)
                    f_titleText.gameObject.SetActive(false);
            }
            else
            {
                f_titleText.text = notice.Title;
                f_titleText.color = notice.TextColor;
            }

            f_messageText.text = notice.Message;
            f_messageText.color = notice.TextColor;

            if (f_titleText != null)
            {
                f_titleText.text = f_dateTime.ToShortTimeString();
                f_titleText.color = notice.TextColor;
            }
        }

        public void Hide()
        {
            if (f_isHiding)
                return;

            f_isHiding = true;
        }


        #endregion
    }//Class End
}
