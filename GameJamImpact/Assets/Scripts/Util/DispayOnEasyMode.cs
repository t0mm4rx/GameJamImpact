using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DispayOnEasyMode : MonoBehaviour {

    [Tooltip("Pointeur vers le niveau 1")]
    private Level1 level1;

	// Use this for initialization
	void Start () {
        level1 = FindObjectOfType<Level1>();
        if(level1 != null && level1.isHardMode)
        {
            GetComponent<Text>().text = "";
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
