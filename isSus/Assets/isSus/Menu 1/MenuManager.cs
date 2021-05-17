using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

namespace IsSus.Game.UI
{
    public class MenuManager : MonoBehaviour
    {
        public void StartGame()
        {
            SceneManager.LoadScene(1);
        }

        public void ExitGame()
        {
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#endif
            Application.Quit();
        }
    }
}
