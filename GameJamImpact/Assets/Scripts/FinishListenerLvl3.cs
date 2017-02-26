using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishListenerLvl3 : MonoBehaviour {

	void Start () {
		
	}

	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col) {
		PlayerPrefs.SetFloat ("integration", FindObjectOfType<GaugeManager>().value);
		SceneManager.LoadScene ("Conclusion");
	}

}
