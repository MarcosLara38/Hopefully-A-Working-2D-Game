using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using UnityEngine;

public class SaveLoadAction : MonoBehaviour
{
    public PlayerData so;
    public PauseMenu menus;
    public PlayerController controller;
    public bool Loading = false;
    private int AmountOfHearts;
    private int Health;
    private float AttackSpeed;
    private int AttackDamage;
    private GameObject[] Enemies;
    private GameObject[] Items;
    public GameObject PreFab, cherryButton, candyButton, candyCandButton, cottonCandyButton, healthButton,
            Heart, CottonCandy, Cherry, Candy, CandyCane;
    public Text FileName;
    public Dropdown name;
    public bool Exist = false;
    public bool NormalLoad = true;
    Dropdown.OptionData fileOne;
    List<Dropdown.OptionData> m_Messages = new List<Dropdown.OptionData>();

    void Start()
    {
        
        foreach (string files in System.IO.Directory.GetFiles(Application.persistentDataPath + SaveManager.directory))
        {
            //if (File.Exists(files)) 
            
            fileOne = new Dropdown.OptionData();
            fileOne.text = Path.GetFileName(files);
            name.options.Add(fileOne);

        }
    }
    public void Save()
    {   
        int temp = 0;
        int MaxEnemiesOnSave = 10;
        so.Health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().health;
        so.AmountOfHearts = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().numOfHearts;
        so.AttackSpeed = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>()._attackSpeed;
        so.AttackDamage = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().attackDamage;
        so.PlayerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        //ADD PLAYER'S SCORE
        
        //Getting all of the items that is in the game and putting it in ITEMS
        foreach(GameObject ITEMS in GameObject.FindGameObjectsWithTag("PickableItem"))
        { 
            if (ITEMS.transform.parent != null)
            {
                if (ITEMS.transform.parent.name != "Hand")
                {
                    //save the item[temp] position into the player data object
                    so.ItemsPositions[temp] = ITEMS.transform.position;
                    //Checks the item's name and save that name to the players data object
                    if (ITEMS.name == Candy.name || ITEMS.name == Candy.name + "(Clone)")
                    {
                        so.ItemName[temp] = Candy.name;
                    }
                    else if (ITEMS.name == Heart.name || ITEMS.name == Heart.name + "(Clone)")
                    {
                        so.ItemName[temp] = Heart.name;
                    }
                    else if (ITEMS.name == CottonCandy.name || ITEMS.name == CottonCandy.name + "(Clone)")
                    {
                        so.ItemName[temp] = CottonCandy.name;
                    }
                    else if (ITEMS.name == CandyCane.name || ITEMS.name == CandyCane.name + "(Clone)")
                    {
                        so.ItemName[temp] = CandyCane.name;
                    }
                    else if (ITEMS.name == Cherry.name || ITEMS.name == Cherry.name + "(Clone)")
                    {
                        so.ItemName[temp] = Cherry.name;
                    }
                    temp++;
                }
            }
            else
            {

            }
        }

        temp = 0;

        //Checking if there is an item in a slot and then saving true into the player data object if true
        for(int nums = 0; nums < 11; nums++)
        {
            if(GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().slots[nums].transform.childCount == 1)
            {
                so.ISFull[nums] = true;
                Debug.Log(GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().slots[nums].transform.GetChild(0).tag);
                so.slotIndex[nums] = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().slots[nums].transform.GetChild(0).tag;
            }
        }

        //
        for(int index = 0; index <= 3; index++)
        {
            so.currentSpawned[index] = GameObject.Find("SpawnManager").GetComponent<SpawnManager>().CurrentSpawned[index];
        }
    
        //
        for (int i = 0; i < 4; i++)
        {
            so.Triggers[i] = GameObject.Find("SpawnManager").GetComponent<SpawnManager>().triggers[i].GetComponent<Trigger>().enemy;
            so.empty[i] = GameObject.Find("SpawnManager").GetComponent<SpawnManager>().triggers[i].GetComponent<Trigger>().Empty;
        }
       
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        
        //Now getting all enemies in the game
        foreach (GameObject enemy in Enemies)
        {
            //Check if it has reach the max amount of enemies that can be saved
            if(temp == MaxEnemiesOnSave)
            {
            }
            else
            {
                //save the enemies position
                so.enemies[temp] = enemy.transform.position;
                temp++;
            }
        }

        //Save the name of the file that the player inputed
        so.name = FileName.text;
              
        //Access the dropdown options inside the load menu and check if the file name exist
        foreach (Dropdown.OptionData message in m_Messages)
        {
            if(FileName.text == message.text)
            {
                Exist = true;            
            }
           
        }
        if (Exist == true)
        {
            Debug.Log("Save file does exist");
        }
        else
        {
            //If the name does not exist then add the new file name to the dropdown list and call SaveManager
            fileOne = new Dropdown.OptionData();
            fileOne.text = FileName.text;
            m_Messages.Add(fileOne); 
            name.options.Add(fileOne);
            SaveManager.fileName = FileName.text;
            SaveManager.Save(so);
            menus.ResumeGame();
        }
        Exist = false;
    }

