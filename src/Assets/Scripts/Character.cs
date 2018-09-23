using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	public int MaxLife;
	public int Life;

	public BulletTypes BulletType;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ReceiveDamage(int amount)
	{
		Life -= amount;
		
		if(Life <= 0)
		{
	//		Destroy(this.gameObject);
		}
	}


}
