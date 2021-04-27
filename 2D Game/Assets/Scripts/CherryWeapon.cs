using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryWeapon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float offset;
    public GameObject cherry;
    public float launchForce;
    public Transform shotPoint;

    private float timeBtwShots;
    public float stateTimeBtwShots;

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        //Vector2 cherryPosition = transform.position;
        //Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Vector2 direction = mousePosition - cherryPosition;
        //transform.right = direction;

        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
               Instantiate(cherry, shotPoint.position, transform.rotation);
                timeBtwShots = stateTimeBtwShots;
                //Shoot();
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
    //void Shoot()
    //{
        //GameObject newCherry = Instantiate(cherry, shotPoint.position, shotPoint.rotation);
        //newCherry.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
    //}
}
