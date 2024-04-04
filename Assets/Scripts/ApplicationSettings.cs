using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class ApplicationSettings : MonoBehaviour
{
    [SerializeField] private bool isOpened; //Открыто ли меню
    [SerializeField] private float volume; //Громкость
    [SerializeField] private int quality; //Качество
    [SerializeField] private bool isFullscreen; //Полноэкранный режим
    [SerializeField] private AudioMixer audioMixer; //Регулятор громкости
    [SerializeField] private TMP_Dropdown resolutionDropdown; //Список с разрешениями для игры
    [SerializeField] private Toggle fullScreenModeToggle;
    [SerializeField] private Slider volumeSlider;

    private Resolution[] resolutions; //Список доступных разрешений
    private int currentResolutionIndex; //Текущее разрешение

    public void Start()
    {
        resolutionDropdown.ClearOptions(); //Удаление старых пунктов
        resolutions = Screen.resolutions; //Получение доступных разрешений
        var options = new HashSet<string>(); //Создание списка со строковыми значениями

        for (var i = 0; i < resolutions.Length; i++) //Поочерёдная работа с каждым разрешением
        {
            var option = resolutions[i].width + " x " + resolutions[i].height; //Создание строки для списка
            options.Add(option); //Добавление строки в список

            if (resolutions[i].Equals(Screen.currentResolution)) //Если текущее разрешение равно проверяемому
            {
                currentResolutionIndex = i; //То получается его индекс
            }
        }

        resolutionDropdown.AddOptions(options.ToList()); //Добавление элементов в выпадающий список
        resolutionDropdown.value = currentResolutionIndex; //Выделение пункта с текущим разрешением
        resolutionDropdown.RefreshShownValue(); //Обновление отображаемого значения

        volumeSlider.onValueChanged.AddListener(ChangeVolume);
        resolutionDropdown.onValueChanged.AddListener(ChangeResolution);
        fullScreenModeToggle.onValueChanged.AddListener(ChangeFullscreenMode);
    }

    private void ChangeVolume(float val) //Изменение звука
    {
        volume = val;
    }

    private void ChangeResolution(int index) //Изменение разрешения
    {
        currentResolutionIndex = index;
    }

    private void ChangeFullscreenMode(bool val) //Включение или отключение полноэкранного режима
    {
        isFullscreen = val;
    }

    public void ChangeQuality(int index) //Изменение качества
    {
        quality = index;
    }

    public void SaveSettings()
    {
        audioMixer.SetFloat("MasterVolume", volume); //Изменение уровня громкости
        QualitySettings.SetQualityLevel(quality); //Изменение качества
        Screen.fullScreen = isFullscreen; //Включение или отключение полноэкранного режима
        Screen.SetResolution(Screen.resolutions[currentResolutionIndex].width, Screen.resolutions[currentResolutionIndex].height, isFullscreen); //Изменения разрешения
        Debug.Log("Success");
    }

    private void OnDestroy()
    {
        volumeSlider.onValueChanged.RemoveListener(ChangeVolume);
        resolutionDropdown.onValueChanged.RemoveListener(ChangeResolution);
        fullScreenModeToggle.onValueChanged.RemoveListener(ChangeFullscreenMode);
    }
}