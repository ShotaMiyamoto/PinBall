using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointManager : MonoBehaviour {

//=====================Point処理関係========================	
	[SerializeField] private int point = 0;
	[SerializeField] private Text PointText;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GetPoint(int point){
		this.point += point;
		PointText.text = ("Points：" + this.point);
	}

}
