// Felix-Bang：FBInfoWindow
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
using UnityEngine.UI;

namespace FelixBang
{
	public class FBInfoWindow : FBWindow 
	{
        #region Delegates/Action
        #endregion

        #region Fields/Properties
        private Image f_iconImage;
        private Text f_nameText;
        private Text f_desText;
        private bool f_inited = false;

		#endregion

		#region Constructor
		#endregion

		#region Unity
		void Start () 
		{
            if (!f_inited)
                InitWidgets();
		}

        void Update () 
		{
			
		}


        #endregion

        #region Interface
        #endregion

        #region Methods
        //---------------- Public ------------------
        public void DrawItemInfo(InventoryItemModel item)
        {
            //if (f_iocn == null)
            //    f_iocn = FBFindUtility.GetChildComponent<Image>(transform, "Icon");

            //InventoryItem = item;
            //f_iocn.sprite = InventoryItem.GetSprite();
            //f_iocn.gameObject.SetActive(true);
        }


        //---------------- Private ------------------
        private void InitWidgets()
        {
            f_iconImage = FBFindUtility.GetChildComponent<Image>(transform, "Icon");
            f_nameText = FBFindUtility.GetChildComponent<Text>(transform, "Name_Text");
            f_desText = FBFindUtility.GetChildComponent<Text>(transform, "Description_Text");
            f_inited = true;
        }

        //---------------- Override ------------------
        protected override void InitWindowOnAwake()
        {
            WindowType.F_existType = FBUIExistType.Popup;
            WindowType.F_lucency = FBUILucency.Penetrate;
        }

        #endregion
    }//Class End
}
