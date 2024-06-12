using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace LevelsLogic._3lvl
{
    public class LoseOrWinChecker : MonoBehaviour
    {
        [SerializeField] private AudioSource gameWinSound;
        [SerializeField] private AudioSource gameLoseSound;
        [SerializeField] private OrdinaryTimer ordinaryTimer;
        [SerializeField] private HealthPointsManager healthPointsManager;
        [SerializeField] private ScoreCounter scoreCounter;
        [SerializeField] private GameObject resultMenu;
        [SerializeField] private TMP_Text resultText;
        [SerializeField] private Button resultReturnToOffice;
        [SerializeField] private Button resultReloadLevel;
        [SerializeField] private int numberLevel;
        [SerializeField] private int salary;

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
            resultMenu.gameObject.SetActive(true);
        }
        
        private void WinGame()
        {
            gameWinSound.Play();
            resultText.text = "Уровень пройден!";
            PlayerStats.LevelCompleted(numberLevel, salary);
        }

        private void LoseGame()
        {
            gameLoseSound.Play();
            resultText.text = "Уровень провален!";
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