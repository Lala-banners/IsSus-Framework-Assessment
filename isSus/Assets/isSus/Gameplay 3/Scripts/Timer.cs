using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace IsSus.Game.UI
{
    public class Timer : MonoBehaviour
    {
        public static Timer instance = null;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
                return;
            }
        }

        public float timeRemaining = 10;
        public bool timerIsRunning = false;
        public TMP_Text timeText;

        // Start is called before the first frame update
        void Start()
        {
            // Starts the timer automatically
            timerIsRunning = true;
        }

        // Update is called once per frame
        void Update()
        {
            DisplayTime(timeRemaining);

            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                //Game Over
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }

        private void DisplayTime(float timeToDisplay)
        {
            float minutes = Mathf.FloorToInt(timeToDisplay / 60);
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);

            //UI Text time
            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}