using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IsSus.Game.UI
{
    public class PauseMenu : MonoBehaviour
    {
        public GameObject pausePanel;
        public bool isPaused;

        // Start is called before the first frame update
        void Start()
        {
            pausePanel.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Paused(pausePanel);
            }
        }

        public void Paused(GameObject panel)
        {
            isPaused = true;
            pausePanel.SetActive(true);
            Time.timeScale = 0;
        }

        public void UnPaused()
        {
            isPaused = false;
            Time.timeScale = 1;
            pausePanel.SetActive(false);
        }
    }
}
