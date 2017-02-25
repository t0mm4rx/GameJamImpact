using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradeController : MonoBehaviour {

	TextMesh textMesh;
	public int grade = 0;
	public float speed = 30;

	void Start () {
		textMesh = gameObject.GetComponent<TextMesh>();
		textMesh.text = gradeToString(grade) + "/20";
		if (grade > 10) {
			textMesh.color = Color.green;
		} else {
			textMesh.color = Color.red;
		}
	}

	void FixedUpdate () {
		transform.Translate (Vector3.left * speed * 0.001f);
	}

	private string gradeToString(int grade) {
		if (grade < 10) {
			return "0" + grade;
		} else {
			return grade + "";
		}
	}

	void OnCollisionEnter2D(Collision2D col) {
		Destroy (gameObject);
	}
}
