//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;//

public class UIController : MonoBehaviour {

	private GameObject gameOverText;//自分で作ったやつ

	private GameObject runLengthText;//自分で作ったやつ

	private float len = 0;//距離の定義(1フレームで進む距離）

	private float speed = 0.03f;//速度の定義

	private bool isGameOver = false;//ゲームオーバーの判定

	// Use this for initialization
	void Start () {
		this.gameOverText = GameObject.Find ("GameOver");//GameObjectから見つけてくる
		this.runLengthText = GameObject.Find ("RunLength");
	}
	
	// Update is called once per frame
	void Update () {
		if (this.isGameOver == false) {
			this.len += this.speed;//走行距離
			this.runLengthText.GetComponent<Text> ().text = "Distance: " + len.ToString ("F2") + "m";
		}

		if (this.isGameOver == true) {
			if (Input.GetMouseButtonDown (0)) {//ゲームオーバーになってからもしクリックボタンが押されたら、
				SceneManager.LoadScene ("GameScene");//ゲームシーンを読み込む
			}
		}
	}
	public void GameOver(){
		this.gameOverText.GetComponent<Text> ().text = "GameOver";
		this.isGameOver = true;

	}
}


//「ToString()」は数値を文字列に変換します。また、引数には文字列に変換する際の書式を指定することができます。
//浮動小数点の値を文字列に変換しています。また、引数を"F2"とすることで、小数部を2桁まで表示するように書式指定しています。
//SceneManagerクラスのLoadScene関数を使うとシーンを読み込むことができます。引数には読み込むシーン名を渡します。