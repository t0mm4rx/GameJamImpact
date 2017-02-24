using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : MonoBehaviour {

	public int fireRate = 2;
	private float lastFire = 0;
	public GameObject prefab;

	void Start () {
		lastFire = Time.time;
	}

	void Update () {
		if (Time.time - lastFire > fireRate) {
			lastFire = Time.time;
			spawnGrade ();
		}
	}

	void spawnGrade() {
		GameObject go = (GameObject)Instantiate(prefab); 
		go.GetComponent<GradeController> ().grade = Random.Range (0, 20);
		int offsetY = Random.Range (0, -2);
		float y = -2 + offsetY;
		go.transform.position = new Vector3 (8, y, 0);
	}
}
