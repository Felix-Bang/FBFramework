//  Felix-Bang：FBSpriteFactory
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
// Describe：获取精灵集中的精灵
// CreateTime：2018/12/24

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FelixBang
{
	public class FBSpriteFactory
	{
        public static Sprite[] FBLoadSprites(string spritesName)
        {
            Sprite[] allSprites = Resources.LoadAll<Sprite>(spritesName);
            return allSprites;
        }
	}
}
