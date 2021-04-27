using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("test there has been an collision");
        if ((other.gameObject.tag == "Enemy" || other.gameObject.name == "Enemy"))
        {
            other.gameObject.GetComponent<EnemyMove>()._lifePoints -= 1;
        }
    }
}
