using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour {

//=====================GameOver処理関係========================	
	[SerializeField] private GameObject ResultText;

	public void SetText(string text){
		ResultText.GetComponent<Text>().text = text;
	}
}
