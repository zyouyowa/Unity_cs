using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * Usage:
 * 	空のGameObjectを"GameManager"の名前を作り、それにこのスクリプトをつける。
 * Tagに"GameManager"を追加し、↑で作ったオブジェクトにそのタグをつける。
*/
public class LockOnManager : MonoBehaviour {
	[HideInInspector]
	private List<GameObject> visibleCharacters;

	void Start () {
		visibleCharacters = new List<GameObject> ();
	}

	public void AddVisibleList (GameObject obj) {
		visibleCharacters.Add (obj);
	}

	public void RemoveVisibleList (GameObject keyObj) {
		if (visibleCharacters.Remove (keyObj)) {
			Debug.Log ("succeed in remove");
		} else {
			Debug.LogError ("failed to remove obj / does not exist or cannot remove");
		}
	}

	public GameObject FindNearestObject (Transform yourself) {
		int index = 0;
		float min_dot = Vector3.Dot (yourself.forward, visibleCharacters [0].transform.position - yourself.position);
		for (int i = 1; i < visibleCharacters.Count; ++i) {
			float dot = Vector3.Dot (yourself.forward, visibleCharacters [i].transform.position - yourself.position);
			if (dot < min_dot) {
				index = i;
				min_dot = dot;
			}
		}
		return visibleCharacters [index];
	}
}
