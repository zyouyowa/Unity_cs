using UnityEngine;
using System.Collections;

//Edit->Project Settings->Script Excution OrderでこのスクリプトはDeffault Timeより後に行うように設定すること
public class FollowingCamera : MonoBehaviour {
	public GameObject target;               //カメラで追従したい対象のオブジェクト
    public float angleLimit_y = 45f;        //縦方向回転においてangleLimit度まで回転できる
	public float distance = 1f;             //対象からカメラまでの距離
    //heightはいらないけど1とか入れてみたら面白い動作をしたのであえて残しました。
	public float height = 0f;               //回転の中心 + heightがカメラの高さ
    public float rotateSpeed = 10f;         //入力値*rotateSpeed[°/s]回転
	public Vector3 offset = Vector3.up;     //targetの座標+offsetの位置が回転の中心
	//Vector2 value;にしなかったのは45,47行目あたりが面倒な気がしたからだけどそんなことはなかった。
    private float value_x;                  //横方向旋回に使う入力値を入れる
	private float usevalue_x;               //横方向旋回を行うときに実際に使う値
    private float value_y;                  //縦方向旋回に使う入力値を入れる
    private float usevalue_y;               //縦方向旋回で実際に使う値

	void Start () {
        //Inspectorでtargetに何もセットされていない場合はPlayerタグを持つオブジェクトをtargetとする
		if (target == null) {
			target = GameObject.FindGameObjectWithTag ("Player");
		}
		//初期化
		value_x = 0;
		usevalue_x = 0;
        value_y = 0;
        usevalue_y = 0;
	}

    //プレイヤーからの入力は取りこぼすといけないのでUpdateで行う
	void Update () {
        //Edit->Project Settings->InputのAxesの中から""の中身を選ぶ
		value_x = Input.GetAxis ("Horizontal2");
        value_y = Input.GetAxis("Vertical2");
	}

    //実行環境によって移動距離などに差が出ないようにゲームの処理は主にFixedUpdate内で行う
	void FixedUpdate () {
        //valueに旋回速度調整パラメータをかけ、
        //fixedDeltaTimeをかけて1フレームあたりの値を出す。
		usevalue_x += value_x * rotateSpeed * Time.fixedDeltaTime;
        usevalue_y += value_y * rotateSpeed * Time.fixedDeltaTime;
        //|usevalue_x|<360となるようにする。|・|は絶対値をとる。
		usevalue_x = Mathf.Repeat (usevalue_x, 360f);
        //usevalue_yの範囲を(-angleLimit < usevalue_y < angleLimit)とする
        usevalue_y = Mathf.Clamp(usevalue_y, -angleLimit_y, angleLimit_y);
        //回転の中心を設定
		Vector3 lookPosition = target.transform.position + offset;
		//(0,height,-distance)の点ををx軸についてusevalue_y度,y軸についてusevalue_x度回転移動させた点を求める。
        Vector3 relativePos = Quaternion.Euler (usevalue_y, usevalue_x, 0) * new Vector3 (0, height, -distance);
        //カメラの位置の更新
		transform.position = lookPosition + relativePos;
        //カメラの向き更新
		transform.LookAt (lookPosition);

		//playerとカメラお間の障害物避ける
		RaycastHit hitInfo;
		if (Physics.Linecast (lookPosition, transform.position, out hitInfo, 1 << LayerMask.NameToLayer ("Ground"))) {
			transform.position = hitInfo.point;
		}
	}
}
