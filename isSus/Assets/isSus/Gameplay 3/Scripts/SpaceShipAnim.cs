using UnityEngine;
using UnityEngine.SceneManagement;

namespace IsSus.Game.Mechanic
{
    public class SpaceShipAnim : MonoBehaviour
    {
        #region Singleton
        public static SpaceShipAnim instance;

        private void Awake()
        {
            if(instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        #endregion

        /// <summary>
        /// Automatically transitions to new scene.
        /// </summary>
        public void OnCrashComplete()
        {
            SceneManager.LoadScene(2);
        }
    }
}
