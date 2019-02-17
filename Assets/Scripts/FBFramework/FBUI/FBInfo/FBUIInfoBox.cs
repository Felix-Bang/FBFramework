// Felix-Bang：FBUIInfoBox
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
	public class FBUIInfoBox : MonoBehaviour
	{
        #region Fields/Properties
        private RectTransform f_rectTrans;
        private Vector2 f_defaultPivot;
        private Image f_iconImage;
        private Text f_nameText;
        private Text f_desText;
        

        [SerializeField]
        private GameObject f_category_pfb;
        //[SerializeField]
        //private GameObject f_row_pfb;
        [SerializeField]
        private GameObject f_separator_pfb;
        [SerializeField]
        private FBUIInfoRow f_row_pfb;
        [SerializeField]
        private bool f_isShowInfo = true;
        [SerializeField]
        private bool f_moveWhenHitHorizontalBorder = true;
        [SerializeField]
        private bool f_moveWhenHitVerticalBorder = true;
        [SerializeField]
        private Vector2 f_borderMargins;


        private bool f_inited = false;
        private bool f_isHoveringSlotWithItem
        {
            get
            {
                var slot = FBUIBaseSlot.CurrentlyHoveringSlot;
                return slot!=null && slot.HasContained;
            }
        }

        protected InventoryItemModel f_currentItem;

        protected FBComponentPool<FBUIInfoRow> f_row_pool;
        protected FBGameObjectPool f_category_pool;
        protected FBGameObjectPool f_separator_pool;

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
            if (f_isHoveringSlotWithItem)
            {
                HandleInfoBox(FBUIBaseSlot.CurrentlyHoveringSlot);
            }
            else
            {
                GetComponent<CanvasGroup>().alpha = 0;
            }

		}

        void LateUpdate()
        {
            if (GetComponent<CanvasGroup>().alpha == 1)
            {
                PositionInfoBox();
                HandleBorders();
            }
        }

       



        #endregion

        #region Interface
        #endregion

        #region Methods
        //---------------- Public ------------------



        //---------------- Private ------------------
        private void InitWidgets()
        {
            f_rectTrans = GetComponent<RectTransform>();
            f_defaultPivot = f_rectTrans.pivot;
                f_iconImage = FBFindUtility.GetChildComponent<Image>(transform, "Icon");
            f_nameText = FBFindUtility.GetChildComponent<Text>(transform, "Name_Text");
            f_desText = FBFindUtility.GetChildComponent<Text>(transform, "Description_Text");



            f_category_pool = new FBGameObjectPool(f_category_pfb, 8);
            f_separator_pool = new FBGameObjectPool(f_separator_pfb,8);
            f_row_pool = new FBComponentPool<FBUIInfoRow>(f_row_pfb, 32);

            f_inited = true;
        }

        private void HandleInfoBox(FBUIBaseSlot hoveringSlot)
        {
            if (hoveringSlot == null || !hoveringSlot.HasContained)
                return;

            //if (hoveringSlot.InventoryItem != f_currentItem)
            //{
                f_currentItem = hoveringSlot.InventoryItem;
                Repaint();
            //}


        }

        private void Repaint()
        {
            f_row_pool.DestroyAll();
            f_separator_pool.DestroyAll();
            f_category_pool.DestroyAll();

            if (f_iconImage != null)
                f_iconImage.sprite = f_currentItem.Sprite;

            if (f_nameText != null)
                f_nameText.text = f_currentItem.Name;

            if (f_desText != null)
                f_desText.text = f_currentItem.Description;

            if (f_isShowInfo)
            {
                DrawItemInfo();
            }
            //Debug.Log("SSSSS");
            GetComponent<CanvasGroup>().alpha = 1;

        }

        public void DrawItemInfo()
        {
            var infoList = f_currentItem.GetInfo();
            int i = 0;

            foreach (var box in infoList)
            {
                i++;
                var boxObj = f_category_pool.Get();
                int addedRows = 0;

                foreach (var row in box)
                {
                    var rowCmp = f_row_pool.Get();
                    rowCmp.transform.SetParent(boxObj.transform);
                    FBTransformUtility.ResetRectTRS(rowCmp.transform);
                    rowCmp.DrawRow(row);
                    addedRows++;
                }

                boxObj.transform.SetParent(transform);
                FBTransformUtility.ResetRectTRS(boxObj.transform);

                if (i < infoList.Count && addedRows > 0 && f_separator_pfb != null)
                {
                    var separator = f_separator_pool.Get();
                    separator.transform.SetParent(transform);
                    FBTransformUtility.ResetRectTRS(separator.transform); 
                }
            }
        }

        private void PositionInfoBox()
        {
            //FBInventoryManager.Instance.PositionRectTransformAtPosition(GetComponentInParent<RectTransform>(),Input.mousePosition);
            
            var canvas = FBInventoryManager.Instance.InventoryCanvas;
            if (canvas.renderMode == RenderMode.ScreenSpaceCamera || canvas.renderMode == RenderMode.WorldSpace)
            {
                Vector2 pos;
                RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.GetComponent<RectTransform>(), Input.mousePosition, canvas.worldCamera, out pos);
                f_rectTrans.position = canvas.transform.TransformPoint(pos);
            }
            else if (canvas.renderMode == RenderMode.ScreenSpaceOverlay)
            {
                f_rectTrans.position = Input.mousePosition;
            }
        }

     

        private void HandleBorders()
        {
            var canvas = FBInventoryManager.Instance.InventoryCanvas;
            if (canvas.renderMode == RenderMode.WorldSpace)
                return;

            if (f_moveWhenHitHorizontalBorder)
            {
                if (Input.mousePosition.x + f_rectTrans.sizeDelta.x > Screen.width - f_borderMargins.x)
                    f_rectTrans.pivot = new Vector2(f_defaultPivot.y, f_defaultPivot.x);
                else
                    f_rectTrans.pivot = new Vector2(f_defaultPivot.x, f_defaultPivot.y);
            }

            if(f_moveWhenHitVerticalBorder)
            {
                if (Input.mousePosition.y - f_rectTrans.sizeDelta.y < 0.0f - f_borderMargins.y)
                    f_rectTrans.pivot = new Vector2(f_rectTrans.pivot.x, f_defaultPivot.x);
                else
                    f_rectTrans.pivot = new Vector2(f_rectTrans.pivot.x, f_defaultPivot.y);
            }
        }
        #endregion
    }//Class End
}
