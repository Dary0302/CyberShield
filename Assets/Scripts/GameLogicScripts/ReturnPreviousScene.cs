using System.Collections;
using LevelsLogic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace GameLogicScripts
{
    public class ReturnPreviousScene : MonoBehaviour
    {
        [SerializeField] private Button returnPreviousSceneButton;
        private Coroutine loadSceneCoroutine;
        
        private void Start()
        {
            returnPreviousSceneButton.onClick.AddListener((() =>
            {
                if (loadSceneCoroutine != null)
                    return;

                loadSceneCoroutine = StartCoroutine(LoadSceneCoroutine(0.27f, PreviousScene.Scene));
            }));
        }
        
        private IEnumerator LoadSceneCoroutine(float delay, string nameScene)
        {
            yield return new WaitForSeconds(delay);
            SceneManager.LoadScene(nameScene);
        }

        private void OnDestroy()
        {
            returnPreviousSceneButton.onClick.RemoveAllListeners();
        }
    }
}
