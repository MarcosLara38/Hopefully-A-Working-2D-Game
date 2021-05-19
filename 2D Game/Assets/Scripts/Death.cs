using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {           
            col.gameObject.GetComponent<Health>().health = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
