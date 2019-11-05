using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

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

    // Update is called once per frame
    void Update()
    {
        if (gameOver && !won)
        {
            mainText.text = "Game Over!";
        } else if (!gameOver && won)
        {
            mainText.text = "Mission Completed!";
        }
    }
}
