using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryWeapon : MonoBehaviour
{
     // Start is called before the first frame update
     void Start()
     {

     }

    //public float offset;
    public GameObject Cherry;
    //public float launchForce;
    //public Transform shotPoint;
    public Vector2 dirction;
    public float LaunchForce;

    //private float timeBtwShots;
    //public float startTimeBtwShots;

     // Update is called once per frame
     void Update()
     {
        //Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        //Vector2 cherryPosition = transform.position;
        //Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Vector2 direction = mousePosition - cherryPosition;
        //transform.right = direction;

        Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 cherryPos = transform.position;

        dirction = MousePos - cherryPos;

        FaceMouse();

        //if (timeBtwShots <= 0)
         //{
             if (Input.GetMouseButtonDown(0))
             {
                //Instantiate(cherry, shotPoint.position, transform.rotation);
                //timeBtwShots = startTimeBtwShots;
                Shoot();
             }
         //}
         //else
         //{
             //timeBtwShots -= Time.deltaTime;
         //}
     }
     //void Shoot()
     //{
         //GameObject newCherry = Instantiate(cherry, shotPoint.position, shotPoint.rotation);
         //newCherry.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
     //}*/

    
    //private float timeBtwShots;
    //public float startTimeBtwShots;
    //public GameObject Cherry;
    //public float LaunchForce;
    //public float force;
    //public GameObject PointPerfab;
    //public GameObject[] Points;
    //public int numberOfPoints;

    /*void Start()
    {
        /*Points = new GameObject[numberOfPoints];
        for (int i = 0; i < numberOfPoints; i++)
        {
            Points[i] = Instantiate(PointPerfab, transform.position, Quaternion.identity);
        }*/
    //}

    /*void Update()
    {
        Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 cherryPos = transform.position;

        dirction = MousePos - cherryPos;

        FaceMouse();

        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //Instantiate(cherry, shotPoint.position, transform.rotation);
                timeBtwShots = startTimeBtwShots;
                Shoot();
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

        /*for (int i = 0; i< Points.Length; i++)
        {
            Points[i].transform.position = PointPosition(i * 0.1f);
        }*/
    //}

    void FaceMouse()
    {
        transform.right = dirction;
    }

    void Shoot()
    {
        GameObject CherryIns = Instantiate(Cherry, transform.position, transform.rotation);

        //CherryIns.GetComponent<Rigidbody2D>().AddForce(transform.right * LaunchForce);
        CherryIns.GetComponent<Rigidbody2D>().velocity = transform.right * LaunchForce;
    }

    /*Vector2 PointPosition(float t)
    {
        Vector2 currentPointPos = (Vector2)transform.position + (dirction.normalized * force * t) + (0.5f * Physics2D.gravity * (t * t));
        return currentPointPos;
    }*/
}
