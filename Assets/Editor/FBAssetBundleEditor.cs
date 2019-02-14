//  Felix-Bang：FBAssetBundleEditor
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
// Describe：
// CreateTime：2018/12/25

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace FelixBang
{
	public class FBAssetBundleEditor
	{
        #region 常量
        #endregion
        #region 字段
        #endregion

        #region 方法
        [MenuItem("FelixBang/FBAssetBundle/Build")]
        public static void FBBuildeAssetBundle()
        {
            string outPath = Application.dataPath + "/AssetBundle";
            BuildPipeline.BuildAssetBundles(outPath, 0,EditorUserBuildSettings.activeBuildTarget);
        }

        [MenuItem("FelixBang/FBAssetBundle/Mark")]
        public static void FBMarkAssetBundle()
        {
            AssetDatabase.RemoveUnusedAssetBundleNames();
            string path = Application.dataPath + "/Arts/Prefabs";
            DirectoryInfo dir = new DirectoryInfo(path);
            FileSystemInfo[] fileInfos = dir.GetFileSystemInfos();
            for (int i = 0; i < fileInfos.Length; i++)
            {
                FileSystemInfo file = fileInfos[i];
                if (file is DirectoryInfo)
                {
                    string filePath = Path.Combine(path, file.Name);

                }
            }

        }

      
        #endregion
	}//Class End
}
