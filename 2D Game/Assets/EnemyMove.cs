using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : Enemies
{
    //variables
    public int _moveSpeed;
    public int _attackDamage;
    public int _lifePoints;
    public float _attackRadius;
    public float _attackSpeed;
    private float nextShootTime = 0f;

    //movement
    public float _followRadius;
    //end
    [SerializeField] Transform playerTransform;
    [SerializeField] Animator enemyAnim;
    SpriteRenderer enemySR;
    public Health myPlayer;

    void Start()
    {
        //get the player transform   
        playerTransform = GameObject.FindWithTag("Player").transform;
        //enemy animation and sprite renderer 
        enemyAnim = gameObject.GetComponent<Animator>();
        enemySR = GetComponent<SpriteRenderer>();
        //set the variables
        setMoveSpeed(_moveSpeed);
        setAttackDamage(_attackDamage);
        setLifePoints(_lifePoints);
        setAttackRadius(_attackRadius);
        setFollowRadius(_followRadius);
    }

    //When out of range stop moving

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("lifepoints" + _lifePoints);
        checkHealth(_lifePoints);

        if (checkFollowRadius(playerTransform.position.x, transform.position.x))
        {
            //if player in front of the enemies
            if (playerTransform.position.x < transform.position.x)
            {

                if (checkAttackRadius(playerTransform.position.x, transform.position.x) && checkAttackRadiusY(playerTransform.position.y, transform.position.y))
                {
                    if (Time.time > nextShootTime)
                    {
                        //for attack animation
                        enemyAnim.SetBool("AttackA", true);
                        myPlayer.health -= getAttackDamage();
                        nextShootTime = Time.time + _attackSpeed;
                    }
                }
                else
                {
                    this.transform.position += new Vector3(-getMoveSpeed() * Time.deltaTime, 0f, 0f);

                    if (this.tag == "flying enemy")
                    {
                        if (playerTransform.position.y > this.transform.position.y)
                        {
                            this.transform.position += new Vector3(0f, getMoveSpeed() * Time.deltaTime, 0f);
                        }
                        else if (playerTransform.position.y < this.transform.position.y)
                        {
                            this.transform.position += new Vector3(0f, -getMoveSpeed() * Time.deltaTime, 0f);
                        }
                    }

                    //for attack animation
                    enemyAnim.SetBool("AttackA", false);
                    //walk
                    enemyAnim.SetBool("Walking", true);
                    enemySR.flipX = true;
                }

            }
            //if player is behind enemies
            else if (playerTransform.position.x > transform.position.x)
            {
                if (checkAttackRadius(playerTransform.position.x, transform.position.x) && checkAttackRadiusY(playerTransform.position.y, transform.position.y))
                {
                    if (Time.time > nextShootTime)
                    {
                        //for attack animation
                        enemyAnim.SetBool("AttackA", true);
                        myPlayer.health -= getAttackDamage();
                        nextShootTime = Time.time + _attackSpeed;
                    }
                }
                else
                {
                    this.transform.position += new Vector3(getMoveSpeed() * Time.deltaTime, 0f, 0f);
                    if (this.tag == "flying enemy")
                    {
                        if (playerTransform.position.y > this.transform.position.y)
                        {
                            this.transform.position += new Vector3(0f, getMoveSpeed() * Time.deltaTime, 0f);
                        }
                        else if (playerTransform.position.y < this.transform.position.y)
                        {
                            this.transform.position += new Vector3(0f, -getMoveSpeed() * Time.deltaTime, 0f);
                        }
                    }

                    //for attack animation
                    enemyAnim.SetBool("AttackA", false);
                    //walk
                    enemyAnim.SetBool("Walking", true);
                    enemySR.flipX = false;
                }


            }
        }
        else
        {
            enemyAnim.SetBool("Walking", false);
        }


    }
}
