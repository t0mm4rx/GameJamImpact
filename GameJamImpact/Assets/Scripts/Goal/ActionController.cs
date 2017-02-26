using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionController : MonoBehaviour {

	public string key;
	private Animator animator;
	private SpriteRenderer spriteRenderer;
	private bool isPlayerOnIt, validated;
	private int type;
	private string name;
	public AnimationClip animaton2;
	private SoundManager soundManager;
	public bool isHardMode = PlayerPrefs.GetInt("isHardMode") == 1;

	public static string[] keys = {
		"up",
		"down",
	};

	void Start () {
		type = Random.Range (0, keys.Length);
		key = keys[type];
		animator = gameObject.GetComponent<Animator> ();
		spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
		soundManager = GameObject.Find ("Player").gameObject.GetComponent<SoundManager>();
		animator.SetInteger ("type", type);
		isPlayerOnIt = false;
		validated = false;
		Debug.Log (PlayerPrefs.GetInt("isHardMode"));
		if (PlayerPrefs.GetInt("isHardMode") == 1) {
			Debug.Log ("Disabled");
			spriteRenderer.enabled = false;
			animator.enabled = false;
		}
	}

	void Update () {
		if (Input.GetKey(key.ToLower()) && isPlayerOnIt && !validated) {
			validated = true;
			if (GameObject.Find ("Player").gameObject.GetComponent<PlayerController> ().levelGauge > 0) {
				GameObject.Find ("Player").gameObject.GetComponent<PlayerController> ().levelGauge -= 0.05f;
				soundManager.playOue();
			}

		}
		if (Input.anyKeyDown && Input.GetKeyUp(key.ToLower()) && isPlayerOnIt && !validated) {
			validated = true;
			GameObject.Find ("Player").gameObject.GetComponent<SoundManager> ().playSound (10);
			GameObject.Find ("Player").gameObject.GetComponent<PlayerController> ().levelGauge += 0.2f;
			soundManager.playBoo ();
		}
		if (transform.position.x < GameObject.Find("Player").transform.position.x - 4) {
			if (!validated && GameObject.Find ("Player").gameObject.GetComponent<PlayerController> ().levelGauge < 1) {
				GameObject.Find ("Player").gameObject.GetComponent<PlayerController> ().levelGauge += 0.2f;
				soundManager.playBoo ();
			}
			Destroy (gameObject);
		}

		if (GameObject.Find ("Player").gameObject.GetComponent<PlayerController> ().levelGauge > 1) {
			GameObject.Find ("Player").gameObject.GetComponent<PlayerController> ().levelGauge = 1;
		}

		if (isPlayerOnIt && Input.anyKeyDown && !Input.GetKeyDown(key.ToLower())) {
			GameObject.Find ("Player").gameObject.GetComponent<PlayerController> ().levelGauge += 0.2f;
			soundManager.playBoo ();
		}

		if (PlayerPrefs.GetInt("isHardMode") == 1 && spriteRenderer.enabled == true) {
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