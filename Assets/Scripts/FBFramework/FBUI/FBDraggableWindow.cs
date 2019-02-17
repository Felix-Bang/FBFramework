//  Felix-Bang：FBDraggableWindow
//　　 へ　　　　　／|
//　　/＼7　　　 ∠＿/
//　 /　│　　 ／　／
//　│　Z ＿,＜　／　　 /`ヽ
//　│　　　　　ヽ　　 /　　〉
//　 Y　　　　　`　 /　　/
//　ｲ●　､　●　　⊂⊃〈　　/
//　()　 へ　　　　|　＼〈
//　　>ｰ ､_　 ィ　 │ ／／
//　 / へ　　 /　ﾉ＜| ＼＼
//　 ヽ_ﾉ　　(_／　 │／／
//　　7　　　　　　　|／
//　　＞―r￣￣`ｰ―＿
// Describe：Use to drag window.
// CreateTime：2018/01/05

using UnityEngine;
using UnityEngine.EventSystems;

namespace FelixBang
{
    public class FBDraggableWindow : MonoBehaviour,IBeginDragHandler,IDragHandler,IPointerDownHandler
	{
        [Header("Dragging")]
        public float F_dragSpeed = 1.0f;

        /// <summary> Once clicked should this draggable window be moved to the foreground? </summary>
        [Header("Bring to foreground")]
        public bool F_onClickBringToForeground = true;

        /// <summary> The max sibling index this window can get when bringing it to the foreground. </summary>
        public int F_maxForegroundIndex = 10;

        private Vector2 f_dragOffset;
        private RectTransform f_rectTransform;

        public static FBDraggableWindow F_CurrentWindow { get; protected set; }

        #region Unity回调
        void Awake () 
		{
            f_rectTransform = GetComponent<RectTransform>();
		}
        #endregion

        #region Interface Realization
        public void OnBeginDrag(PointerEventData eventData)
        {
           f_dragOffset = new Vector2(f_rectTransform.anchoredPosition.x, f_rectTransform.anchoredPosition.y) - eventData.position;

        }

        public void OnDrag(PointerEventData eventData)
        {
            f_rectTransform.anchoredPosition = new Vector3(eventData.position.x + f_dragOffset.x * F_dragSpeed, eventData.position.y + f_dragOffset.y * F_dragSpeed, 0.0f);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (F_onClickBringToForeground)
                MoveToForeground();
        }
        #endregion

        #region Method
        /// <summary> Bring this draggable window all the way to the front (maxSiblingIndex) </summary>
        private void MoveToForeground()
        {
            if (F_CurrentWindow == this)
                return; // Already top window.

            transform.SetSiblingIndex(F_maxForegroundIndex);
            F_CurrentWindow = this;
        }
        #endregion
    }//Class End
}
