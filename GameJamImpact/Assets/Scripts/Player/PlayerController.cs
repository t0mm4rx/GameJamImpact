using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public enum Direction
    {
        LEFT,
        RIGHT
    }

    // Collider vers les pieds du personnage
    private CapsuleCollider2D feets;

    [Header("Movements")]

    [Tooltip("Indique si le personnage doit courir.")]
    public bool isWalking;

    [Tooltip("Sens de déplacement par défaut du personnage.")]
    public Direction moveDirection;

    [SerializeField]
    [Tooltip("Vitesse du personnage.")]
    private float speed;

    [Header("Jump")]

    [SerializeField]
    [Tooltip("Layer correspondant au sol.")]
    private LayerMask groundMask;

    [SerializeField]
    [Tooltip("Axe du contrôleur de saut.")]
    private string jumpAxis;

    [SerializeField]
    [Tooltip("Force du saut du personnage.")]
    private float jumpPower;

	// Use this for initialization
	void Start () {
        feets = this.GetComponentInChildren<CapsuleCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        HandleWalk();
        HandleJump();
	}

    // Fonction gérant le déplacement du personnage
    void HandleWalk()
    {
        if (isWalking)
        {
            Vector2 dir = new Vector2(moveDirection == Direction.LEFT ? -1.0f : 1.0f, 0.0f);
            transform.position = (Vector2) transform.position + (dir * speed * Time.deltaTime);
        }
    }

    // Fonction gérant le saut du personnage
    void HandleJump()
    {
        if (Input.GetAxis(jumpAxis) > 0 && feets.IsTouchingLayers(groundMask))
        {
            Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(0, jumpPower);
        }
    }
}
