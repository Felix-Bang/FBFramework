// Felix-Bang：FBComponentPool
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
// Describe：ComponentPool
// CreateTime：2019/2/15

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace FelixBang
{
    public class FBComponentPool<T> : FBPoolBase<T> where T : class, IFBPoolable
    {
        private static List<IFBPoolable> _interfaceCache = new List<IFBPoolable>();


        public FBComponentPool(T baseObject, int startSize = 32)
            : base(baseObject, startSize)
        {

        }

        public override T Instantiate()
        {
            var obj = UnityEngine.Object.Instantiate<GameObject>(BaseObject.gameObject);

            obj.transform.SetParent(RootObject);
            obj.gameObject.SetActive(false); // Start disabled

            var c = obj.GetComponent<T>();
            InactiveObjectsPool.Add(c);
            return c;
        }
        
        public override T Get(bool createWhenNoneLeft = true)
        {
            T item = null;
            if (InactiveObjectsPool.Count == 0)
            {
                if (createWhenNoneLeft)
                {
                    FBDebug.Log("New object created, considering increasing the pool size if this is logged often");
                    item = Instantiate();
                }
            }
            else
            {
                item = InactiveObjectsPool[InactiveObjectsPool.Count - 1];
            }

            Assert.IsNotNull(item, "Couldn't get poolable object from pool!");
            item.gameObject.SetActive(true);
            item.gameObject.transform.localScale = Vector3.one;
            item.gameObject.transform.localRotation = Quaternion.identity;

            ActiveObjectsList.Add(item);
            InactiveObjectsPool.RemoveAt(InactiveObjectsPool.Count - 1);

            return item;
        }

        public override void Destroy(T item)
        {
            item.gameObject.transform.SetParent(RootObject);
            item.gameObject.SetActive(false); // Up for reuse

            item.gameObject.GetComponents<IFBPoolable>(_interfaceCache);
            foreach (var c in _interfaceCache)
            {
                c.ResetStateForPool();
            }

            InactiveObjectsPool.Add(item);
            ActiveObjectsList.Remove(item);
        }
    }
}
