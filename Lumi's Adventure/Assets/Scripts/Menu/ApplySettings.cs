using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsApplier : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Image brightnessFilter; // Arrastra el filtro de esta escena aquí

    void Start()
    {
        ApplyStoredSettings();
    }

    public void ApplyStoredSettings()
    {
        // 1. Aplicar Volumen
        if (audioMixer != null)
        {
            float vol = PlayerPrefs.GetFloat("volume", 0.5f);
            audioMixer.SetFloat("volume", vol);
        }

        // 2. Aplicar Brillo
        if (brightnessFilter != null)
        {
            float br = PlayerPrefs.GetFloat("brightness", 1f);
            Color c = brightnessFilter.color;
            c.a = 1 - br;
            brightnessFilter.color = c;
        }
    }
}