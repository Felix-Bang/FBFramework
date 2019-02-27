// Felix-Bang：Plat
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

namespace FelixBang.Jumper
{
	public class Plat : MonoBehaviour 
	{
        #region Delegates/Action
        #endregion

        #region Fields/Properties
        private int f_level;
        
        private SpriteRenderer f_platSprite;
        private bool f_isInitWidget = false;
		#endregion

		#region Constructor
		#endregion

		#region Unity
		void Awake () 
		{
			
		}

		void Start () 
		{
			
		}
	
		void Update () 
		{
			
		}
		#endregion

		#region Interface
		#endregion
		
		#region Methods
        public void InitPlat(Sprite sprite)
        {
            if (!f_isInitWidget)
                InitWidget();

            
            f_platSprite.sprite = sprite;
        }

        private void InitWidget()
        {
            f_platSprite = FBFindUtility.GetChildComponent<SpriteRenderer>(transform, "Platform");
            f_isInitWidget = true;
        }
		#endregion
	}//Class End
}
