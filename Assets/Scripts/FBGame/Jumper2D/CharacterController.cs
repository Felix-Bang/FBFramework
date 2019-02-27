// Felix-Bang：CharacterController
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
// Describe：角色控制
// CreateTime：2019/02/27

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace FelixBang.Jumper
{
	public class CharacterController : MonoBehaviour 
	{
        #region Fields/Properties
        private SpriteRenderer f_skin;
       
        //跳跃方向
        private bool f_isMoveToLeft;
        //当前是否正在跳跃
        private bool f_isJumping= false; 
        //左跳目标位置
        private Vector3 f_nextLeftPlatformPos;
        //右跳目标位置
        private Vector3 f_nextRightPlatformPos;
        #endregion

        #region Unity
        private void Start()
        {
            SetSkin();
        }


        void Update()
        {
            if (!GameManager.Instance.IsGameStart || GameManager.Instance.IsGameOver)
                return;

            if (Input.GetMouseButtonDown(0) && !f_isJumping)
            {
                Spwner.Instance.CreatPlats();

                f_isJumping = true;
                Vector3 mousePos = Input.mousePosition;
                f_isMoveToLeft = mousePos.x < Screen.width * 0.5f;

                Jump();
            }
        }
        #endregion

        #region Methods
        public void SetSkin()
        {
            if (f_skin == null)
                f_skin = GetComponent<SpriteRenderer>();

            f_skin.sprite = GameManager.Instance.GetCharacterTheme();
        }

        private void Jump()
        {
            if (f_isMoveToLeft)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                transform.DOMoveX(f_nextLeftPlatformPos.x, 0.2f);
                transform.DOMoveY(f_nextLeftPlatformPos.y + 0.8f, 0.2f);
            }
            else
            {
                transform.localScale = Vector3.one;
                transform.DOMoveX(f_nextRightPlatformPos.x, 0.2f);
                transform.DOMoveY(f_nextRightPlatformPos.y + 0.8f, 0.2f);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Vector3 currentPlatformPos;
            if (collision.tag == DefineConst.Plat_Tag)
            {
                f_isJumping = false;
                currentPlatformPos = collision.gameObject.transform.position;
                JumperResourcesContainer f_res = GameManager.Instance.Res;
                f_nextLeftPlatformPos = new Vector3(currentPlatformPos.x - f_res.DeltaPlat.x, currentPlatformPos.y + f_res.DeltaPlat.y, 0);
                f_nextRightPlatformPos = new Vector3(currentPlatformPos.x + f_res.DeltaPlat.x, currentPlatformPos.y + f_res.DeltaPlat.y, 0);
            }
        }
        #endregion
    }//Class End
}
