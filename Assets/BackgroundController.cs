using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {
	//スクロール速度
	private float scrollSpeed = -0.03f;
	//背景終了
	private float deadLine = -16; //fいらん??
	//背景開始
	private float startLine = 15.8f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//背景移動（x,y,z)
		transform.Translate (this.scrollSpeed, 0, 0);

		//画面外に出たら画面右端に移動
		if (transform.position.x < this.deadLine) {
			transform.position = new Vector2 (this.startLine, 0);//なんでnew?? 作り出しているのに消さなくて良い？
		}
	}
}
