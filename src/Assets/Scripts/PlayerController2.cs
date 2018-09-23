using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour 
{
    private bool jump = false;
    public float jumpForce = 5000F;
    public float forwardForce = 5000F;
    public float backForce = 2500F;
    public Vector3 forwardDirection = new Vector3(1F, 0F, 0F);
 
    // positional drag
    public float sqrdSpeedThresholdForDrag = 25F;
    public float superDrag = 2F;
    public float fastDrag = 0.5F;
    public float slowDrag = 0.01F;
 
    public bool playerControl = true;
 
    private Rigidbody2D rig;

 	// Use this for initialization
	void Start () 
	{
		// stats = GetComponent<PlayerStats>();
		// anim = GetComponent<Animator>();
		rig = GetComponent<Rigidbody2D>();
	}

    void FixedUpdate()
    {
        Debug.Log(rig.velocity.sqrMagnitude);

        if (Mathf.Abs(thrust) > 0.01F)
        {
            if (rig.velocity.sqrMagnitude > sqrdSpeedThresholdForDrag)
                rig.drag = fastDrag;
            else
                rig.drag = slowDrag;
        }
        else
            rig.drag = superDrag;
    }
 
    float thrust = 0F;
    float turn = 0F;
 
    void Thrust(float t)
    {
        thrust = Mathf.Clamp(t, -1F, 1F);
    }
 
    void Update ()
    {
        float theThrust = thrust;
 
        if (playerControl)
        {
            thrust = Input.GetAxis("Horizontal");
        }
 
        if (thrust > 0F)
        {
            theThrust *= forwardForce;
        }
        else
        {
            theThrust *= backForce;
        }
 
        rig.AddForce(Vector2.right * theThrust * Time.deltaTime);
        //rig.AddRelativeForce(forwardDirection * theThrust * Time.deltaTime);

        if(jump)
		{
			//anim.SetTrigger("Jump");
			rig.AddForce(new Vector2(0f, jumpForce));
			jump = false;
		}
    }
}