using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace LevelsLogic._3lvl
{
    public class HealthPointsManager : MonoBehaviour
    {
        [SerializeField] private Transform healthPointsPanel;
        [SerializeField] private GameObject heart;
        [FormerlySerializedAs("voidHeart"),SerializeField] private GameObject emptyHeart;
        private int countHealthPoints;
        private int currentCountHealthPoints;
        public event Action GameLose;

        private void Start()
        {
            countHealthPoints = PlayerStats.GetQuantityHealthPoints();
            currentCountHealthPoints = countHealthPoints;
            for (var i = 0; i < countHealthPoints; i++)
            {
                Instantiate(heart, healthPointsPanel.position, Quaternion.identity, healthPointsPanel);
            }
        }

        public void WrongAnswer()
        {
            currentCountHealthPoints--;

            foreach (Transform healthPoint in healthPointsPanel)
                Destroy(healthPoint.gameObject);
            
            for (var i = 0; i < countHealthPoints; i++)
            {
                Instantiate(currentCountHealthPoints > i ? heart : emptyHeart, healthPointsPanel.position, Quaternion.identity, healthPointsPanel);
            }

            if (currentCountHealthPoints == 0)
                GameLose?.Invoke();
        }
    }
}
