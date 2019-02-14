// Felix-Bang：FBInventoryDefine
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
// CreateTime：2019/1/18

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FelixBang
{
	public class FBInventoryDefine
	{
        #region Fields/Properties
        public const string F_path_pickedPrefab = "Prefabs/UI/Inventory/UIPickedSlot";
        #endregion
	}//Class End

    /// <summary> 物品类型 </summary>
    public enum InventoryItemType
    {
        /// <summary> 消耗品 </summary>
        Consumable,
        /// <summary> 装备 </summary>
        Equipment,
        /// <summary> 武器 </summary>
        Weapon,
        /// <summary> 材料 </summary>
        Material
    }

    /// <summary> 品质 </summary>
    public enum InventoryItemQuality
    {
        /// <summary> 基础/初始装备 </summary>
        Basic,
        /// <summary> 普通 </summary>
        Common,
        /// <summary> 稀有 </summary>
        Rare,
        /// <summary> 传奇 </summary>
        Legendary,

        //...
    }

    /// <summary> 装备类型 </summary>
    public enum EquipmentType
    {
        None,
        Head,
        Neck,
        Chest,
        Ring,
        Leg,
        Bracer,
        Boots,
        Shoulder,
        Belt,
        OffHand
    }

    /// <summary> 武器类型 </summary>
    public enum WeaponType
    {
        None,
        OffHand,
        MainHand
    }

    public enum UISlotType
    {
        HideName,
        HideAmount,
        OnlyIcon,
    }
}
