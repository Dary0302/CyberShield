using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    private Coroutine loadSceneCoroutine;

    public void SwitcherScene(int idScene)
    {
        if (loadSceneCoroutine != null)
            return;

        loadSceneCoroutine = StartCoroutine(LoadSceneCoroutine(0.27f, idScene));
    }

    private IEnumerator LoadSceneCoroutine(float delay, int idScene)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(idScene);
    }
}