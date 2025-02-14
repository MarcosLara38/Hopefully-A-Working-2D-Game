﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject Item;
    private Transform player;
    private GameObject temp;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public void SpawnDroppedItem()
    {
        Vector2 playerPos = new Vector2(player.position.x, player.position.y);
        temp = Instantiate(Item, playerPos, Quaternion.identity);
        Destroy(temp.GetComponent<CherryWeapon>());
    }


    // Update is called once per frame
    void Update()
    {

    }
}
