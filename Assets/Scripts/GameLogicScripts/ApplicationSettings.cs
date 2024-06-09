using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class ApplicationSettings : MonoBehaviour
{
    [SerializeField] private float volumeGame;
    [SerializeField] private float volumeMusic;
    [SerializeField] private float volumeUI;

    [SerializeField] private bool isFullscreen;
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Toggle fullScreenModeToggle;
    [SerializeField] private Slider volumeMusicSlider;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Slider volumeUISlider;

    private const string MusicVolumeKey = "MusicVolume";
    private const string MasterVolumeKey = "MasterVolume";
    private const string UIVolumeKey = "UIVolume";

    private bool isSavedSettings = true;

    public void Start()
    {
        volumeSlider.onValueChanged.AddListener(ChangeVolume);
        volumeMusicSlider.onValueChanged.AddListener(ChangeMusicVolume);
        volumeUISlider.onValueChanged.AddListener(ChangeUIVolume);
        fullScreenModeToggle.onValueChanged.AddListener(ChangeFullscreenMode);

        if (PlayerPrefs.HasKey(MasterVolumeKey))
            volumeSlider.value = PlayerPrefs.GetFloat(MasterVolumeKey);
        if (PlayerPrefs.HasKey(MusicVolumeKey))
            volumeMusicSlider.value = PlayerPrefs.GetFloat(MusicVolumeKey);
        if (PlayerPrefs.HasKey(UIVolumeKey))
            volumeUISlider.value = PlayerPrefs.GetFloat(UIVolumeKey);
    }

    private void ChangeVolume(float valume) //Изменение звука
    {
        audioMixer.SetFloat(MasterVolumeKey, volumeGame = valume);
        isSavedSettings = false;
    }

    private void ChangeMusicVolume(float valume) //Изменение звука
    {
        audioMixer.SetFloat(MusicVolumeKey, volumeMusic = valume);
        isSavedSettings = false;
    }

    private void ChangeUIVolume(float valume)
    {
        audioMixer.SetFloat(UIVolumeKey, volumeUI = valume);
        isSavedSettings = false;
    }

    private void ChangeFullscreenMode(bool val)
    {
        isFullscreen = val;
        Screen.fullScreen = isFullscreen;
        isSavedSettings = false;
    }

    public void SaveSettings()
    {
        audioMixer.SetFloat(MusicVolumeKey, volumeMusic);
        audioMixer.SetFloat(MasterVolumeKey, volumeGame);
        audioMixer.SetFloat(UIVolumeKey, volumeUI);
        Screen.fullScreen = isFullscreen;
        isSavedSettings = true;
        PlayerPrefs.SetFloat(MusicVolumeKey, volumeMusic);
        PlayerPrefs.SetFloat(MasterVolumeKey, volumeGame);
        PlayerPrefs.SetFloat(UIVolumeKey, volumeUI);
        PlayerPrefs.Save();
        Debug.Log("Success Save Settings");
    }

    private void OnDestroy()
    {
        volumeSlider.onValueChanged.RemoveListener(ChangeVolume);
        volumeMusicSlider.onValueChanged.RemoveListener(ChangeMusicVolume);
        volumeUISlider.onValueChanged.RemoveListener(ChangeUIVolume);
        fullScreenModeToggle.onValueChanged.RemoveListener(ChangeFullscreenMode);
    }
}