using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour {
	public GameObject CubePrefab;//取得

	private float delta = 0;//時間計測用の変数??
	private float span = 1.0f; //キューブを作る時間間隔を勝手に定義
	private float genPosX = 12;//generatepositionのx=12

	private float offsetY = 0.3f;//offset??
	private float spaceY = 6.9f;//縦方向の空間間隔

	private float offsetX = 0.5f;
	private float spaceX = 0.4f;//横の空間間隔

	private int maxBlockNum = 4;//作るのは最大で4個まで

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		this.delta += Time.deltaTime;//

		if (this.delta > this.span) {//秒として比較
			this.delta = 0;

			//こっから
			int n = Random.Range (1, maxBlockNum + 1);//数の数えかた? 生成するキューブの数を1~4
			//n 
			for (int i = 0; i < n; i++) {  //i<nなら(生成するcubeが0個以上なら??）繰り返す →1個以上... →2個以上...
				//nとiの関係性は??
				GameObject go = Instantiate (CubePrefab) as GameObject;  //GameObjectクラスのgo変数はCubePreをGameobjectとして生成
				go.transform.position = new Vector2 (this.genPosX, this.offsetY + i * this.spaceY);//生成位置　（定義済み, ?  offsetY = 調整)
			}//キューブを生成する位置は縦方向にspaceY変数のぶんだけスペースを空けて生成しています。 
			this.span = this.offsetX + this.spaceX * n;
			//間隔= オフセット値　+ スペース変数 * キューブの数
		}
	}
}
//「Time.deltaTime」でフレーム間の時間の差分を取得できます。


//offsetの意味　→ずらすため？