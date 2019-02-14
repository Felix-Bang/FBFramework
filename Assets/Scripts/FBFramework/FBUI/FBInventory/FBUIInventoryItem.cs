// Felix-Bang：FBUIInventoryItem
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
using UnityEngine.UI;

namespace FelixBang
{
	public class FBUIInventoryItem : MonoBehaviour 
	{
        #region Fields/Properties
        private Text f_amountText;
        private Text f_nameText;
        private Image f_iocnImage;
        #endregion

        #region Methods
        public void RefreshItemUI(Sprite icon,string count,string name)
        {
            RefreshItemUI(icon, count);
            f_nameText.text = name;
        }

        public void RefreshItemUI(Sprite icon, string count)
        {
            RefreshItemUI(icon);
            f_amountText.text = count;
        }

        public void RefreshItemUI(Sprite icon)
        {
            f_iocnImage.sprite = icon;
        }
        #endregion
    }//Class End
}
