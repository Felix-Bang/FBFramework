// Felix-Bang：FBMessageKVModel
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

namespace FelixBang
{
	public class FBMessageKVModel
	{
        private string f_key;

        private object f_value;

        public string Key
        {
            get { return f_key; }
        }

        public object Value
        {
            get { return f_value; }
        }

        public FBMessageKVModel(string key,object valueObj)
        {
            this.f_key = key;
            f_value = valueObj;
        }
    }//Class End
}
