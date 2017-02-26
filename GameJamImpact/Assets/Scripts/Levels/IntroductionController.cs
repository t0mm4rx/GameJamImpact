using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroductionController : MonoBehaviour {

	void Start () {
		PlayerPrefs.SetInt ("isHardMode", 0);
	}

	void Update () {
		if (Input.GetKeyDown("return") || Input.GetKeyDown("space")) {
			SceneManager.LoadScene ("Level1");
		}
	}
}
