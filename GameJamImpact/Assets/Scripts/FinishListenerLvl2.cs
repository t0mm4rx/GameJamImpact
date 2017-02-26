using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishListenerLvl2 : MonoBehaviour {
	void Start () {
		
	}
	void Update () {
		
	}

	public void OnTriggerEnter2D (Collider2D col) {
		if (col.name == "Player") {
			GameObject.Find ("Main Camera").gameObject.GetComponent<Level2>().doesSpawnGrades = false;
			StartCoroutine(End());
		}
	}

	IEnumerator End() {
		yield return new WaitForSeconds(3);
		if (PlayerPrefs.GetInt ("isHardMode") == 1) {
			PlayerPrefs.SetInt ("isHardMode", 0);
			SceneManager.LoadScene ("Scenes/Transition 2-3");
		} else {
			PlayerPrefs.SetInt ("isHardMode", 1);
			SceneManager.LoadScene ("Scenes/Transition 1-2");
		}

	}
}
