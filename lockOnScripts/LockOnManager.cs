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
		int index = -1;
		float min_dot = Mathf.Infinity;
		for (int i = 0; i < visibleCharacters.Count; ++i) {
			Ray ray = new Ray (yourself.position, visibleCharacters [i].transform.position - yourself.position);
			if (!Physics.Raycast (ray, Mathf.Infinity, 1 << LayerMask.NameToLayer ("Ground"))) {
				float dot = Vector3.Dot (yourself.forward, visibleCharacters [i].transform.position - yourself.position);
				if (dot < min_dot) {
					index = i;
					min_dot = dot;
				}
			}
		}
		print (index);
		if (index == -1) {
			print ("写ってない");
			return null;
		} else {
			print ("写ってる");
			return visibleCharacters [index];
		}
	}
}
