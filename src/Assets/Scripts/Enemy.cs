using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{

    private float speed = 0;

    public float ShootSpeed = 0.5f;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// This function is called when the MonoBehaviour will be destroyed.
    /// </summary>
    void OnDestroy()
    {
        CancelInvoke();
    }

    void LaunchProjectile()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, (Game.instance.Player.transform.position - transform.position));

        if (hit.transform == Game.instance.Player.transform)
        {
            Game.instance.SpawnBullet(BulletType, transform.position, Game.instance.Player.transform.position, speed);
        }
    }

    /// <summary>
    /// OnBecameVisible is called when the renderer became visible by any camera.
    /// </summary>
    void OnBecameVisible()
    {
        InvokeRepeating("LaunchProjectile", 0.5f, ShootSpeed);
    }

    /// <summary>
    /// OnBecameInvisible is called when the renderer is no longer visible by any camera.
    /// </summary>
    void OnBecameInvisible()
    {
        CancelInvoke();
    }
}
