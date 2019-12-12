using UnityEngine;

public class Medkit : MonoBehaviour
{
    [SerializeField] private long heal = 15;
    [SerializeField] private GameObject sound = null;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController && playerController.health > 0 && playerController.health < playerController.maxHealth)
            {
                playerController.health += heal;
                if (sound) Instantiate(sound, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}
