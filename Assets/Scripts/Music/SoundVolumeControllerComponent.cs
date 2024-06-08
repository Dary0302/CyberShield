using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Serialization;

namespace Music
{
    public class SoundVolumeControllerComponent : MonoBehaviour
    {
        [FormerlySerializedAs("audio"),Header("Components")]
        [Tooltip("Audio Source Does Тo Connect Automatically")]
        [SerializeField] private AudioMixer audioMixer;
    
        [Header("Keys")]
        [Tooltip("Save Data PlayerPrefs Key")]
        [SerializeField] private string saveVolumeKey;
    
        private float volume;
    
        private void Awake()
        {    
            // Checks whether a save is available in the registry.
            if (PlayerPrefs.HasKey(saveVolumeKey))
            {
                volume = PlayerPrefs.GetFloat(saveVolumeKey);
                audioMixer.SetFloat(saveVolumeKey, volume);
            }
            else
            {
                // Setting the default volume.
                volume = 0f;
                PlayerPrefs.SetFloat(saveVolumeKey, volume);
                audioMixer.SetFloat(saveVolumeKey, volume);
            }
        }
    
        private void LateUpdate()
        {
            PlayerPrefs.SetFloat(saveVolumeKey, volume);
        }
    }
}
