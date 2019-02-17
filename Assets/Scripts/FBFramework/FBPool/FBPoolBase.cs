// Felix-Bang：FBPoolBase
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
// Describe：Base for pool
// CreateTime：2019/2/15

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace FelixBang
{
    public abstract class FBPoolBase<T> : IEnumerable<T>
    {
        public List<T> InactiveObjectsPool { get; protected set; }
        public List<T> ActiveObjectsList { get; protected set; } 
        public Transform RootObject { get; protected set; }
        public T BaseObject { get; protected set; }
        public int StartSize { get; protected set; }

        protected FBPoolBase(T baseObject, int startSize = 32)
        {
            this.BaseObject = baseObject;
            this.StartSize = startSize;
            this.ActiveObjectsList = new List<T>(startSize);
            InactiveObjectsPool = new List<T>(startSize);

            RootObject = new GameObject("PoolRoot").transform;
            RootObject.transform.SetParent(FBLaucher.Instance.transform);

            Init();
        }

        private void Init()
        {
            for (int i = 0; i < StartSize; i++)
                Instantiate();
        }

        public abstract T Instantiate();

        public abstract T Get(bool createWhenNoneLeft = true);

        public abstract void Destroy(T item);

        public void DestroyAll()
        {
            int c = 0;
            while(ActiveObjectsList.Count > 0 && c++ < StartSize)
                Destroy(ActiveObjectsList[0]);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ActiveObjectsList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
