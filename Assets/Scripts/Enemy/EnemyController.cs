using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Vector2Int damage = new Vector2Int(3, 6);
    [SerializeField] private float RPM = 750;
    [SerializeField] private float aggroDistance = 30;
    [SerializeField] private float fieldOfView = 70;
    [SerializeField] private float attackDistance = 25;

    [Header("Sound Effects")]
    [SerializeField] private AudioClip fireSound = null;

    [Header("Setup")]
    [SerializeField] private Transform sightPoint = null;
    [SerializeField] private Light muzzleLight = null;

    private Animator animator;
    private new Animation animation;
    private NavMeshAgent navMeshAgent;
    private AudioSource audioSource;
    private EnemyHealth enemyHealth;
    private bool chasing = false;
    private bool firing = false;
    private PlayerController player;
    private float nextShot = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
        animation = GetComponent<Animation>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();
        enemyHealth = GetComponent<EnemyHealth>();
        if (!sightPoint) sightPoint = transform;
    }

    void Update()
    {
        if (!enemyHealth.dead)
        {
            getPlayer(false);
            if (player)
            {
                navMeshAgent.enabled = true;
                if (!player.dead)
                {
                    if (!chasing)
                    {
                        if (Vector3.Distance(sightPoint.position, player.transform.position) <= 3) chasing = true;
                        if (Vector3.Distance(sightPoint.position, player.transform.position) <= aggroDistance)
                        {
                            Vector3 playerPosition = (player.transform.position - sightPoint.position).normalized;
                            if (Vector3.Dot(transform.forward, playerPosition) > 0 && Vector3.Angle(transform.forward, playerPosition) <= fieldOfView)
                            {   
                                Ray ray = new Ray(sightPoint.position, player.transform.position - sightPoint.position);
                                if (Physics.Raycast(ray, out RaycastHit hit) && hit.collider.CompareTag("Player")) chasing = true;
                            }
                        }
                    } else
                    {
                        if (Vector3.Distance(sightPoint.position, player.transform.position) <= attackDistance)
                        {
                            Ray ray = new Ray(sightPoint.position, transform.forward * attackDistance);
                            if (Physics.Raycast(ray, out RaycastHit hit) && hit.collider.CompareTag("Player"))
                            {
                                firing = true;
                            } else
                            {
                                firing = false;
                            }
                        } else
                        {
                            firing = false;
                        }
                    }
                    if (firing && Time.time >= nextShot)
                    {
                        nextShot = Time.time + 60 / RPM;
                        player.takeDamage(Random.Range(damage.x, damage.y));
                        if (muzzleLight)
                        {
                            muzzleLight.enabled = true;
                            CancelInvoke("resetEffects");
                            Invoke("resetEffects", 0.075f);
                        }
                        foreach (EnemyController enemyController in FindObjectsOfType<EnemyController>())
                        {
                            if (Vector3.Distance(transform.position, enemyController.transform.position) <= 50) enemyController.getPlayer(true);
                        }
                        if (audioSource && fireSound) audioSource.PlayOneShot(fireSound);
                    }
                } else
                {
                    chasing = false;
                    firing = false;
                }
            } else
            {
                chasing = false;
                firing = false;
            }
            if (chasing)
            {
                if (!firing)
                {
                    navMeshAgent.isStopped = false;
                    navMeshAgent.SetDestination(player.transform.position);
                    if (animator) animator.SetBool("Walking", true);
                    if (animation && !animation.isPlaying) animation.Play();
                } else
                {
                    navMeshAgent.isStopped = true;
                    if (animator) animator.SetBool("Walking", false);
                    if (animation && animation.isPlaying) animation.Stop();
                }
            } else
            {
                navMeshAgent.isStopped = true;
                if (animator) animator.SetBool("Walking", false);
                if (animation && animation.isPlaying) animation.Stop();
            }
        } else
        {
            navMeshAgent.enabled = false;
            if (animator) animator.SetBool("Walking", false);
            if (animation && animation.isPlaying) animation.Stop();
        }
    }

    #region Main Functions
    public void getPlayer(bool hit)
    {
        player = FindObjectOfType<PlayerController>();
        if (hit) chasing = true;
    }

    void resetEffects()
    {
        if (muzzleLight) muzzleLight.enabled = false;
    }

    public void playDeathAnimation()
    {
        if (animator)
        {
            animator.SetBool("Walking", false);
            if (Random.value <= 0.5f)
            {
                animator.SetTrigger("DieForward");
            } else
            {
                animator.SetTrigger("DieBack");
            }
            StartCoroutine(dropBody());
        }
    }

    IEnumerator dropBody() //
    {
        for (int i = 0; i < 18; i ++)
        {
            transform.position -= new Vector3(0, 0.05f, 0);
            yield return new WaitForEndOfFrame();
        }
    }
    #endregion
}