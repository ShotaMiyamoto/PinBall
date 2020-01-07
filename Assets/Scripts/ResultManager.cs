using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour {

//=====================GameOver処理関係========================	
	[SerializeField] private GameObject ResultText;
	[SerializeField] private GameObject RestartButton;

	void Start(){
		RestartButton.SetActive(false);
	}

	public void SetText(string text){
		ResultText.GetComponent<Text>().text = text;
		RestartButton.SetActive(true);
	}

	public void RestartScene(){
		//現在のシーン名の取得
		Scene loadScene = SceneManager.GetActiveScene();
		//シーン再読み込み
		SceneManager.LoadScene(loadScene.name);
	}
}
