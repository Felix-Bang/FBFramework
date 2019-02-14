//  Felix-Bang：FBFindUtility
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
// Describe：查找工具
// Createtime：2018/11/19

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FelixBang
{
	public class FBFindUtility : MonoBehaviour
	{
        #region 方法

        /// <summary>
        /// 查找父物体trans下的所以子物体
        /// </summary>
        /// <param name="trans">父物体的Transform</param>
        /// <returns></returns>
        public static List<Transform> FindAllChidren(Transform trans)
        {
            var list = new List<Transform>();
            int childrenLength = trans.childCount;

            for (int i = 0; i < trans.childCount; i++)
            {
                list.Add(trans.GetChild(i));
               
                if (trans.GetChild(i).childCount > 0)
                {
                   list.AddRange(FindAllChidren(trans.GetChild(i)));
                }
            }

            return list;
        }

        /// <summary>
        /// 根据名称查找子物体
        /// </summary>
        /// <param name="trans">父物体的Transform</param>
        /// <param name="childName">目标子物体的名称</param>
        /// <returns></returns>
        public static GameObject FindChildByName(Transform trans, string childName)
        {
            Transform child = trans.Find(childName);

            if (child != null)
                return child.gameObject;

            int count = trans.childCount;
            GameObject go = null;

            for (int i = 0; i < count; ++i)
            {
                child = trans.GetChild(i);
                go = FindChildByName(child, childName);

                if (go != null)
                    return go;
            }

            return null;
        }

        /// <summary>
        /// 获取子物体的脚本
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="trans">父物体的Transform</param>
        /// <param name="childName">目标子物体的名称</param>
        /// <returns></returns>
        public static T GetChildComponent<T>(Transform trans, string childName) where T:Component
        {
            GameObject child=FindChildByName(trans,childName);

            if (child == null)
                return null;

            return child.GetComponent<T>();
        }

        /// <summary>
        /// 为子物体添加脚本
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="trans">父物体的Transform</param>
        /// <param name="childName">目标子物体的名称</param>
        /// <returns></returns>
        public static T AddComponentToChild<T>(Transform trans, string childName) where T : Component
        {
            GameObject child = FindChildByName(trans, childName);

            if (child == null)
                return null;

            T[] components = child.GetComponentsInChildren<T>();
            for (int i = 0; i < components.Length; i++)
            {
                if (components[i] != null)
                    Destroy(components[i]);
            }

            return child.AddComponent<T>();
        }

      
        #endregion
    }
}
