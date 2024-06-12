using System.Collections;
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
        private Coroutine loadSceneCoroutine;

        private void Start()
        {
            if (toMainMenuButton != null)
                toMainMenuButton.onClick.AddListener(() =>
                {
                    if (loadSceneCoroutine != null)
                        return;

                    loadSceneCoroutine = StartCoroutine(LoadSceneCoroutine(0.27f, "SampleScene"));
                });
            if (toOfficeButton != null)
                toOfficeButton.onClick.AddListener(() =>
                {
                    if (loadSceneCoroutine != null)
                        return;

                    loadSceneCoroutine = StartCoroutine(LoadSceneCoroutine(0.27f, "Desktop"));
                });
            if (toSettingsButton != null)
                toSettingsButton.onClick.AddListener(() =>
                {
                    if (loadSceneCoroutine != null)
                        return;
                    
                    PreviousScene.Scene = SceneManager.GetActiveScene().name;

                    loadSceneCoroutine = StartCoroutine(LoadSceneCoroutine(0.27f, "SettingsMenu"));
                });
        }

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Escape))
                return;

            if (toOfficeButton is not null)
                OpenEscMenu();
        }

        private IEnumerator LoadSceneCoroutine(float delay, string nameScene)
        {
            yield return new WaitForSeconds(delay);
            SceneManager.LoadScene(nameScene);
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