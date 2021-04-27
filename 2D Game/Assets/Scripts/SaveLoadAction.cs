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
    private int AmountOfHearts;
    private int Health;
    private float AttackSpeed;
    private int AttackDamage;
    private GameObject[] Enemies;
    private GameObject[] Items;
    public GameObject PreFab;
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
        for(int index = 0; index <= 3; index++)
        {
            so.currentSpawned[index] = GameObject.Find("SpawnManager").GetComponent<SpawnManager>().CurrentSpawned[index];
        }
    
        for (int i = 0; i < 4; i++)
        {
            so.Triggers[i] = GameObject.Find("SpawnManager").GetComponent<SpawnManager>().triggers[i].GetComponent<Trigger>().enemy;
            so.empty[i] = GameObject.Find("SpawnManager").GetComponent<SpawnManager>().triggers[i].GetComponent<Trigger>().Empty;
        }
       
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Debug.Log("Enemies left are " + Enemies.Length);
        foreach (GameObject enemy in Enemies)
        {
            if(temp == MaxEnemiesOnSave)
            {
            }
            else
            {
                so.enemies[temp] = enemy.transform.position;
                Debug.Log(enemy.gameObject.transform.position);
                Debug.Log(enemy);
                temp++;
            }
        }

        so.name = FileName.text;
              
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

    public void Load()
    {
        int temp = 0;
        Debug.Log("Trying to load");
        SaveManager.fileName = name.options[name.value].text;
        for (int i = 0; i < Application.persistentDataPath.Length; i++)
        {
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
        foreach(GameObject emi in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(emi);
        }

        GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().health = so.Health;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().numOfHearts = so.AmountOfHearts;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>()._attackSpeed = so.AttackSpeed;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().attackDamage = so.AttackDamage;
        GameObject.FindGameObjectWithTag("Player").transform.position = so.PlayerPosition;
        for (int index = 0; index < 4; index++)
        {
           GameObject.Find("SpawnManager").GetComponent<SpawnManager>().CurrentSpawned[index] = so.currentSpawned[index];
           Debug.Log(GameObject.Find("SpawnManager").GetComponent<SpawnManager>().CurrentSpawned[index]);
        } 
        for (int i = 0; i < 4; i++)
        {
           
            //GameObject.Find("SpawnManager").GetComponent<SpawnManager>().triggers[i].GetComponent<Trigger>().enemy = so.Triggers[i];
            GameObject.Find("SpawnManager").GetComponent<SpawnManager>().triggers[i].GetComponent<Trigger>().Empty = so.empty[i];
            //Debug.Log(GameObject.Find("SpawnManager").GetComponent<SpawnManager>().triggers[i].GetComponent<Trigger>().enemy);
        }   
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
        menus.ResumeGame();
    }

    public void MenuLoad()
    {
        int temp = 0;
        Debug.Log("Trying to Menu load");

        for (int i = 0; i < Application.persistentDataPath.Length; i++)
        {
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
        foreach (GameObject emi in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(emi);
        }

        GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().health = so.Health;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().numOfHearts = so.AmountOfHearts;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>()._attackSpeed = so.AttackSpeed;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().attackDamage = so.AttackDamage;
        GameObject.FindGameObjectWithTag("Player").transform.position = so.PlayerPosition;
        for (int index = 0; index < 4; index++)
        {           
            GameObject.Find("SpawnManager").GetComponent<SpawnManager>().CurrentSpawned[index] = so.currentSpawned[index];
            Debug.Log(GameObject.Find("SpawnManager").GetComponent<SpawnManager>().CurrentSpawned[index]);
        }
        for (int i = 0; i < 4; i++)
        {
            //Debug.Log(GameObject.Find("SpawnManager").GetComponent<SpawnManager>().triggers[i].GetComponent<Trigger>().Empty);
            //GameObject.Find("SpawnManager").GetComponent<SpawnManager>().triggers[i].GetComponent<Trigger>().enemy = so.Triggers[i];
            //GameObject.Find("SpawnManager").GetComponent<SpawnManager>().triggers[i].GetComponent<Trigger>().Empty = so.empty[i];

        }
        foreach (Vector2 positions in so.enemies)
        {
            Debug.Log("Spawnning an Enemy" + positions);
            if (positions.x == 0 && positions.y == 0)
            {

            }
            else
            {
                Instantiate(PreFab, positions, Quaternion.identity);
                //GameObject.Find("SpawnManager").GetComponent<SpawnManager>().triggers[temp].GetComponent<Trigger>().enemy = Instantiate(PreFab, positions, Quaternion.identity);
                //GameObject.Find("SpawnManager").GetComponent<SpawnManager>().spawnEnemys();
                temp++;
            }
        }

    }
}
