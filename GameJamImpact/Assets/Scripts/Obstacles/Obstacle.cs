using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    [SerializeField]
    [Tooltip("Layers du player.")]
    private LayerMask playerLayerMask;

    [SerializeField]
    [Tooltip("Temps de stun quand l'obstacle touche le joueur.")]
    private float stunTime = 3.0f;

    [SerializeField]
    [Tooltip("Evolution de la jauge lors du contact.")]
    [Range(-1.0f,1.0f)]
    private float gaugeEvolution = 0.0f;

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
            if(pc != null)
            {
                pc.Stun(stunTime);
                pc.IncreaseGauge(gaugeEvolution);
            }
        }
    }
}
