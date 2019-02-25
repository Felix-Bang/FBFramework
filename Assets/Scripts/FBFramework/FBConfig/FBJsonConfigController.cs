// Felix-Bang：FBJsonConfigManager
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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FelixBang
{
	public class FBJsonConfigController : IFBConfig 
	{
        #region Properties/Fields
        private static Dictionary<string, string> f_configFiles_dic;
        #endregion

        #region Constructor
        public FBJsonConfigController(string path)
        {
            f_configFiles_dic = new Dictionary<string, string>();

            if (string.IsNullOrEmpty(path)) return;
            try
            {
                TextAsset asset = Resources.Load<TextAsset>(path);
                InitJson(asset.text);
            }
            catch
            {
                throw new FBConfigException(GetType() + "/FBJsonConfigManager()/json analysis exception! path: " + path);
            }
        }
        #endregion



        #region Interface
        public Dictionary<string, string> ConfigFiles_Dic
        {
            get { return f_configFiles_dic; }
        }

        public int GetConfigFilesMaxNumber()
        {
            if (f_configFiles_dic != null && f_configFiles_dic.Count > 0)
                return f_configFiles_dic.Count;
            else
                return 0;
        }
        #endregion

        #region Methods
        private void InitJson(string jsonStr)
        {
            FBConfigKVInfo jsonInfo = JsonUtility.FromJson<FBConfigKVInfo>(jsonStr);

            foreach (FBConfigKVModel kv in jsonInfo.KeyValueList)
                f_configFiles_dic.Add(kv.Key, kv.Value);
        }
        #endregion
    }//Class End
}
