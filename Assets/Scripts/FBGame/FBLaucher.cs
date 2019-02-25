//  Felix-Bang：FBLaucher
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
// Describe：启动器
// CreateTime：2017/12/20

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FelixBang
{
	public class FBLaucher : FBSingleton<FBLaucher>
	{
        #region Unity回调
        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneWasLoaded;
        }

        void Start () 
		{
            DontDestroyOnLoad(gameObject);
            FBDebug.IsDebug = true;
            //设置游戏性能相关
            FBQulityUtility.SetQulity(30, 0);

            CreatManagers();

            FBWindowManager.Instance.ShowWindow(FBWindowConst.F_window_login);
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneWasLoaded;
        }
        #endregion

        #region 方法
        private void CreatManagers()
        {
            FBWindowManager windowManager = FBWindowManager.Instance;
            windowManager.transform.SetParent(transform);

            FBTimerManager timerManager = FBTimerManager.Instance;
            timerManager.transform.SetParent(transform);

            FBInventoryManager inventoryManager = FBInventoryManager.Instance;
            inventoryManager.transform.SetParent(transform);
        }

        /// <summary>
        /// 加载场景
        /// </summary>
        /// <param name="index">场景索引</param>
        public void LoadScene(int index,Action exitAction)
        {
            //退出旧场景
            //事件参数
            FBSceneArgs e = new FBSceneArgs
            {
                Index = SceneManager.GetActiveScene().buildIndex
            };
            
            //发布事件
        

            //加载新场景
            SceneManager.LoadScene(index, LoadSceneMode.Single);
        }



        private void OnSceneWasLoaded(Scene arg0, LoadSceneMode arg1)
        {
            Debug.Log("加载场景");
        }


        #endregion
    }
}
