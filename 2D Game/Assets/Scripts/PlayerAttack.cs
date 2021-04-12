using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //void OnTriggerEnter2D(Collider2D other)
    //{
        //Debug.Log("test there has been an collision");
        //if ((other.gameObject.tag == "Enemy" || other.gameObject.name == "Enemy"))
        //{
            //other.gameObject.GetComponent<EnemyMove>()._lifePoints -= 1;
        //}
    //}
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public LayerMask whatIsEnemies;

    public Transform attackPos;
    public float attackRange;
    public int damage;

    void Update()
    {
        if(timeBtwAttack <= 0)
        {
            //then you can attack
            if(Input.GetMouseButtonDown(0))
            {
                //camAnim.SetTrigger("shake");
                //playerAnim.SetTrigger("attack");
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for(int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyAI>().TakeDamage(damage);

                }
            }
            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;

        }
        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackPos.position, attackRange);
        }
    }
}
