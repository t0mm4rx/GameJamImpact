using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterToNextScreen : MonoBehaviour {

	public string nextScreen;
	public bool setEasyMode = false;

	void Start () {
		
	}

	void Update () {
		if (Input.GetKeyDown("return") || Input.GetKeyDown("space")) {
			if (setEasyMode) {
				PlayerPrefs.SetInt ("isHardMode", 0);
			}
			SceneManager.LoadScene (nextScreen);
		}
	}
}
