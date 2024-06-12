using UnityEngine;
using UnityEngine.SceneManagement;

namespace Music
{
    public class BackgroundInstanceControllerComponent : MonoBehaviour
    {
        private void Awake()
        {
            transform.SetParent(null);
            var obj = GameObject.FindGameObjectsWithTag("BG_music_main_menu");
            if (obj.Length > 1)
            {
                Destroy(gameObject);
            }
            else
            {
                DontDestroyOnLoad(gameObject);
                SceneManager.activeSceneChanged += OnActiveSceneChanged;
            }
        }

        private void OnActiveSceneChanged(Scene previousScene, Scene loadedScene)
        {
            if (loadedScene.name is not ("SettingsMenu" or "SampleScene"))
            {
                Destroy(gameObject);
            }
        }

        private void OnDestroy()
        {
            SceneManager.activeSceneChanged -= OnActiveSceneChanged;
        }
    }
}