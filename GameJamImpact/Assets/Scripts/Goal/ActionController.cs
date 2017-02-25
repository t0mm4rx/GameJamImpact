using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionController : MonoBehaviour {

	public string key;
	private TextMesh textMesh;
	private bool isPlayerOnIt, validated;
	private int type;
	private string name;

	public static string[] keys = {
		"up",
		"down",
	};

	public static string[] names = {
		"Rire",
		"Applaudir",
	};

	void Start () {
		type = Random.Range (0, keys.Length);
		key = keys[type];
		name = names[type];
		textMesh = gameObject.GetComponent<TextMesh> ();
		textMesh.text = name;
		isPlayerOnIt = false;
		validated = false;
	}

	void Update () {
		if (isPlayerOnIt && textMesh.color != Color.gray && !validated) {
			textMesh.color = Color.grey;
			GameObject.Find ("Player").gameObject.GetComponent<SoundManager> ().playSound (type);
		}
		if (!isPlayerOnIt && textMesh.color != Color.white && !validated) {
			textMesh.color = Color.white;
		}

		if (Input.GetKey(key.ToLower()) && isPlayerOnIt && !validated) {
			validated = true;
			textMesh.color = Color.green;
			if (GameObject.Find ("Player").gameObject.GetComponent<PlayerController> ().levelGauge > 0) {
				GameObject.Find ("Player").gameObject.GetComponent<PlayerController> ().levelGauge -= 0.05f;
			}
		}
		if (Input.anyKeyDown && Input.GetKeyUp(key.ToLower()) && isPlayerOnIt && !validated) {
			validated = false;
			textMesh.color = Color.red;
			GameObject.Find ("Player").gameObject.GetComponent<SoundManager> ().playSound (10);
			GameObject.Find ("Player").gameObject.GetComponent<PlayerController> ().levelGauge += 0.2f;
		}
		if (transform.position.x < GameObject.Find("Player").transform.position.x - 4) {
			if (!validated && GameObject.Find ("Player").gameObject.GetComponent<PlayerController> ().levelGauge < 1) {
				GameObject.Find ("Player").gameObject.GetComponent<PlayerController> ().levelGauge += 0.2f;
			}
			Destroy (gameObject);
		}

		if (GameObject.Find ("Player").gameObject.GetComponent<PlayerController> ().levelGauge > 1) {
			GameObject.Find ("Player").gameObject.GetComponent<PlayerController> ().levelGauge = 1;
		}
	}

	void OnTriggerEnter2D(Collider2D col) {

		if (col.name == "Player") {
			isPlayerOnIt = true;
		}

	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.name == "Player") {
			isPlayerOnIt = false;
		}

	}

}