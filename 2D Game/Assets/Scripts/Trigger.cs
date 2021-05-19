using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public bool SpawnningEnemy = false;
    public bool Empty = true;
    public int trigIndex = 0;
    public GameObject enemy;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if(GameObject.Find("SpawnManager").GetComponent<SpawnManager>().CurrentSpawned[trigIndex] == 0 && enemy == null)
            {
                SpawnningEnemy = true;
            }
            
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {

        }
    }
}
