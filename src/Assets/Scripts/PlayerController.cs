using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	[HideInInspector] public bool jump = true;

	/// <summary>
	/// Determine the force that is applied to the player horizontal vector.
	/// </summary>
	public float MoveForce = 200f;

	/// <summary>
	/// Determine the force that is applied to the player vertical vector (While jumping).
	/// </summary>
	public float JumpForce = 500f;

	/// <summary>
	/// Determine the position at which the ground will be looked at.
	/// </summary>
	public Transform GroundCheck;

	private bool grounded = false;
	private float MaxSpeed 
	{
		get { return stats.Speed  * (1 + stats.SpeedFactor); }
	}
	private float MinSpeed 
	{
		get { return stats.Speed * ( 1 - stats.SpeedFactor); }
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
	void Update () {
		grounded = Physics2D.Linecast(transform.position, GroundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

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
		//anim.SetFloat("Speed", Mathf.Abs(h));

		if(h > 0 && Mathf.Abs(rig.velocity.x) < MaxSpeed)
		{
			rig.velocity = rig.velocity * 1.1f; // Gradually Increase Velocity
		}
		else if(h < 0 && Mathf.Abs(rig.velocity.x) > MinSpeed)
		{
			rig.velocity = rig.velocity * 0.9f; // Gradually Reduce Velocity
		}
		else if(h == 0)
		{
			rig.velocity = new Vector2(stats.Speed, rig.velocity.y);
		}

		// Ensure we are not exceeding min or max speed.
		if(Mathf.Abs(rig.velocity.x) > MaxSpeed)
		{
			rig.velocity = new Vector2(MaxSpeed, rig.velocity.y);
		}
		else if(Mathf.Abs(rig.velocity.x) < MinSpeed)
		{
			rig.velocity = new Vector2(MinSpeed, rig.velocity.y);
		}

		Debug.Log(rig.velocity);

		if(jump)
		{
			//anim.SetTrigger("Jump");
			rig.AddForce(new Vector2(0f, JumpForce));
			jump = false;
		}
	}
}
