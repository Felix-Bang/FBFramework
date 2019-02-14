//  Felix-Bang：FBQulityUtility
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
// CreateTime：

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FelixBang
{
	public sealed class FBQulityUtility
	{
        #region 方法
        public static void SetQulity(int frameRate = 30, int vSyncCount = 0)
        {
            SetFPS(frameRate);
            SetVSync(vSyncCount);
        }

        private static void SetFPS(int frameRate = 30)
        {
            //设置targetFrameRate为-1（默认）使独立版游戏尽可能快的渲染
            Application.targetFrameRate = frameRate;
        }
    
        private static void SetVSync(int count=0)
        {
            // VSyncs数值需要在每帧之间传递，使用0为不等待垂直同步。值必须是0，1或2。
            QualitySettings.vSyncCount = count;
        }
        #endregion
	}
}
