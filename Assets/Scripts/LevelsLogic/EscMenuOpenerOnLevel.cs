using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace LevelsLogic
{
    public class EscMenuOpenerOnLevel : MonoBehaviour
    {
        [SerializeField] private GameObject escMenu;
        [SerializeField] private Button toSettingsButton;
        private bool isOpenEscMenu;

        private void Start()
        {
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
            toSettingsButton.onClick.RemoveAllListeners();
        }
    }
}
