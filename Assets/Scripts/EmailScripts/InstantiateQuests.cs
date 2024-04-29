using System.Collections.Generic;
using UnityEngine;

public class InstantiateQuests : MonoBehaviour
{
    [SerializeField] private LetterView letterViewPrefab;
    [SerializeField] private Transform content;
    [SerializeField] private List<SampleQuest> quests = new();

    private void Start()
    {
        foreach (var quest in quests)
        {
            var newLetter = Instantiate(letterViewPrefab, content.position, Quaternion.identity, content);
            newLetter.SetData(quest);
        }
    }
}