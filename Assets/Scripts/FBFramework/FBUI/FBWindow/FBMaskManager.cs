// Felix-Bang：FBMaskManager
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
	public class FBMaskManager : FBSingleton<FBMaskManager> 
	{
        #region Fields/Properties
        private GameObject f_canvas = null;
        private GameObject f_topPanel;
        private GameObject f_maskPanel;
        private Camera f_uiCamera;
        private float f_originalDepth;        //摄像机原始深度
		#endregion

		#region Unity
		void Awake () 
		{
            f_canvas = GameObject.FindGameObjectWithTag(FBWindowDefine.F_tag_canvas);
            f_topPanel = f_canvas;
            f_maskPanel = FBFindUtility.FindChildByName(f_canvas.transform, FBWindowDefine.F_node_mask);
            f_uiCamera = GameObject.FindGameObjectWithTag(FBWindowDefine.F_tag_uicamera).GetComponent<Camera>();
            if (f_uiCamera != null)
                f_originalDepth = f_uiCamera.depth;
            else
                Debug.LogError("The uicamera is missing!");

        }
        #endregion

        #region Methods
        /// <summary>
        /// 显示遮罩
        /// </summary>
        /// <param name="topWindow">需要置顶窗体</param>
        /// <param name="luncy">透明度属性</param>
        public void FBShowMask(GameObject topWindow,FBUILucency luncy=FBUILucency.Luceny)
        {
            //canvas移动到最前位置（最下层）
            f_topPanel.transform.SetAsLastSibling();
            //遮罩（MaskWindow）显示以及透明属性设置
            switch (luncy)
            {
                case FBUILucency.Luceny:
                    FbSetShowMask(true, FBWindowDefine.F_maskRGB_luceny, FBWindowDefine.F_maskA_luceny);
                    break;
                case FBUILucency.TraLucency:
                    FbSetShowMask(true, FBWindowDefine.F_maskRGB_traLucency, FBWindowDefine.F_maskA_traLucency);
                    break;
                case FBUILucency.LowLucency:
                    FbSetShowMask(true, FBWindowDefine.F_maskRGB_lowLucency, FBWindowDefine.F_maskA_lowLucency);
                    break;
                case FBUILucency.Penetrate:
                    FbSetShowMask(false);
                    break;
                default:
                    break;
            }

            //遮罩（MaskWindow）移动
            f_maskPanel.transform.SetAsLastSibling();
            //显示窗体（topWindow）移动
            topWindow.transform.SetAsLastSibling();
            //调节UICamera的深度（保证当前摄像机最前显示）
            if (f_uiCamera != null)
                f_uiCamera.depth = f_originalDepth + 100;
        }

        /// <summary> 隐藏遮罩 </summary>
        public void FBHideMask()
        {
            f_topPanel.transform.SetAsFirstSibling();
            //禁用遮罩
            if (f_maskPanel.activeInHierarchy)
                f_maskPanel.SetActive(false);
            //还原摄像机深度
            if (f_uiCamera != null)
                f_uiCamera.depth = f_originalDepth;
        }

        private void FbSetShowMask(bool isShow, float rgb = 0, float a = 0)
        {
            if (isShow)
            {
                f_maskPanel.SetActive(isShow);
                f_maskPanel.GetComponent<Image>().color = new Color(rgb, rgb, rgb, a);
            }
            else
            {
                if (f_maskPanel.activeInHierarchy)
                    f_maskPanel.SetActive(false);
            }
        }
        #endregion
    }//Class End
}
