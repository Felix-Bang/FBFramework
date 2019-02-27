// Felix-Bang：FBGameManager
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
// Describe：游戏管理
// CreateTime：2019/02/27

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FelixBang.Jumper
{
	public class GameManager : FBSingleton<GameManager> 
	{
        #region Delegates/Action
        #endregion

        #region Fields/Properties
        [SerializeField]
        private JumperResourcesContainer f_res;
        public JumperResourcesContainer Res
        {
            get { return f_res; }
        }

        [SerializeField]
        private Camera f_camera;
        [SerializeField]
        private SpriteRenderer f_background;
        [SerializeField]
        private Canvas f_canvas;

        private int f_level = 1;
        private int CurrentLevel
        {
            get { return f_level; }
            set
            {
                f_level = value;
                SetBackground();
            }
        }

        /// <summary> 游戏是否开始 </summary>
        public bool IsGameStart { get; set; }
        /// <summary> 游戏是否结束 </summary>
        public bool IsGameOver { get; set; }
		#endregion

		#region Unity
		void Start () 
		{
            SetBackground();
            WindowManager windowManager = WindowManager.Instance;
            windowManager.transform.SetParent(transform);
            windowManager.InitWindowDic(f_canvas.transform);

            Spwner spwner = Spwner.Instance;
            Spwner.Instance.InitSpwnerInfo(f_res);

            WindowManager.Instance.ShowWindow(WindowID.Home);
        }
        #endregion

        #region Interface
        #endregion

        #region Methods
        private void SetBackground()
        {
            f_background.sprite = f_res.BgThemeList[f_level];
        }

        public Sprite GetPlatTheme()
        {
            return f_res.PlatThemeList[f_level];
        }

        public Sprite GetCharacterTheme()
        {
            return f_res.CharacterSkinList[f_level];
        }
        #endregion
    }//Class End
}
