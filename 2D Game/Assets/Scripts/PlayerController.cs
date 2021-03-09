using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MovementSpeed = 1f;                
    float movement;     
    bool jump = false;
    bool groundCheck = true;
    bool attacking = false;
    public float JumpForce = 1f;
    public Rigidbody2D rigidbody;
    public Animator animator;

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
        if (Input.GetMouseButtonDown(0))
        {
            attacking = true;
            Debug.Log("Attack");
        }
    }

    void FixedUpdate()
    {
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;
        if(jump == true)
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
            animator.SetBool("IsAttacking", false);
        }
    }

   
}
