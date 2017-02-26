using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishListenerLvl3 : MonoBehaviour {

	void Start () {
		
	}

	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (PlayerPrefs.GetInt ("isHardMode") == 0) {
			PlayerPrefs.SetInt ("isHardMode", 1);
			SceneManager.LoadScene ("Transition 2-3");
		} else {
			PlayerPrefs.SetInt ("isHardMode", 0);
			SceneManager.LoadScene ("Introduction");
		}
	}

}
