using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Level2 : MonoBehaviour {

	public float fireRate = 2, immunityTime = 5;
	private float lastFire = 0, lastImmunity = 0;
	private bool isImmunity = false;
	public GameObject prefab;
	private Text actionText;
	public bool isHardMode = true, doesSpawnGrades = true;
	public Sprite backgroundHard;

	void Start () {
		lastFire = Time.time;
		doesSpawnGrades = true;
		actionText = GameObject.Find ("ActionText").gameObject.GetComponent<Text> ();
		if (PlayerPrefs.GetInt("isHardMode") == 1) {
			isHardMode = true;
		}

		if (isHardMode) {
			Debug.Log ("Hard");
			GameObject.Find ("bg_2 Front").gameObject.GetComponent<SpriteRenderer> ().sprite = backgroundHard;
			GameObject.Find ("bg_2 Behind").gameObject.GetComponent<SpriteRenderer> ().sprite = backgroundHard;
		}
	}

	void FixedUpdate () {
		if (Time.time - lastFire > fireRate) {
			lastFire = Time.time;
			if (doesSpawnGrades) {
				spawnGrade ();
			}
		}
		if (isImmunity && Time.time - lastImmunity > immunityTime) {
			isImmunity = false;
			actionText.enabled = true;
		}
		if (isHardMode && Time.time - lastImmunity > 1.5f) {
			actionText.color = Color.white;
		}
		if (Input.GetKeyDown ("a")) {
			immunity();
		}
	}

	void spawnGrade() {
		GameObject go = (GameObject)Instantiate(prefab);
		if (isImmunity) {
			go.GetComponent<GradeController> ().grade = Random.Range (14, 20);
		} else {
			go.GetComponent<GradeController> ().grade = Random.Range (0, 16);
		}
		int offsetY = Random.Range (0, 2);
		float y = -2 - offsetY * 0.8f;
		go.transform.position = new Vector3 (transform.position.x + 10, y, 0);
	}

	public void immunity() {
		if (!isImmunity && !isHardMode) {
			actionText.enabled = false;
			lastImmunity = Time.time;
			isImmunity = true;
		}
		if (isHardMode) {
			actionText.color = Color.red;
			lastImmunity = Time.time;
		}
	}
}
