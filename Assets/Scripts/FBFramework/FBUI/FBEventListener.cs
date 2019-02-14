// Felix-Bang：FBEventListener
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
// Describe：事件监听
// CreateTime：2019/1/21
using UnityEngine;
using UnityEngine.EventSystems;

namespace FelixBang
{
    public class EventListener : EventTrigger
    {
        public delegate void FBVoidDelegate(GameObject go);
        public FBVoidDelegate OnClickDel;
        public FBVoidDelegate OnDownDel;
        public FBVoidDelegate OnEnterDel;
        public FBVoidDelegate OnExitDel;
        public FBVoidDelegate OnUpDel;
        public FBVoidDelegate OnSelectDel;
        public FBVoidDelegate OnUpdateSelectDel;

        /// <summary>
        /// 得到“监听器”组件
        /// </summary>
        /// <param name="go">监听的游戏对象</param>
        /// <returns>
        /// 监听器
        /// </returns>
        public static EventListener Get(GameObject go)
        {
            EventListener lister = go.GetComponent<EventListener>();
            if (lister==null)
                lister = go.AddComponent<EventListener>();

            return lister;
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            if(OnClickDel!=null)
            {
                OnClickDel(gameObject);
            }
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            if (OnDownDel != null)
            {
                OnDownDel(gameObject);
            }
        }

        public override void OnPointerEnter(PointerEventData eventData)
        {
            if (OnEnterDel != null)
            {
                OnEnterDel(gameObject);
            }
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            if (OnExitDel != null)
            {
                OnExitDel(gameObject);
            }
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            if (OnUpDel != null)
            {
                OnUpDel(gameObject);
            }
        }
    
        public override void OnSelect(BaseEventData eventBaseData)
        {
            if (OnSelectDel != null)
            {
                OnSelectDel(gameObject);
            }
        }

        public override void OnUpdateSelected(BaseEventData eventBaseData)
        {
            if (OnUpdateSelectDel != null)
            {
                OnUpdateSelectDel(gameObject);
            }
        }
	
    }//Class_end
}
