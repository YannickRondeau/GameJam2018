using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private float speed = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void LaunchProjectile()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, (Game.instance.Player.transform.position - transform.position));

        if (hit.transform == Game.instance.Player.transform)
        {
            Game.instance.SpawnBullet(transform.position, Game.instance.Player.transform.position, speed);
        }
    }

    /// <summary>
    /// OnBecameVisible is called when the renderer became visible by any camera.
    /// </summary>
    void OnBecameVisible()
    {
        InvokeRepeating("LaunchProjectile", 0.5f, 0.1f);
    }

    /// <summary>
    /// OnBecameInvisible is called when the renderer is no longer visible by any camera.
    /// </summary>
    void OnBecameInvisible()
    {
        CancelInvoke();
    }
}
