using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    /// <summary>
    /// Метод для смены сцены по её ID
    /// </summary>
    /// <param name="idScene">ID сцены, можно узнать из File/BuildSettings</param>
    public void SwitchScene(int idScene)
    {
        SceneManager.LoadScene(idScene);
    }
}