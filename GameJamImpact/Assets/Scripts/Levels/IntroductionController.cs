using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroductionController : MonoBehaviour {

	void Start () {
		PlayerPrefs.SetFloat ("education", 0);
		PlayerPrefs.SetFloat ("culture", 0);
		PlayerPrefs.SetFloat ("integration", 0);
		PlayerPrefs.SetInt ("isHardMode", 1);
		PlayerPrefs.SetInt ("money", 2500);
	}

	void Update () {
		if (Input.GetKeyDown("return") || Input.GetKeyDown("space")) {
			SceneManager.LoadScene ("Transition 0-1");
		}
	}
}
