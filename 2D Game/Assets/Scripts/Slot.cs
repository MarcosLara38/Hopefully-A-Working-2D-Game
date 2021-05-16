using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private Inventory inventory;
    public int i;
    public string item;


    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        //item = "";
    }

    private void Update()
    {
        if (transform.childCount <= 0)
        {
            inventory.isFull[i] = false;
            item = "";
        }
        foreach (Transform child in transform)
        {
            item = child.transform.name;
            //currentItem = item;
        }
    }

    // Need to delete weapon that player is holding. try to delete the player's weapon with find
    public void DropItem()
    {
        Debug.Log("DropItem is from:   " + inventory.currentItem + "   and   " + transform.GetChild(0).name);
        var player = GameObject.Find("Player").transform;
        if (inventory.UsingWeapon == true && inventory.currentItem != transform.GetChild(0).name)
        {
            foreach (Transform child in transform)
            {
                Debug.Log(child + "   and   " + inventory.currentItem + " ||");
                child.GetComponent<Spawn>().SpawnDroppedItem();

                GameObject.Destroy(child.gameObject);

            }

        }
        else if (inventory.UsingWeapon == true && inventory.currentItem == transform.GetChild(0).name)
        {
            foreach (Transform child in inventory.Hand.transform)//player)
            {
                if (child.tag == "PickableItem")
                {
                    inventory.currentItem = " ";
                    GameObject.Destroy(child.gameObject);
                    inventory.UsingWeapon = false;
                }
            }
        }
        if (inventory.UsingWeapon == false)
        {
            foreach (Transform child in transform)
            {
                Debug.Log(child + "   and   " + inventory.currentItem + " ||");
                child.GetComponent<Spawn>().SpawnDroppedItem();

                GameObject.Destroy(child.gameObject);

            }
        }






    }
}
