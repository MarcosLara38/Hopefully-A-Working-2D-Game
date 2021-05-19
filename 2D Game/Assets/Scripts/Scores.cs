using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Scores : MonoBehaviour
{
    public Text thisText;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        thisText = GetComponent<Text>();

        //score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            score += 500;
        }
        //thisText.text = "Score is " + score;

    }
}
