// Felix-Bang：FBKnapsackSlot
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
	public class FBKnapsackSlot : FBUIBaseSlot 
	{
        #region Fields/Properties
        private RectTransform f_containTrans;
        private Text f_amountText;
        private int f_amount;

        private float f_targetScale = 1;
        private Vector3 f_maxScale = new Vector3(1.5f, 1.5f, 1.5f);
        private float f_rate = 5;

        public bool IsFull
        {
            get { return f_amount >= Capacity;  }
        }

        public int RemainAmount
        {
            get
            {
                if (IsFull)
                    return 0;
                else
                    return Capacity - f_amount;
            }
        }
        #endregion

        #region
        void Awake()
        {
            f_containTrans = transform.GetChild(0).GetComponent<RectTransform>();
            f_amountText = this.GetComponentInChildren<Text>();
            if (f_amountText != null)
                f_amountText.text = string.Empty;
        }

        private void Update()
        {
            //动画
            if (f_containTrans.localScale.x != f_targetScale)
            {
                float scale = Mathf.Lerp(f_containTrans.localScale.x, f_targetScale, f_rate * Time.deltaTime);
                f_containTrans.localScale = new Vector3(scale, scale, scale);
                if (Mathf.Abs(f_containTrans.localScale.x - f_targetScale) < 0.02f)
                    f_containTrans.localScale = new Vector3(f_targetScale, f_targetScale, f_targetScale);
            }
        }
        #endregion

        #region Methods
        //-------------------------- Public -------------------------------
        public void AddKnapsackItem(InventoryItemModel item, int amount = 1)
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
        }

        public void SetAmount(int amount = 1,bool isRefresh=false)
        {
            f_containTrans.localScale = f_maxScale;

            if (isRefresh)
                f_amount = amount;
            else
                f_amount += amount;

            if (f_amount > 0)
                f_amountText.text = f_amount.ToString();
            else
                f_amountText.text = string.Empty;

        }

        //-------------------------- Private -------------------------------



        //-------------------------- Override -------------------------------
        public override void OnPointerDown(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)                                         // 左键事件
            {
                if (HasContained)                                                                              //已放置物体
                {
                    if (FBInventoryManager.Instance.HavePickd)                                                 //已拣起物体
                    {
                        FBUIPickedSlot picked = FBInventoryManager.Instance.PickedSlot;

                        if (InventoryItem.ID == picked.ID)                                                     //已放置物体和已捡起物体类型相同
                        {
                            if (IsFull)
                                return;

                            if (Input.GetKey(KeyCode.LeftControl))                                             //按着Ctrl键
                            {
                                SetAmount();
                                FBInventoryManager.Instance.DropOff();
                            }
                            else
                            {
                                int dropAmount = RemainAmount >= picked.Amount ? picked.Amount:RemainAmount;
                                SetAmount(dropAmount);
                                FBInventoryManager.Instance.DropOff(dropAmount);
                            }
                        }
                        else                                                                                   //已包含物体和已捡起物体类型不同
                        {
                            InventoryItemModel tmpItem = InventoryItem;
                            int tmpCount = f_amount;

                            AddKnapsackItem(picked.InventoryItem, picked.Amount);
                            FBInventoryManager.Instance.PickedSlot.PickUp(tmpItem, tmpCount);
                        }
                    }
                    else                                                                                       //没有拣起物体
                    {
                        if (Input.GetKey(KeyCode.LeftControl))                                                 //按着Ctrl
                        {
                         
                            int pickCount = (f_amount + 1) / 2;
                            //拣起一半
                            //FBInventoryManager.Instance.FBPickItem(f_item.F_Item, pickCount);
                            int remainCount = f_amount - pickCount;
                            if (remainCount < 1)
                                RemoveContain();
                            else
                                SetAmount(remainCount);
                        }
                        else
                        {
                          
                            //拣起全部
                            FBInventoryManager.Instance.PickUp(InventoryItem,f_amount);
                            RemoveContain();
                        }
                    }
                }
                else                                                                                           //未放置物体
                {
               
                    if (FBInventoryManager.Instance.HavePickd)
                    {
                        FBUIPickedSlot picked = FBInventoryManager.Instance.PickedSlot;
                        if (Input.GetKey(KeyCode.LeftControl))
                        {
                            AddKnapsackItem(picked.InventoryItem);
                            FBInventoryManager.Instance.DropOff();
                        }
                        else
                        {
                            AddKnapsackItem(picked.InventoryItem, picked.Amount);
                            FBInventoryManager.Instance.DropOff(picked.Amount);
                        }
                    }
                    else
                        return;
                }
            }
            else if (eventData.button == PointerEventData.InputButton.Right)                                   //右键事件
            {
                //if (!F_IsEmpty)
                //{
                //    if (f_item.F_Item is FBEquipment || f_item.F_Item is FBWeapon)
                //    {
                //        FBEquipmentWindow.F_instance.FBPutOn(f_item.F_Item);
                //        f_item.FBSubtractAmount(1);
                //        if (f_item.F_Amount < 1)
                //            DestroyImmediate(f_item.gameObject);
                //    }
                //}
            }
            else
                return;

        }

        public override void RemoveContain()
        {
            base.RemoveContain();
            f_amount = 0;
            f_amountText.text = string.Empty;
           
        }
        #endregion
    }//Class End
}
