// Felix-Bang：FBKnapsackWindow
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
	public class FBUIKnapsack : FBUIInventory
	{

        #region Methods
        protected override void StoreItemToSameSlot(FBInventoryItemModel item)
        {
            FBKnapsackSlot slot = GetSlot(item);
            if (slot != null)
                slot.AddKnapsackItem(item);
            else
                StoreItemToEmptySlot(item);
        }

        protected override void StoreItemToEmptySlot(FBInventoryItemModel item)
        {
            FBKnapsackSlot slot = GetSlot();
            if (slot == null)
                 FBInventoryManager.Instance.ShowNotice("没有空的位置");
            else
                slot.AddKnapsackItem(item);
        }

        private FBKnapsackSlot GetSlot(FBInventoryItemModel item = null)
        {
            foreach (FBKnapsackSlot slot in f_slot_list)
            {
                if (item == null)
                {
                    if (!slot.HasContained)
                        return slot;
                }
                else
                {
                    if (slot.HasContained && slot.ID.Equals(item.ID) && !slot.IsFull)
                        return slot;
                }
            }

            return null;
        }
        #endregion
    }//Class End
}
