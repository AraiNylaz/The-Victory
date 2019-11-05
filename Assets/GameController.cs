using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    [SerializeField] private Objective[] objectives = new Objective[0];
    [SerializeField] private Text mainText = null;

    [HideInInspector] public bool gameOver = false;
    [HideInInspector] public bool won = false;

    void Awake()
    {
        if (!instance)
        {
            instance = this;
        } else if (instance != this)
        {
            Destroy(gameObject);
        }
        gameOver = false;
        won = false;
    }

    void Update()
    {
        int objectivesCompleted = 0;
        foreach (Objective objective in objectives)
        {
            objective.isCompleted();
            if (objective.completed) ++objectivesCompleted;
        }
        if (!gameOver && objectivesCompleted >= objectives.Length) won = true;
        if (gameOver && !won)
        {
            mainText.text = "Game Over!";
        } else if (!gameOver && won)
        {
            mainText.text = "Mission Completed!";
        }
    }
}
