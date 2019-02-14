//  Felix-Bang：FBSingleton
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
// Describe：单例
// Createtime：2018/11/16

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FelixBang
{
	public class FBSingleton<T> : MonoBehaviour where T: MonoBehaviour
    {
        #region 字段
        private static T f_instance = null;
        private static readonly object f_Lock = new object();
        private static bool f_applicationIsQuitting = false;
        #endregion

        #region 属性
        public static T Instance
        {
            get
            {
                if (f_applicationIsQuitting)
                {
                    FBDebug.LogWarning("[FBSingleton]F_Instance " + typeof(T).Name + 
                        " already destoryed on application quit." + 
                        "Won't creat again-returning null!");

                    return null;
                }

                lock (f_Lock)
                {
                    if (f_instance == null)
                        f_instance = FindObjectOfType<T>();

                    if (FindObjectsOfType<T>().Length > 1)
                    {
                        FBDebug.LogWarning("[FBSingleton]Something went really wrong,there should never be more than one singleton!");
                        return f_instance;
                    }

                    if (f_instance == null)
                    {
                        string singletonName = typeof(T).Name;
                        GameObject singleton = GameObject.Find(singletonName);
                        if (singleton == null)
                            singleton = new GameObject();

                        f_instance = singleton.AddComponent<T>();
                        singleton.name = "(Singleton)" + typeof(T).Name;

                        DontDestroyOnLoad(singleton);
                    }
                    else
                    {
                        //FBDebug.Log("Already exist: " + f_instance.name);
                    }

                    return f_instance;
                }
            }
        }
        #endregion

        public void OnDestroy()
        {
            f_applicationIsQuitting = true;
        }
    }
}