    //Every 5 mins the game will auto save
    public void AutoSave()
    {
        int temp = 0;
        int MaxEnemiesOnSave = 10;
        so.Health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().health;
        so.AmountOfHearts = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().numOfHearts;
        so.AttackSpeed = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>()._attackSpeed;
        so.AttackDamage = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().attackDamage;
        so.PlayerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;

        //Getting all of the items that is in the game and putting it in ITEMS
        foreach (GameObject ITEMS in GameObject.FindGameObjectsWithTag("PickableItem"))
        {
            
            
            if (ITEMS.transform.parent != null)
            {
                if (ITEMS.transform.parent.name != "Hand")
                {
                    //save the item[temp] position into the player data object
                    so.ItemsPositions[temp] = ITEMS.transform.position;
                    //Checks the item's name and save that name to the players data object
                    if (ITEMS.name == Candy.name || ITEMS.name == Candy.name + "(Clone)")
                    {
                        so.ItemName[temp] = Candy.name;
                    }
                    else if (ITEMS.name == Heart.name || ITEMS.name == Heart.name + "(Clone)")
                    {
                        so.ItemName[temp] = Heart.name;
                    }
                    else if (ITEMS.name == CottonCandy.name || ITEMS.name == CottonCandy.name + "(Clone)")
                    {
                        so.ItemName[temp] = CottonCandy.name;
                    }
                    else if (ITEMS.name == CandyCane.name || ITEMS.name == CandyCane.name + "(Clone)")
                    {
                        so.ItemName[temp] = CandyCane.name;
                    }
                    else if (ITEMS.name == Cherry.name || ITEMS.name == Cherry.name + "(Clone)")
                    {
                        so.ItemName[temp] = Cherry.name;
                    }
                    temp++;
                }
            }
            else
            {
                
            }
        }

        temp = 0;

        //Checking if there is an item in a slot and then saving true into the player data object if true
        for (int nums = 0; nums < 11; nums++)
        {
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().slots[nums].transform.childCount == 1)
            {
                so.ISFull[nums] = true;
                Debug.Log(GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().slots[nums].transform.GetChild(0).tag);
                so.slotIndex[nums] = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().slots[nums].transform.GetChild(0).tag;
            }
        }

        //
        for (int index = 0; index <= 3; index++)
        {
            so.currentSpawned[index] = GameObject.Find("SpawnManager").GetComponent<SpawnManager>().CurrentSpawned[index];
        }

        //
        for (int i = 0; i < 4; i++)
        {
            so.Triggers[i] = GameObject.Find("SpawnManager").GetComponent<SpawnManager>().triggers[i].GetComponent<Trigger>().enemy;
            so.empty[i] = GameObject.Find("SpawnManager").GetComponent<SpawnManager>().triggers[i].GetComponent<Trigger>().Empty;
        }

        Enemies = GameObject.FindGameObjectsWithTag("Enemy");

        //Now getting all enemies in the game
        foreach (GameObject enemy in Enemies)
        {
            //Check if it has reach the max amount of enemies that can be saved
            if (temp == MaxEnemiesOnSave)
            {
            }
            else
            {
                //save the enemies position
                so.enemies[temp] = enemy.transform.position;
                temp++;
            }
        }

        //Save the name of the file that the player inputed
        so.name = "AutoSave";

