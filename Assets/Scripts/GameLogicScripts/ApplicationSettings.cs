using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.Serialization;

public class ApplicationSettings : MonoBehaviour
{
    [FormerlySerializedAs("volume game"), SerializeField]
    private float volumeGame; //Громкость игры

    [FormerlySerializedAs("volume music"), SerializeField]
    private float volumeMusic; //Громкость музыки

    [SerializeField] private bool isFullscreen; //Полноэкранный режим
    [SerializeField] private AudioMixer audioMixer; //Регулятор громкости
    [SerializeField] private Toggle fullScreenModeToggle;
    [SerializeField] private Slider volumeMusicSlider;
    [SerializeField] private Slider volumeSlider;
    
    private const string MusicVolumeKey = "MusicVolume";
    private const string MasterVolumeKey = "MasterVolume";

    private bool isSavedSettings = true;

    public void Start()
    {
        volumeSlider.onValueChanged.AddListener(ChangeVolume);
        volumeMusicSlider.onValueChanged.AddListener(ChangeMusicVolume);
        fullScreenModeToggle.onValueChanged.AddListener(ChangeFullscreenMode);
        
        if (PlayerPrefs.HasKey(MasterVolumeKey))
        {
            volumeSlider.value = PlayerPrefs.GetFloat(MasterVolumeKey);
        }
        if (PlayerPrefs.HasKey(MusicVolumeKey))
        {
            volumeMusicSlider.value = PlayerPrefs.GetFloat(MusicVolumeKey);
        }
    }

    private void ChangeVolume(float val) //Изменение звука
    {
        audioMixer.SetFloat(MasterVolumeKey, volumeGame = val);
        isSavedSettings = false;
    }

    private void ChangeMusicVolume(float val) //Изменение звука
    {
        audioMixer.SetFloat(MusicVolumeKey, volumeMusic = val);
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
        Screen.fullScreen = isFullscreen;
        isSavedSettings = true;
        PlayerPrefs.SetFloat(MusicVolumeKey, volumeMusic);
        PlayerPrefs.SetFloat(MasterVolumeKey, volumeGame);
        PlayerPrefs.Save();
        Debug.Log("Success Save Settings");
    }

    private void OnDestroy()
    {
        volumeSlider.onValueChanged.RemoveListener(ChangeVolume);
        volumeMusicSlider.onValueChanged.RemoveListener(ChangeMusicVolume);
        fullScreenModeToggle.onValueChanged.RemoveListener(ChangeFullscreenMode);
    }
}