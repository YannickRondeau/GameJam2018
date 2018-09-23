using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 public enum BulletTypes
    {
        Small,
        FastSmall,

        Medium,
        FastMedium,

        Big,
        FastBig
    }

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

        GameObject hitObj = CheckColliders();

        if (hitObj != null)
        {
            Character character = hitObj.GetComponent<Character>();
            if (character != null)
            {
                character.ReceiveDamage(10);
            }

            delete();
        }

    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


    GameObject CheckColliders()
    {
        ContactFilter2D cf = new ContactFilter2D();
        cf.useTriggers = true;

        List<string> mask = new List<string>();//args.RequiredLayers.Concat(args.BlockingLayers).ToList();
        mask.Add("Solid");

        cf.SetLayerMask(LayerMask.GetMask(mask.ToArray()));

        Collider2D[] colliders = new Collider2D[12];
        GetComponent<Collider2D>().OverlapCollider(cf, colliders);

        if (colliders[0] != null)
        {

            return colliders[0].gameObject;
        }

        return null;
    }

    void delete()
    {
        Destroy(this.gameObject);
    }

}
