using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quest")]
public class SampleQuest : ScriptableObject
{
    [field: SerializeField] public string QuestName { get; private set; }
    [field: SerializeField] public string Description { get; private set; }
    [field: SerializeField] public string SenderName { get; private set; }
    [field: SerializeField] public Sprite SenderPhoto { get; private set; }
    [field: SerializeField] public Button AcceptButton { get; private set; }
}