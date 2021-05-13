using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyMove : Enemies
{
    //variables
    public int _moveSpeed;
    public int _attackDamage;
    public int _lifePoints;
    public float _attackRadius;
    public float _attackSpeed;
    private float nextShootTime = 0f;
    public int currentLifePoints;
    public Rigidbody2D rig;
    public Vector2 moveDirection;
    //movement
    public float _followRadius;
    //end
    [SerializeField] Transform playerTransform;
    [SerializeField] Animator enemyAnim;
    SpriteRenderer enemySR;
    public Health PlayerHealth;
    public PlayerController PlayerData;
    public GameObject PreFab;
    private GameObject text;

    void Start()
    {
        //get the player transform   
        playerTransform = GameObject.FindWithTag("Player").transform;
        PlayerData = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        PlayerHealth = GameObject.FindWithTag("Player").GetComponent<Health>();
        //enemy animation and sprite renderer 
        enemyAnim = gameObject.GetComponent<Animator>();
        enemySR = GetComponent<SpriteRenderer>();
        //set the variables
        setMoveSpeed(_moveSpeed);
        setAttackDamage(_attackDamage);
        setLifePoints(_lifePoints);
        setAttackRadius(_attackRadius);
        setFollowRadius(_followRadius);
        currentLifePoints = _lifePoints;
    }

    //When out of range stop moving

    // Update is called once per frame
    void Update()
    {

        //Debug.Log("lifepoints" + _lifePoints);
        if(_lifePoints != currentLifePoints)
        {
            Debug.Log("if");
            if(enemySR.flipX == true)
            {
                text = Instantiate(PreFab);
                text.transform.SetParent(transform);
                text.transform.localPosition = new Vector2(0f, 2f);
                text.transform.GetChild(0).GetComponent<TextMeshPro>().SetText(PlayerData.attackDamage + " Damage");
                moveDirection = transform.position - playerTransform.transform.position;
                rig.AddForce(moveDirection.normalized * 325f); 
                checkHealth(_lifePoints);
            }
            else
            {
                text = Instantiate(PreFab);
                text.transform.SetParent(transform);
                text.transform.localPosition = new Vector2(0f, 2f);
                text.transform.GetChild(0).GetComponent<TextMeshPro>().SetText(PlayerData.attackDamage + " Damage");
                moveDirection = transform.position - playerTransform.transform.position;
                rig.AddForce(moveDirection.normalized * 325f);
                checkHealth(_lifePoints);
            }
            //FindObjectOfType<AudioManager>().Play("PlayerDeath");
            currentLifePoints = _lifePoints;

        }
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
                        PlayerHealth.health -= getAttackDamage();
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
                        PlayerHealth.health -= getAttackDamage();
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
