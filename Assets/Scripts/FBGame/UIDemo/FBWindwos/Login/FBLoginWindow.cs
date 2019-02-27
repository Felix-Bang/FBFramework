// Felix-Bang：FBLoginWindow
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
// CreateTime：2019/1/21

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace FelixBang
{
	public class FBLoginWindow : FBWindow
    {
        #region Fields/Properties
        private CanvasGroup f_idGroup;
        private CanvasGroup f_loginGroup;
        private CanvasGroup f_signGroup;

        private InputField f_loginUser_input;
        private InputField f_loginPassword_input;

        private InputField f_signUser_input;
        private InputField f_signPassword_input;
        private InputField f_confirmPassword_input;

        private Animator f_anima;

        [SerializeField]
        private Motion f_showIDMotion;
        [SerializeField]
        private Motion f_visitorMotion;
        [SerializeField]
        private Motion f_quitMotion;
        [SerializeField]
        private Motion f_signupMotion;
        [SerializeField]
        private Motion f_backMotion;
        #endregion

        #region Unity

        void Start () 
		{
            f_idGroup = FBFindUtility.GetChildComponent<CanvasGroup>(transform, "ID_Panel");
            f_loginGroup = FBFindUtility.GetChildComponent<CanvasGroup>(transform, "Login_Panel");
            f_signGroup = FBFindUtility.GetChildComponent<CanvasGroup>(transform, "Signup_Panel");

            //------------------------------ID------------------------------------
            RegisterButtonClickEvent("Single_Btn", obj => SwitchWindow(FBWindowConst.F_window_start));
            RegisterButtonClickEvent("Visitor_Btn", obj => PlayMotion(f_anima, f_visitorMotion));
            RegisterButtonClickEvent("WeChat_Btn", obj => SwitchWindow(FBWindowConst.F_window_start));
            RegisterButtonClickEvent("QQ_Btn", obj => SwitchWindow(FBWindowConst.F_window_start));

            //------------------------------Login------------------------------------
            f_loginUser_input = FBFindUtility.GetChildComponent<InputField>(f_loginGroup.transform, "L_Userame_Input");
            f_loginPassword_input = FBFindUtility.GetChildComponent<InputField>(f_loginGroup.transform, "L_Password_Input");

            RegisterButtonClickEvent("Login_Btn", obj => OnLogin());
            RegisterButtonClickEvent("L_Signup_Btn", obj => PlayMotion(f_anima, f_signupMotion));
            RegisterButtonClickEvent("Quit_Btn", obj => PlayMotion(f_anima, f_quitMotion));

            //------------------------------Signup------------------------------------
            f_signUser_input = FBFindUtility.GetChildComponent<InputField>(f_signGroup.transform, "S_Userame_Input");
            f_signPassword_input = FBFindUtility.GetChildComponent<InputField>(f_signGroup.transform, "S_Password_Input");
            f_confirmPassword_input = FBFindUtility.GetChildComponent<InputField>(f_signGroup.transform, "Confirm_Input");

            RegisterButtonClickEvent("S_Signup_Btn", obj => OnSignUp());
            RegisterButtonClickEvent("Back_Btn", obj => PlayMotion(f_anima, f_backMotion));
           
        }
        #endregion

        #region Methods
        protected override void InitWindowOnAwake()
        {
            WindowName = FBWindowConst.F_window_login;
            f_anima = GetComponent<Animator>();
        }

        private void OnLogin()
        {
            string userName = f_loginUser_input.text;
            string password = f_loginPassword_input.text;

            SwitchWindow(FBWindowConst.F_window_start);
        }

        private void OnSignUp()
        {
            string userName = f_signUser_input.text;
            string password = f_signPassword_input.text;
            string confirm = f_confirmPassword_input.text;

            f_loginUser_input.text = userName;
            f_loginPassword_input.text= f_signPassword_input.text;

            PlayMotion(f_anima, f_backMotion);

            f_signUser_input.text=string.Empty;
            f_signPassword_input.text = string.Empty;
            f_confirmPassword_input.text = string.Empty;
        }

        //private void PlayMotion(Motion motion)
        //{
        //    int hash = Animator.StringToHash(motion.name);
        //    f_anima.Play(hash);
        //}

        public override void OnReset()
        {
            ResetCanvasGroup(f_idGroup);
            
            ResetCanvasGroup(f_loginGroup);
            ResetCanvasGroup(f_signGroup);
        }

        private void ResetCanvasGroup(CanvasGroup group)
        {
            group.alpha = 0;
            group.interactable = false;
            group.blocksRaycasts = false;
        }


        #endregion
    }//Class End
}
