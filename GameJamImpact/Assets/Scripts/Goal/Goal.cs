using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

    [SerializeField]
    [Tooltip("Layers du player.")]
    private LayerMask playerLayerMask;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject go = collision.gameObject;

        if (playerLayerMask == (playerLayerMask | (1 << go.layer)))
        {
            PlayerController pc = go.GetComponent<PlayerController>();
            if (pc != null)
            {
                pc.WinFirstLevel();
            }
        }
    }
}
