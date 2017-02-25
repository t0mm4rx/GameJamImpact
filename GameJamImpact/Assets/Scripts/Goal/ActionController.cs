using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionController : MonoBehaviour {

	public string key;
	private TextMesh textMesh;
	private bool isPlayerOnIt, validated;

	public static string[] keys = {
		"UP",
		"DOWN",
		"LEFT",
		"DOWN"
	};

	void Start () {
		key = keys[Random.Range(0, keys.Length)];
		textMesh = gameObject.GetComponent<TextMesh> ();
		textMesh.text = key;
		isPlayerOnIt = false;
		validated = false;
	}

	void Update () {
		if (isPlayerOnIt && textMesh.color != Color.gray && !validated) {
			textMesh.color = Color.grey;
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
		if (transform.position.x < GameObject.Find("Player").transform.position.x - 4) {
			if (!validated && GameObject.Find ("Player").gameObject.GetComponent<PlayerController> ().levelGauge < 1) {
				GameObject.Find ("Player").gameObject.GetComponent<PlayerController> ().levelGauge += 0.2f;
			}
			Destroy (gameObject);
		}

		if(GameObject.Find ("Player").gameObject.GetComponent<PlayerController> ().levelGauge > 1) {
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