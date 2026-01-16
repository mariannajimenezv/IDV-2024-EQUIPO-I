using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public TMP_Dropdown resolutionDropDown;
    public Image brightnessFilter;

    public Slider volumeSlider;
    public Slider brightnessSlider;

    Resolution[] resolutions;

    void Start()
    {
        if(resolutionDropDown != null) LoadResolutions(); 
        LoadSettings();
    } 

    public void LoadResolutions()
    {
        resolutions = Screen.resolutions;
        resolutionDropDown.ClearOptions();

        List<string> options = new();

        int currentResolutionIndex = 0;
        for (int i=0; i<resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currentResolutionIndex;
        resolutionDropDown.RefreshShownValue();
    }

    private void LoadSettings()
    {
        float savedVolume = PlayerPrefs.GetFloat("volume", 0);
        if (audioMixer != null) audioMixer.SetFloat("volume", savedVolume);
        
        // Sincronizar el slider visualmente si estamos en la escena de menú
        if (volumeSlider != null) volumeSlider.value = savedVolume;

        // Cargar y Aplicar Brillo
        float savedBrightness = PlayerPrefs.GetFloat("brightness", 1f);
        SetBrightness(savedBrightness);
    }

    // UI interactables
    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    
    public void SetVolume(float volume)
    {
        PlayerPrefs.SetFloat("volume", volume); // Persistencia
        if (audioMixer != null) audioMixer.SetFloat("volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetBrightness(float brightness)
    {
        PlayerPrefs.SetFloat("brightness", brightness);
        if(brightnessFilter != null)
        {
            Color c = brightnessFilter.color;
            c.a = 1 - brightness;
            brightnessFilter.color = c;
            PlayerPrefs.SetFloat("brightness", brightness);
        }
    }
}
