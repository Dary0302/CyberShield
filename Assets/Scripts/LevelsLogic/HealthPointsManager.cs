using System;
using UnityEngine;

namespace LevelsLogic
{
    public class HealthPointsManager : MonoBehaviour
    {
        [SerializeField] private AudioSource gameLoseSound;
        [SerializeField] private Transform healthPointsPanel;
        [SerializeField] private GameObject heart;
        [SerializeField] private GameObject emptyHeart;
        [SerializeField] private GameObject lockHeart;
        private int maxHealth;
        private int countHealthPoints;
        private int currentCountHealthPoints;
        public event Action GameLose;

        private void Start()
        {
            maxHealth = PlayerStats.MaxHealthPoints;
            countHealthPoints = PlayerStats.GetQuantityHealthPoints();
            currentCountHealthPoints = countHealthPoints;
            for (var i = 0; i < maxHealth; i++)
            {
                Instantiate(i < countHealthPoints ? heart : lockHeart, healthPointsPanel.position, Quaternion.identity, healthPointsPanel);
            }
        }

        public void WrongAnswer()
        {
            currentCountHealthPoints--;

            foreach (Transform healthPoint in healthPointsPanel)
                Destroy(healthPoint.gameObject);

            for (var i = 0; i < maxHealth; i++)
            {
                if (countHealthPoints < i + 1)
                    Instantiate(lockHeart, healthPointsPanel.position, Quaternion.identity, healthPointsPanel);
                else
                    Instantiate(currentCountHealthPoints > i ? heart : emptyHeart, healthPointsPanel.position, Quaternion.identity, healthPointsPanel);
            }

            if (currentCountHealthPoints != 0)
                return;
            
            gameLoseSound.Play();
            GameLose?.Invoke();
        }
    }
}