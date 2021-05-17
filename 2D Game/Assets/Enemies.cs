using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemies : MonoBehaviour
{
    int moveSpeed;
    int attackDamage;
    int lifePoints;
    float attackRadius;
    float attackSpeed;
    int Score;

    void Start()
    {
    }

    //movement
    float followRadius;

    public void setMoveSpeed(int speed)
    {
        moveSpeed = speed;
    }

    public void setAttackDamage(int attdmg)
    {
        attackDamage = attdmg;
    }

    public void setLifePoints(int lp)
    {
        lifePoints = lp;
    }

    public void setAttackSpeed(float attackspeed)
    {
        attackSpeed = attackspeed;
    }

    public int getMoveSpeed()
    {
        return moveSpeed;
    }

    public int getAttackDamage()
    {
        return attackDamage;
    }

    public int getLifePoints()
    {
        return lifePoints;
    }

    public float getAttackSpeed()
    {
        return attackSpeed;
    }


    //movement toward a player
    public void setFollowRadius(float r)
    {
        followRadius = r;
    }
    //attack radius 
    public void setAttackRadius(float r)
    {
        attackRadius = r;
    }

    //if player in radius move toward him 
    public bool checkFollowRadius(float playerPosition, float enemyPosition)
    {
        if (Mathf.Abs(playerPosition - enemyPosition) < followRadius)
        {
            //player in range
            return true;
        }
        else
        {
            return false;
        }
    }

    //if player in radius attack him
    public bool checkAttackRadius(float playerPosition, float enemyPosition)
    {
        if (Mathf.Abs(playerPosition - enemyPosition) < attackRadius)
        {
            //in range for attack
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool checkFollowRadiusY(float playerPosition, float enemyPosition)
    {
        if (Mathf.Abs(playerPosition - enemyPosition) < followRadius)
        {
            //player in range
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool checkAttackRadiusY(float playerPosition, float enemyPosition)
    {
        if (Mathf.Abs(playerPosition - enemyPosition) < attackRadius)
        {
            //in range for attack
            return true;
        }
        else
        {
            return false;
        }
    }
    public void checkHealth(int _health)
    {
        if (_health <= 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().score += 500;
            //GameObject.Find("SpawnManager").GetComponent<SpawnManager>().triggers[spawnIndex].GetComponent<Trigger>().Empty = true;
            Destroy(gameObject);
        }
    }



}

