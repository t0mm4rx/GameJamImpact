using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

interface ILevelInteraction
{
    void CallLevelInteraction();
}

public class PlayerController : MonoBehaviour {

    public enum Direction
    {
        LEFT,
        RIGHT
    }

    #region references
    // Collider vers les pieds du personnage
    private CapsuleCollider2D feets;

    // Sprite du personnage
    private SpriteRenderer sprite;
    #endregion

    #region movements
    [Header("Movements")]

    [Tooltip("Indique si le personnage doit courir.")]
    public bool enableWalking = true;

    [Tooltip("Sens de déplacement par défaut du personnage.")]
    public Direction moveDirection;

    [SerializeField]
    [Tooltip("Vitesse du personnage.")]
    private float speed;

    // Vitesse actuelle du personnage.
    private float currentSpeed;

    [SerializeField]
    [Tooltip("Transform du background du niveau")]
    private Transform backgroundTransform;

    [SerializeField]
    [Tooltip("Vitesse du parallax.")]
    [Range(0.0f,1.0f)]
    private float parallaxSpeed;
    #endregion

    #region jump
    [Header("Jump")]

    [Tooltip("Indique si le personnage peut sauter.")]
    public bool enableJumping = true;

    [SerializeField]
    [Tooltip("Layers correspondant au sol.")]
    private LayerMask groundLayerMask;

    [SerializeField]
    [Tooltip("Layers correspondant aux obstacles.")]
    private LayerMask obstacleLayerMask;

    [SerializeField]
    [Tooltip("Axe du contrôleur de saut.")]
    private string jumpAxis;

    [SerializeField]
    [Tooltip("Force du saut du personnage.")]
    private float jumpPower;
    #endregion

    #region stun
    [Header("Stun")]

    [SerializeField]
    [Tooltip("Fréquence de clignotements du personnage lors du stun.")]
    private float blinkFrequencyOnStun = 2.0f;

    [SerializeField]
    [Tooltip("Taux de ralentissement du personnage lors du stun.")]
    private float slowdownOnStun = 2.0f;

    // Temps passé depuis le dernier stun.
    private float timeSinceLastStun = 0.0f;

    // Temps pendant lequel le personnage est stunned.
    private float stunTime = 0.0f;
    #endregion

    #region gauges
    [Header("Gauges")]

    [SerializeField]
    [Tooltip("Objet désignant la jauge dans l'interface.")]
    private GaugeManager gauge;

    [SerializeField]
    [Tooltip("Jauge du niveau")]
    [Range(0.0f, 1.0f)]
    public float levelGauge = 0.0f;
    #endregion

    #region money

    [SerializeField]
    private MoneyGauge moneyGauge;

    #endregion

    #region level interaction
    [Header("Level Interactions")]

    [SerializeField]
    [Tooltip("Interaction avec le niveau.")]
    private GameObject levelInteraction;

    [SerializeField]
    [Tooltip("Axe de l'appel de l'intéraction avec le niveau.")]
    private string levelInteractionAxis;
    #endregion

    #region win level 1
    [Header("Win Level 1")]

    [SerializeField]
    [Tooltip("Indique si le personnage a gagné le niveau.")]
    private bool hasWon;

    [Tooltip("Coordonnées d'origine.")]
    private Vector2 originTransform;

    [Tooltip("Transform du lit du personnage.")]
    private Vector2 goalLevel1;

    [Tooltip("Temps pour que le personnage aille sur le lit.")]
    private float timeToTransform = 0.0f;

    [Tooltip("Temps passé depuis la victoire.")]
    private float timeSinceWin = 0.0f;

    [Tooltip("Prochaine scène à atteindre.")]
    private string nextScene;
    #endregion

    #region camera

    [SerializeField]
    [Tooltip("Position locale de la caméra une fois arrivée au goal.")]
    private Vector3 cameraFinalLocalPosition;

    [Tooltip("Pointeur vers la caméra")]
    private Transform cameraTransform;

    [Tooltip("Position locale de la caméra")]
    private Vector3 cameraLocalPosition;
    
    #endregion

    // Indique si le personnage est stunned
    public bool isStunned
    {
        get { return timeSinceLastStun < stunTime; }
    }

    private void Awake()
    {
        moneyGauge = FindObjectOfType<MoneyGauge>();
        DontDestroyOnLoad(moneyGauge);
    }

