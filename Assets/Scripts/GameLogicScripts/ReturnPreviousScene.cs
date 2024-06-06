using LevelsLogic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace GameLogicScripts
{
    public class ReturnPreviousScene : MonoBehaviour
    {
        [SerializeField] private Button returnPreviousSceneButton;
        private void Start()
        {
            returnPreviousSceneButton.onClick.AddListener(() => SceneManager.LoadScene(PreviousScene.Scene));
        }

        private void OnDestroy()
        {
            returnPreviousSceneButton.onClick.RemoveAllListeners();
        }
    }
}
