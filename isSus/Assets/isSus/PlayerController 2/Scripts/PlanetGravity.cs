using UnityEngine;

namespace IsSus.Game.Mechanic
{
	public class PlanetGravity : MonoBehaviour
	{
		public float gravity = -10;

		/// <summary>
		/// This function locks the player's rigidbody to the position and rotation of the planet with gravity.
		/// </summary>
		/// <param name="player"></param>
		public void GravityLock(Rigidbody player)
		{
			Vector3 gravityUp = (player.position - transform.position).normalized;
			Vector3 localUp = player.transform.up;

			// Apply downwards gravity to body
			player.AddForce(gravityUp * gravity);
			// Allign bodies up axis with the centre of planet
			player.rotation = Quaternion.FromToRotation(localUp, gravityUp) * player.rotation;
		}
	}
}
