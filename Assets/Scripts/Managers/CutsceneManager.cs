using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

[System.Serializable]
public struct Dialog
{
    public string text;
    public float time;
    public float nextDialogTime;
}

public class CutsceneManager : MonoBehaviour
{
    public Dialog[] dialogue = new Dialog[0];

    [Header("Setup")]
    [SerializeField] private Text dialogText = null;
    [SerializeField] private GameObject loadingScreen = null;
    [SerializeField] private Slider loadingSlider = null;
    [SerializeField] private Text loadingPercentage = null;
    [SerializeField] private AudioMixer audioMixer = null;

    private Controls input;
    private int currentDialog = 0;
    private bool loading = false;

    void Awake()
    {
        input = new Controls();
        loading = false;
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
        Invoke("endCutscene", 846);
        StartCoroutine(updateDialog());
    }

    void OnEnable()
    {
        input.Enable();
        input.Gameplay.SkipCutscene.performed += context => endCutscene();
    }

    void OnDisable()
    {
        input.Disable();
        input.Gameplay.SkipCutscene.performed -= context => endCutscene();
    }

    void Update()
    {
        if (!loading)
        {
            loadingScreen.SetActive(false);
        } else
        {
            loadingScreen.SetActive(true);
        }
    }

    void endCutscene()
    {
        StartCoroutine(loadScene("Forest"));
    }

    IEnumerator updateDialog()
    {
        currentDialog = 0;
        dialogText.text = dialogue[0].text;
        while (currentDialog < dialogue.Length)
        {
            yield return new WaitForSeconds(dialogue[currentDialog].time);
            dialogText.text = "";
            yield return new WaitForSeconds(dialogue[currentDialog].nextDialogTime);
            ++currentDialog;
            dialogText.text = dialogue[currentDialog].text;
        }
        dialogText.text = "";
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
                yield return null;
            }
        }
    }
}
