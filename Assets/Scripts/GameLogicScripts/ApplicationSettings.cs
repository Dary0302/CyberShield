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

    //[SerializeField] private int quality; //Качество
    [SerializeField] private bool isFullscreen; //Полноэкранный режим
    [SerializeField] private AudioMixer audioMixer; //Регулятор громкости
    //[SerializeField] private TMP_Dropdown resolutionDropdown; //Список с разрешениями для игры
    [SerializeField] private Toggle fullScreenModeToggle;
    [SerializeField] private Slider volumeMusicSlider;
    [SerializeField] private Slider volumeSlider;

    private bool isSavedSettings = true;
    //private Resolution[] resolutions; //Список доступных разрешений
    //private int currentResolutionIndex; //Текущее разрешение

    public void Start()
    {
        /*resolutionDropdown.ClearOptions(); //Удаление старых пунктов
        resolutions = Screen.resolutions; //Получение доступных разрешений
        var options = new HashSet<string>(); //Создание списка со строковыми значениями

        for (var i = 0; i < resolutions.Length; i++) //Поочерёдная работа с каждым разрешением
        {
            var option = String.Join(" x ", resolutions[i].width, resolutions[i].height); //Создание строки для списка
            options.Add(option); //Добавление строки в список

            if (resolutions[i].Equals(Screen.currentResolution)) //Если текущее разрешение равно проверяемому
                currentResolutionIndex = i; //То получается его индекс
        }

        resolutionDropdown.AddOptions(options.ToList()); //Добавление элементов в выпадающий список
        resolutionDropdown.value = currentResolutionIndex; //Выделение пункта с текущим разрешением
        resolutionDropdown.RefreshShownValue(); //Обновление отображаемого значения*/

        volumeSlider.onValueChanged.AddListener(ChangeVolume);
        volumeMusicSlider.onValueChanged.AddListener(ChangeMusicVolume);
        //resolutionDropdown.onValueChanged.AddListener(ChangeResolution);
        fullScreenModeToggle.onValueChanged.AddListener(ChangeFullscreenMode);
    }

    private void ChangeVolume(float val) //Изменение звука
    {
        audioMixer.SetFloat("MasterVolume", volumeGame = val);
        isSavedSettings = false;
    }

    private void ChangeMusicVolume(float val) //Изменение звука
    {
        audioMixer.SetFloat("MusicVolume", volumeMusic = val);
        isSavedSettings = false;
    }

    /*private void ChangeResolution(int index) //Изменение разрешения
    {
        currentResolutionIndex = index;
        Screen.SetResolution(Screen.resolutions[currentResolutionIndex].width, Screen.resolutions[currentResolutionIndex].height, isFullscreen);
        isSavedSettings = false;
    }*/

    private void ChangeFullscreenMode(bool val) //Включение или отключение полноэкранного режима
    {
        isFullscreen = val;
        Screen.fullScreen = isFullscreen;
        isSavedSettings = false;
    }

    public void SaveSettings()
    {
        audioMixer.SetFloat("MusicVolume", volumeMusic); //Изменение уровня громкости
        //QualitySettings.SetQualityLevel(quality); //Изменение качества
        Screen.fullScreen = isFullscreen; //Включение или отключение полноэкранного режима
        //Screen.SetResolution(Screen.resolutions[currentResolutionIndex].width, Screen.resolutions[currentResolutionIndex].height, isFullscreen); //Изменения разрешения
        isSavedSettings = true;
        Debug.Log("Success Save Settings");
    }

    private void OnDestroy()
    {
        volumeSlider.onValueChanged.RemoveListener(ChangeVolume);
        volumeMusicSlider.onValueChanged.RemoveListener(ChangeMusicVolume);
        //resolutionDropdown.onValueChanged.RemoveListener(ChangeResolution);
        fullScreenModeToggle.onValueChanged.RemoveListener(ChangeFullscreenMode);
    }
}