// Felix-Bang：FBUINotice
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FelixBang
{
	public class FBUINotice : MonoBehaviour 
	{
        #region Delegates/Action
        #endregion

        #region Fields/Properties
        [SerializeField]
        private FBUINoticeRow f_row_pfb;
        private RectTransform f_rectTrans;
        private ScrollRect f_scrollRect;
        private GridLayoutGroup f_grid;

        [SerializeField]
        private int f_maxMessage = 50;
        [SerializeField]
        private bool f_destoryAfterShowTime = true;

        private List<FBUINoticeRow> f_messages = new List<FBUINoticeRow>();
        private FBComponentPool<FBUINoticeRow> f_pool;

        #endregion

		#region Constructor
		#endregion

		#region Unity
		void Awake () 
		{
            f_pool = new FBComponentPool<FBUINoticeRow>(f_row_pfb,f_maxMessage);
            f_grid = FBFindUtility.GetChildComponent<GridLayoutGroup>(transform, "Content");
		}

		void Start () 
		{
            
		}
	
		void Update () 
		{
			
		}
        #endregion

        #region Interface
        #endregion

        #region Methods
        public void AddMessage(string message)
        {
            AddMessage(message, NoticeDuration.Short);
        }

        public void AddMessage(string title,string message)
        {
            AddMessage(title, message, NoticeDuration.Short);
        }

        public virtual void AddMessage(string message, NoticeDuration duration)
        {
            AddMessage(string.Empty, message, duration);
        }

        public virtual void AddMessage(string title, string message, NoticeDuration duration)
        {
            AddMessage(new NoticeRowModel(title, message, duration));
        }

        public virtual void AddMessage(NoticeRowModel notice)
        {
            if (string.IsNullOrEmpty(notice.Message))
                return;

            if (f_row_pfb != null)
            {
                var item = f_pool.Get();
                item.transform.SetParent(f_grid.transform);
                item.transform.SetAsLastSibling();
                FBTransformUtility.ResetRectTRS(item.transform);
                item.Repaint(notice);
                f_messages.Add(item);
            }

            if (f_messages.Count > f_maxMessage)
            {
                StartCoroutine(DestoryAfter(f_messages[0], 3));
                f_messages[0].Hide();
                f_messages.RemoveAt(0);
            }

        }

        private IEnumerator DestoryAfter(FBUINoticeRow row, float time)
        {
            yield return new WaitForSeconds(time);
            f_pool.Destroy(row);
        }

        #endregion
    }//Class End
}
