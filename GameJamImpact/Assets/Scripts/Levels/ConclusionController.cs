using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConclusionController : MonoBehaviour {

	Text score1, score2, score3;

	void Start () {
		score1 = GameObject.Find ("Score1").gameObject.GetComponent<Text> ();
		score2 = GameObject.Find ("Score2").gameObject.GetComponent<Text> ();
		score3 = GameObject.Find ("Score3").gameObject.GetComponent<Text> ();

		score1.text = Mathf.Floor((1 - PlayerPrefs.GetFloat ("education")) * 10) + " / 10";
		score2.text = Mathf.Floor(PlayerPrefs.GetFloat ("culture") * 10) + " / 10";
		score3.text = Mathf.Floor((1 - PlayerPrefs.GetFloat ("integration")) * 10 )+ " / 10";

	}

	void Update () {
		
	}
}
