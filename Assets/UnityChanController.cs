using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour {

	Animator animator;//1 AnimatorはUnityが持っているもので、animatorは変数
	Rigidbody2D rigid2D;// :2

	private float groundLevel = -3.0f;//地面の位置を定義（あとで使う）//1
	private float dump = 0.8f;//ジャンプ速度の減衰する:2
	float jumpVelocity = 20;//ジャンプの速度:2

	private float deadLine = -9;//ゲームオーバーになるx座標位置

	// Use this for initialization
	void Start () {
		this.animator = GetComponent<Animator> (); //Animatorのコンポーネントを取得する:1
		this.rigid2D = GetComponent<Rigidbody2D>();//コンポーネントを取得:2
	}
	
	// Update is called once per frame
	void Update () {
		this.animator.SetFloat ("Horizontal", 1);//代入する（Horizontal = 1）??// 走るアニメーションを再生するために、Animatorのパラメータを調節する:1

		bool isGround = (transform.position.y > this.groundLevel) ? false : true; //isGround変数 = 着地していなかったらfalse,そうでなかったらtrue//1
		this.animator.SetBool ("isGround", isGround);//animatorクラスの中のSetBool関数（//1

		GetComponent<AudioSource> ().volume = (isGround) ? 1 : 0;//AudioSourceコンポーネント内でのボリューム変数　＝　もし地面についていれば、大きさ1,そうでなければ0

		if (Input.GetMouseButtonDown (0) && isGround){//もし（クリック　& 着地状態）なら　:isGround=true 0=左クリック:3
				this.rigid2D.velocity = new Vector2 (0, this.jumpVelocity);//newはクラスを新しく作る（x,y):3

			}

		if (Input.GetMouseButton (0) == false) {//もしクリックをやめたら、?? 3
				if (this.rigid2D.velocity.y > 0) {//もし上方向への速度が0より大きかったら、
					this.rigid2D.velocity *= this.dump; //0.8をかけ続ける??: 3
			}
		}
		if (transform.position.x < this.deadLine){
			//Findでオブジェクトを探してGetComponentでそのオブジェクトのスクリプトを取得する方法
			GameObject.Find("Canvas").GetComponent<UIController>().GameOver();//// UIControllerのGameOver関数を呼び出して画面上に「GameOver」と表示する　並べ方??
			Destroy (gameObject);
		}
	}
}

//Setfloatは浮動小数点数?
//SetBoolは真偽値を代入する?」

// Rigidbody2Dクラスの「velocity」変数は、オブジェクトの線形速度です。
//AudioSourceクラスの「volume」変数は、音量を表しています。