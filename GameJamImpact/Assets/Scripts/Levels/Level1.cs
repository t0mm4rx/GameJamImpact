using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour {

    [SerializeField]
    [Tooltip("Conteneur des obstacles.")]
    private Transform obstacles;

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
    public float rangeXObstacleRepop;

    [SerializeField]
    [Tooltip("Coordonnées du goal à atteindre.")]
    public Transform goal;

    [SerializeField]
    [Tooltip("Liste des sprites possibles pour les bébés.")]
    private Sprite[] sprites;

    [SerializeField]
    [Tooltip("Indique si on est en mode hard.")]
	public bool isHardMode = false;

    // Use this for initialization
    void Start () {
        Vector2 lastObstacle = firstObstaclePosition;
		if (PlayerPrefs.GetInt("isHardMode") == 1) {
			isHardMode = true;
		}
        while(lastObstacle.x < goal.transform.position.x - minXObstacleRepop)
        {
            GenerateObstacle(lastObstacle);
            lastObstacle = lastObstacle + new Vector2(minXObstacleRepop + Random.Range(0.0f, rangeXObstacleRepop), 0.0f);
        }
	}

    // Génère un obstacle à la position newPosition
    void GenerateObstacle(Vector2 newPosition)
    {
        obstacle.transform.position = newPosition;
        int spriteIndex = Random.Range(0, sprites.Length);
        obstacle.GetComponent<SpriteRenderer>().sprite = sprites[spriteIndex];
        if(Random.Range(0,2) == 1)
        {
            Vector3 newScale = obstacle.transform.localScale;
            newScale.Scale(new Vector3(-1, 1, 1));
            obstacle.transform.localScale = newScale;
        }

        Instantiate<GameObject>(obstacle, obstacles, true);
    }
	
}
