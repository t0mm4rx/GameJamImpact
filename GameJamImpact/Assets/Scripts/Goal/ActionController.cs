using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionController : MonoBehaviour {

	public string key;
	private SpriteRenderer spriteRenderer;
	private bool isPlayerOnIt, validated;
	private int type;
	private string name;
	public Sprite sprite2;
	private SoundManager soundManager;
	public bool isHardMode = false;

	public static string[] keys = {
		"up",
		"down",
	};

	void Start () {
		type = Random.Range (0, keys.Length);
		key = keys[type];
		spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
		soundManager = GameObject.Find ("Player").gameObject.GetComponent<SoundManager>();
		if (type == 1) {
			spriteRenderer.sprite = sprite2;
		}
		isPlayerOnIt = false;
		validated = false;
	}

	void Update () {
		if (Input.GetKey(key.ToLower()) && isPlayerOnIt && !validated) {
			validated = true;
			if (GameObject.Find ("Player").gameObject.GetComponent<PlayerController> ().levelGauge > 0) {
				GameObject.Find ("Player").gameObject.GetComponent<PlayerController> ().levelGauge -= 0.05f;
			}
			spriteRenderer.color = Color.green;

		}
		if (Input.anyKeyDown && Input.GetKeyUp(key.ToLower()) && isPlayerOnIt && !validated) {
			validated = true;
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

		if (isPlayerOnIt && Input.anyKeyDown && Input.GetKeyUp(key.ToLower())) {
			GameObject.Find ("Player").gameObject.GetComponent<PlayerController> ().levelGauge += 0.2f;
		}

		if (isHardMode && spriteRenderer.enabled == true) {
			spriteRenderer.enabled = false;
		}
	}

	void OnTriggerEnter2D(Collider2D col) {

		if (col.name == "Player") {
			isPlayerOnIt = true;
			soundManager.playSound (type);
		}

	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.name == "Player") {
			isPlayerOnIt = false;
		}

	}

}