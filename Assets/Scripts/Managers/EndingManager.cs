using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class EndingManager : MonoBehaviour
{
    public Dialog[] dialogue = new Dialog[0];

    [Header("Setup")]
    [SerializeField] private Text dialogText = null;
    [SerializeField] private GameObject loadingScreen = null;
    [SerializeField] private Slider loadingSlider = null;
    [SerializeField] private Text loadingPercentage = null;
    [SerializeField] private Canvas missionCompletedMenu = null;
    [SerializeField] private AudioMixer audioMixer = null;

    private AudioSource audioSource;
    private Controls input;
    private int currentDialog = 0;
    private bool loading = false;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
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
        StartCoroutine(cutscene());
        StartCoroutine(updateDialog());
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

    IEnumerator cutscene()
    {
        for (int i = 0; i < 160; i++)
        {
            yield return new WaitForEndOfFrame();
            Camera.main.transform.Rotate(0, 0.5f, 0);
        }
        yield return new WaitForSeconds(20);
        missionCompletedMenu.enabled = true;
    }

    IEnumerator updateDialog()
    {
        currentDialog = 0;
        yield return new WaitForSeconds(dialogue[0].nextDialogTime);
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
                missionCompletedMenu.enabled = false;
                yield return null;
            }
        }
    }

    public void exitToMainMenu()
    {
        if (audioSource) audioSource.PlayOneShot(audioSource.clip);
        StartCoroutine(loadScene("Main Menu"));
    }
}