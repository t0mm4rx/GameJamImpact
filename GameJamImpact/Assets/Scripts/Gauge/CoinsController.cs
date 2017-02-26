using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsController : MonoBehaviour {

	void Start () {
		GameObject.Find ("Coins").GetComponent<Text> ().text = PlayerPrefs.GetInt("money") + " €";
	}

	void Update () {
		
	}
}
