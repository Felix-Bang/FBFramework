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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FelixBang
{
	public class FBInventoryItemModel : FBModel
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

        private Sprite f_sprite;
        public Sprite Sprite
        {
            get
            {
                if (f_sprite == null)
                {
                    string path = "Weapons/" + SpriteName;
                    f_sprite = Resources.Load<Sprite>(path);
                }

                return f_sprite;
            }
        }
        #endregion

        #region Constructor
        public FBInventoryItemModel()
        {
            ID = -1;
        }

        public FBInventoryItemModel(int id, string name, InventoryItemType type, InventoryItemQuality quality, string des, int capacity, int buyPrice, int sellPrice, string sprite)
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
        internal LinkedList<FBInfoRowModel[]> GetInfo()
        {
            var list = new LinkedList<FBInfoRowModel[]>();

            list.AddLast(new FBInfoRowModel[] {
                new FBInfoRowModel("Type",Type),
                new FBInfoRowModel("Quality",Quality),
                new FBInfoRowModel("Price",BuyPrice.ToString()),
            });
            return list;
        }

        
        #endregion
    }//Class End
}
