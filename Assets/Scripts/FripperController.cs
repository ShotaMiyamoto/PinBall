using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{

    //Hingeコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20f;

    //弾いたときの傾き
    private float flickAngle = -20f;

    // Use this for initialization
    void Start()
    {
        //HingeJointコンポーネント取得
        this.myHingeJoint = this.GetComponent<HingeJoint>();

        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    void Update()
    {
        //=====================スマホ上の操作========================	
        if (Input.touchCount > 0)
        {
            var touches = Input.touches; //var型で暗示的に型を定義する。

            //=====================タッチ座標によって処理を変える========================	
            for (int i = 0; i < touches.Length; i++)
            {
                if (Screen.width / 2 < touches[i].position.x)
                { //=====================右側処理=====================
                    Debug.Log("右側タッチ");
                    switch (touches[i].phase)
                    {

                        case TouchPhase.Began: //触れた時
                            if (tag == "RightFripperTag")
                            {
                                SetAngle(this.flickAngle);
                            }

                            break;

                        case TouchPhase.Ended: //離れた時
                            if (tag == "RightFripperTag")
                            {
                                SetAngle(this.defaultAngle);

                            }
                            break;
                    }

                }
                else
                {//=====================左側処理=====================
                    switch (touches[i].phase)
                    {
                        case TouchPhase.Began: //触れた時
                            if (tag == "LeftFripperTag")
                            {
                                SetAngle(this.flickAngle);
                            }
                            break;

                        case TouchPhase.Ended: //離れた時
                            if (tag == "LeftFripperTag")
                            {
                                SetAngle(this.defaultAngle);
                            }
                            break;
                    }
                }
            }
        }

        //=====================エディタ上の操作========================	

        //左矢印キーを押した時左フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        //右矢印キーを押した時右フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        //左矢印キーが離された時左フリッパーを元に戻す
        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        //右矢印キーが離された時右フリッパーを元に戻す
        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }

    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
