using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game instance;

    public GameObject Bullet;

    public GameObject Player;

    private GameObject playerBulletSpawn;


    public int SmallBulletSpeed = 4000;
    public int FastSmallBulletSpeed= 6000;

    public int MediumBulletSpeed = 2500;
    public int FastMediumBulletSpeed = 3500;

    public int BigBulletSpeed = 1500;
    public int FastBigBulletSpeed = 2200;



    // Use this for initialization
    void Start()
    {
        if (instance == null)
        {
            instance = this;
			Application.targetFrameRate = 300;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        playerBulletSpawn = FindObjectsWithTag(Player.transform, "BulletSpawn").FirstOrDefault();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(MouseButton.Left))
        {
            //Grab our mouse position in relation to it's location of the camera/world combination. Great sensation!
            Vector3 mousePos_world = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 mousePos = new Vector3(mousePos_world.x, mousePos_world.y, transform.position.z);

            SpawnBullet(BulletTypes.FastSmall, playerBulletSpawn.transform.position, mousePos);
        }
    }

    public void SpawnBullet(BulletTypes bulletType, Vector3 start, Vector3 targetPos, float shooterSpeed = 0)
    {
        GameObject tempMyBullet = Instantiate(Bullet, start, Quaternion.identity) as GameObject;



        if (bulletType == BulletTypes.Medium || bulletType == BulletTypes.FastMedium)
        {
            tempMyBullet.transform.localScale *= 5;
        }

        if (bulletType == BulletTypes.Big || bulletType == BulletTypes.FastBig)
        {
            tempMyBullet.transform.localScale *= 20;
        }

        targetPos = targetPos - start;

        tempMyBullet.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg);

        Vector3 velocity = tempMyBullet.transform.rotation * Vector3.right;


        if (bulletType == BulletTypes.Small)
        {
            velocity *= SmallBulletSpeed+ shooterSpeed;
        }

		if (bulletType == BulletTypes.FastSmall)
        {
            velocity *= FastSmallBulletSpeed+ shooterSpeed;
        }

		if (bulletType == BulletTypes.Medium)
        {
            velocity *= MediumBulletSpeed+ shooterSpeed;
        }

		if (bulletType == BulletTypes.FastMedium)
        {
            velocity *= FastMediumBulletSpeed+ shooterSpeed;
        }

		if (bulletType == BulletTypes.Big)
        {
            velocity *= BigBulletSpeed+ shooterSpeed;
        }

		if (bulletType == BulletTypes.FastBig)
        {
            velocity *= FastBigBulletSpeed+ shooterSpeed;
        }

        tempMyBullet.GetComponent<Rigidbody2D>().AddRelativeForce(velocity );
    }

    private List<GameObject> FindObjectsWithTag(Transform parent, string tag)
    {
        List<GameObject> taggedGameObjects = new List<GameObject>();

        for (int i = 0; i < parent.childCount; i++)
        {
            Transform child = parent.GetChild(i);
            if (child.tag == tag)
            {
                taggedGameObjects.Add(child.gameObject);
            }
            if (child.childCount > 0)
            {
                taggedGameObjects.AddRange(FindObjectsWithTag(child, tag));
            }
        }
        return taggedGameObjects;
    }
}
