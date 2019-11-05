using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private long maxHealth = 100;
    [SerializeField] private float walkSpeed = 5;
    [SerializeField] private float runSpeed = 7; 
    [SerializeField] private float jumpHeight = 1.5f;
    [SerializeField] private float crouchHeight = 1.2f;
    [SerializeField] private Vector2 mouseSensitivity = new Vector2(5, 5);
    [SerializeField] private LayerMask groundLayer = 0;

    [Header("UI")]
    [SerializeField] private Image damageOverlay = null;
    [SerializeField] private Image crosshair = null;
    [SerializeField] private Text healthText = null;
    [SerializeField] private Text rescueText = null;
    [SerializeField] private Text warnText = null;

    [Header("Sound Effects")]
    [SerializeField] private AudioClip[] hurtSounds = new AudioClip[0];
    [SerializeField] private AudioClip[] deathSounds = new AudioClip[0];

    [Header("Setup")]
    [SerializeField] private PlayerGun[] weapons = new PlayerGun[0];

    private CharacterController characterController;
    private new CapsuleCollider collider;
    private AudioSource audioSource;
    private Controls input;
    private long health = 100;
    [HideInInspector] public bool dead = false;
    private bool crouching = false;
    private bool running = false;
    private int hostagesKilled = 0;
    private bool damaged = false;
    private Vector3 velocity;
    private bool grounded = false;
    private Vector3 movement;
    private Vector2 cameraMovement;
    private float cameraX = 0;
    private Hostage currentHostage;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        collider = GetComponent<CapsuleCollider>();
        audioSource = GetComponent<AudioSource>();
        health = maxHealth;
        dead = false;
        resetWarnText();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Awake()
    {
        input = new Controls();
    }

    void OnEnable()
    {
        input.Enable();
        input.Player.Move.performed += context => move(context.ReadValue<Vector2>());
        input.Player.Run.performed += context => run(true);
        input.Player.Jump.performed += context => jump();
        input.Player.Crouch.performed += context => crouch();
        input.Player.Turn.performed += context => turn(context.ReadValue<Vector2>());
        input.Player.RescueHostage.performed += context => rescueHostage();
        input.Player.Move.canceled += context => move(Vector2.zero);
        input.Player.Run.canceled += context => run(false);
    }

    void OnDisable()
    {
        input.Disable();
        input.Player.Move.performed -= context => move(context.ReadValue<Vector2>());
        input.Player.Run.performed -= context => run(true);
        input.Player.Jump.performed -= context => jump();
        input.Player.Crouch.performed -= context => crouch();
        input.Player.Turn.performed -= context => turn(context.ReadValue<Vector2>());
        input.Player.RescueHostage.performed += context => rescueHostage();
        input.Player.Move.canceled -= context => move(Vector2.zero);
        input.Player.Run.canceled -= context => run(false);
    }

    void Update()
    {
        if (health <= 0 && !dead && !GameController.instance.gameOver && !GameController.instance.won)
        {
            dead = true;
            GameController.instance.gameOver = true;
            Camera.main.transform.position = transform.position;
            Camera.main.transform.rotation = transform.rotation;
            Camera.main.transform.Rotate(new Vector3(-15, 0, 85));
            foreach (PlayerGun weapon in weapons)
            {
                if (weapon && weapon.gameObject.activeInHierarchy) weapon.deadState();
            }
            if (crosshair) crosshair.enabled = false;
            Cursor.lockState = CursorLockMode.None;
        }
        grounded = Physics.CheckSphere(transform.position, 0.4f, groundLayer);
        if (grounded && velocity.y < 0) velocity.y = -2;
        if (!dead)
        {
            float moveHorizontal = Input.GetAxisRaw("Horizontal");
            float moveVertical = Input.GetAxisRaw("Vertical");
            movement = transform.right * moveHorizontal + transform.forward * moveVertical;
            float speed;
            if (!running)
            {
                speed = walkSpeed;
            } else
            {
                speed = runSpeed;
            }
            characterController.Move(movement.normalized * speed * Time.deltaTime);
            Ray ray = new Ray (Camera.main.transform.position, Camera.main.transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, 2) && hit.collider.GetComponent<Hostage>() && !hit.collider.GetComponent<Hostage>().rescued)
            {
                currentHostage = hit.collider.GetComponent<Hostage>();
                rescueText.enabled = true;
            } else
            {
                currentHostage = null;
                rescueText.enabled = false;
            }
        }
        velocity += Physics.gravity * 2 * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
        if (health < 0)
        {
            health = 0;
        } else if (health > maxHealth)
        {
            health = maxHealth;
        }
        if (crouching) running = false;
        if (damaged)
        {
            damageOverlay.color = new Color(1, 0, 0, 0.5f);
        } else
        {
            damageOverlay.color = Color.Lerp(damageOverlay.color, new Color(1, 0, 0, 0), 10);
        }
        damaged = false;
        healthText.text = "Health: " + health + "/" + maxHealth;
    }

    #region Input Functions
    void move(Vector2 direction)
    {
        //movement = new Vector3(direction.x, 0, direction.y);
    }

    void run(bool state)
    {
        if (!dead && !crouching) running = state;
    }

    void jump()
    {
        if (!dead && grounded)
        {
            if (!crouching)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2 * Physics.gravity.y * 2);
            } else
            {
                crouch();
            }
        }
    }

    void crouch()
    {
        if (!dead && grounded)
        {
            if (!crouching)
            {
                crouching = true;
                characterController.height -= crouchHeight;
                collider.height -= crouchHeight;
            } else
            {
                crouching = false;
                characterController.height += crouchHeight;
                collider.height += crouchHeight;
            }
        }
    }

    void turn(Vector2 direction)
    {
        if (!dead)
        {
            cameraMovement = new Vector2(direction.x * mouseSensitivity.x * Time.deltaTime, direction.y * mouseSensitivity.y * Time.deltaTime);
            cameraX -= cameraMovement.y;
            cameraX = Mathf.Clamp(cameraX, -90, 90);
            transform.Rotate(Vector3.up * cameraMovement.x);
            Camera.main.transform.localRotation = Quaternion.Euler(cameraX, 0, 0);
        }
    }

    void rescueHostage()
    {
        if (currentHostage && !currentHostage.rescued) currentHostage.rescue();
    }
    #endregion

    #region Main Functions
    public void takeDamage(long damage)
    {
        if (health > 0 && !dead)
        {
            damaged = true;
            if (damage > 0)
            {
                health -= damage;
            } else
            {
                --health;
            }
            if (audioSource)
            {
                if (health > 0)
                {
                    if (hurtSounds.Length > 0)
                    {
                        AudioClip sound = hurtSounds[Random.Range(0, hurtSounds.Length)];
                        if (sound) audioSource.PlayOneShot(sound);
                    } else
                    {
                        audioSource.Play();
                    }
                } else
                {
                    if (deathSounds.Length > 0)
                    {
                        AudioClip sound = deathSounds[Random.Range(0, deathSounds.Length)];
                        if (sound) audioSource.PlayOneShot(sound);
                    }
                }
            }
        }
    }

    public void warn()
    {
        if (!dead)
        {
            ++hostagesKilled;
            if (hostagesKilled < 2)
            {
                warnText.enabled = true;
                Invoke("resetWarnText", 1.5f);
            } else
            {
                health = 0;
            }
        }
    }

    void resetWarnText()
    {
        warnText.enabled = false;
    }
    #endregion
}