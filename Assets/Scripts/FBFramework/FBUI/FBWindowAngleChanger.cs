//  Felix-Bang：FBWindowAngleChanger
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
// Describe：控制3DWindow的旋转角度
// CreateTime：2018/01/13

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FelixBang
{
	public class FBWindowAngleChanger : MonoBehaviour
	{
        #region 字段
        private RectTransform f_rectTransform;
        private Vector2 f_prevPosition;

        public Vector2 F_angleEffect = new Vector2(20, 20);
        #endregion

        #region 生命周期
        void Awake()
        {
            f_rectTransform = GetComponent<RectTransform>();
        }

        void Start()
	    {
            SetAngleBasedOnPosition();
        }
	
	    void Update()
	    {
            if (WindowMoved(f_prevPosition, f_rectTransform.anchoredPosition))
            {
                f_prevPosition = f_rectTransform.anchoredPosition;
                SetAngleBasedOnPosition();
            }
	    }
        #endregion

        #region 方法
        private bool WindowMoved(Vector2 posA, Vector2 posB)
        {
            float x = Mathf.Abs(posA.x - posB.x);
            float y = Mathf.Abs(posA.y - posB.y);
            return x > 0.1f || y > 0.1f;
        }

        private void SetAngleBasedOnPosition()
        {
            Vector3[] corners = new Vector3[4];
            f_rectTransform.GetWorldCorners(corners);          

            float x = corners.Average(o => o.x);
            float y = corners.Average(o => o.y);
            var center = new Vector2(x, y);

            var normalizedPos = center / 10f;
            //float xAngle = normalizedPos.y * F_angleEffect.y;
            //float yAngle = normalizedPos.x * F_angleEffect.x;

            //if (Mathf.Abs(xAngle) >= 45)
            //{
            //    if (xAngle > 0)
            //        xAngle = -45;
            //    else
            //        xAngle = 45;
            //}
            //else
            //    xAngle = -xAngle;

            //if (Mathf.Abs(yAngle) >= 45)
            //{
            //    if (yAngle > 0)
            //        yAngle = 45;
            //    else
            //        yAngle = -45;
            //}

            //f_rectTransform.localRotation = Quaternion.Euler(xAngle, yAngle, 0f);

            f_rectTransform.localRotation = Quaternion.Euler(-normalizedPos.y * F_angleEffect.y, normalizedPos.x * F_angleEffect.x, 0f);

        }
        #endregion
    }//Class End
}
