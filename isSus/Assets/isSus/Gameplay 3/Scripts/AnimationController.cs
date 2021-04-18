using UnityEngine;
using UnityEngine.SceneManagement;

namespace IsSus.Game.Mechanic
{
    public class AnimationController : MonoBehaviour
    {
        public Animator levelAnimator;
        private int levelToLoad;

        /// <summary>
        /// Start fading in to level.
        /// </summary>
        /// <param name="levelIndex">The level to load.</param>
        public void FadeToLevel(int levelIndex)
        {
            levelToLoad = levelIndex;
            levelAnimator.SetTrigger("FadeOut");
        }

        /// <summary>
        /// Automatically changes scene on end of fade using animation event.
        /// </summary>
        public void OnFadeComplete()
        {
            SpaceShipAnim.instance.OnCrashComplete();
        }
    }
}
