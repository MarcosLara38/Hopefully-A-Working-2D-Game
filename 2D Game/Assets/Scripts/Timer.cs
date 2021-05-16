using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 300;
    public bool timerIsRunning = false;

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("AutoSaving!");
                GameObject.FindGameObjectWithTag("Player").GetComponent<SaveLoadAction>().AutoSave();
                timeRemaining = 300;
                //timerIsRunning = false;
            }
        }
    }
}
