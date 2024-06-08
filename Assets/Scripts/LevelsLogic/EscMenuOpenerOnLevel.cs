using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace LevelsLogic
{
    public class EscMenuOpenerOnLevel : MonoBehaviour
    {
        [SerializeField] private GameObject escMenu;
        [SerializeField] private Button toMainMenuButton;
        [SerializeField] private Button toOfficeButton;
        [SerializeField] private Button toSettingsButton;
        [SerializeField] private StopTimers stopTimers;
        private bool isOpenEscMenu;

        private void Start()
        {
            if (toMainMenuButton != null)
                toMainMenuButton.onClick.AddListener(() => SceneManager.LoadScene("SampleScene"));
            if (toOfficeButton != null)
                toOfficeButton.onClick.AddListener(() => SceneManager.LoadScene("Desktop"));
            if (toSettingsButton != null)
                toSettingsButton.onClick.AddListener(() =>
                {
                    PreviousScene.Scene = SceneManager.GetActiveScene().name;
                    SceneManager.LoadScene("SettingsMenu");
                });
        }

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Escape))
                return;

            if (toOfficeButton is not null)
                OpenEscMenu();
        }

        private void OpenEscMenu()
        {
            if (escMenu is null)
                return;

            stopTimers?.PauseTimers();

            escMenu.SetActive(!isOpenEscMenu);
            isOpenEscMenu = !isOpenEscMenu;
        }

        private void OnDestroy()
        {
            if (toMainMenuButton != null)
                toMainMenuButton.onClick.RemoveAllListeners();
            if (toOfficeButton != null)
                toOfficeButton.onClick.RemoveAllListeners();
            if (toSettingsButton != null)
                toSettingsButton.onClick.RemoveAllListeners();
        }
    }
}