using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {

	//Hingeコンポーネントを入れる
	private HingeJoint myHingeJoint;

	//初期の傾き
	private float defaultAngle = 20f;

	//弾いたときの傾き
	private float flickAngle = -20f;

	// Use this for initialization
	void Start () {
		//HingeJointコンポーネント取得
		this.myHingeJoint = this.GetComponent<HingeJoint>();

		SetAngle(this.defaultAngle);
	}
	
	// Update is called once per frame
	void Update () {
		//=====================スマホ上の操作========================	
		if(Input.touchCount > 0)
		{
			Touch[] touch = new Touch[Input.touchCount];
			Vector2[] touchPos = new Vector2[Input.touchCount];

			for(int i = 0; i > Input.touchCount; i++){
				touch[i] = Input.GetTouch(i);
				touchPos[i] = touch[i].position;
			}

			//=====================タッチ座標によって処理を変える========================	
			for(int i = 0; i < touchPos.Length; i++){
				Debug.Log(touchPos[i].x);
				Debug.Log(Screen.width / 2);
				if(Screen.width / 2 < touchPos[i].x){ //右側処理
					Debug.Log("右側タッチ");
					switch(touch[i].phase){

						case TouchPhase.Began: //触れた時
							if(tag == "RightFripperTag"){
								SetAngle (this.flickAngle);
							}
							
						break;

						case TouchPhase.Ended: //離れた時
							if(tag == "RightFripperTag"){
								SetAngle (this.defaultAngle);

							}
						break;
					}

				}else{  							　 //左側処理　
					Debug.Log("左側タッチ");
					switch(touch[i].phase){
						case TouchPhase.Began:　//触れた時
							if(tag == "LeftFripperTag"){
								SetAngle (this.flickAngle);
							}
						break;

						case TouchPhase.Ended: //離れた時
							if(tag == "LeftFripperTag"){
								SetAngle (this.defaultAngle);
							}
						break;
					}
				}
			}
		}

		//=====================エディタ上の操作========================	

		//左矢印キーを押した時左フリッパーを動かす
		if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			SetAngle (this.flickAngle);
		}

		//右矢印キーを押した時右フリッパーを動かす
		if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle (this.flickAngle);
		}

		//左矢印キーが離された時左フリッパーを元に戻す
		if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			SetAngle (this.defaultAngle);
		}
		//右矢印キーが離された時右フリッパーを元に戻す
		if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle (this.defaultAngle);
		}
		
	}
	
	//フリッパーの傾きを設定
	public void SetAngle(float angle){
		JointSpring jointSpr = this.myHingeJoint.spring;
		jointSpr.targetPosition = angle;
		this.myHingeJoint.spring = jointSpr;
	}
}
