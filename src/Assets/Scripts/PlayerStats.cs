using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour 
{
	/// <summary>
	/// Determine the multiplication factor that reduce or accelerate the player.
	/// </summary>
	public float SpeedFactor = 0.25f;
	
	public float Speed = 5f;
	public int MaxHealth = 100;
	public int CurrentHealth = 100;
}
