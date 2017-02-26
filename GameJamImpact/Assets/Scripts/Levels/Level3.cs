using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3 : MonoBehaviour {

	public float actionRate = 1;
	private float lastTime;
	public GameObject actionPrefab;
	public bool isHardMode = true;

	void Start () {
		lastTime = Time.time;
		if (isHardMode) {
			actionRate *= 4;
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
		go.transform.position = new Vector3 (GameObject.Find("Player").transform.position.x + 20, -3f, 0);
	}
}
