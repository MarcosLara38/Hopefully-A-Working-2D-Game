using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        float score = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().score;
        if (score == 3000)
        {
            SceneManager.LoadScene(2);
        }
    }
}
