// Felix-Bang：FBVendorSlot
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
	public class FBVendorSlot : FBUIBaseSlot 
	{
        private Text f_nameText;
        private Text f_priceText;


        void Awake()
        {
            f_nameText = FBFindUtility.GetChildComponent<Text>(transform, "Name_Text");
            if (f_nameText != null)
                f_nameText.text = string.Empty;

            f_priceText = FBFindUtility.GetChildComponent<Text>(transform, "Price_Text");
            if (f_priceText != null)
                f_priceText.text = string.Empty;
        }

        #region Methods
        public void AddVendorItem(FBInventoryItemModel item)
        {
            StoreInventoryItem(item);
            f_nameText.text = item.Name;
            f_priceText.text = item.BuyPrice.ToString();
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Right && !FBInventoryManager.Instance.HavePickd)
            {
                if (HasContained)
                {
                    //购买
                    FBInventoryManager.Instance.Buy(InventoryItem);
                }
            }
            else if (eventData.button == PointerEventData.InputButton.Left && FBInventoryManager.Instance.HavePickd)
            {
                //出售
                FBInventoryManager.Instance.Sell();
            }
        }
        #endregion
    }//Class End
}
