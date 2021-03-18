using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int numOfHearts;
    float temp;
    int temp2;
    int count;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite ThreeFourthHeart;
    public Sprite OneHalfHeart;
    public Sprite OneFourthHeart;
    public Sprite emptyHeart;
    
    void Update()
    {
        if(health > numOfHearts*4)
        {
            health = numOfHearts*4;
        }
        if(health < 0)
        {
            health = 0;
        }
        temp = health % 4;              // value indicates what type of heart is needed
        temp2 = health / 4;            // value indicates how many full hearts
        Debug.Log("temp" + temp);
        Debug.Log("temp2" + temp2);      

        for (int i = 0; i < hearts.Length; i++)
        {               
            if(i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

        if (health > 0)
        {
            for (int i = 0; i < temp2; i++)
            {
                hearts[i].sprite = fullHeart;
            }
            if (temp > 0)
            {
                if (temp == 1)
                {
                    hearts[temp2].sprite = OneFourthHeart;
                }
                if (temp == 2)
                {
                    hearts[temp2].sprite = OneHalfHeart;
                }
                if (temp == 3)
                {
                    hearts[temp2].sprite = ThreeFourthHeart;
                }
            }
            else if (temp2 != numOfHearts)
            {
                for (int i = temp2; i < numOfHearts; i++)
                {
                    hearts[i].sprite = emptyHeart;
                }
            }
        } 
        else if (health == 0)
        {
            hearts[0].sprite = emptyHeart;
        }
    
    }


}
