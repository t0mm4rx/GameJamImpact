using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterToNextScreen : MonoBehaviour {

	public string nextScreen;

	void Start () {
		
	}

	void Update () {
		if (Input.GetKeyDown("return") || Input.GetKeyDown("space")) {
			SceneManager.LoadScene (nextScreen);
		}
	}
}
