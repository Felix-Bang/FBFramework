// Felix-Bang：FBGameObjectPool
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
// Describe：GameObjectPool
// CreateTime：2019/2/15

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace FelixBang
{
    public class FBGameObjectPool : FBPoolBase<GameObject>
    {
        private static List<IFBPoolable> f_interfaceCache = new List<IFBPoolable>();

        public FBGameObjectPool(GameObject prefab, int startSize = 32)
            : base(prefab, startSize)
        {
        }

        public override GameObject Instantiate()
        {
            var obj = UnityEngine.Object.Instantiate(BaseObject);

            obj.transform.SetParent(RootObject);
            obj.gameObject.SetActive(false); // Start disabled
            
            InactiveObjectsPool.Add(obj);
            return obj;
        }

        public override GameObject Get(bool createWhenNoneLeft = true)
        {
            GameObject obj = null;
            if (InactiveObjectsPool.Count == 0)
            {
                if (createWhenNoneLeft)
                {
                    FBDebug.Log("New object created, considering increasing the pool size if this is logged often");
                    obj = Instantiate();
                }
            }
            else
            {
                obj = InactiveObjectsPool[InactiveObjectsPool.Count - 1];
            }

            Assert.IsNotNull(obj, "Couldn't get poolable object from pool!");
            obj.gameObject.SetActive(true);
            obj.gameObject.transform.localScale = Vector3.one;
            obj.gameObject.transform.localRotation = Quaternion.identity;

            ActiveObjectsList.Add(obj);
            InactiveObjectsPool.RemoveAt(InactiveObjectsPool.Count - 1);

            return obj;
        }

        public override void Destroy(GameObject obj)
        {
            obj.transform.SetParent(RootObject);
            obj.SetActive(false); // Up for reuse

            obj.GetComponents<IFBPoolable>(f_interfaceCache);
            foreach (var component in f_interfaceCache)
            {
                component.ResetStateForPool();
            }

            InactiveObjectsPool.Add(obj);
            ActiveObjectsList.Remove(obj);
        }
    }
}
