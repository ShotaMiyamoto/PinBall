using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

//=====================Point処理関係========================	
	[SerializeField] private PointManager PointManager;

//=====================GameOver処理関係========================	

	//ボールが見える可能性のあるz軸の最大値
	private float visiblePosZ = -6.5f;
	[SerializeField] private ResultManager ResultManager;

	// Update is called once per frame
	void Update () {
			//ボールが画面外に出た場合
			if (this.transform.position.z < this.visiblePosZ) {
					//GameoverTextにゲームオーバを表示
					ResultManager.SetText("GameOver");
			}
	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "SmallStarTag") {
			PointManager.GetPoint(5);
		} else if (col.tag == "LargeStarTag") {
			PointManager.GetPoint(10);
		}else if(col.tag == "SmallCloudTag") {
			PointManager.GetPoint(8);
		}else if(col.tag == "LargeCloudTag"){
			PointManager.GetPoint(15);
		}
	}
}
