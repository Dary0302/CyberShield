using System.Collections.Generic;
using UnityEngine;

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
            if (countQuests > PlayerStats.LevelsCompletedNumber)
                continue;
            
            var newLetter = Instantiate(letterViewPrefab, content.position, Quaternion.identity, content);
            
            if (countQuests < PlayerStats.LevelsCompletedNumber)
                newLetter.SetDoneCheckMark();

            countQuests++;
            
            newLetter.SetData(quest);
        }
    }
}