using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    private int spawnIndex;
    public Transform[] spawnpoints;
    public int[] CurrentSpawned;
    public GameObject[] triggers;
    private Vector3 spawnPos;
    public int count;
    public int MaxSpawn = 1;
    public int Index = 0;
    //public Trigger trig;

    void Start()
    {
        count = transform.childCount;
        spawnpoints = new Transform[count];
        CurrentSpawned = new int[count];
        triggers = new GameObject[count];
        for (int i = 0; i < count; i++)
        {
            spawnpoints[i] = transform.GetChild(i);
            if(SaveManager.NeedLoad != true)
            {
                CurrentSpawned[i] = 0;
            }
            
            triggers[i] = GameObject.Find("TriggersForSpawnning").transform.GetChild(i).gameObject;
        }      
    }

    void Update()
    {

        foreach (GameObject trig in triggers)
        {
            if(trig.GetComponent<Trigger>().SpawnningEnemy == true)
            {
                //Debug.Log("in Foreach");
                spawnIndex = trig.GetComponent<Trigger>().trigIndex;    
                trig.GetComponent<Trigger>().SpawnningEnemy = false;
                spawnEnemys();
                        
            }
            if (trig.GetComponent<Trigger>().enemy == null && GameObject.FindGameObjectWithTag("Player").GetComponent<SaveLoadAction>().Loading == false)
            {
                CurrentSpawned[trig.GetComponent<Trigger>().trigIndex] = 0;
                trig.GetComponent<Trigger>().Empty = true;
            }

        }

       
    }

    public void spawnEnemys()
    {


        //spawnIndex = Random.Range(0, count);
        if (CurrentSpawned[spawnIndex] >= 1 && triggers[spawnIndex].GetComponent<Trigger>().Empty == false)
        {
            if(triggers[spawnIndex].GetComponent<Trigger>().enemy == null)
            {
                triggers[spawnIndex].GetComponent<Trigger>().Empty = true;
                CurrentSpawned[spawnIndex] = 0;
            }

        }
        else
        {
            Debug.Log("2");
            CurrentSpawned[spawnIndex]++;
            triggers[spawnIndex].GetComponent<Trigger>().Empty = false;
            triggers[spawnIndex].GetComponent<Trigger>().enemy = Instantiate(enemyPrefab, spawnpoints[spawnIndex].position, enemyPrefab.transform.rotation);
        }
    }
}
