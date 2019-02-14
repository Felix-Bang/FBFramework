// Felix-Bang：FBUIVendor
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
	public class FBUIVendor : FBUIInventory 
	{
        #region Fields/Properties
        public int[] F_itemId;
		#endregion

		#region Unity
		void Start () 
		{
            InitVendorGoods();
		}
        #endregion

        #region Interface
        #endregion

        #region Methods
        private void InitVendorGoods()
        {
           
            for (int i = 0, imax = F_itemId.Length; i < imax; i++)
            {
                StoreItemToEmptySlot(FBInventoryManager.Instance.GetInventoryItemById(F_itemId[i]));
            }
        }

        protected override void StoreItemToEmptySlot(InventoryItemModel item)
        {
            FBVendorSlot slot = GetSlot();
            if (slot == null)
                FBDebug.LogWarning("没有空的位置");
            else
                slot.AddVendorItem(item);
        }

        private FBVendorSlot GetSlot(InventoryItemModel item = null)
        {
            foreach (FBVendorSlot slot in f_slot_list)
            {
                if (!slot.HasContained)
                    return slot;
            }

            return null;
        }
        #endregion
    }//Class End
}
