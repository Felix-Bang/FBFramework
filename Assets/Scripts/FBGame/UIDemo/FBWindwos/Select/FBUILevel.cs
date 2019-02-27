// Felix-Bang：FBUILevel
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
    public class FBUILevel : MonoBehaviour
    {
        #region Fields/Properties
        private Image f_image;
        private GameObject f_lock;
        private Text f_levelText;
        private Text f_nameText;
        private Text f_subText;
        private GameObject f_contentRootObj;
        private int f_ItenDataIndex = -1;

        private bool f_isInit = false;
        #endregion

        #region Constructor
        #endregion

        #region Unity
        void Start()
        {
            f_image = FBFindUtility.GetChildComponent<Image>(transform, "Level_Image");
            f_lock = FBFindUtility.FindChildByName(transform, "Lock");
            f_levelText = FBFindUtility.GetChildComponent<Text>(transform, "Level_Text");
            f_nameText = FBFindUtility.GetChildComponent<Text>(transform, "Name_Text");
            f_subText = FBFindUtility.GetChildComponent<Text>(transform, "Sub_Text");
        }
        #endregion

        #region Interface
        #endregion

        #region Methods
        public void Init()
        {
            if (!f_isInit)
                InitWidgets();

            EventListener.Get(gameObject).OnClickDel = OnItemClick;
        }

      
        public void SetLevelData(FBLevelModel level,int index)
        {
            f_ItenDataIndex = index;
            f_levelText.text = level.GetLevel();
            f_nameText.text = level.Name;
            f_subText.text = level.Describe;
            f_image.sprite = level.Sprite;
            f_lock.SetActive(level.IsLock);
        }

        private void InitWidgets()
        {
            f_image = FBFindUtility.GetChildComponent<Image>(transform, "Level_Image");
            f_lock = FBFindUtility.FindChildByName(transform, "Lock");
            f_levelText = FBFindUtility.GetChildComponent<Text>(transform, "Level_Text");
            f_nameText = FBFindUtility.GetChildComponent<Text>(transform, "Name_Text");
            f_subText = FBFindUtility.GetChildComponent<Text>(transform, "Sub_Text");
            f_isInit = true;    
        }

        private void OnItemClick(GameObject go)
        {
            FBWindowManager.Instance.ShowWindow(FBWindowConst.F_window_main);
            FBWindowManager.Instance.ShowWindow(FBWindowConst.F_window_inventory);

            FBWindowManager.Instance.CloseWindow(FBWindowConst.F_window_select);
        }
        #endregion
    }//Class End
}
