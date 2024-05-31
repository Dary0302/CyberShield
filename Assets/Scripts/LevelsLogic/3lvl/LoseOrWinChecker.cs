using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace LevelsLogic._3lvl
{
    public class LoseOrWinChecker : MonoBehaviour
    {
        [SerializeField] private OrdinaryTimer ordinaryTimer;
        [SerializeField] private HealthPointsManager healthPointsManager;
        [SerializeField] private ScoreCounter scoreCounter;
        [SerializeField] private GameObject resultMenu;
        [SerializeField] private TMP_Text resultText;
        [SerializeField] private Button resultReturnToOffice;
        [SerializeField] private Button resultReloadLevel;

        private void Start()
        {
            ordinaryTimer.GameLose += EndGame;
            ordinaryTimer.GameLose += LoseGame;
            healthPointsManager.GameLose += EndGame;
            healthPointsManager.GameLose += LoseGame;
            scoreCounter.GameWin += EndGame;
            scoreCounter.GameWin += WinGame;
        }

        private void EndGame()
        {
            resultReturnToOffice.onClick.AddListener(() => SceneManager.LoadScene("Desktop"));
            resultReloadLevel.onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().name));
            ordinaryTimer.Pause();
        }

        private void LoseGame()
        {
            resultText.text = "Уровень провален!";
            resultMenu.gameObject.SetActive(true);
        }

        private void WinGame()
        {
            resultText.text = "Уровень пройден!";
            PlayerStats.LevelCompleted(3);
            resultMenu.gameObject.SetActive(true);
        }

        private void OnDestroy()
        {
            ordinaryTimer.GameLose -= EndGame;
            ordinaryTimer.GameLose -= LoseGame;
            healthPointsManager.GameLose -= EndGame;
            healthPointsManager.GameLose -= LoseGame;
            scoreCounter.GameWin -= EndGame;
            scoreCounter.GameWin -= WinGame;
        }
    }
}

