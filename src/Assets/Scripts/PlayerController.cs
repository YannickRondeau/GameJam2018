using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	public bool jump = false;

	/// <summary>
	/// Determine the force that is applied to the player horizontal vector.
	/// </summary>
	public float Speed = 20f;

	/// <summary>
	/// Determine the bonus multiplicator for the player's speed!
	/// </summary>
	public float SpeedBooster = 0.5f;

	/// <summary>
	/// Determine the force that is applied to the player vertical vector (While jumping).
	/// </summary>
	public float JumpForce = 20f;

	/// <summary>
	/// Determine the position at which the ground will be looked at.
	/// </summary>
	public Transform GroundCheck;

	private bool grounded = false;

	private float MaxSpeed 
	{
		get { return Speed  * (1 + Mathf.Clamp(SpeedBooster, 0f, 2f)); }
	}
	private float MinSpeed 
	{
		get { return Speed * ( 1 - Mathf.Clamp(SpeedBooster, 0f, 0.6f)); }
	}

	private Animator anim;
	private Rigidbody2D rig;
	private PlayerStats stats;

	// Use this for initialization
	void Start () 
	{
		stats = GetComponent<PlayerStats>();
		anim = GetComponent<Animator>();
		rig = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		grounded = Physics2D.OverlapCircle(GroundCheck.position, 0.2f, 1 << LayerMask.NameToLayer("Ground") | 1 << LayerMask.NameToLayer("Solid")); // checks if you are within 0.15 position in the Y of the ground

		if(Input.GetButtonDown("Jump") && grounded)
		{
			jump = true;
		}
	}

	/// <summary>
	/// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
	/// </summary>
	void FixedUpdate()
	{
		float h = Input.GetAxis("Horizontal");

		Vector2 movement = Vector2.right * Speed;

		if(h > 0)
		{
			movement *= MaxSpeed;
		}
		else if(h < 0)
		{
			movement *= MinSpeed;
		}
		else if(h == 0)
		{
			movement *= Speed;
		}

		rig.AddForce(movement);


		if(jump)
		{
			//anim.SetTrigger("Jump");
			rig.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
			jump = false;
		}
	}
}
