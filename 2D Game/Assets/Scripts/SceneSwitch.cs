using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
        //float score = GetComponent<Inventory>().score;
        //if (score == 1000)
        //{
            //name = "Credits";
            //SceneManager.LoadScene(name);
        //}
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
