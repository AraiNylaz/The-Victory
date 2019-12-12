using UnityEngine;
using UnityEngine.UI;

public class SetSensitivity : MonoBehaviour
{
    [SerializeField] private string sensitivity = "";
    [SerializeField] private float defaultValue = 4;

    private Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
        if (PlayerPrefs.HasKey(sensitivity))
        {
            slider.value = PlayerPrefs.GetFloat(sensitivity);
        } else
        {
            slider.value = defaultValue;
        }
    }

    public void setSensitivity()
    {
        PlayerPrefs.SetFloat(sensitivity, slider.value);
        PlayerPrefs.Save();
    }
}