using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class MainMenu : MonoBehaviour
{
    public float _attackSpeed = 2;
    private float nextShootTime = 50f;
    public Dropdown name;
    public PlayerData so;
    Dropdown.OptionData fileOne;

    void Start()
    {
        foreach (string files in System.IO.Directory.GetFiles(Application.persistentDataPath + SaveManager.directory))
        {
            fileOne = new Dropdown.OptionData();
            fileOne.text = Path.GetFileName(files);
            name.options.Add(fileOne);
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    
    public void Load()
    {
        SaveManager.fileName = name.options[name.value].text;
        SaveManager.NeedLoad = true;
        StartGame();      
    }

    public void Delete()
    {
        if(File.Exists(Application.persistentDataPath + SaveManager.directory + name.options[name.value].text))
        {
            Debug.Log("File does exist and now deleting     " + Application.persistentDataPath + SaveManager.directory + name.options[name.value].text);
            File.Delete(Application.persistentDataPath + SaveManager.directory + name.options[name.value].text);
            name.options[name.value].text = "";
            name.options.RemoveAt(name.value);
            
            //if()
        }
        else
        {
            Debug.Log("File does not exist");
        }
    }
}
