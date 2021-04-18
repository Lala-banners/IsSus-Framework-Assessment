using UnityEngine;
using Cinemachine;

namespace IsSus.Game.Mechanic
{
    public class ChangeCamera : MonoBehaviour
    {
        public GameObject baseCamera; //outside camera is third person perspective & suitHUD is inside the player's helmet which obscures view of aliens
        public GameObject section2;
        public GameObject section3;
        public GameObject section4;
        public GameObject section5;
        public GameObject section6;
        AudioListener baseCamAudio, section2Audio, section3Audio, section4Audio,section5Audio, section6Audio,helmetCamAudioListener;
        public GameObject HUD;

        public CinemachineVirtualCamera vc;

        // Start is called before the first frame update
        void Start()
        {
            //Get the Audio Listener components from each camera 
            baseCamAudio = baseCamera.GetComponent<AudioListener>();
            section2Audio = section2.GetComponent<AudioListener>();
            section3Audio = section3.GetComponent<AudioListener>();
            section4Audio = section4.GetComponent<AudioListener>();
            section5Audio = section5.GetComponent<AudioListener>();
            section5Audio = section6.GetComponent<AudioListener>();
            helmetCamAudioListener = HUD.GetComponent<AudioListener>();

            //Set the positions of the cameras from the playerprefs
            ToggleCamera(PlayerPrefs.GetInt("CameraPosition"));
        }

