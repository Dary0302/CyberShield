using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace EmailScripts
{
    public class LetterView : MonoBehaviour
    {
        [SerializeField] private AudioSource buttonClickSound;
        [SerializeField] private Image portrait;
        [SerializeField] private TMP_Text questName;
        [SerializeField] private TMP_Text senderName;
        [SerializeField] private TMP_Text description;
        [SerializeField] private Button acceptButton;
        [SerializeField] private Image notDoneCheckMark;
        [SerializeField] private Image doneCheckMark;
        private Coroutine loadSceneCoroutine;

        public void SetData(SampleQuest quest)
        {
            portrait.sprite = quest.SenderPhoto;
            questName.text = quest.QuestName;
            senderName.text = quest.SenderName;
            description.text = quest.Description;

            acceptButton.onClick.AddListener(() =>
            {
                if (loadSceneCoroutine != null)
                    return;

                buttonClickSound.Play();
                loadSceneCoroutine = StartCoroutine(LoadSceneCoroutine(0.53f, quest.LvlId));
            });
        }

        public void SetDoneCheckMark()
        {
            notDoneCheckMark.sprite = doneCheckMark.sprite;
        }

        private IEnumerator LoadSceneCoroutine(float delay, int idScene)
        {
            yield return new WaitForSeconds(delay);
            SceneManager.LoadScene(idScene);
        }
    }
}