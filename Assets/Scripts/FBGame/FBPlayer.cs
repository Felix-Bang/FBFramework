// Felix-Bang：FBPlayer
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
using UnityEngine.UI;

namespace FelixBang
{
	public class FBPlayer : MonoBehaviour 
	{
        #region Delegates/Action
        #endregion

        #region Fields/Properties
    

        private int coinAmount = 1000;
        public Text text;
        #endregion

        #region Constructor
        #endregion

        #region Unity
        void Awake () 
		{
			
		}

		void Start () 
		{
            text.text = coinAmount.ToString();

        }
	
		void Update () 
		{
            if (Input.GetKeyDown(KeyCode.G))
            {
                int id = Random.Range(0, 7);

                FBInventoryManager.Instance.StoreInKnapsack(id);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {

                //knapsack.FBSwitchDisplay();
            }

            if (Input.GetKeyDown(KeyCode.C))
            {

                //chest.FBSwitchDisplay();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {

                //equipment.FBSwitchDisplay();
            }

            if (Input.GetKeyDown(KeyCode.P))
            {
                FBEarnCoin(50);


            }
        }
        #endregion

        #region Interface
        #endregion

        #region Methods
        public bool FBConsumeCoin(int count)
        {
            if (coinAmount >= count)
            {
                coinAmount -= count;
                text.text = coinAmount.ToString();
                return true;
            }
            return false;
        }

        public void FBEarnCoin(int count)
        {
            coinAmount += count;
            text.text = coinAmount.ToString();
        }
		#endregion
	}//Class End
}
