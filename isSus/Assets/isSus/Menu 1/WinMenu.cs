using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IsSus.Game.UI
{
    public class WinMenu : MonoBehaviour
    {
        public GameObject winPanel;

        // Start is called before the first frame update
        void Start()
        {
            winPanel.SetActive(false);
        }

        public void WinGame()
        {
            winPanel.SetActive(true);
            Time.timeScale = 0;
            Timer.instance.timerIsRunning = false; //Stop timer
        }

    }
}