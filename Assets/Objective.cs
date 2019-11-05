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
            if (amount < enemies.Length)
            {
                checkmark.enabled = false;
            } else
            {
                checkmark.enabled = true;
            }
        } else if (type == "Rescue")
        {
            int amount = 0;
            foreach (Hostage hostage in FindObjectsOfType<Hostage>())
            {
                if (hostage.rescued) ++amount;
            }
            hostagesRescued = amount;
            if (amount < hostages)
            {
                checkmark.enabled = false;
            } else if (amount >= hostages)
            {
                checkmark.enabled = true;
            }
            count.text = "Hostages: " + hostagesRescued + "/" + hostages;
        }
    }

    public void isCompleted()
    {
        if (type == "Clear")
        {
            if (FindObjectsOfType<EnemyController>().Length <= 0) completed = true;
        } else if (type == "Rescue")
        {
            if (hostagesRescued >= hostages) completed = true;
        }
    }
}