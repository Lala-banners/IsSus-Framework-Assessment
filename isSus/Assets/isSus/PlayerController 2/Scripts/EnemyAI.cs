using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace IsSus.Game.Controller.Alien
{
    public class EnemyAI : MonoBehaviour
    {
        public Transform player;
        public LayerMask groundMask, playerMask;

        [Header("Patrolling")]
        public float speed;
        public Transform[] points;
        public Vector3 walkPoint;
        private int walkPointIndex;
        bool walkPointSet;
        public float walkPointRange;

        [Header("Attacking")]
        public float timeBtwAttacks;
        bool alreadyAttacked;

        [Header("States")]
        public float sightRange, attackRange;
        public bool playerInSight, playerInAttack;

        private void Awake()
        {
            player = GameObject.Find("Player").transform;
        }

        // Start is called before the first frame update
        void Start()
        {
            walkPointIndex = Random.Range(0, points.Length);
        }

        // Update is called once per frame
        void Update()
        {
            //Check for sight and attack range of player
            playerInSight = Physics.CheckSphere(transform.position, sightRange, playerMask);
            playerInAttack = Physics.CheckSphere(transform.position, attackRange, playerMask);

            //If player is not in sight range and attack range, then patrol
            if (!playerInSight && !playerInAttack) Patrol();
            //If player is in sight range but not attack range, then chase
            if (playerInSight && !playerInAttack) Chase();
            //If player is in sight range and attack range, then attack
            if (playerInSight && playerInAttack) Attack();
        }

        public void Patrol()
        {
            if (!walkPointSet)
                SearchWalkPoint();

            //If walk point has been set
            if (walkPointSet)
            {
                //Patrol code here
                transform.position = Vector3.MoveTowards(transform.position, points[walkPointIndex].position, speed * Time.deltaTime);
            }

            //Calculate distance between current position and walkpoint
            Vector3 distanceToWalkPoint = transform.position - walkPoint;

            //Check if walkpoint has been reached, if not then search for a new walkpoint
            if (distanceToWalkPoint.magnitude < 1f)
            {
                walkPointSet = false;
            }
        }

        private void SearchWalkPoint()
        {
            //Calculate random point in walk point range
            float randomZ = Random.Range(-walkPointRange, walkPointRange);
            float randomX = Random.Range(-walkPointRange, walkPointRange);

            //Walk points for x and z are added to the range, while y position stays the same
            walkPoint = new Vector3(transform.position.x + randomX,
                                    transform.position.y,
                                    transform.position.z + randomZ);

            //This random walk point could be off the map so check
            if (Physics.Raycast(walkPoint, -transform.up, 2f, groundMask))
                walkPointSet = true;
        }

        public void Chase()
        {
            //Set the alien's transform to the player
            transform.position = player.position;
        }

        public void Attack()
        {
            //Make sure enemy doesn't move since they are shooting at the player
            //alien.SetDestination(transform.position);

            //Also make sure the enemies look at the player
            transform.LookAt(player);

            if (!alreadyAttacked)
            {
                //Shooting code 

                alreadyAttacked = true;
                Invoke(nameof(ResetAttack), timeBtwAttacks);
            }
        }

        private void ResetAttack()
        {
            alreadyAttacked = false;
        }

        /// <summary>
        /// Visualise the projectiles depending if shooting from sight range or attack range
        /// </summary>
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, attackRange);
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, sightRange);
        }
    }
}
