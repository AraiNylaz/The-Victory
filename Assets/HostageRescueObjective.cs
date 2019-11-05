using UnityEngine;
using UnityEngine.UI;

public class HostageRescueObjective : MonoBehaviour
{
    [SerializeField] private Text count = null;
    [SerializeField] private Image checkmark = null;

    private long hostageAmount = 0;
    [HideInInspector] public long hostagesRescued = 0;

    void Start()
    {
        foreach (Hostage hostage in FindObjectsOfType<Hostage>()) ++hostageAmount;
    }

    void Update()
    {
        long amount = 0;
        foreach (Hostage hostage in FindObjectsOfType<Hostage>())
        {
            if (hostage.rescued) ++amount;
        }
        hostagesRescued = amount;
        if (hostagesRescued >= hostageAmount)
        {
            GameController.instance.won = true;
            checkmark.enabled = true;
        }
        count.text = "Hostages: " + hostagesRescued + "/" + hostageAmount;
    }
}
