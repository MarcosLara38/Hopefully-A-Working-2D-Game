using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{

    public Transform target;
    public float speed = 200f;
    public float nextWaypointDistance = 3f;
    public Animator animator;
    public int health;
    //public GameObject bloodEffect;
    private float dazedTime;
    public float startDazedTime;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (dazedTime <= 0)
        {
            speed = 2;
        }
        else
        {
            speed = 0;
            dazedTime -= Time.deltaTime;
        }
        if (path == null)
        {
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        if (rb.velocity.x >= 0.001f)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (rb.velocity.x <= 0.001f)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }

        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    }
    
    void Update()
    {

    }

    // enemy takes damge
    public void TakeDamage(int damage) 
    {
        //play a hurt sound
        //Instantiate(bloodEffect, transform.position, Quaternion.identity);
        dazedTime = startDazedTime;
        health -= damage;
        // enemy is destroy
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        //Debug.Log ("damage TAKEN !")
    }


}
