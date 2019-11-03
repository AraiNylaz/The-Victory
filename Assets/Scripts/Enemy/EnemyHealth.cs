using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private long maxHealth = 100;

    [Header("Sound Effects")]
    [SerializeField] private AudioClip hurtSound = null;
    [SerializeField] private AudioClip deathSound = null;

    [Header("Setup")]
    public Transform bloodPoint = null;

    private AudioSource audioSource;
    private long health = 100;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        health = maxHealth;
    }

    void Update()
    {
        if (health <= 0) Destroy(gameObject);
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
        if (health > 0)
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