        void Update()
        {
            ActivateHUD(); //To always call so the cameras switch

            #region Activating other cameras
            //Activating other cameras in the scene with number buttons on keyboard
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                ActivateSection1();
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                ActivateSection2();
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                ActivateSection3();
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                ActivateSection4();
            }
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                ActivateSection5();
            }
            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                ActivateSection6();
            }
            #endregion
        }




        /// <summary>
        /// This function will call the logic for changing the positions of the cameras to be either inside the helmet or third person.
        /// </summary>
        public void ActivateHUD()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                CameraCounter();
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }

        /// <summary>
        /// This function will control which camera is activated at a time when being called.
        /// </summary>
        /// <param name="camPos">Position of the cameras.</param>
        public void ToggleCamera(int camPos)
        {
            if (camPos > 1)
            {
                camPos = 0;
            }

            //Set up saving of camera positions
            PlayerPrefs.SetInt("CameraPosition", camPos);

            //If camera position is 1
            if (camPos == 0)
            {
                //Activate camera 1
                baseCamera.SetActive(true);
                //baseCamAudio.enabled = true;

                //Deactivate helmet HUD camera
                HUD.SetActive(false);
                //helmetCamAudioListener.enabled = false;
            }
            //if camera position is 2, activate HUD camera
            else if (camPos == 1)
            {
                HUD.SetActive(true);
                //helmetCamAudioListener.enabled = true;

                baseCamera.SetActive(false);
                //baseCamAudio.enabled = false;
            }
        }

        /// <summary>
        /// This function will keep track of how many times the camera will switch between third person and helmet HUD.
        /// </summary>
        public void CameraCounter()
        {
            int cameraPosCounter = PlayerPrefs.GetInt("CameraPosition");
            cameraPosCounter++;
            ToggleCamera(cameraPosCounter);
        }

        /// <summary>
        /// Activate section 1 satellite and deactivate all others.
        /// </summary>
        public void ActivateSection1()
        {
            //Activate Base Satellite
            baseCamera.SetActive(true);
            //baseCamAudio.enabled = true;

            //Deactivate Satellite 2
            section2.SetActive(false);
            //section2Audio.enabled = false;

            //Deactivate Satellite 3
            section3.SetActive(false);
            //section3Audio.enabled = false;

            //Deactivate Satellite 4
            section4.SetActive(false);
            //section4Audio.enabled = false;

            //Deactivate Satellite 5
            section5.SetActive(false);
            //section5Audio.enabled = false;

            //Deactivate Satellite 6
            section6.SetActive(false);
            //section6Audio.enabled = false;
        }

        /// <summary>
        /// Activate section 2 satellite and deactivate all others.
        /// </summary>
        public void ActivateSection2()
        {
            //Activate Satellite 2
            section2.SetActive(true);
            //section2Audio.enabled = true;

            //Deactivate Base Satellite 
            baseCamera.SetActive(false);
            //baseCamAudio.enabled = false;

            //Deactivate Satellite 3
            section3.SetActive(false);
            //section3Audio.enabled = false;

            //Deactivate Satellite 4
            section4.SetActive(false);
            //section4Audio.enabled = false;

            //Deactivate Satellite 5
            section5.SetActive(false);
            //section5Audio.enabled = false;

            //Deactivate Satellite 6
            section6.SetActive(false);
            //section6Audio.enabled = false;
        }

        /// <summary>
        /// Activate section 3 satellite and deactivate all others.
        /// </summary>
        public void ActivateSection3()
        {
            //Activate Satellite 3
            section3.SetActive(true);
            //section3Audio.enabled = true;

            //Deactivate Base Satellite
            baseCamera.SetActive(false);
            //baseCamAudio.enabled = false;

            //Deactivate Satellite 2
            section2.SetActive(false);
            //section2Audio.enabled = false;

            //Deactivate Satellite 4
            section4.SetActive(false);
            //section4Audio.enabled = false;

            //Deactivate Satellite 5
            section5.SetActive(false);
            //section5Audio.enabled = false;

            //Deactivate Satellite 6
            section6.SetActive(false);
            //section6Audio.enabled = false;
        }

        /// <summary>
        /// Activate section 4 satellite and deactivate all others.
        /// </summary>
        public void ActivateSection4()
        {
            //Activate Satellite 4
            section4.SetActive(true);
            //section4Audio.enabled = true;

            //Deactivate Base Satellite
            baseCamera.SetActive(false);
            //baseCamAudio.enabled = false;

            //Deactivate Satellite 2
            section2.SetActive(false);
           // section2Audio.enabled = false;

            //Deactivate Satellite 3
            section3.SetActive(false);
            //section3Audio.enabled = false;

            //Deactivate Satellite 5
            section5.SetActive(false);
            //section5Audio.enabled = false;

            //Deactivate Satellite 6 
            section6.SetActive(false);
            //section6Audio.enabled = false;
        }

        /// <summary>
        /// Activate section 5 satellite and deactivate all others.
        /// </summary>
        public void ActivateSection5()
        {
            //Activate Satellite 5
            section5.SetActive(true);
            //section5Audio.enabled = true;

            //Deactivate Base Satellite
            baseCamera.SetActive(false);
            //baseCamAudio.enabled = false;

            //Deactivate Satellite 2
            section2.SetActive(false);
            //section2Audio.enabled = false;

            //Deactivate Satellite 3
            section3.SetActive(false);
            //section3Audio.enabled = false;

            //Deactivate Satellite 4
            section4.SetActive(false);
            //section4Audio.enabled = false;

            //Deactivate Satellite 6
            section6.SetActive(false);
            //section6Audio.enabled = false;
        }

        /// <summary>
        /// Activate section 6 satellite and deactivate all others.
        /// </summary>
        public void ActivateSection6()
        {
            //Activate Satellite 6
            section6.SetActive(true);
            //section6Audio.enabled = true;

            //Deactivate Base Satellite
            baseCamera.SetActive(false);
            //baseCamAudio.enabled = false;

            //Deactivate Satellite 2
            section2.SetActive(false);
            //section2Audio.enabled = false;

            //Deactivate Satellite 3
            section3.SetActive(false);
            //section3Audio.enabled = false;

            //Deactivate Satellite 4
            section4.SetActive(false);
            //section4Audio.enabled = false;

            //Deactivate Satellite 5
            section5.SetActive(false);
            //section5Audio.enabled = false;
        }
    }
}
