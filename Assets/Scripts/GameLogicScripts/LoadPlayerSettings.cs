using UnityEngine;
using UnityEngine.Audio;

public class LoadPlayerSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    private void Start()
    {
        if (PlayerPrefs.HasKey("MasterVolume"))
        {
            audioMixer.SetFloat("MasterVolume", PlayerPrefs.GetFloat("MasterVolume"));
            
        }
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            audioMixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("MusicVolume"));
        }
    }
}