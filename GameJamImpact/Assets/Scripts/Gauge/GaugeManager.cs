using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaugeManager : MonoBehaviour {

    // Contenant de la jauge
    private RectTransform contenant;

    [Range(0.0f, 1.0f)]
    public float value;

	// Use this for initialization
	void Start () {
        foreach(RectTransform rt in this.GetComponentsInChildren<RectTransform>())
        {
            if (rt.gameObject != this.gameObject)
                contenant = rt;
        }
	}
	
	// Update is called once per frame
	void Update () {
        contenant.anchorMax = new Vector2(value, 1);
	}
}
