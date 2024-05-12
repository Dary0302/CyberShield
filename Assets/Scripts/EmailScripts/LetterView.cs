using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LetterView : MonoBehaviour
{
    [SerializeField] private Image portrait;
    [SerializeField] private TMP_Text questName;
    [SerializeField] private TMP_Text senderName;
    [SerializeField] private TMP_Text description;
    [SerializeField] private Button acceptButton;
    [SerializeField] private Image notDoneCheckMark;
    [SerializeField] private Image doneCheckMark;

    public void SetData(SampleQuest quest)
    {
        portrait.sprite = quest.SenderPhoto;
        questName.text = quest.QuestName;
        senderName.text = quest.SenderName;
        description.text = quest.Description;
        acceptButton.onClick.AddListener(() =>  SceneManager.LoadScene(quest.LvlId));
    }

    public void SetDoneCheckMark()
    {
        notDoneCheckMark.sprite = doneCheckMark.sprite;
    }
}
