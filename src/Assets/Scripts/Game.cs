using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

	public static Game instance;

	public GameObject Bullet;
	public GameObject Unit;

	public GameObject Player;


	// Use this for initialization
	void Start () 
	{
		
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () 
	{

            if (Input.GetMouseButtonUp(MouseButton.Left))
            {

			   	//Grab our mouse position in relation to it's location of the camera/world combination. Great sensation!
				Vector3 mousePos_world = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				Vector3 mousePos = new Vector3(mousePos_world.x, mousePos_world.y, transform.position.z);

				SpawnBullet(Unit.transform.position, mousePos);
	
            }
	}

	public void SpawnBullet(Vector3 start, Vector3 targetPos, float shooterSpeed =0)
	{
	
				GameObject tempMyBullet = Instantiate(Bullet,start,Quaternion.identity) as GameObject;
				tempMyBullet.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg);
			
				Vector3 velocity = tempMyBullet.transform.rotation * Vector3.right;
				tempMyBullet.GetComponent<Rigidbody2D>().AddRelativeForce(velocity * (6000 + shooterSpeed));

	}
}
