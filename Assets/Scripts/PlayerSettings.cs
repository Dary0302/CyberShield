using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PlayerSettings : MonoBehaviour
{
    public bool isOpened; //Открыто ли меню
    public float volume; //Громкость
    public int quality; //Качество
    public bool isFullscreen; //Полноэкранный режим
    public AudioMixer audioMixer; //Регулятор громкости
    public Dropdown resolutionDropdown; //Список с разрешениями для игры
    private Resolution[] resolutions; //Список доступных разрешений
    private int currentResolutionIndex; //Текущее разрешение

    public void Update()
    {
        resolutionDropdown.ClearOptions(); //Удаление старых пунктов
        resolutions = Screen.resolutions; //Получение доступных разрешений
        var options = new List<string> (); //Создание списка со строковыми значениями

        for(var i = 0; i < resolutions.Length; i++) //Поочерёдная работа с каждым разрешением
        {
            var option = resolutions [i].width + " x " + resolutions [i].height; //Создание строки для списка
            options.Add(option); //Добавление строки в список

            if(resolutions[i].Equals(Screen.currentResolution)) //Если текущее разрешение равно проверяемому
            {
                currentResolutionIndex = i; //То получается его индекс
            }
        }

        resolutionDropdown.AddOptions(options); //Добавление элементов в выпадающий список
        resolutionDropdown.value = currentResolutionIndex; //Выделение пункта с текущим разрешением
        resolutionDropdown.RefreshShownValue(); //Обновление отображаемого значения
    }

    public void ChangeVolume(float val) //Изменение звука
    {
        volume = val;
    }

    public void ChangeResolution(int index) //Изменение разрешения
    {
        currentResolutionIndex = index;
    }

    public void ChangeFullscreenMode(bool val) //Включение или отключение полноэкранного режима
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
}
