using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IsSus.Game.Controller;

namespace IsSus.Game.Mechanic
{
    public class AlienGravity : MonoBehaviour
    {
        public PlanetGravity lockOn;
        public Rigidbody rb;
        public LayerMask grounded;
        public bool isGrounded;

        // Start is called before the first frame update
        void Start()
        {
            lockOn = GameObject.FindGameObjectWithTag("Planet").GetComponent<PlanetGravity>();
            rb.useGravity = false; //Disable gravity to keep alien transform locked on planet
            rb.constraints = RigidbodyConstraints.FreezeRotation; //Freeze rotation to make sure the player doesn't go flying off
        }

        private void Update()
        {
            RaycastHit info;
            Ray _ray = new Ray(transform.position, -transform.up);
            if (Physics.Raycast(_ray, out info, 1 + 0.1f, grounded))
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
            }
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            //Force Alien's rigidbody to be locked to the planet
            if (lockOn)
            {
                lockOn.GravityLock(rb);
            }
        }
    }
}
