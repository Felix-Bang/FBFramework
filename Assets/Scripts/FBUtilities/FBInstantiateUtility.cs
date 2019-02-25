// Felix-Bang：FBInstantiateUtility
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
	public class FBInstantiateUtility : MonoBehaviour 
	{





        /// <summary>
        /// 实例化预制件到场景中
        /// </summary>
        /// <param name="parent">父物体Trans</param>
        /// <param name="prefab">预制件</param>
        /// <param name="pos">自定义位置</param>
        /// <param name="scale">自定义缩放</param>
        /// <returns></returns>
        public static GameObject CreatPrefab(Transform parent, string path, Vector3 pos, Vector3 scale)
        {
            GameObject go = CreatPrefab(parent, path);

            if (go != null)
            {
                go.transform.localPosition = pos;
                go.transform.localScale = scale;
            }

            return go;
        }

        /// <summary>
        /// 实例化预制件到场景中
        /// </summary>
        /// <param name="parent">父物体</param>
        /// <param name="prefab">预制件</param>
        /// <returns></returns>
        public static GameObject CreatPrefab(Transform parent, string path)
        {
            GameObject prefab = Resources.Load<GameObject>(path);
            GameObject go = Instantiate(prefab);
           
            if(go!=null)
            {
                Transform t = go.transform;
                t.SetParent(parent);
                t.localPosition = Vector3.zero;
                t.localRotation = Quaternion.identity;
                t.localScale = Vector3.one;

                go.layer = parent.gameObject.layer;
                go.name = prefab.name;
            }

            return go;
        }

        public static GameObject CreatPrefab(string path)
        {
            GameObject prefab = Resources.Load<GameObject>(path);
            GameObject go = Instantiate(prefab);

            if (go != null)
            {
                Transform t = go.transform;
                t.localPosition = Vector3.zero;
                t.localRotation = Quaternion.identity;
                t.localScale = Vector3.one;

                go.name = prefab.name;
            }

            return go;
        }


    }//Class End
}
