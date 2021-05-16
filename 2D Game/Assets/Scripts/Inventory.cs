﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryUI;
    public PauseMenu pause;
    public bool inventoryIsOn = false;
    public bool[] isFull;
    public GameObject[] slots;
    public bool UsingWeapon = false;
    public string currentItem;
    public GameObject Hand;
    public Transform[] allChildren;
    int i = 0;
    public int score = 0;
    public Text targetName;

    void Start()
    {
        allChildren = GetComponentsInChildren<Transform>(true);
        
    }
    // Update is called once per frame
    void Update()
    {

        if (Hand == null)
        {
            foreach (Transform child in allChildren)
            {
               // Debug.Log(child);
                if (child.name == "bone_6")
                {
                    Hand = child.gameObject;
                    break;
                }
             
            }
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (inventoryIsOn)
            {
                ResumeGame();
            }
            else
            {
                //Debug.Log("Tab is pressed");
                inventory();
            }
        }

    }

    public void inventory()
    {
        //PREVENT INVENTORY OPENING WHEN PAUSED
        inventoryUI.SetActive(true);
        targetName = GameObject.Find("Score").GetComponent<Text>();
        targetName.text = "Score is " + score;
        //Time.timeScale = 0f;
        inventoryIsOn = true;
    }

    public void ResumeGame()
    {
        inventoryUI.SetActive(false);
        //Time.timeScale = 1f;
        inventoryIsOn = false;
    }
}