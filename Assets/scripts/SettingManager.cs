using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    public Toggle fullscreenToggle;
    public Dropdown resolutionDropdown;
    public Dropdown textureQualityDropdown;
    public Dropdown antialiasingDropdown;
    public Dropdown vSyncDropdown;
    public Slider musicVolumeSlider;

    public AudioSource musicSource;
    public Resolution[] resolutions;
    public Gamesettings gameSettings;


    void OnEnable()
    {
        gameSettings = new Gamesettings();

        fullscreenToggle.onValueChanged.AddListener(delegate { OnFullscreenToogle(); });
        resolutionDropdown.onValueChanged.AddListener(delegate { OnResolutionChange(); });
        textureQualityDropdown.onValueChanged.AddListener(delegate { OnTextureQualityChange(); });
        antialiasingDropdown.onValueChanged.AddListener(delegate { OnAntialiasingChange(); });
        vSyncDropdown.onValueChanged.AddListener(delegate { OnVSyncChange(); });
        musicVolumeSlider.onValueChanged.AddListener(delegate { OnMusicVolumeChange(); });

        resolutions = Screen.resolutions;
    }

    public void OnFullscreenToogle()
    {
        gameSettings.fullscreen = Screen.fullScreen = fullscreenToggle.isOn;

    }

    public void OnResolutionChange()
    {

    }

    public void OnTextureQualityChange()
    {
        QualitySettings.globalTextureMipmapLimit = gameSettings.textureQuality = textureQualityDropdown.value;
    }

    public void OnAntialiasingChange()
    {
        QualitySettings.antiAliasing = gameSettings.antialiasing = (int)Mathf.Pow(2f, antialiasingDropdown.value);
    }

    public void OnVSyncChange()
    {
        QualitySettings.vSyncCount = gameSettings.vSync = vSyncDropdown.value;
    }

    public void OnMusicVolumeChange()
    {
        musicSource.volume = gameSettings.musicVolume = musicVolumeSlider.value;
    }

    public void SaveSettings()
    {

    }

    public void LoadSettings()
    {

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
