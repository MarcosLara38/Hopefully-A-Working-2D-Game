using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemAction : MonoBehaviour
{
    public bool InsideAItem = false;
    private CircleCollider2D circle;
    private Text thisText;
    private PlayerController Player;
    private Inventory inventory;
    public GameObject itemButton;
    public string[] items;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        if (this.gameObject.tag == "PickableItem")
        {
            thisText = GetComponentInChildren<Text>();
        }

        items = new string[] {"Heart", "Candy cane", "Candy", "Cherry", "cotton candy", "Heart(Clone)",
                              "Candy cane(Clone)", "Candy(Clone)", "Cherry(Clone)", "cotton candy(Clone)" };
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (this.gameObject.tag == "Money" || this.gameObject.tag == "Points")
            {

            }
            else if (this.gameObject.tag == "PickableItem")
            {
                InsideAItem = true;
                thisText.text = "Press E to Collect";
            }

            Player = col.gameObject.GetComponent<PlayerController>();
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        Debug.Log("The player left the item");
        if (this.gameObject.tag == "PickableItem")
        {
            thisText.text = "";
        }
        InsideAItem = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && InsideAItem == true)
        {
            //string currentItem = this.name;
            //Debug.Log("You tried to grab " + this.name);
            //foreach (var item in items)
            //{
            //if (currentItem == item)
            //{
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    Debug.Log("The player collected the item");
                    inventory.isFull[i] = true;
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    Destroy(this.gameObject);
                    break;
                }
            }
            //  }
            //}

        }
    }
}