// Felix-Bang：FBUIInventory
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

namespace FelixBang
{
	public class FBUIInventory : MonoBehaviour 
	{

        #region Fields/Properties
        private CanvasGroup f_group;
        protected FBUIBaseSlot[] f_slot_list;

        private float f_targtAlpha = 0;
        private float f_rate = 5;
        #endregion

        #region Constructor
        #endregion

        #region Unity
        void Awake () 
		{
            f_group = f_group = GetComponent<CanvasGroup>();
            f_slot_list = GetComponentsInChildren<FBUIBaseSlot>();
            RegisterButtonClickEvent("Close_Button", p => SwitchDisplay());
        }
	
		void Update () 
		{
            if (f_group.alpha != f_targtAlpha)
            {
                float alpha = Mathf.Lerp(f_group.alpha, f_targtAlpha, f_rate * Time.deltaTime);
                f_group.alpha = alpha;

                if (Mathf.Abs(f_group.alpha - f_targtAlpha) < 0.1f)
                    f_group.alpha = f_targtAlpha;
            }
        }
        #endregion

        #region Methods
        public void SwitchDisplay()
        {
            if (f_targtAlpha == 0)
            {
                f_group.blocksRaycasts = true;
                f_targtAlpha = 1;
            }
            else
            {
                f_group.blocksRaycasts = false;
                f_targtAlpha = 0;
            }
        }

        public void StoreItem(int id)
        {
            StoreItem(FBInventoryManager.Instance.GetInventoryItemById(id));
        }

        public void StoreItem(InventoryItemModel item)
        {
            if (item == null)
            {
                FBDebug.LogWarning("The item is empty!");
                return;
            }

            if (item.Capacity == 1)  //一个物品槽只能放一个
                StoreItemToEmptySlot(item);
            else
                StoreItemToSameSlot(item);
        }

        protected virtual void StoreItemToEmptySlot(InventoryItemModel item)
        {}

        protected virtual void StoreItemToSameSlot(InventoryItemModel item)
        {}

        protected void RegisterButtonClickEvent(string buttonName, EventListener.FBVoidDelegate handler)
        {
            GameObject btn = FBFindUtility.FindChildByName(transform, buttonName);
            if (btn != null)
                EventListener.Get(btn).OnClickDel = handler;
        }

        #endregion
    }//Class End
}
