using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    [SerializeField] private Objective[] objectives = new Objective[0];
    [SerializeField] private Text mainText = null;
    [SerializeField] private AudioMixer audioMixer = null;

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
        Time.timeScale = 1;
        AudioListener.pause = false;
        if (!PlayerPrefs.HasKey("SoundVolume"))
        {
            PlayerPrefs.SetFloat("SoundVolume", 1);
            PlayerPrefs.Save();
        } else
        {
            audioMixer.SetFloat("SoundVolume", Mathf.Log10(PlayerPrefs.GetFloat("SoundVolume")) * 20);
        }
        if (!PlayerPrefs.HasKey("MusicVolume"))
        {
            PlayerPrefs.SetFloat("MusicVolume", 1);
            PlayerPrefs.Save();
        } else
        {
            audioMixer.SetFloat("MusicVolume", Mathf.Log10(PlayerPrefs.GetFloat("MusicVolume")) * 20);
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
