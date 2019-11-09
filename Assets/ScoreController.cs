using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour
{
	//pointをよびだす
	GameObject PointObject;
	PointScript script;


	//得点を表示するテキスト
	private GameObject ScoreText ;

	//結果を表示するテキスト
	private GameObject ResultText;

	//ゲーム終了の判定
	private bool isEnd = false;

	//全体で使う数値、文章のリスト
	List<Result> m_list;

	void Start(){
		m_list = new List<Result>()
		{
			new Result(1, 5, "安全な家だった！"),
			new Result(2, 10, "おやつをたべた！"),
			new Result(3, 15, "ご飯をたべた！"),
			new Result(4, 20, "ゆっくり休憩した！"),
			new Result(5, 30, "空き巣を逮捕した！"),
			new Result(6, 50, "爆弾を解除した！"),
			new Result(7, 0, @"爆発してしまった… GAME OVER")
		};

		//シーン中のScoreTextを取得
		this.ScoreText = GameObject.Find ("ScoreText");

		//シーン中のResultTextを取得
		this.ResultText = GameObject.Find ("ResultText");

		//PointObjectを取得
		PointObject = GameObject.Find ("PointObject");
		//PointScriptを呼び出す
		script = PointObject.GetComponent<PointScript> ();
	}

	public void OnClick()
	{
		//抽選する
		int random = Random.Range (0, m_list.Count);

		//スコア加算する
		int Score = m_list [random].score;
		script.pt += Score;
		this.ScoreText.GetComponent<Text> ().text = "すこあ:" + script.pt + "pt";

		//ログを出す
		string message = m_list [random].result;
		this.ResultText.GetComponent<Text> ().text = message;
		Debug.Log (message);

		//ゲーム終了にする
		if (m_list [random].num == 7) {
			this.isEnd = true;
			SceneManager.LoadScene ("GameoverScene");
		}
	}
}
public class Result
{
	public int num;
	public int score;
	public string result;
	// <summary>デフォルトコンストラクタ</summary>
	public Result() { }
	// <summary>コンストラクタ</summary>
	// <param name="n">num</param>
	// <param name="s">score</param>
	// <param name="r">result</param>
	public Result(int n, int s, string r)
	{
		num = n;
		score = s;
		result = r;
	}
}
