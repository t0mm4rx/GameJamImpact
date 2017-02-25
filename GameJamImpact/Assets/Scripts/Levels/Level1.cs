using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour {

    [SerializeField]
    [Tooltip("Modèle d'un obstacle.")]
    public GameObject obstacle;

    [SerializeField]
    [Tooltip("Coordonnée du premier obtacle.")]
    public Vector2 firstObstaclePosition;

    [SerializeField]
    [Tooltip("Borne minimale de l'écart de pop des obstacles.")]
    public float minXObstacleRepop;

    [SerializeField]
    [Tooltip("Borne maximale de l'écart de pop des obstacles.")]
    public float maxXObstacleRepop;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
