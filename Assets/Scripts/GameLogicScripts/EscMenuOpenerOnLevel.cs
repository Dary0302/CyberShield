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

            OpenEscMenu();
        }

        private void OpenEscMenu()
        {
            escMenu.SetActive(!isOpenEscMenu);
            isOpenEscMenu = !isOpenEscMenu;
        }

        private void OnDestroy()
        {
            toMainMenuButton.onClick.RemoveAllListeners();
            toOfficeButton.onClick.RemoveAllListeners();
            toSettingsButton.onClick.RemoveAllListeners();
        }
    }
}