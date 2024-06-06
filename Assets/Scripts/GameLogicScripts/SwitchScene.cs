using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public void SwitcherScene(int idScene)
    {
        SceneManager.LoadScene(idScene);
    }
}