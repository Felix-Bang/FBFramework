// Felix-Bang：FBIntroWindow
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FelixBang
{
	public class FBIntroWindow : FBWindow
    {
       
        #region Unity
		void Start () 
		{
            RegisterButtonClickEvent("Close_Button", p => CloseWindow(FBWindowConst.F_window_intro));
            RegisterButtonClickEvent("UI_Button", p =>
             {
                 OpenWindow(FBWindowConst.F_window_more);
                 string content = "UI即User Interface（用户界面）的简称。泛指用户的操作界面，包含移动APP，网页，智能穿戴设备等。UI设计主要指界面的样式，美观程度。而使用上，对软件的人机交互、操作逻辑、界面美观的整体设计则是同样重要的另一个门道。";
                 SendMessage("More", "UI", content);
             });

            RegisterButtonClickEvent("Framework_Button", p =>
            {
                OpenWindow(FBWindowConst.F_window_more);
                string content = "框架（Framework）是整个或部分系统的可重用设计，表现为一组抽象构件及构件实例间交互的方法。";
                SendMessage("More", "Framework", content);
            });

            RegisterButtonClickEvent("DesignPattern_Button", p =>
            {
                OpenWindow(FBWindowConst.F_window_more);
                string content = "设计模式（Design Pattern）是一套被反复使用、多数人知晓的、经过分类的、代码设计经验的总结。";
                SendMessage("More", "DesignPattern", content);
            });
        }

        #endregion

        #region Method
        //------------------ override -----------------------
        protected override void InitWindowOnAwake()
        {
            WindowType.F_existType = FBUIExistType.Popup;
            WindowType.F_lucency = FBUILucency.TraLucency;
            WindowType.F_showModel = FBUIShowModel.ReverseSwitch;
        }


        #endregion

    }//Class End
}
