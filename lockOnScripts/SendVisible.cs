using UnityEngine;
using System.Collections;

/*
 * このスクリプトはロックオンとかをしたいオブジェクトにつける
*/
public class SendVisible : MonoBehaviour {
	private static string MAIN_CAMERA_TAG = "MainCamera";
	//↑staticによって弊害があるならstatic無しでいい
	private LockOnManager lockOnManager;
	[HideInInspector]
	public bool isRendering;

	void Start () {
		lockOnManager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<LockOnManager> ();
		isRendering = false;
	}

	private void OnBecameVisible () {
		if (Camera.current.tag == MAIN_CAMERA_TAG) {
			print ("写ってる");
			if (!isRendering)
				lockOnManager.AddVisibleList (gameObject);
			isRendering = true;
		}
	}

	private void OnBecameInvisible () {
		if (Camera.current != null) {
			//↑これを入れないとあとで停止時に毎回エラーでてウザい。それだけだから消してもいい
			if (Camera.current.tag == MAIN_CAMERA_TAG) {
				print ("写ってない");
				if (isRendering)
					lockOnManager.RemoveVisibleList (gameObject);
				isRendering = false;
			}
		}
	}
}