            //If the name does not exist then add the new file name to the dropdown list and call SaveManager
            fileOne = new Dropdown.OptionData();
            fileOne.text = "AutoSave";
            m_Messages.Add(fileOne);
            name.options.Add(fileOne);
            SaveManager.fileName = "AutoSave";
            SaveManager.Save(so);
            menus.ResumeGame();
        Exist = false;
    }

    public void Load()
    {
        int temp = 0;
        Debug.Log("Trying to load");

        //Get the selected file name from the dropdown list and call SaveManager with that name
        SaveManager.fileName = name.options[name.value].text;

        //Checking if the file name is in its full path name or just the end of the file
        for (int i = 0; i < Application.persistentDataPath.Length; i++)
        {
            //Compares the characters of the full path string with the player's string
            if (Application.persistentDataPath[i] != SaveManager.fileName[i])
            {
                NormalLoad = true;
                break;
            }
            else
            {
                NormalLoad = false;
            }
        }
        if (NormalLoad == true)
        {
            so = SaveManager.Load();
        }
        else
        {
            so = SaveManager.MenuLoad();
        }

        //Destror every enemies in the game to refresh the game
        foreach(GameObject emi in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(emi);
        }

        //start the load the save player data into the current player
        GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().health = so.Health;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().numOfHearts = so.AmountOfHearts;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>()._attackSpeed = so.AttackSpeed;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().attackDamage = so.AttackDamage;
        GameObject.FindGameObjectWithTag("Player").transform.position = so.PlayerPosition;
        
        //Destory all possible items that could be in the game
        temp = 0;
        foreach(GameObject items in GameObject.FindGameObjectsWithTag("PickableItem"))
        {
            Destroy(items);
        }

        //spawn all the items into the game and in the right position
        foreach (string itemName in so.ItemName)
        {
            if (itemName == Candy.name)
            {
                Instantiate(Candy, so.ItemsPositions[temp], Quaternion.identity);
                temp++;
            }
            else if (itemName == Heart.name)
            {
                Instantiate(Heart, so.ItemsPositions[temp], Quaternion.identity);
                temp++;
            }
            else if (itemName == CottonCandy.name)
            {
                Instantiate(CottonCandy, so.ItemsPositions[temp], Quaternion.identity);
                temp++;
            }
            else if (itemName == CandyCane.name)
            {
                Instantiate(CandyCane, so.ItemsPositions[temp], Quaternion.identity);
                temp++;
            }
            else if (itemName == Cherry.name)
            {
                //Instantiate(Cherry, so.ItemsPositions[temp], Quaternion.identity);
                Destroy(Instantiate(Cherry, so.ItemsPositions[temp], Quaternion.identity).GetComponent<CherryWeapon>());
                temp++;
            }
        }

        temp = 0;

        //Foreach item that is save in the players inventory, compare the names and spawn the correct item.
        for (int nums = 0; nums < 11; nums++)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().isFull[nums] = so.ISFull[nums];

            if (GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().slots[nums].transform.childCount == 1)
            {
                //destroying current item inside the inventory slot
                Destroy(GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().slots[nums].transform.GetChild(0).gameObject);
            }

            if (so.slotIndex[nums] != "")
            {
                if (so.slotIndex[nums] == cherryButton.name)
                {
                    Instantiate(cherryButton, GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().slots[nums].transform, false);
                    Destroy(GameObject.Find("Cherry")); Destroy(GameObject.Find("Cherry(Clone)"));
                }
                else if (so.slotIndex[nums] == candyButton.name)
                {
                    Instantiate(candyButton, GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().slots[nums].transform, false);
                    Destroy(GameObject.Find("Candy")); Destroy(GameObject.Find("Candy(Clone)"));
                }
                else if (so.slotIndex[nums] == candyCandButton.name)
                {
                    Instantiate(candyCandButton, GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().slots[nums].transform, false);
                    Destroy(GameObject.Find("Candy cane")); Destroy(GameObject.Find("Candy cane(Clone)"));
                }
                else if (so.slotIndex[nums] == cottonCandyButton.name)
                {
                    Instantiate(cottonCandyButton, GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().slots[nums].transform, false);
                    Destroy(GameObject.Find("cotton candy")); Destroy(GameObject.Find("cotton candy(Clone)"));
                }
                else if (so.slotIndex[nums] == healthButton.name)
                {
                    Instantiate(healthButton, GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().slots[nums].transform, false);
                    Destroy(GameObject.Find("Heart")); Destroy(GameObject.Find("Heart(Clone)"));
                }

            }
        }

        //UNSURE IF WORKING
        for (int index = 0; index < 4; index++)
        {
           GameObject.Find("SpawnManager").GetComponent<SpawnManager>().CurrentSpawned[index] = so.currentSpawned[index];
           Debug.Log(GameObject.Find("SpawnManager").GetComponent<SpawnManager>().CurrentSpawned[index]);
        } 

        //UNSURE IF WORKING
        for (int i = 0; i < 4; i++)
        {
           
            //GameObject.Find("SpawnManager").GetComponent<SpawnManager>().triggers[i].GetComponent<Trigger>().enemy = so.Triggers[i];
            GameObject.Find("SpawnManager").GetComponent<SpawnManager>().triggers[i].GetComponent<Trigger>().Empty = so.empty[i];
            //Debug.Log(GameObject.Find("SpawnManager").GetComponent<SpawnManager>().triggers[i].GetComponent<Trigger>().enemy);
        }   

        //Spawing in enemies in their right position
        foreach (Vector2 positions in so.enemies)
            {
                if (positions.x == 0 && positions.y == 0)
                {

                }
                else
                {
                    GameObject.Find("SpawnManager").GetComponent<SpawnManager>().triggers[temp].GetComponent<Trigger>().enemy = Instantiate(PreFab, positions, Quaternion.identity);
                    temp++;
                }                               
            } 
        
        //Turning off all Menus UI and resuming the game
        menus.ResumeGame();
    }

    public void AutoLoad()
    {
        int temp = 0;
        Debug.Log("Trying to auto load");

        //Get the selected file name from the dropdown list and call SaveManager with that name
        SaveManager.fileName = "AutoSave";

        //Checking if the file name is in its full path name or just the end of the file
        for (int i = 0; i < Application.persistentDataPath.Length; i++)
        {
            //Compares the characters of the full path string with the player's string
            if (Application.persistentDataPath[i] != SaveManager.fileName[i])
            {
                NormalLoad = true;
                break;
            }
            else
            {
                NormalLoad = false;
            }
        }
        if (NormalLoad == true)
        {
            so = SaveManager.Load();
        }
        else
        {
            so = SaveManager.MenuLoad();
        }

        //Destror every enemies in the game to refresh the game
        foreach (GameObject emi in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(emi);
        }

        //start the load the save player data into the current player
        GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().health = so.Health;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().numOfHearts = so.AmountOfHearts;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>()._attackSpeed = so.AttackSpeed;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().attackDamage = so.AttackDamage;
        GameObject.FindGameObjectWithTag("Player").transform.position = so.PlayerPosition;

        //Destory all possible items that could be in the game
        temp = 0;
        foreach (GameObject items in GameObject.FindGameObjectsWithTag("PickableItem"))
        {
            Destroy(items);
        }

        //spawn all the items into the game and in the right position
        foreach (string itemName in so.ItemName)
        {
            if (itemName == Candy.name)
            {
                Instantiate(Candy, so.ItemsPositions[temp], Quaternion.identity);
                temp++;
            }
            else if (itemName == Heart.name)
            {
                Instantiate(Heart, so.ItemsPositions[temp], Quaternion.identity);
                temp++;
            }
            else if (itemName == CottonCandy.name)
            {
                Instantiate(CottonCandy, so.ItemsPositions[temp], Quaternion.identity);
                temp++;
            }
            else if (itemName == CandyCane.name)
            {
                Instantiate(CandyCane, so.ItemsPositions[temp], Quaternion.identity);
                temp++;
            }
            else if (itemName == Cherry.name)
            {
                //Instantiate(Cherry, so.ItemsPositions[temp], Quaternion.identity);
                Destroy(Instantiate(Cherry, so.ItemsPositions[temp], Quaternion.identity).GetComponent<CherryWeapon>());
                temp++;
            }
        }

        temp = 0;

        //Foreach item that is save in the players inventory, compare the names and spawn the correct item.
        for (int nums = 0; nums < 11; nums++)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().isFull[nums] = so.ISFull[nums];

            if (GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().slots[nums].transform.childCount == 1)
            {
                //destroying current item inside the inventory slot
                Destroy(GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().slots[nums].transform.GetChild(0).gameObject);
            }

            if (so.slotIndex[nums] != "")
            {
                if (so.slotIndex[nums] == cherryButton.name)
                {
                    Instantiate(cherryButton, GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().slots[nums].transform, false);
                    Destroy(GameObject.Find("Cherry")); Destroy(GameObject.Find("Cherry(Clone)"));
                }
                else if (so.slotIndex[nums] == candyButton.name)
                {
                    Instantiate(candyButton, GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().slots[nums].transform, false);
                    Destroy(GameObject.Find("Candy")); Destroy(GameObject.Find("Candy(Clone)"));
                }
                else if (so.slotIndex[nums] == candyCandButton.name)
                {
                    Instantiate(candyCandButton, GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().slots[nums].transform, false);
                    Destroy(GameObject.Find("Candy cane")); Destroy(GameObject.Find("Candy cane(Clone)"));
                }
                else if (so.slotIndex[nums] == cottonCandyButton.name)
                {
                    Instantiate(cottonCandyButton, GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().slots[nums].transform, false);
                    Destroy(GameObject.Find("cotton candy")); Destroy(GameObject.Find("cotton candy(Clone)"));
                }
                else if (so.slotIndex[nums] == healthButton.name)
                {
                    Instantiate(healthButton, GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().slots[nums].transform, false);
                    Destroy(GameObject.Find("Heart")); Destroy(GameObject.Find("Heart(Clone)"));
                }

            }
        }

        //UNSURE IF WORKING
        for (int index = 0; index < 4; index++)
        {
            GameObject.Find("SpawnManager").GetComponent<SpawnManager>().CurrentSpawned[index] = so.currentSpawned[index];
            Debug.Log(GameObject.Find("SpawnManager").GetComponent<SpawnManager>().CurrentSpawned[index]);
        }

        //UNSURE IF WORKING
        for (int i = 0; i < 4; i++)
        {

            //GameObject.Find("SpawnManager").GetComponent<SpawnManager>().triggers[i].GetComponent<Trigger>().enemy = so.Triggers[i];
            GameObject.Find("SpawnManager").GetComponent<SpawnManager>().triggers[i].GetComponent<Trigger>().Empty = so.empty[i];
            //Debug.Log(GameObject.Find("SpawnManager").GetComponent<SpawnManager>().triggers[i].GetComponent<Trigger>().enemy);
        }

        //Spawing in enemies in their right position
        foreach (Vector2 positions in so.enemies)
        {
            if (positions.x == 0 && positions.y == 0)
            {

            }
            else
            {
                GameObject.Find("SpawnManager").GetComponent<SpawnManager>().triggers[temp].GetComponent<Trigger>().enemy = Instantiate(PreFab, positions, Quaternion.identity);
                temp++;
            }
        }

        //Turning off all Menus UI and resuming the game
        //menus.ResumeGame();
    }

    public void MenuLoad()
    {
        int temp = 0;
        Loading = true;
        Debug.Log("Trying to Menu load");

        //Get the selected file name from the dropdown list and call SaveManager with that name
        //SaveManager.fileName = name.options[name.value].text;

        //Checking if the file name is in its full path name or just the end of the file
        for (int i = 0; i < Application.persistentDataPath.Length; i++)
        {
            //Compares the characters of the full path string with the player's string
            if (Application.persistentDataPath[i] != SaveManager.fileName[i])
            {
                NormalLoad = true;
                break;
            }
            else
            {
                NormalLoad = false;
            }
        }
        if (NormalLoad == true)
        {
            so = SaveManager.Load();
        }
        else
        {
            so = SaveManager.MenuLoad();
        }
        if (so.name == "")
        {
            Application.LoadLevel(Application.loadedLevel);
        }
        else
        {
            //Destror every enemies in the game to refresh the game
            foreach (GameObject emi in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                Destroy(emi);
            }

            //start the load the save player data into the current player
            GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().health = so.Health;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().numOfHearts = so.AmountOfHearts;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>()._attackSpeed = so.AttackSpeed;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().attackDamage = so.AttackDamage;
            GameObject.FindGameObjectWithTag("Player").transform.position = so.PlayerPosition;

            //Destory all possible items that could be in the game
            temp = 0;
            foreach (GameObject items in GameObject.FindGameObjectsWithTag("PickableItem"))
            {
                Destroy(items);
            }

            //spawn all the items into the game and in the right position
            foreach (string itemName in so.ItemName)
            {
                if (itemName == Candy.name)
                {
                    Instantiate(Candy, so.ItemsPositions[temp], Quaternion.identity);
                    temp++;
                }
                else if (itemName == Heart.name)
                {
                    Instantiate(Heart, so.ItemsPositions[temp], Quaternion.identity);
                    temp++;
                }
                else if (itemName == CottonCandy.name)
                {
                    Instantiate(CottonCandy, so.ItemsPositions[temp], Quaternion.identity);
                    temp++;
                }
                else if (itemName == CandyCane.name)
                {
                    Instantiate(CandyCane, so.ItemsPositions[temp], Quaternion.identity);
                    temp++;
                }
                else if (itemName == Cherry.name)
                {
                    //Instantiate(Cherry, so.ItemsPositions[temp], Quaternion.identity);
                    Destroy(Instantiate(Cherry, so.ItemsPositions[temp], Quaternion.identity).GetComponent<CherryWeapon>());
                    temp++;
                }
            }

            temp = 0;

            //Foreach item that is save in the players inventory, compare the names and spawn the correct item.
            for (int nums = 0; nums < 11; nums++)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().isFull[nums] = so.ISFull[nums];

                if (GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().slots[nums].transform.childCount == 1)
                {
                    //destroying current item inside the inventory slot
                    Destroy(GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().slots[nums].transform.GetChild(0).gameObject);
                }

                if (so.slotIndex[nums] != "")
                {
                    if (so.slotIndex[nums] == cherryButton.name)
                    {
                        Instantiate(cherryButton, GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().slots[nums].transform, false);
                        Destroy(GameObject.Find("Cherry")); Destroy(GameObject.Find("Cherry(Clone)"));
                    }
                    else if (so.slotIndex[nums] == candyButton.name)
                    {
                        Instantiate(candyButton, GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().slots[nums].transform, false);
                        Destroy(GameObject.Find("Candy")); Destroy(GameObject.Find("Candy(Clone)"));
                    }
                    else if (so.slotIndex[nums] == candyCandButton.name)
                    {
                        Instantiate(candyCandButton, GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().slots[nums].transform, false);
                        Destroy(GameObject.Find("Candy cane")); Destroy(GameObject.Find("Candy cane(Clone)"));
                    }
                    else if (so.slotIndex[nums] == cottonCandyButton.name)
                    {
                        Instantiate(cottonCandyButton, GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().slots[nums].transform, false);
                        Destroy(GameObject.Find("cotton candy")); Destroy(GameObject.Find("cotton candy(Clone)"));
                    }
                    else if (so.slotIndex[nums] == healthButton.name)
                    {
                        Instantiate(healthButton, GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().slots[nums].transform, false);
                        Destroy(GameObject.Find("Heart")); Destroy(GameObject.Find("Heart(Clone)"));
                    }

                }
            }

            //UNSURE IF WORKING
            for (int index = 0; index < 4; index++)
            {
                GameObject.Find("SpawnManager").GetComponent<SpawnManager>().CurrentSpawned[index] = so.currentSpawned[index];
                Debug.Log(GameObject.Find("SpawnManager").GetComponent<SpawnManager>().CurrentSpawned[index]);
            }

            //UNSURE IF WORKING
            for (int i = 0; i < 4; i++)
            {

                //GameObject.Find("SpawnManager").GetComponent<SpawnManager>().triggers[i].GetComponent<Trigger>().enemy = so.Triggers[i];
                GameObject.Find("SpawnManager").GetComponent<SpawnManager>().triggers[i].GetComponent<Trigger>().Empty = so.empty[i];
                //Debug.Log(GameObject.Find("SpawnManager").GetComponent<SpawnManager>().triggers[i].GetComponent<Trigger>().enemy);
            }

            //Spawing in enemies in their right position
            foreach (Vector2 positions in so.enemies)
            {
                if (positions.x == 0 && positions.y == 0)
                {

                }
                else
                {
                    //GameObject.Find("SpawnManager").GetComponent<SpawnManager>().triggers[temp].GetComponent<Trigger>().enemy = Instantiate(PreFab, positions, Quaternion.identity);
                    GameObject.Find("SpawnManager").GetComponent<SpawnManager>().triggers[temp].GetComponent<Trigger>().enemy = Instantiate(PreFab, positions, Quaternion.identity);
                    //Instantiate(PreFab, positions, Quaternion.identity);
                    temp++;
                }
            }
        }
        Loading = false;
    }
        
}
