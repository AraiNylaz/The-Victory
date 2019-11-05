using UnityEngine;
using UnityEngine.UI;

public class Objective : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private string type = "Clear";

    [Header("UI")]
    [SerializeField] private Text count = null;
    [SerializeField] private Image checkmark = null;

    [HideInInspector] public bool completed = false;
    private EnemyController[] enemies;
    private int hostages = 0;
    private int hostagesRescued = 0;

    void Awake()
    {
        completed = false;
        if (type == "Clear")
        {
            enemies = FindObjectsOfType<EnemyController>();
        } else if (type == "Rescue")
        {
            foreach (Hostage hostage in FindObjectsOfType<Hostage>()) ++hostages;
        }
    }

    void Update()
    {
        if (type == "Clear")
        {
            int amount = 0;
            for (int i = 0; i < enemies.Length; i++)
            {
                EnemyHealth enemyHealth = enemies[i].GetComponent<EnemyHealth>();
                if (enemyHealth && enemyHealth.dead) ++amount;
            }
        } else if (type == "Rescue")
        {
            int amount = 0;
            foreach (Hostage hostage in FindObjectsOfType<Hostage>())
            {
                if (hostage.rescued) ++amount;
            }
            hostagesRescued = amount;
            count.text = "Hostages: " + hostagesRescued + "/" + hostages;
        }
    }

    public void isCompleted()
    {
        if (!completed)
        {
            if (type == "Clear")
            {
                int amount = 0;
                for (int i = 0; i < enemies.Length; i++)
                {
                    EnemyHealth enemyHealth = enemies[i].GetComponent<EnemyHealth>();
                    if (enemyHealth && enemyHealth.dead) ++amount;
                }
                if (amount >= enemies.Length)
                {
                    completed = true;
                    checkmark.enabled = true;
                }
            } else if (type == "Rescue")
            {
                if (hostagesRescued >= hostages)
                {
                    completed = true;
                    checkmark.enabled = true;
                }
            }
        }
    }
}