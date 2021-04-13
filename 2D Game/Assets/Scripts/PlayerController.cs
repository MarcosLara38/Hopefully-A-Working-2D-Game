using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MovementSpeed = 1f;
    public float Running = 1f;
    public float _attackSpeed;
    private float nextShootTime = 0f;
    public float Range;
    public int attackDamage;
    public bool WeaponType = false;
    float movement;
    bool jump = false;
    bool groundCheck = true;
    bool attacking = false;
    bool m_FacingRight = false;
    bool lookingUP = false;
    bool lookingDown = false;
    public float JumpForce = 1f;
    public Rigidbody2D rigidbody;
    public Animator animator;
    public Health myPlayer;
    public Scores myScores;
    public CapsuleCollider2D Capsule;
    public PlayerAttack player;

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(movement));
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rigidbody.velocity.y) < 0.001f)
        {
            jump = true;
            groundCheck = false;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            lookingUP = true;
            //Debug.Log("Running");
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            lookingUP = false;
            // Debug.Log("Stop Running");
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            lookingDown = true;
            //Debug.Log("Running");
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            lookingDown = false;
            // Debug.Log("Stop Running");
        }
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.P))
        {
            if (WeaponType == false)
            {
                if (Time.time > nextShootTime)
                {
                    attacking = true;

                    if (m_FacingRight && lookingUP == false && lookingDown == false)
                    {
                        player.AttackWithCircle(attackDamage, Range, 1, 0);
                    }
                    else if (m_FacingRight == false && lookingUP == false && lookingDown == false)
                    {
                        player.AttackWithCircle(attackDamage, Range, -1, 0);
                    }

                    if (lookingDown)
                    {
                        player.AttackWithCircle(attackDamage, Range, 0, -1.5f);
                    }

                    if (lookingUP)
                    {
                        player.AttackWithCircle(attackDamage, Range, 0, 1.5f);
                    }
                    nextShootTime = Time.time + _attackSpeed;
                }
            }
            else
            {
                if (Time.time > nextShootTime)
                {
                    attacking = true;

                    if (m_FacingRight && lookingUP == false && lookingDown == false)
                    {
                        player.Attack(attackDamage, Range, 1, 0);
                    }
                    else if (m_FacingRight == false && lookingUP == false && lookingDown == false)
                    {
                        player.Attack(attackDamage, Range, -1, 0);
                    }

                    if (lookingDown)
                    {
                        player.Attack(attackDamage, Range, 0, -1);
                    }

                    if (lookingUP)
                    {
                        player.Attack(attackDamage, Range, 0, 1);
                    }
                    nextShootTime = Time.time + _attackSpeed;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Running = 2f;
            //Debug.Log("Running");
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Running = 1f;
            // Debug.Log("Stop Running");
        }

        /*if (Input.GetKeyDown(KeyCode.F))
        {
            myPlayer.health--;
            //Debug.Log("Lose Health");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            myPlayer.health++;
            //Debug.Log("Gain Health");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            myPlayer.numOfHearts++;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            myPlayer.numOfHearts--;
        }
        */
        if (movement < 0)
        {
            m_FacingRight = false;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else if (movement > 0)
        {
            m_FacingRight = true;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

    }

    void FixedUpdate()
    {
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed * Running;

        if (jump == true)
        {
            rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            jump = false;
            groundCheck = true;
        }

        if (attacking)
        {
            animator.SetBool("IsAttacking", true);
            attacking = false;

        }
        else if (attacking == false)
        {
            if (Time.time > nextShootTime)
            {
                animator.SetBool("IsAttacking", false);
                //circle.offset = new Vector2(.3f, .23f);
                //Capsule.enabled = false;
            }
        }
    }
}
