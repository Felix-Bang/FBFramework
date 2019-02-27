// Felix-Bang：FBPlatformSpwner
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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FelixBang.Jumper
{
	public class Spwner : FBSingleton<Spwner>
	{
        #region Fields/Properties
        private JumperResourcesContainer f_res;

        //生成平台的数量
        private int f_spawnCount;
        private Vector3 f_spawnPos;
        private bool f_isLeft = false;
		#endregion

		#region Unity
        public override void OnDestroy()
        {
            base.OnDestroy();
        }
        #endregion

        #region Methods
        public void InitSpwnerInfo(JumperResourcesContainer resContainer)
        {
            f_res = resContainer;
            f_spawnPos = f_res.PlatStartPos;
            f_spawnCount = f_res.PlatInitCount;
        }

        public void CreatCharacter()
        {
            GameObject go= FBInstantiateUtility.CreatPrefabInWorldSpace(f_res.CharacterPfb,f_res.CharacterStartPos);

        }

        public void InitPlatform()
        {
            for (int i = 0; i < f_res.PlatInitCount; i++)
                CreatPlats();
        }

        public void CreatPlats()
        {
            if (f_spawnCount > 0)
                f_spawnCount--;
            else
            {
                f_isLeft = !f_isLeft;
                f_spawnCount = UnityEngine.Random.Range(1, 5);
            }

            SpawnPlatform();
        }

        private void SpawnPlatform()
        {
            SpawnNormalPlatform();

            if (f_isLeft)
                f_spawnPos = new Vector3(f_spawnPos.x - f_res.DeltaPlat.x, f_spawnPos.y + f_res.DeltaPlat.y, 0);
            else
                f_spawnPos = new Vector3(f_spawnPos.x + f_res.DeltaPlat.x, f_spawnPos.y + f_res.DeltaPlat.y, 0);
        }

        private void SpawnNormalPlatform()
        {
           GameObject go = FBInstantiateUtility.CreatPrefabInWorldSpace(f_res.PlatPfb, f_spawnPos, transform);
            Plat plat = go.GetComponent<Plat>();
            plat.InitPlat(GameManager.Instance.GetPlatTheme());
        }
        #endregion
    }//Class End
}
