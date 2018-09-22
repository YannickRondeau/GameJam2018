using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour 
{

     float defaultSpeed = 60.0f;
     float speed;
	public void Init(Vector3 targetPos, float InitialSpeed)
	{
        speed = InitialSpeed + defaultSpeed;
	}

    void Update() 
    {

         if(CheckColliders())
         {
             delete();
         }       

    }

     void OnBecameInvisible()
    {
         Destroy(gameObject);
     }


    bool CheckColliders()
    {

        ContactFilter2D cf = new ContactFilter2D();
        cf.useTriggers = true;

        List<string> mask = new List<string>();//args.RequiredLayers.Concat(args.BlockingLayers).ToList();
        mask.Add("Solid");


        cf.SetLayerMask(LayerMask.GetMask(mask.ToArray()));

        Collider2D[] colliders = new Collider2D[12];
        GetComponent<Collider2D>().OverlapCollider(cf, colliders);

        if(colliders[0]!= null)
        {
            return true;
        }

        return false;
    } 
		
    void delete()
    {
        Destroy(this.gameObject);
    }

}
