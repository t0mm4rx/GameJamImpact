﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishListener : MonoBehaviour {
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
		SceneManager.LoadScene("Scenes/Level3");
	}
}
