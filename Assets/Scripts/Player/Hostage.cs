using UnityEngine;
using UnityEngine.AI;

public class Hostage : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private long maxHealth = 100;

    [Header("Sound Effects")]
    [SerializeField] private AudioClip hurtSound = null;
    [SerializeField] private AudioClip deathSound = null;

    private NavMeshAgent navMeshAgent;
    private new Animation animation;
    private AudioSource audioSource;
    private long health = 100;
    [HideInInspector] public bool dead = false;
    [HideInInspector] public bool rescued = false;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animation = GetComponent<Animation>();
        audioSource = GetComponent<AudioSource>();
        health = maxHealth;
        dead = false;
        rescued = false;
    }

    void Update()
    {
        if (health <= 0 && !dead)
        {
            dead = true;
            if (Random.value <= 0.5f)
            {
                animation.Play("Falling Forward Death", PlayMode.StopAll);
            } else
            {
                animation.Play("Falling Back Death", PlayMode.StopAll);
            }
            GetComponent<Collider>().enabled = false;
            if (FindObjectOfType<PlayerController>()) FindObjectOfType<PlayerController>().warn();
        }
    }

    #region Main Functions
    public void rescue()
    {
        if (!dead && !rescued)
        {
            rescued = true;
            animation.Play("Idle", PlayMode.StopAll);
        }
    }

    public void takeDamage(long damage)
    {
        if (health > 0 && !dead)
        {
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
                    if (hurtSound)
                    {
                        audioSource.PlayOneShot(hurtSound);
                    } else
                    {
                        audioSource.Play();
                    }
                } else
                {
                    if (deathSound) audioSource.PlayOneShot(deathSound);
                }
            }
        }
    }
    #endregion
}