using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3 : MonoBehaviour {

	public float actionRate = 1;
	private float lastTime;
	public GameObject actionPrefab;
	public bool isHardMode = false;

	void Start () {
		lastTime = Time.time;
		if (PlayerPrefs.GetInt("isHardMode") == 1) {
			isHardMode = true;
		}
	}

	void Update () {
		if (Time.time - lastTime > actionRate) {
			lastTime = Time.time;
			spawnAction ();
		}
	}
		
	private void spawnAction() {
		GameObject go = Instantiate (actionPrefab);
		go.transform.position = new Vector3 (GameObject.Find("Player").transform.position.x + 16, -0.9f, 0);
	}
}
