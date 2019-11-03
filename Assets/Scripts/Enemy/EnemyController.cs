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
        if (!sightPoint) sightPoint = transform;
    }

    void Update()
    {
        getPlayer(false);
        if (player)
        {
            if (!player.dead)
            {
                if (!chasing)
                {
                    if (Vector3.Distance(sightPoint.position, player.transform.position) <= aggroDistance)
                    {
                        Vector3 playerPosition = (player.transform.position - sightPoint.position).normalized;
                        if (Vector3.Dot(transform.forward, playerPosition) > 0 && Vector3.Angle(transform.forward, playerPosition) <= fieldOfView)
                        {   
                            Ray ray = new Ray(sightPoint.position, player.transform.position - sightPoint.position);
                            if (Physics.Raycast(ray, out RaycastHit hit) && hit.collider.CompareTag("Player")) chasing = true;
                        }
                    }
                    if (Vector3.Distance(sightPoint.position, player.transform.position) <= 3) chasing = true;
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
    }

    public void getPlayer(bool hit)
    {
        player = FindObjectOfType<PlayerController>();
        if (hit) chasing = true;
    }

    void resetEffects()
    {
        if (muzzleLight) muzzleLight.enabled = false;
    }
}