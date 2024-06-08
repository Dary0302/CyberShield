using System;
using UnityEngine;
using UnityEngine.UI;

namespace Music
{
    public class FillButtonSound : MonoBehaviour
    {
        [SerializeField] private Button[] buttons;
        [SerializeField] private AudioSource audioSource;
        private void Start()
        {
            foreach (var button in buttons)
            {
                button.onClick.AddListener(() => audioSource.Play());
            }
        }

        private void OnDestroy()
        {
            foreach (var button in buttons)
            {
                button.onClick.RemoveListener(() => audioSource.Play());
            }
        }
    }
}
