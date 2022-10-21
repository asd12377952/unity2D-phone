using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System;
using TMPro;


public class menu : MonoBehaviour {

	public Button start;
	public TextMeshProUGUI highScore;
	
	void Start () {
		Time.timeScale = 1;
		string checkLevelName = PlayerPrefs.GetString("savedLevel");
		highScore.text=checkLevelName;
		start.onClick.AddListener(() => onStart());
	}
	//按鈕內sendMessageUp輸入startGame後按下按鈕會到Level1
	void  onStart() {
		GameData.hp = 250;
		GameData.jumpTwice = 0;
		GameData.twiceshoot = 0;
		GameData.damage = 1.0f;
		GameData.bulletLife = 0.3f;
		GameData.def = 0;
		GameData.lv = 1;
		GameData.exp = 0;
		GameData.point = 1;
		GameData.exppoint = 15;
		GameData.bosslevel = false;
		GameData.score = 0;
		SceneManager.LoadScene("level1");
	}
	
}
