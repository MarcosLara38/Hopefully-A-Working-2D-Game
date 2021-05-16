using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private GameMaster gm;
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("CheckPointPing");
            //gm.lastCheckPointPos = transform.position;
            GameObject.FindGameObjectWithTag("Player").GetComponent<SaveLoadAction>().AutoSave();

        }
    }
}
