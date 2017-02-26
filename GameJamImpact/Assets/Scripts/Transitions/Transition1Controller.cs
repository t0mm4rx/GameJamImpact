using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Transition1Controller : MonoBehaviour {

	private Text ecole1, ecole2, prix1, prix2;
	public AudioClip sound1, sound2, sound3, sound4;
	private int selected = 0;
	private int bigTitle = 28, smallTitle = 24, bigPrice = 23, smallPrice = 20;
	private AudioSource audioSource;

	void Start () {
		audioSource = gameObject.GetComponent <AudioSource> ();
		ecole1 = GameObject.Find ("Ecole1").gameObject.GetComponent<Text>();
		ecole2 = GameObject.Find ("Ecole2").gameObject.GetComponent<Text>();
		prix1 = GameObject.Find ("Prix1").gameObject.GetComponent<Text>();
		prix2 = GameObject.Find ("Prix2").gameObject.GetComponent<Text>();
		selectItem (0);
	}

	void Update () {
		if (Input.GetKeyDown("up") || Input.GetKeyDown("down")) {
			if (selected == 0) {
				selectItem (1);
			} else {
				selectItem (0);
			}
		}

		if (Input.GetKeyDown("return") || Input.GetKeyDown("space")) {
			SceneManager.LoadScene ("Scenes/Level2");
			if (selected == 0) {
				PlayerPrefs.SetInt ("isHardMode", 0);
			} else if (selected == 1) {
				PlayerPrefs.SetInt ("isHardMode", 1);
			}
		}
	}

	private void selectItem(int item) {
		if (item == 0) {
			selected = 0;
			ecole1.fontSize = bigTitle;
			prix1.fontSize = smallTitle;
			ecole2.fontSize = 20;
			prix2.fontSize = 15;
			audioSource.Stop ();
			if (Random.Range(0, 2) == 1) {
				audioSource.PlayOneShot (sound1);
			} else {
				audioSource.PlayOneShot (sound2);
			}
		} else {
			selected = 1;
			ecole2.fontSize = bigTitle;
			prix2.fontSize = smallTitle;
			ecole1.fontSize = bigPrice;
			prix1.fontSize = smallPrice;
			audioSource.Stop ();
			if (Random.Range(0, 2) == 1) {
				audioSource.PlayOneShot (sound4);
			} else {
				audioSource.PlayOneShot (sound3);
			}
		}
	}
}