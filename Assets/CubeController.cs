using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {

	private float speed = -0.2f;//スピードを勝手に定義

	private float deadLine = -10;//消滅位置x座標を勝手に定義
//	private bool Sound = false;

	// Use this for initialization
	void Start () {
	}
	// Update is called once per frame
	void Update () {
		transform.Translate (this.speed, 0, 0);//x座標についてのみ定義したスピードで移動させる
		if (transform.position.x < this.deadLine) {
			Destroy (gameObject);
		}
//		if (this.Sound) {
//			GetComponent<AudioSource> ().volume = 1;

	}

	void OnCollisionEnter2D (Collision2D other){
		if (other.gameObject.tag == "CubeTag" || other.gameObject.tag == "groundTag"){
			GetComponent<AudioSource> ().Play ();
//		this.Sound = true;
		}
	}
}




// TransformクラスのTranslate関数は、引数に与えた値のぶんだけ現在の位置から移動します
//（指定した値の座標に移動するわけではないことに注意してください）。
//第一引数から順にX軸方向、Y軸方向、Z軸方向の移動距離を指定できます。

//キューブが落ちる??
//Update で　voidは使えない？

