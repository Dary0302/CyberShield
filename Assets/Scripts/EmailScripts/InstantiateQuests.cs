using System.Collections.Generic;
using UnityEngine;

namespace EmailScripts
{
    public class InstantiateQuests : MonoBehaviour
    {
        [SerializeField] private LetterView letterViewPrefab;
        [SerializeField] private Transform content;
        [SerializeField] private List<SampleQuest> quests = new();

        private void Start()
        {
            var countQuests = 0;
            foreach (var quest in quests)
            {
                if (countQuests > PlayerStats.GetLevelsCompletedNumber())
                    break;
            
                var newLetter = Instantiate(letterViewPrefab, content.position, Quaternion.identity, content);
            
                if (countQuests < PlayerStats.GetLevelsCompletedNumber())
                    newLetter.SetDoneCheckMark();

                countQuests++;
            
                newLetter.SetData(quest);
            }
        }
    }
}