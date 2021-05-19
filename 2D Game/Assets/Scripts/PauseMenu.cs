using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuUI;
    public GameObject OptionMenuUI;
    public GameObject SaveMenuUI;
    public GameObject LoadMenuUI;
    public bool GameIsPaused = false;
    public bool InsideOfInventory = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        PauseMenuUI.SetActive(true);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().enabled = false;
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void ResumeGame()
    {       
        PauseMenuUI.SetActive(false);
        OptionMenuUI.SetActive(false);
        SaveMenuUI.SetActive(false);
        LoadMenuUI.SetActive(false);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().enabled = true;
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void MainMenu()
    {
        PauseMenuUI.SetActive(false);
        OptionMenuUI.SetActive(false);
        SaveMenuUI.SetActive(false);
        LoadMenuUI.SetActive(false);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().enabled = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

   
}
