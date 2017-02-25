using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradeController : MonoBehaviour {

	TextMesh textMesh;
	public int grade = 0;
	public float speed = 0.015f;
	private PlayerController playerController;

	void Start () {
		textMesh = gameObject.GetComponent<TextMesh>();
		textMesh.text = gradeToString(grade) + "/20";
		playerController = GameObject.Find ("Player").gameObject.GetComponent<PlayerController>();
		if (grade > 10) {
			textMesh.color = Color.green;
		} else {
			textMesh.color = Color.red;
		}
	}

	void FixedUpdate () {
		Vector3 pos = transform.position;
		pos.x -= speed;
		transform.position = pos;
	}

	private string gradeToString(int grade) {
		if (grade < 10) {
			return "0" + grade;
		} else {
			return grade + "";
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (textMesh.color == Color.red) {
			if (playerController.levelGauge > 0) {
				playerController.levelGauge -= 0.1f;
			}
		} else {
			if (playerController.levelGauge < 1) {
				playerController.levelGauge += 0.1f;
			}
		}
		Destroy (gameObject);
	}
}
