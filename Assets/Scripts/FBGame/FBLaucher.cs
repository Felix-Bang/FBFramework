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


namespace FelixBang
{
	public class FBLaucher : FBSingleton<FBLaucher>
	{
        #region Unity回调
        private void Awake()
        {
            
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
        #endregion

        #region 方法
        private void CreatManagers()
        {
            FBWindowManager windowManager = FBWindowManager.Instance;
            windowManager.transform.SetParent(transform);

            FBInventoryManager inventoryManager = FBInventoryManager.Instance;
            inventoryManager.transform.SetParent(transform);



        }
        #endregion
    }
}
