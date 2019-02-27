// Felix-Bang：CameraFollow
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
// Describe：相机跟随
// CreateTime：2019/02/27

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FelixBang.Jumper
{
	public class CameraFollow : MonoBehaviour 
	{
        #region Fields/Properties
        /// <summary> 跟随目标（角色Player）</summary>
        private Transform f_target;
        /// <summary> 偏移 </summary>
        private Vector3 f_offset;
        /// <summary> 当前速度，这个值在你访问这个函数的时候会被随时修改。 </summary>
        private Vector2 f_velocity;
		#endregion

		#region Constructor
		#endregion

		#region Unity	
		void Update () 
		{
            if (f_target == null && GameObject.FindGameObjectWithTag(DefineConst.Player_Tag) != null)
            {
                f_target = GameObject.FindGameObjectWithTag(DefineConst.Player_Tag).transform;
                f_offset = f_target.position - transform.position;
            }
		}

        private void FixedUpdate()
        {
            if (f_target != null)
            {
                float posX = Mathf.SmoothDamp(transform.position.x, f_target.position.x - f_offset.x, ref f_velocity.x, 0.05f);
                float posY = Mathf.SmoothDamp(transform.position.y, f_target.position.y - f_offset.y, ref f_velocity.y, 0.05f);

                if(posY>transform.position.y)
                    transform.position = new Vector3(posX, posY, transform.position.z);
            }
        }
        #endregion
    }//Class End
}
