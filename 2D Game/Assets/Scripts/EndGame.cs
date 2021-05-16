using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;
//using TMPro;

public class EndGame : MonoBehaviour
{
    //public Text target;
    //private GameObject text;
    void OnTriggerEnter2D(Collider2D other)
    {
        float score = GetComponent<Inventory>().score;
        if (score == 5000)
        {
            //text.transform.GetChild(0).GetComponent<TextMeshPro>().SetText("You've Won. Game is Ending");
            SceneManager.LoadScene(2);
        }
        //SceneManager.LoadScene(2);
    }
}
