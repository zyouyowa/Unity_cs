using UnityEngine;
using System.Collections;

/*
 * これは使用例
 * こんな感じに使う
*/
public class PlayerLockOn : MonoBehaviour {
	private bool flag_down, flag, flag_up;
	private LockOnManager lockOnManager;
	private GameObject target;
	private bool lookOn;

	void Start () {
		flag_down = flag = flag_up = false;
		lockOnManager = GameObject.FindWithTag ("GameManager").GetComponent<LockOnManager> ();
		lookOn = false;
	}

	void Update () {
		/* if(Input.GetAxis("Fire1")==1.0f)でもいいはず
		 * 実数の比較はなんか信用できないので↓のようにしただけ。わりとどうでもいい
		*/ 
		flag = !(Input.GetAxis ("Fire1") != 1.0f);
		if (flag) {
			flag_up = true;
			if (flag_down) {
				OnFire1Down ();
				flag_down = false;
			}
		} else {
			flag_down = true;
			if (flag_up) {
				OnFire1Up ();
				flag_up = false;
			}
		}
	}

	void FixedUpdate () {
		if (flag) {
			OnFire1 ();
		}
		if (lookOn) {

		} else {

		}
	}
	//down,upはフレームレートに依存しないのでFixed内でしなくていいと思われる。
	void OnFire1Down () {
		lookOn = !lookOn;
		if (lookOn) {
			target = lockOnManager.FindNearestObject (transform);
			//だいたいnullを返してくるから↓は必須
			if (target == null) {
				lookOn = false;
			}
		}
	}

	void OnFire1Up () {

	}

	void OnFire1 () {

	}
}
