using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LetterView : MonoBehaviour
{
    [SerializeField] private Image portrait;
    [SerializeField] private TMP_Text questName;
    [SerializeField] private TMP_Text senderName;
    [SerializeField] private TMP_Text description;
    [SerializeField] private Button acceptButton;

    public void SetData(SampleQuest quest)
    {
        portrait.sprite = quest.SenderPhoto;
        senderName.text = quest.SenderName;
        description.text = quest.Description;
        questName.text = quest.QuestName;
    }
}
