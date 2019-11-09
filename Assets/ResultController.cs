using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultController : MonoBehaviour {

	//pointをよびだす
	GameObject PointObject;
	PointScript script;

	//スコアを表示するテキスト
	private GameObject ScoreText;


	void start(){
		
		//シーン中のScoreを取得
		this.ScoreText = GameObject.Find ("ScoreText");


		//PointObjectを取得
		GameObject.Find("PointObject").GetComponent<PointScript>();
		//PointScriptを呼び出す
		script = GameObject.Find("PointObject").GetComponent<PointScript> ();
	}
		

	void Update (){
		//すこあの表示
		this.ScoreText.GetComponent<Text> ().text = "すこあ:" + script.pt + "pt";
	}
}