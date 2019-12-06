using UnityEngine;
using UnityEngine.UI;

public class Objective : MonoBehaviour
{
    [SerializeField] private Types type = Types.Clear;
    [SerializeField] private Text count = null;
    [SerializeField] private Image checkmark = null;

    [SerializeField] private enum Types {Clear, Rescue};
    [HideInInspector] public bool completed = false;
    private EnemyController[] enemies;
    private int hostages = 0;
    private int hostagesRescued = 0;

    void Awake()
    {
        completed = false;
        if (type == Types.Clear)
        {
            enemies = FindObjectsOfType<EnemyController>();
        } else if (type == Types.Rescue)
        {
            foreach (Hostage hostage in FindObjectsOfType<Hostage>()) ++hostages;
        }
    }

    void Update()
    {
        if (type == Types.Clear)
        {
            int amount = 0;
            for (int i = 0; i < enemies.Length; i++)
            {
                EnemyHealth enemyHealth = enemies[i].GetComponent<EnemyHealth>();
                if (enemyHealth && enemyHealth.dead) ++amount;
            }
        } else if (type == Types.Rescue)
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
            if (type == Types.Clear)
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
            } else if (type == Types.Rescue)
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