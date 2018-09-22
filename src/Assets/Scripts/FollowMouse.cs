using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		pos.z = transform.position.z;
        transform.position = pos;
	}
}
