// Felix-Bang：FBVarsManager
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
// Describe：游戏资源管理
// CreateTime：2019/02/27

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FelixBang.Jumper
{
    [CreateAssetMenu(menuName = "CreatJumperContainer")]
	public class JumperResourcesContainer : ScriptableObject 
	{
        #region Fields/Properties
        /// <summary> 背景主题 </summary>
        public List<Sprite> BgThemeList = new List<Sprite>();
        /// <summary> 角色预制件 </summary>
        public GameObject CharacterPfb;
        /// <summary> 角色初始位置 </summary>
        public Vector3 CharacterStartPos;
        /// <summary> 台阶预制件 </summary>
        public GameObject PlatPfb;
        /// <summary> 台阶间隔 </summary>
        public Vector2 DeltaPlat = new Vector2(0.554f, 0.645f);
        /// <summary> 台阶初始位置 </summary>
        public Vector3 PlatStartPos;
        /// <summary> 初始化台阶个数 </summary>
        public int PlatInitCount = 5;

        /// <summary> 台阶主题 </summary>
        public List<Sprite> PlatThemeList = new List<Sprite>();
        /// <summary> 角色主题 </summary>
        public List<Sprite> CharacterSkinList = new List<Sprite>();

        #endregion

    }//Class End

    
}
