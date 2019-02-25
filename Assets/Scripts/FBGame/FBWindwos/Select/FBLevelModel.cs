// Felix-Bang：FBLevelModel
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FelixBang
{
    public class FBLevelModel
    {


        #region Fields/Properties
        public uint ID { get; set; }
        public string Name { get; set; }
        public string Describe { get; set; }
        public int Level { get; set; }
        public bool IsLock { get; set; }
        public string SpriteName { get; set; }

        private Sprite f_sprite;
        public Sprite Sprite
        {
            get
            {
                if (f_sprite == null)
                {
                    string path = "Sprites/Level/" + SpriteName;
                    f_sprite = Resources.Load<Sprite>(path);
                }

                return f_sprite;
            }
        }
        #endregion

        #region Constructor
        #endregion



        #region Interface
        #endregion

        #region Methods
        public string GetLevel()
        {
            return Level.ToString();
        }
        public Sprite GetSprite()
        {
            return null;
        }
		#endregion
	}//Class End
}
