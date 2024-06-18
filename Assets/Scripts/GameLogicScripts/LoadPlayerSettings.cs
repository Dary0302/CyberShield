using UnityEngine;
using UnityEngine.Audio;

public class LoadPlayerSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    private void Start()
    {
        if (PlayerPrefs.HasKey("MasterVolume"))
            audioMixer.SetFloat("MasterVolume", PlayerPrefs.GetFloat("MasterVolume"));
        else
            audioMixer.SetFloat("MasterVolume", -10);
        
        if (PlayerPrefs.HasKey("MusicVolume"))
            audioMixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("MusicVolume"));
        else
            audioMixer.SetFloat("MusicVolume", -10);
    }
}