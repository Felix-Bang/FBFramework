//  Felix-Bang：FBWindowType
//　　 へ　　　　　／|
//　　/＼7　　　 ∠＿/
//　 /　│　　 ／　／
//　│　Z ＿,＜　／　　 /`ヽ
//　│　　　　　ヽ　　 /　　〉
//　 Y　　　　　`　 /　　/
//　ｲ●　､　●　　⊂⊃〈　　/
//　()　 へ　　　　|　＼〈
//　　>ｰ ､_　 ィ　 │ ／／
//　 / へ　　 /　ﾉ＜| ＼＼
//　 ヽ_ﾉ　　(_／　 │／／
//　　7　　　　　　　|／
//　　＞―r￣￣`ｰ―＿
// Describe：窗体类型
// CreateTime：2018/12/20

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace FelixBang
{
    [Serializable]
    public class FBWindowType
    {
        public bool F_isClearStackData = false;
        /// <summary> Window存在方式 </summary>
        public FBUIExistType F_existType = FBUIExistType.Normal;
        /// <summary> Window显示方式 </summary>
        public FBUIShowModel F_showModel = FBUIShowModel.Normal;
        /// <summary> Window透明方式 </summary>
        public FBUILucency F_lucency = FBUILucency.Luceny;
	}
}
