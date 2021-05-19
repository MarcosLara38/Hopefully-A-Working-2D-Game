using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    public GameObject Item;
    public GameObject newObj;
    public Slot slot;
    public Inventory inventory;

    private void Start()
    {
        slot = transform.parent.GetComponent<Slot>();
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    public void useItem()
    {
        //var player = GameObject.Find("PlayerBone").transform;
        if (inventory.UsingWeapon == false || inventory.currentItem != slot.item)
        {
            Debug.Log("inventory.currentItem: " + inventory.currentItem + "     and     " + slot.item);
            foreach (Transform child in transform.parent)
            {
                /*Debug.Log("Child is: " + Item.GetComponent<ItemAction>().itemButton.name);
                foreach (Transform child2 in inventory.Hand.transform)//player)
                {
                    if (child2.tag == "PickableItem")
                    {
                        GameObject.Destroy(child2.gameObject);
                    }
                }
                CHANGE HEART FUNCTION TO HEAL PLAYER INSTEAD OF PUTING IT IN THEIR HAND*/
                if (Item.name == "Heart")
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().health += 4;
                    foreach (Transform PlayerChildren in GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().allChildren = GetComponentsInChildren<Transform>(true))
                    {
                        Debug.Log(PlayerChildren.name);
                        if (PlayerChildren.name == "Health Button(Clone)")
                        {
                            GameObject.Destroy(PlayerChildren.gameObject);
                            break;
                        }

                    }
                }
                else
                {
                    //Debug.Log("Child is: " + Item.GetComponent<ItemAction>().itemButton.name);
                    foreach (Transform child2 in inventory.Hand.transform)//player)
                    {
                        if (child2.tag == "PickableItem")
                        {
                            GameObject.Destroy(child2.gameObject);
                        }
                    }
                    newObj = GameObject.Instantiate(Item);
                    newObj.transform.parent = inventory.Hand.transform;//GameObject.Find("PlayerBone").transform;
                    newObj.transform.localPosition = new Vector2(0.782f, 0.821f);
                    newObj.transform.localRotation = Quaternion.identity;
                    inventory.currentItem = Item.GetComponent<ItemAction>().itemButton.name + "(Clone)";
                    inventory.UsingWeapon = true;
                }
            }
        }
        else if (inventory.UsingWeapon == true && inventory.currentItem == slot.item)
        {
            inventory.UsingWeapon = false;
            inventory.currentItem = " ";
            foreach (Transform child in inventory.Hand.transform)//GameObject.Find("PlayerBone").transform)
            {
                Debug.Log(child.gameObject + "   and   " + inventory.currentItem);
                if (child.tag == "PickableItem")
                {
                    GameObject.Destroy(child.gameObject);
                }

            }

        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
