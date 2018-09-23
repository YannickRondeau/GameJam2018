using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour 
{
	private int MaxHealth = 100;
	public int CurrentHealth = 100;


	public void TakeDamage(int damage)
	{
		if(CurrentHealth > damage)
		{
			CurrentHealth -= damage;
		}
		else
		{
			// YOU'RE DEAD!
		}
	}
}