    // Use this for initialization
    void Start () {
        feets = this.GetComponentInChildren<CapsuleCollider2D>();
        sprite = this.GetComponentInChildren<SpriteRenderer>();
        cameraTransform = this.transform.FindChild("Main Camera").transform;
        cameraLocalPosition = cameraTransform.localPosition;
	}
	
	// Update is called once per frame
	void Update ()
    {
        HandleStunnedState();
        HandleLevelInteraction();
        HandleWalk();
        HandleJump();
        HandleWin();
        
        moneyGauge.Display();
        
        gauge.value = levelGauge;
        currentSpeed = speed;
	}

    // Fonction gérant le déplacement du personnage
    void HandleWalk()
    {
        if (enableWalking)
        {
            Vector2 dir = new Vector2(moveDirection == Direction.LEFT ? -1.0f : 1.0f, 0.0f);
            Vector2 vit = (dir * currentSpeed * Time.deltaTime);
            transform.position = (Vector2) transform.position + vit;

            if(backgroundTransform != null)
            {
                backgroundTransform.position = backgroundTransform.position + (Vector3) vit * parallaxSpeed;
                InfiniteScroll ins = backgroundTransform.GetComponent<InfiniteScroll>();
                if(ins != null)
                    ins.checkIfFarerThanFrontBackground(this.transform.position);
            }
        }
    }

    // Fonction gérant le saut du personnage
    void HandleJump()
    {
        if (enableJumping && Input.GetAxis(jumpAxis) > 0 && feets.IsTouchingLayers(groundLayerMask))
        {
            Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(0, jumpPower);
        }
    }

    // Fonction gérant les collisions avec des obstacles
    void HandleStunnedState()
    {
        if (isStunned)
        {
            // Gestion du clignotement
            sprite.enabled = (Mathf.RoundToInt(timeSinceLastStun * blinkFrequencyOnStun) % 2 == 0 ? false : true);
            currentSpeed = speed / slowdownOnStun;

            timeSinceLastStun += Time.deltaTime;
        } else
        {
            this.GetComponentInChildren<SpriteRenderer>().enabled = true;
            currentSpeed = speed;
        }
    }

    // Fonction gérant l'appel de l'intéraction avec le niveau
    void HandleLevelInteraction()
    {
        if (Input.GetAxis(levelInteractionAxis) > 0 && levelInteraction != null)
        {
            foreach(ILevelInteraction ile in levelInteraction.GetComponents<ILevelInteraction>())
                ile.CallLevelInteraction();
        }
    }

    // Fonction gérant ce qui se passe lors de la victoire
    void HandleWin()
    {
        if (hasWon)
        {
            this.transform.position = Vector2.Lerp(originTransform, goalLevel1, timeSinceWin / timeToTransform);
            cameraTransform.localPosition = Vector3.Lerp(cameraLocalPosition, cameraFinalLocalPosition, timeSinceWin / timeToTransform);
            timeSinceWin += Time.deltaTime;

            // Gestion de la transition entre les scènes
            if (timeSinceWin > timeToTransform && Input.GetAxis(jumpAxis) > 0)
            {
                SceneManager.LoadScene(nextScene);
            }
        }
    }

    /// <summary>
    /// Stun le player pendant un certain temps.
    /// </summary>
    /// <param name="_stunTime">Temps pendant lequel le player est stunned.</param>
    public void Stun(float _stunTime)
    {
        if (!isStunned)
        {
            stunTime = _stunTime;
            timeSinceLastStun = 0.0f;
        }
    }

    /// <summary>
    /// Augmente la jauge du joueur.
    /// </summary>
    /// <param name="g">Quantité à augmenter de la jauge.</param>
    public void IncreaseGauge(float g)
    {
        levelGauge = Mathf.Clamp(levelGauge + g, 0.0f, 1.0f);
    }

    /// <summary>
    /// Fonction appelée lorsque le joueur finit le premier niveau
    /// </summary>
    public void WinFirstLevel(Vector2 positionToReach, string _nextScene, float _timeToTransform = 3.0f)
    {
        enableWalking = false;
        enableJumping = false;
        goalLevel1 = positionToReach;
        originTransform = this.transform.position;
        timeToTransform = _timeToTransform;
        nextScene = _nextScene;

        hasWon = true;
    }
}
