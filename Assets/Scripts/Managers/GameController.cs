using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    [Header("Settings")]
    [SerializeField] private Objective[] objectives = new Objective[0];

    [Header("UI")]
    [SerializeField] private Canvas gameHUD = null;
    [SerializeField] private Canvas gamePausedMenu = null;
    [SerializeField] private Canvas gameOverMenu = null;
    [SerializeField] private Canvas levelCompletedMenu = null;
    [SerializeField] private Canvas settingsMenu = null;
    [SerializeField] private Canvas graphicsQualityMenu = null;
    [SerializeField] private Canvas soundMenu = null;
    [SerializeField] private GameObject loadingScreen = null; 
    [SerializeField] private Slider loadingSlider = null;
    [SerializeField] private Text loadingPercentage = null;

    [Header("Sound Effects")]
    [SerializeField] private AudioClip buttonClick = null;

    [Header("Setup")]
    [SerializeField] private AudioMixer audioMixer = null;

    private AudioSource audioSource;
    private Controls input;
    private enum ClickSources {GamePaused, GameOver, LevelCompleted}
    [HideInInspector] public bool gameOver = false;
    [HideInInspector] public bool won = false;
    [HideInInspector] public bool paused = false;
    private ClickSources clickSource = ClickSources.GamePaused;
    private bool loading = false;

    void Awake()
    {
        if (!instance)
        {
            instance = this;
        } else if (instance != this)
        {
            Destroy(gameObject);
        }
        audioSource = GetComponent<AudioSource>();
        input = new Controls();
        if (audioSource) audioSource.ignoreListenerPause = true;
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
        paused = false;
        gameHUD.enabled = true;
        gamePausedMenu.enabled = false;
        gameOverMenu.enabled = false;
        levelCompletedMenu.enabled = false;
        settingsMenu.enabled = false;
        graphicsQualityMenu.enabled = false;
        soundMenu.enabled = false;
    }

    void OnEnable()
    {
        input.Enable();
        input.Gameplay.Pause.performed += context => pause();
        input.Gameplay.Resume.performed += context => resume(false);
    }

    void OnDisable()
    {
        input.Disable();
        input.Gameplay.Pause.performed -= context => pause();
        input.Gameplay.Resume.performed -= context => resume(false);
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
            if (!loading && !settingsMenu.enabled && !graphicsQualityMenu.enabled && !soundMenu.enabled) gameOverMenu.enabled = true;
        } else if (!gameOver && won)
        {
            if (!loading && !settingsMenu.enabled && !graphicsQualityMenu.enabled && !soundMenu.enabled) levelCompletedMenu.enabled = true;
        }
        if (!loading)
        {
            loadingScreen.SetActive(false);
        } else
        {
            loadingScreen.SetActive(true);
        }
    }

    IEnumerator loadScene(string scene)
    {
        if (!loading)
        {
            loading = true;
            AsyncOperation load = SceneManager.LoadSceneAsync(scene);
            if (Camera.main.GetComponent<AudioSource>()) Camera.main.GetComponent<AudioSource>().Stop();
            while (!load.isDone)
            {
                Time.timeScale = 0;
                AudioListener.pause = true;
                if (load.progress < 0.9f)
                {
                    loadingSlider.value = load.progress;
                    loadingPercentage.text = Mathf.Floor(load.progress * 100) + "%";
                } else
                {
                    loadingSlider.value = 1;
                    loadingPercentage.text = "100%";
                }
                gameHUD.enabled = false;
                gamePausedMenu.enabled = false;
                gameOverMenu.enabled = false;
                levelCompletedMenu.enabled = false;
                settingsMenu.enabled = false;
                graphicsQualityMenu.enabled = false;
                soundMenu.enabled = false;
                yield return null;
            }
        }
    }

    #region Input Functions
    void pause()
    {
        if (!paused)
        {
            paused = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
            AudioListener.pause = true;
            gamePausedMenu.enabled = true;
        } else
        {
            paused = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
            AudioListener.pause = false;
            gamePausedMenu.enabled = false;
        }
    }
    #endregion

    #region Menu Functions

    public void resume(bool wasClicked)
    {
        if (audioSource && wasClicked)
        {
            if (buttonClick)
            {
                audioSource.PlayOneShot(buttonClick);
            } else
            {
                audioSource.Play();
            }
        }
        paused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        AudioListener.pause = false;
        gamePausedMenu.enabled = false;
    }

    public void restart()
    {
        if (audioSource)
        {
            if (buttonClick)
            {
                audioSource.PlayOneShot(buttonClick);
            } else
            {
                audioSource.Play();
            }
        }
        StartCoroutine(loadScene(SceneManager.GetActiveScene().name));
    }

    public void exitToMainMenu()
    {
        if (audioSource)
        {
            if (buttonClick)
            {
                audioSource.PlayOneShot(buttonClick);
            } else
            {
                audioSource.Play();
            }
        }
        StartCoroutine(loadScene("Main Menu"));
    }

    public void exitGame()
    {
        if (audioSource)
        {
            if (buttonClick)
            {
                audioSource.PlayOneShot(buttonClick);
            } else
            {
                audioSource.Play();
            }
        }
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void openCanvasFromClickSource(Canvas canvas)
    {
        if (!canvas.enabled)
        {
            canvas.enabled = true;
            if (clickSource == ClickSources.GamePaused)
            {
                gamePausedMenu.enabled = false;
            } else if (clickSource == ClickSources.GameOver)
            {
                gameOverMenu.enabled = false;
            } else if (clickSource == ClickSources.LevelCompleted)
            {
                levelCompletedMenu.enabled = false;
            }
        } else
        {
            canvas.enabled = false;
            if (clickSource == ClickSources.GamePaused)
            {
                gamePausedMenu.enabled = true;
            } else if (clickSource == ClickSources.GameOver)
            {
                gameOverMenu.enabled = true;
            } else if (clickSource == ClickSources.LevelCompleted)
            {
                levelCompletedMenu.enabled = true;
            }
        }
    }

    public void openCanvasFromSettings(Canvas canvas)
    {
        if (!canvas.enabled)
        {
            canvas.enabled = true;
            settingsMenu.enabled = false;
        } else
        {
            canvas.enabled = false;
            settingsMenu.enabled = true;
        }
    }
    #endregion
}
