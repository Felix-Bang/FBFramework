// Felix-Bang：FBMessageCenter
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
// CreateTime：2019/1/18

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FelixBang
{
    public class FBMessageCenter
    {
        #region Delegates/Action
        public delegate void MessageDeliveryDel(FBMessageKVModel kv);
        #endregion

        #region Properties/Fields
        public static Dictionary<string, MessageDeliveryDel> Messages_Dic = new Dictionary<string, MessageDeliveryDel>();
        #endregion

        #region MethodsRegister
        public static void RegisterMessage(string messageType, MessageDeliveryDel handler)
        {
            if (!Messages_Dic.ContainsKey(messageType))
                Messages_Dic.Add(messageType, null);

            Messages_Dic[messageType] += handler;
        }

        public static void CancelMessage(string messageType, MessageDeliveryDel handler)
        {
            if (Messages_Dic.ContainsKey(messageType))
                Messages_Dic[messageType] -= handler;
        }

        public static void CancelAllMessages()
        {
            if (Messages_Dic != null)
                Messages_Dic.Clear();
        }

        public static void SendMessage(string messageType, FBMessageKVModel kv)
        {
            MessageDeliveryDel del;
            if (Messages_Dic.TryGetValue(messageType, out del))
            {
                if (del != null)
                    del(kv);
            }
        }

        #endregion
    }//Class End
}
