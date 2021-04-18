using UnityEngine;

namespace IsSus.Game.Mechanic
{
    public class Gun : MonoBehaviour
    {
        public float damage = 10f;
        public float shootRange = 100f;
        public Camera gunCam; //Camera reference

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            //Check if player has clicked on fire button (left shift)
            if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                Shoot();
            }
        }

        /// <summary>
        /// Shooting code with Raycasts.
        /// </summary>
        public void Shoot()
        {
            RaycastHit hit;
            if(Physics.Raycast(gunCam.transform.position, gunCam.transform.forward, out hit, shootRange))
            {
                print(hit.transform.name); //Get name of object the ray hit
            }
        }
    }
}
