using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BlinkingText : MonoBehaviour {

	private float alpha = 1f;
	private bool isIncreasing = false;
	public float speed = 0.01f;
	private Text text;

	void Start () {
		text = gameObject.GetComponent<Text> ();
	}

	void FixedUpdate () {
		if (isIncreasing) {
			alpha += 0.05f;
		} else {
			alpha -= 0.05f;
		}
		if (alpha <= 0) {
			isIncreasing = true;
		}
		if (alpha >= 1) {
			isIncreasing = false;
		}
		Color c = text.color;
		c.a = alpha;
		text.color = c;
	}
}
