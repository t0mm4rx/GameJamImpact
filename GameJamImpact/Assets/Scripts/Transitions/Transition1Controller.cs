using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transition1Controller : MonoBehaviour {

	private Text ecole1, ecole2, prix1, prix2;
	private int selected = 0;
	private int bigTitle = 28, smallTitle = 24, bigPrice = 23, smallPrice = 20;

	void Start () {
		ecole1 = GameObject.Find ("Ecole1").gameObject.GetComponent<Text>();
		ecole2 = GameObject.Find ("Ecole2").gameObject.GetComponent<Text>();
		prix1 = GameObject.Find ("Prix1").gameObject.GetComponent<Text>();
		prix2 = GameObject.Find ("Prix2").gameObject.GetComponent<Text>();
		selectItem (0);
	}

	void Update () {
		if (Input.GetKeyDown("up") || Input.GetKeyDown("down")) {
			if (selected == 0) {
				selectItem (1);
			} else {
				selectItem (0);
			}
		}

		if (Input.GetKeyDown("enter") || Input.GetKeyDown("space")) {
			if (selected == 0) {

			} else if (selected == 1) {
			
			}
		}
	}

	private void selectItem(int item) {
		if (item == 0) {
			selected = 0;
			ecole1.fontSize = bigTitle;
			prix1.fontSize = smallTitle;
			ecole2.fontSize = 20;
			prix2.fontSize = 15;
		} else {
			selected = 1;
			ecole2.fontSize = bigTitle;
			prix2.fontSize = smallTitle;
			ecole1.fontSize = bigPrice;
			prix1.fontSize = smallPrice;
		}
	}
}