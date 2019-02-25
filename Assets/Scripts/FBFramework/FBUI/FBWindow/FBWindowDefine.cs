//  Felix-Bang：FBUIDefine
//　　 へ　　　　　／|
//　　/＼7　　　 ∠＿/
//　 /　│　　 ／　／
//　│　Z ＿,＜　／　　 /`ヽ
//　│　　　　　ヽ　　 /　　〉
//　 Y　　　　　`　 /　　/
//　ｲ●　､　●　　⊂⊃〈　　/
//　()　 へ　　　　|　＼〈
//　　>ｰ ､_　 ィ　 │ ／／
//　 / へ　　 /　ﾉ＜| ＼＼
//　 ヽ_ﾉ　　(_／　 │／／
//　　7　　　　　　　|／
//　　＞―r￣￣`ｰ―＿
// Describe：1、系统常量；2、全局方法；3、系统枚举类型；4、委托
// CreateTime：2018/12/20

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FelixBang
{
	public class FBWindowDefine
	{
        /// <summary> path </summary>
        public const string F_path_canvas = "Prefabs/UI/Windows/Canvas";
        public const string F_path_windows = "ConfigFiles/UI/WindowPathData";

        /// <summary> Canvas 标签 </summary>
        public const string F_tag_canvas = "F_Canvas";
        public const string F_tag_uicamera = "F_UICamera";

        /// <summary> window 节点 </summary>
        public const string F_node_normal = "Normal";
        public const string F_node_fixed = "Fixed";
        public const string F_node_popup = "Popup";
        public const string F_node_mask = "MaskPanel";

        /// <summary>  Mask Luceny </summary>
        public const float F_maskRGB_luceny = 255 / 255F;
        public const float F_maskA_luceny = 0 / 255F;

        /// <summary>  Mask TraLucency </summary>
        public const float F_maskRGB_traLucency = 220 / 255F;
        public const float F_maskA_traLucency = 50 / 255F;

        /// <summary>  Mask LowLucency </summary>
        public const float F_maskRGB_lowLucency = 50 / 255F;
        public const float F_maskA_lowLucency = 200 / 255F;

    }

    public class FBWindowConst
    {
        public const string F_window_login = "LoginWindow";
        public const string F_window_start = "StartWindow";
        public const string F_window_startOption = "StartOptionWindow";
        public const string F_window_options = "OptionsWindow";
        public const string F_window_select = "SelectWindow";
        public const string F_window_main = "MainWindow";
        public const string F_window_inventory = "InventoryWindow";
        public const string F_window_intro = "IntroWindow";
        //public const string F_window_knapsack = "KnapsackWindow";
        public const string F_window_more = "MoreWindow";
        public const string F_window_top = "TopWindow";
    }

    #region UI enum
    /// <summary> UI存在类型 </summary>
    public enum FBUIExistType
    {
        //普通
        Normal,
        //固定
        Fixed,
        //弹出
        Popup
    }

    /// <summary> UI的显示类型 </summary>
    public enum FBUIShowModel
    {
        //普通
        Normal,
        //反向切换（原路返回）
        ReverseSwitch,
        //隐藏其它
        HideOther
    }

    /// <summary> UI的透明类型 </summary>
    public enum FBUILucency
    {
        /// <summary> 透明,不能穿透 </summary>
        Luceny,
        /// <summary> 半透明,不能穿透 </summary>
        TraLucency,
        /// <summary> 低透明,不能穿透 </summary>
        LowLucency,
        /// <summary> 能穿透 </summary>
        Penetrate,
    }
    #endregion
}
