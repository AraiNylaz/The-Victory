using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private long maxHealth = 100;

    [Header("Sound Effects")]
    [SerializeField] private AudioClip hurtSound = null;
    [SerializeField] private AudioClip deathSound = null;

    private new Collider collider;
    private AudioSource audioSource;
    private EnemyController enemyController;
    private long health = 100;
    [HideInInspector] public bool dead = false;

    void Start()
    {
        collider = GetComponent<Collider>();
        audioSource = GetComponent<AudioSource>();
        enemyController = GetComponent<EnemyController>();
        health = maxHealth;
        dead = false;
    }

    void Update()
    {
        if (health <= 0 && !dead)
        {
            dead = true;
            if (collider) collider.enabled = false;
            if (enemyController) enemyController.playDeathAnimation();
        }
        if (health < 0)
        {
            health = 0;
        } else if (health > maxHealth)
        {
            health = maxHealth;
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
}