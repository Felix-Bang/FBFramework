// Felix-Bang：FBInventoryManager
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
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace FelixBang
{
	public class FBInventoryManager : FBSingleton<FBInventoryManager> 
	{

        #region Variables/Properties/Fields
        private List<FBInventoryItemModel> f_inventoryItem_list = new List<FBInventoryItemModel>();

        private Transform f_canvas;
        private FBUIKnapsack f_knapsack;
        private FBUIVendor f_vendor;
        private FBUIChest f_chest;
        private FBUINotice f_notice;

        
        public Canvas InventoryCanvas
        {
            get { return f_canvas.GetComponent<Canvas>(); }
        }

        public bool HavePickd
        {
            get { return PickedSlot.HasContained; }
        }

        public FBUIPickedSlot PickedSlot { get; set; }
		#endregion

		#region Unity Life
		void Start () 
		{
            InitWidgets();
            f_canvas = FBWindowManager.Instance.CanvasTrans;
            GameObject pickObj = FBInstantiateUtility.CreatPrefab(f_canvas, FBInventoryDefine.F_path_pickedPrefab);
            PickedSlot = pickObj.GetComponent<FBUIPickedSlot>();
            PickedSlot.OnHide();
        }

        private void InitWidgets()
        {
            FBInventoryItemModel item0 = new FBInventoryItemModel
            {
                ID = 0,
                Name = "礼盒",
                Quality = "Basic",
                SellPrice = 800,
                Type = "Consumable",
                Capacity = 3,
                BuyPrice = 1500,
                Description = "打开您将获得一件远古装备！",
                SpriteName = "axe_t_01"
            };

            FBInventoryItemModel item1 = new FBInventoryItemModel
            {
                ID = 1,
                Name = "笔记本",
                Quality = "Common",
                SellPrice = 100,
                Type = "Consumable",
                Capacity = 5,
                BuyPrice = 300,
                Description = "打开您将获的200经验值！",
                SpriteName = "b_t_01"
            };

            FBInventoryItemModel item2 = new FBInventoryItemModel
            {
                ID = 2,
                Name = "背包",
                Quality = "Rare",
                SellPrice = 300,
                Type = "Consumable",
                Capacity = 5,
                BuyPrice = 600,
                Description = "打开您背包扩大20个位置！",
                SpriteName = "bl_t_01"
            };

            FBInventoryItemModel item3 = new FBInventoryItemModel
            {
                ID = 3,
                Name = "购物车",
                Quality = "Rare",
                SellPrice = 350,
                Type = "Weapon",
                Capacity = 2,
                BuyPrice = 800,
                Description = "提升购买力+200！",
                SpriteName = "f_t_01"
            };

            FBInventoryItemModel item4 = new FBInventoryItemModel
            {
                ID = 4,
                Name = "飞机",
                Quality = "Legendary",
                SellPrice = 600,
                Type = "Weapon",
                Capacity = 1,
                BuyPrice = 1200,
                Description = "提升速度+200！",
                SpriteName = "kn_t_01"
            };

            FBInventoryItemModel item5 = new FBInventoryItemModel
            {
                ID = 5,
                Name = "耳机",
                Quality = "Common",
                SellPrice = 100,
                Type = "Equipment",
                Capacity = 5,
                BuyPrice = 200,
                Description = "提升听力+10！",
                SpriteName = "m_t_01"
            };

      
            FBInventoryItemModel item6 = new FBInventoryItemModel
            {
                ID = 6,
                Name = "眼镜",
                Type = "Equipment",
                Quality = "Common",
                Description = "提升视力+10！",
                Capacity = 1,
                BuyPrice = 200,
                SellPrice = 100,
                SpriteName = "st_t_01",

                //Strength = 200,
                //Intellect = 100,
                //Agility = 50,
                //Stamina = 20,

                //EquipType = EquipmentType.Neck


            };


            f_inventoryItem_list.Add(item0);
            f_inventoryItem_list.Add(item1);
            f_inventoryItem_list.Add(item2);
            f_inventoryItem_list.Add(item3);
            f_inventoryItem_list.Add(item4);
            f_inventoryItem_list.Add(item5);
            f_inventoryItem_list.Add(item6);
        }

        void Update () 
		{
            if (HavePickd)
            {
                Vector2 pos;
                RectTransformUtility.ScreenPointToLocalPointInRectangle(FBWindowManager.Instance.CanvasTrans as RectTransform, Input.mousePosition, FBWindowManager.Instance.UICamera, out pos);
                PickedSlot.SetPosition(pos);
            }

            //if (f_toolTipShow)
            //{
            //    Vector2 pos;
            //    RectTransformUtility.ScreenPointToLocalPointInRectangle(f_canvas.transform as RectTransform, Input.mousePosition, f_canvas.GetComponentInChildren<Camera>(), out pos);
            //    f_toolTip.FBSetPosition(pos);
            //}

            //if (HavePickd && Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(-1))
            //{
            //    //f_isPicked = false;
            //    f_pickedItem.FBHide();
            //}

            if (Input.GetKeyDown(KeyCode.G))
            {
                int id = UnityEngine.Random.Range(0, 7);

                StoreInKnapsack(id);
            }
        }
        #endregion

        #region Methods
        public void InitInventoryUI(Transform inventoryParent)
        {
            f_knapsack = inventoryParent.GetComponentInChildren<FBUIKnapsack>();
            f_chest = inventoryParent.GetComponentInChildren<FBUIChest>();
            f_vendor = inventoryParent.GetComponentInChildren<FBUIVendor>();
            f_notice = inventoryParent.GetComponentInChildren<FBUINotice>();
        }
        
        public FBInventoryItemModel GetInventoryItemById(int id)
        {         
            foreach (FBInventoryItemModel item in f_inventoryItem_list)
            {              
                if (item.ID == id)
                    return item;
            }

            return null;
        }

        public void StoreInKnapsack(int id)
        {
            f_knapsack.StoreItem(id);
        }

        public void OnShowToolTips(string content)
        {
            if (HavePickd)
                return;

            //f_toolTipShow = true;
            //f_toolTip.FBShow(content);
            
        }

        public void OnHideToolTips()
        {
            if (HavePickd)
                return;

            //f_toolTipShow = false;
            //f_toolTip.FBHide();
           
        }

        public void PickUp(FBInventoryItemModel item,int amount)
        {
            PickedSlot.PickUp(item, amount);

            //if (f_toolTipShow)
            //{
            //    f_toolTipShow = false;
            //    //f_toolTip.FBHide();
            //}
        }

        public void DropOff(int amount=1)
        {

            PickedSlot.DropOff(amount);
            //if (f_pickedItem.F_Amount <= 0)
            //{
            //    //f_isPicked = false;
            //    f_pickedItem.FBHide();
            //}
        }
        //---------------- 显示/隐藏 -----------------
        public void SwitchKnapsackDisplay()
        {
            f_knapsack.SwitchDisplay();
        }

        public void SwitchChestDisplay()
        {
            f_chest.SwitchDisplay();
        }

        public void SwitchVendorDisplay()
        {
            f_vendor.SwitchDisplay();
        }

        public void ShowNotice(string message)
        {
            f_notice.AddMessage(message);
        }

        //---------------- 购买/出售 -------------------
        public void Buy(FBInventoryItemModel item)
        {
            //付钱
            FBDebug.Log("付钱");
            //将Item放入背包
            FBDebug.Log("将Item放入背包");
        }
        
        public void Sell()
        {
            int sellAmout = 1;
            if (Input.GetKey(KeyCode.LeftControl))
                sellAmout = 1;
            else
                sellAmout = PickedSlot.Amount;

            int coinAmout = PickedSlot.InventoryItem.SellPrice * sellAmout;

            //赚钱
            FBDebug.Log("赚钱");
            //从背包移除
            FBDebug.Log("从背包移除");
        }

        public void PositionRectTransformAtPosition(RectTransform rectTrans,Vector3 screenPos)
        {
            var canvas = f_canvas.GetComponent<Canvas>();
            if (canvas.renderMode == RenderMode.ScreenSpaceCamera || canvas.renderMode == RenderMode.WorldSpace)
            {
                Vector2 pos;
                RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.GetComponent<RectTransform>(), screenPos, canvas.worldCamera, out pos);
                rectTrans.position = canvas.transform.TransformPoint(pos);
            }
            else if (canvas.renderMode == RenderMode.ScreenSpaceOverlay)
            {
                rectTrans.position = screenPos;
            }
        }
        #endregion
    }//Class End
}
