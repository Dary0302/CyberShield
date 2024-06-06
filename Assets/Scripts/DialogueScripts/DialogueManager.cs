using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace DialogueScripts
{
    public class DialogueManager : MonoBehaviour
    {
        public GameObject dialogueWindow;
        public Image dialogueSquare;
        public Image robotEmotion;
        public TMP_Text dialogueText;
        public TMP_Text nameText;
        [FormerlySerializedAs("dialogueRobotEmotions"),SerializeField] private DialogueRobotEmotionsManager dialogueRobotEmotionsManager;
        [SerializeField] private Image backGroundRobot;
        [SerializeField] private Image backGroundGG;
        public float delayBetweenCharacters = 0.05f;

        private int currentDialogueNumber;
        private Queue<Dialogue.Sentence> sentences;

        public void Awake()
        {
            sentences = new();
        }

        public void StartDialogue(Dialogue dialogue, int dialogueNumber)
        {
            sentences.Clear();
            currentDialogueNumber = dialogueNumber;

            foreach (var sentence in dialogue.sentences)
            {
                sentences.Enqueue(sentence);
            }
            DisplayNextSentence();
        }

        public void DisplayNextSentence()
        {
            if (sentences.Count == 0)
            {
                EndDialogue();
                return;
            }
            var sentence = sentences.Dequeue();

            robotEmotion.sprite = dialogueRobotEmotionsManager.GetEmotionRobot(sentence.RobotEmotion).FaceEmotion;
            nameText.text = "";
            dialogueSquare.sprite = backGroundGG.sprite;
            if (sentence.Name == Names.Robot)
            {
                nameText.text = "Помощник";
                dialogueSquare.sprite = backGroundRobot.sprite;
            }
            
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence.Text));
        }

        private IEnumerator TypeSentence(string sentence)
        {
            dialogueText.text = "";
            foreach (var letter in sentence.ToCharArray())
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(delayBetweenCharacters);
            }
        }

        public void EndDialogue()
        {
            PlayerPrefs.SetInt("lastDialogueNumber", currentDialogueNumber + 1);
            PlayerPrefs.Save();
            dialogueWindow.gameObject.SetActive(false);
        }
    }
}