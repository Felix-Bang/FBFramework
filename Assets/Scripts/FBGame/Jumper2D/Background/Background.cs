// Felix-Bang：FBBgTheme
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
// Describe：背景主题
// CreateTime：2019/02/27

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FelixBang.Jumper
{
	public class Background : MonoBehaviour 
	{
        #region Fields/Properties
        [SerializeField]
        private JumperResourcesContainer f_res;
        private SpriteRenderer f_sprite;
		#endregion

		#region Unity
		void Awake () 
		{
            f_sprite = GetComponent<SpriteRenderer>();
            int index = Random.Range(0, f_res.BgThemeList.Count);

            f_sprite.sprite = f_res.BgThemeList[index];
        }
		#endregion
	}//Class End
}
