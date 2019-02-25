//  Felix-Bang：FBResourcesManager
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
// Describe：本功能是在Unity的Resources类的基础之上，增加了“缓存”的处理。
// CreateTime：2019/1/19
using UnityEngine;
using System.Collections;

namespace FelixBang
{
    public class FBResourcesManager : FBSingleton<FBResourcesManager>
    {
        #region Fields/Properties
        //容器键值对集合
        private Hashtable f_hashtable = null;                       
        #endregion

        void Start()
        {
            f_hashtable = new Hashtable();
        }

        #region Method
        /// <summary>
        /// 调用资源（带对象缓冲技术）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <param name="isCatch"></param>
        /// <returns></returns>
        public T LoadResource<T>(string path, bool isCatch) where T : UnityEngine.Object
        {
            if (f_hashtable.Contains(path))
                return f_hashtable[path] as T;

            T TResource = Resources.Load<T>(path);
            if (TResource == null)
                Debug.LogError(GetType() + "/GetInstance()/TResource 提取的资源找不到，请检查。 path=" + path);
            else if (isCatch)
                f_hashtable.Add(path, TResource);

            return TResource;
        }

        /// <summary>
        /// 调用资源（带对象缓冲技术）
        /// </summary>
        /// <param name="path"></param>
        /// <param name="isCatch"></param>
        /// <returns></returns>
        public GameObject LoadAsset(string path, bool isCatch)
        {
            GameObject goObj = LoadResource<GameObject>(path, isCatch);
            GameObject goObjClone = GameObject.Instantiate<GameObject>(goObj);

            if (goObjClone == null)
                Debug.LogError(GetType() + "/LoadAsset()/克隆资源不成功，请检查。 path=" + path);
            
            //goObj = null;//??????????
            return goObjClone;
        }
        #endregion
    }//Class_end
}