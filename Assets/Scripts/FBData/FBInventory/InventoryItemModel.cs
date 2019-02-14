// Felix-Bang：FBInventoryItemModel
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
	public class InventoryItemModel : ItemModel 
	{
        #region Fields/Properties
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Quality { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public int BuyPrice { get; set; }
        public int SellPrice { get; set; }
        public string SpriteName { get; set; }
        #endregion

        #region Constructor
        public InventoryItemModel()
        {
            ID = -1;
        }

        public InventoryItemModel(int id, string name, InventoryItemType type, InventoryItemQuality quality, string des, int capacity, int buyPrice, int sellPrice, string sprite)
        {
            ID = id;
            Name = name;
            //Type = type;
            //Quality = quality;
            Description = des;
            Capacity = capacity;
            BuyPrice = buyPrice;
            SellPrice = sellPrice;
            SpriteName = sprite;
        }
        #endregion

        #region Interface
        #endregion

        #region Methods
        public Sprite GetSprite()
        {
            Sprite sp;
            string path = "Sprites/Icons/" + SpriteName;
            sp = Resources.Load<Sprite>(path);
            return sp;
        }
        #endregion
    }//Class End
}
