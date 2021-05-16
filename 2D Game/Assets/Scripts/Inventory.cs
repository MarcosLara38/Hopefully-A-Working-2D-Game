using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    public Text target;
    public int score;
    private GameObject text;

    void Start()
    {
        allChildren = GetComponentsInChildren<Transform>();
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
        inventoryUI.SetActive(true);
        //Time.timeScale = 0f;
        inventoryIsOn = true;
        target = GameObject.Find("Score").GetComponent<Text>();
        target.text = "Score is " + score;
    }

    public void ResumeGame()
    {
        inventoryUI.SetActive(false);
        //Time.timeScale = 1f;
        inventoryIsOn = false;
    }
}