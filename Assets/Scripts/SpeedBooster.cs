using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBooster : MonoBehaviour 
{
	public float Multiplicator = 2f;
	public float Duration = 5f;

	/// <summary>
	/// Sent when another object enters a trigger collider attached to this
	/// object (2D physics only).
	/// </summary>
	/// <param name="other">The other Collider2D involved in this collision.</param>
	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log("Collide");
		if(other.gameObject.CompareTag("Player"))
		{
			StartCoroutine(Pickup(other));
		}
	}

	IEnumerator Pickup(Collider2D player)
	{
		// Spawn an effect.

		// Apply effect to the player.
		PlayerStats stats = player.GetComponent<PlayerStats>();

		// Multiply the speed of the player by the factor.
		stats.SpeedFactor *= Multiplicator;

		GetComponent<SpriteRenderer>().enabled = false;
		GetComponent<CircleCollider2D>().enabled = false;

		// Wait x amount of seconds
		yield return new WaitForSeconds(Duration);

		// Set back the speed of the player after the powerup duration.
		stats.SpeedFactor /= Multiplicator;

		// Remove power up object.
		Destroy(gameObject);
	}
}
