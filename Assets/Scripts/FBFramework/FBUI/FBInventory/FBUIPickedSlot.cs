// Felix-Bang：FBUIPickedSlot
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
	public class FBUIPickedSlot : FBUIBaseSlot
    {
        #region Fields/Properties

        private Text f_amountText;
        private int f_amount;

        public bool IsFull
        {
            get { return f_amount >= Capacity; }
        }

        public int Amount
        {
            get { return f_amount; }
        }
        #endregion

        #region Methods
        public void OnHide()
        {
            gameObject.SetActive(false);
        }

        public void OnShow()
        {
            gameObject.SetActive(true);
        }

        public void PickUp(FBInventoryItemModel item, int amount = 1)
        {
            if (HasContained)
            {
                if (InventoryItem.ID == item.ID)
                    SetAmount(amount);
                else
                {
                    StoreInventoryItem(item);
                    SetAmount(amount, true);
                }
            }
            else
            {
                StoreInventoryItem(item);
                SetAmount(amount);
            }

            OnShow();
        }

        public void SetPosition(Vector3 position)
        {
            transform.localPosition = position;
        }

        public void DropOff(int amount)
        {
            SetAmount(-amount);

            if (f_amount < 1)
            {
                RemoveContain();
            }
        }

        private void SetAmount(int amount,bool isRefresh=false)
        {
            if (isRefresh)
                f_amount = amount;
            else
                f_amount += amount;

            if (f_amountText == null)
                f_amountText = this.GetComponentInChildren<Text>();

            if (f_amount > 0)
                f_amountText.text = f_amount.ToString();
            else
                f_amountText.text = string.Empty;
        }


        public override void RemoveContain()
        {
            base.RemoveContain();
            f_amount = 0;
            f_amountText.text = string.Empty;

            OnHide();
        }
        #endregion
    }//Class End
}
