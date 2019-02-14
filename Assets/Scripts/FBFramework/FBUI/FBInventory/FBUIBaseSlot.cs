// Felix-Bang：FBUIBaseSlot
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
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace FelixBang
{
	public abstract class FBUIBaseSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        #region Fields/Properties

        private Image f_iocn;

        public InventoryItemModel InventoryItem
        {
            get; private set;
        }

        public virtual bool HasContained
        {
            get { return InventoryItem != null; }
        }

        public int ID
        {
            get { return InventoryItem.ID; }
        }

        public int Capacity
        {
            get { return InventoryItem.Capacity; }
        }
        #endregion

        #region Button handler UI events

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (HasContained)
                return;

            Debug.Log("显示物品信息");
            //FBInventoryManager.Instance.OnShowToolTips();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (HasContained)
                return;

            Debug.Log("隐藏物品信息");
        }

        public virtual void OnPointerDown(PointerEventData eventData){}

        public void OnBeginDrag(PointerEventData eventData)
        {
            Debug.Log("OnBeginDrag");
        }

        public void OnDrag(PointerEventData eventData)
        {
            Debug.Log("OnDrag");
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Debug.Log("OnEndDrag");
        }
        #endregion


        #region Method
        //--------------------------- Public ------------------------------

        public void StoreInventoryItem(InventoryItemModel item)
        {
            if (f_iocn == null)
                f_iocn = FBFindUtility.GetChildComponent<Image>(transform, "Icon");

            InventoryItem = item;

            f_iocn.sprite = InventoryItem.GetSprite();
            f_iocn.gameObject.SetActive(true);
        }

        public virtual void RemoveContain()
        {
            InventoryItem = null;
            f_iocn.sprite = null;
            f_iocn.gameObject.SetActive(false);
        }
        #endregion
    }//Class End
}
