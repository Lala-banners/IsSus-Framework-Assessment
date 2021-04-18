using UnityEngine;
using TMPro;
using UnityEngine.UI;
using IsSus.Game.Mechanic;

namespace IsSus.Game.Controller
{
    public class PlayerController : MonoBehaviour
    {
        /* ESSENTIALS IN PC
         * Movement
         * Jumping
         * Camera look
         * Shooting + ammo
         * Take Damage
         * Health
         * Die
         * Gain EXP on kill enemies
        */

        #region Hidden Player Stats for Editor
        [HideInInspector] public string playerName = "Player";
        [HideInInspector] public string playerLevel = "1";
        [HideInInspector] public string playerEXP = "5";
        [HideInInspector] public string playerScore = "0";
        #endregion

        [Header("Player Movement")]
        public float speed = 1f;
        public float jumpForce = 0.1f;
        public Rigidbody rb;

        [Header("Player Shooting")]
        [Range(3f, 10f)] public float stunDamage;
        public int ammunition = 15;

        [Header("Health")]
        public float currentHealth = 100;
        public float maximumHealth = 100;
        public Image healthRing;
        public float smoothSpeed;

        [Header("Locked Player To Planet")]
        public PlanetGravity lockedOn;
        public Animator playerAnimator;
        public LayerMask grounded;
        public bool isGrounded;
        Vector3 moveDirection;

        [Header("Mouse & Camera")]
        public float mouseXSensitivity = 1;
        public float mouseYSensitivity = 1;

        private void Start()
        {
            currentHealth = maximumHealth;
            rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            #region Player Movement
            moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
            #endregion

            #region Health
            //Player Health
            if (currentHealth > maximumHealth) currentHealth = maximumHealth;
            smoothSpeed = 3f * Time.deltaTime; //To smooth transition from one colour to another
            Health();
            HealthRingColourChange();
            #endregion

            #region Check if player is grounded
            RaycastHit info;
            Ray _ray = new Ray(transform.position, -transform.up);
            if(Physics.Raycast(_ray, out info, 1 + 0.1f,grounded))
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
            }
            #endregion
        }

        private void FixedUpdate()
        {
            //Make player move
            rb.MovePosition(rb.position + transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
            if (lockedOn)
            {
                lockedOn.GravityLock(rb);
            }
        }

        /// <summary>
        /// This function takes care of the colour changing effect when the player takes damage or heals.
        /// </summary>
        public void HealthRingColourChange()
        {
            Color healthCol = Color.Lerp(Color.red, Color.green, (currentHealth/maximumHealth));
            healthRing.color = healthCol;
        }

        /// <summary>
        /// This function looks after the visualisation of the health ring inside the HUD.
        /// </summary>
        public void Health()
        {
            healthRing.fillAmount = Mathf.Lerp(healthRing.fillAmount, currentHealth / maximumHealth, smoothSpeed);
        }

        /// <summary>
        /// This function looks after the player taking damage from enemies.
        /// </summary>
        public void TakeDamage(float _damage)
        {
            if (currentHealth > 0) currentHealth -= _damage;
        }

        /// <summary>
        /// This function takes care of healing the player.
        /// </summary>
        public void Heal(float _healAmount)
        {
            if (currentHealth < maximumHealth) currentHealth += _healAmount;
        }

        /// <summary>
        /// This function takes care of the player dying.
        /// </summary>
        public void Dead()
        {
            if(currentHealth <= 0)
            {
                print("Player is dead");
            }
        }
    }
}
