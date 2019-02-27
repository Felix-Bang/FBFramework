// Felix-Bang：GameWindow
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
using UnityEngine.Events;
using UnityEngine.UI;

namespace FelixBang.Jumper
{
	public class GameWindow : BaseWindow
    {
        #region Fields/Properties
        private Button f_pauseBtn;
        private Button f_playBtn;
        private Text f_scoreTxt;
        private Text f_diamondTxt;
		#endregion

		#region Unity
		void Start () 
		{
            gameObject.SetActive(false);
            f_scoreTxt = FBFindUtility.GetChildComponent<Text>(transform, "Score_Txt");
            f_diamondTxt = FBFindUtility.GetChildComponent<Text>(transform, "Diamond_Txt");
            f_pauseBtn = RegistButtonClick("Pause_Btn", OnPauseBtnClick);
            f_playBtn = RegistButtonClick("Play_Btn", OnPlayBtnClick);
        }
	
        private void OnDestroy()
        {
            FBEventCenter.RemoveListener(FBEventDefine.ShowGameView, OnShow);
        }
        #endregion

        #region Methods
        public override void InitOnAwake()
        {
            base.InitOnAwake();
            ID = WindowID.Game;
            FBEventCenter.AddListener(FBEventDefine.ShowGameView, OnShow);
        }

        public override void OnShowHandle()
        {


            Spwner.Instance.InitPlatform();
            Spwner.Instance.CreatCharacter();

            GameManager.Instance.IsGameStart = true;
        }

        private void OnPauseBtnClick()
        {
            f_pauseBtn.gameObject.SetActive(false);
            f_playBtn.gameObject.SetActive(true);
        }

        private void OnPlayBtnClick()
        {
            f_pauseBtn.gameObject.SetActive(true);
            f_playBtn.gameObject.SetActive(false);
        }

       
        #endregion
    }//Class End
}
