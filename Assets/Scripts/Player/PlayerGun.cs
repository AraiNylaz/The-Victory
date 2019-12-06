using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGun : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private long damage = 20;
    [SerializeField] private float RPM = 750;
    [SerializeField] private float spread = 0.05f;
    [SerializeField] private int maxAmmo = 30;
    [Tooltip("Amount of shots in a bullet.")] [SerializeField] private int shots = 1;
    [Tooltip("Amount of bullets to fire in a shot.")] [SerializeField] private int bulletsFired = 1;
    [SerializeField] private float reloadTime = 3;
    [SerializeField] private bool auto = false;
    [SerializeField] private Vector3 aimPosition = Vector3.zero;
    [SerializeField] private float aimFOVIncrement = 15;

    [Header("UI")]
    [SerializeField] private Text ammoText = null;
    [SerializeField] private Image crosshair = null;

    [Header("Sound Effects")]
    [SerializeField] private AudioClip fireSound = null;
    [SerializeField] private AudioClip reloadSound = null;

    [Header("Setup")]
    [SerializeField] private Transform muzzle = null;
    [SerializeField] private GameObject blood = null;
    [SerializeField] private GameObject bulletHole = null;
    [SerializeField] private Camera weaponCamera = null;

    private AudioSource audioSource;
    private Light muzzleLight;
    private PlayerController playerController;
    private Controls input;
    private int ammo = 30;
    private bool firing = false;
    private bool aiming = false;
    private bool reloading = false;
    private bool holding = false;
    private float nextShot = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        muzzleLight = muzzle.GetComponent<Light>();
        playerController = GetComponent<PlayerController>();
        ammo = maxAmmo;
        resetEffects();
    }

    void Awake()
    {
        input = new Controls();
    }

    void OnEnable()
    {
        input.Enable();
        input.Player.Fire.performed += context => shoot(true);
        input.Player.Aim.performed += context => aim(true);
        input.Player.Reload.performed += context => reload();
        input.Player.Fire.canceled += context => shoot(false);
        input.Player.Aim.canceled += context => aim(false);
    }

    void OnDisable()
    {
        input.Disable();
        input.Player.Fire.performed -= context => shoot(true);
        input.Player.Aim.performed -= context => aim(true);
        input.Player.Reload.performed -= context => reload();
        input.Player.Fire.canceled -= context => shoot(false);
        input.Player.Aim.canceled -= context => aim(false);
    }

    void Update()
    {
        if (ammo < 0)
        {
            ammo = 0;
        } else if (ammo > maxAmmo)
        {
            ammo = maxAmmo;
        }
        if (!reloading)
        {
            ammoText.text = "Ammo: " + ammo + "/" + maxAmmo;
        } else
        {
            ammoText.text = "Reloading...";
        }
    }

    #region Input Functions
    void shoot(bool state)
    {
        if (!GameController.instance.gameOver && !GameController.instance.won && !GameController.instance.paused)
        {
            if (state)
            {
                if (ammo > 0 && Time.time >= nextShot)
                {
                    if (!auto)
                    {
                        if (!holding)
                        {
                            StartCoroutine(fire(damage, RPM, spread, shots, bulletsFired));
                            holding = true;
                        }
                    } else
                    {
                        holding = true;
                        StartCoroutine(autofire());
                    }
                }
            } else
            {
                holding = false;
                StopCoroutine(autofire());
            }
        }
    }

    void aim(bool state)
    {
        if (!GameController.instance.gameOver && !GameController.instance.won && !GameController.instance.paused)
        {
            if (!reloading)
            {
                if (state && !aiming)
                {
                    aiming = true;
                    transform.Translate(-aimPosition);
                    Camera.main.fieldOfView -= aimFOVIncrement;
                    if (weaponCamera) weaponCamera.fieldOfView = Camera.main.fieldOfView;
                    if (crosshair) crosshair.enabled = false;
                } else if (!state && aiming)
                {
                    aiming = false;
                    transform.Translate(aimPosition);
                    Camera.main.fieldOfView += aimFOVIncrement;
                    if (weaponCamera) weaponCamera.fieldOfView = Camera.main.fieldOfView;
                    if (crosshair) crosshair.enabled = true;
                }
            }
        }
    }

    void reload()
    {
        if (ammo < maxAmmo && !reloading && !GameController.instance.gameOver && !GameController.instance.won && !GameController.instance.paused)
        {
            aim(false);
            reloading = true;
            Invoke("finishReload", reloadTime);
            if (audioSource && reloadSound) audioSource.PlayOneShot(reloadSound);
        }
    }
    #endregion

    #region Main Functions
    IEnumerator fire(long damage, float RPM, float spread, int shots, int bulletsFired)
    {
        if (!firing && !reloading && !GameController.instance.gameOver && !GameController.instance.won && !GameController.instance.paused)
        {
            int c = 0;
            int shotsToFire = bulletsFired;
            if (shotsToFire < 1) shotsToFire = 1;
            firing = true;
            while (c < shotsToFire)
            {
                if (Time.time >= nextShot)
                {
                    ++c;
                    --ammo;
                    nextShot = Time.time + 60 / RPM;
                    if (muzzleLight) muzzleLight.enabled = true;
                    if (audioSource && fireSound) audioSource.PlayOneShot(fireSound);
                    CancelInvoke("resetEffects");
                    Invoke("resetEffects", 0.075f);
                    for (int i = 0; i < shots; i++)
                    {
                        Vector3 bulletDirection = muzzle.forward;
                        bulletDirection.x += Random.Range(-spread, spread);
                        bulletDirection.y += Random.Range(-spread, spread);
                        Ray bulletRay = new Ray(muzzle.position, muzzle.forward);
                        if (Physics.Raycast(bulletRay, out RaycastHit bulletHit))
                        {
                            if (bulletHit.collider.CompareTag("Enemy") && bulletHit.collider.GetComponent<EnemyHealth>())
                            {
                                bulletHit.collider.GetComponent<EnemyHealth>().takeDamage(damage);
                                EnemyController enemyController = bulletHit.collider.GetComponent<EnemyController>();
                                if (enemyController) enemyController.getPlayer(true);
                                if (blood) Instantiate(blood, bulletHit.point, Quaternion.FromToRotation(Vector3.forward, bulletHit.normal));
                            } else if (bulletHit.collider.CompareTag("Hostage") && bulletHit.collider.GetComponent<Hostage>())
                            {
                                bulletHit.collider.GetComponent<Hostage>().takeDamage(damage);
                                if (blood) Instantiate(blood, bulletHit.point, Quaternion.FromToRotation(Vector3.forward, bulletHit.normal));
                            } else
                            {
                                if (bulletHole)
                                {
                                    GameObject hole = Instantiate(bulletHole, bulletHit.point, Quaternion.FromToRotation(Vector3.forward, bulletHit.normal));
                                    hole.transform.Translate(0, 0, 0.01f);
                                }
                            }
                        }
                        foreach (EnemyController enemyController in FindObjectsOfType<EnemyController>())
                        {
                            if (Vector3.Distance(muzzle.position, enemyController.transform.position) <= 50) enemyController.getPlayer(true);
                        }
                    }
                } else
                {
                    yield return null;
                }
            }
            firing = false;
        } else
        {
            yield return null;
        }
    }

    IEnumerator autofire()
    {
        while (!reloading && holding)
        {
            if (ammo > 0 && !reloading && Time.time >= nextShot) StartCoroutine(fire(damage, RPM, spread, shots, 1));
            yield return null;
        }
    }

    void finishReload()
    {
        ammo = maxAmmo;
        reloading = false;
    }

    void resetEffects()
    {
        if (muzzleLight) muzzleLight.enabled = false;
    }

    public void deadState()
    {
        reloading = false;
        CancelInvoke("finishReload");
        if (aiming) aim(false);
        if (crosshair) crosshair.enabled = false;
        Destroy(gameObject);
    }
    #endregion
}