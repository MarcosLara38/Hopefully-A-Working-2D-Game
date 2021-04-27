using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Vector2 direction;

    public void Attack(int _damage, float _range, float Xdir, float Ydir)
    {
        direction = new Vector2(Xdir, Ydir);

        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
        RaycastHit2D hit = Physics2D.Raycast(this.gameObject.transform.position, direction);
        Debug.DrawRay(this.gameObject.transform.position, direction * _range, Color.green);
        if (hit.distance <= _range)
        {
            if (hit.collider != null)
            {
                //Debug.Log("test:" + hit.collider.gameObject.name);
                if (hit.transform.gameObject.tag == "Enemy" || hit.transform.gameObject.tag == "flying enemy")
                {
                    hit.transform.gameObject.GetComponent<EnemyMove>()._lifePoints -= _damage;
                }
            }
        }
        this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        this.gameObject.GetComponent<CircleCollider2D>().enabled = true;

    }

    public void AttackWithCircle(int _damage, float _range, float Xdir, float Ydir)
    {
        Vector2 playerPosition = new Vector2(this.transform.position.x + Xdir, this.transform.position.y + Ydir);
        float radius = .75f;
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(playerPosition, _range);

        if (hitColliders != null)
        {
            foreach (var hitCollider in hitColliders)
            {
                //Debug.Log("Circle cast is hitting: " + hitCollider.gameObject.name);
                if (hitCollider.transform.gameObject.tag == "Enemy" || hitCollider.transform.gameObject.tag == "flying enemy")
                {
                    hitCollider.transform.gameObject.GetComponent<EnemyMove>()._lifePoints -= _damage;
                    Debug.Log("circle is hitting enemy");
                }

            }
        }
    }
}
