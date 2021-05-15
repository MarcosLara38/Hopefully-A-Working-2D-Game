using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public float runSpeed = 1f;
    public float jumpForce = 1f;

    private Rigidbody2D rBody;



    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        var move = Input.GetAxis("Horizontal");
        transform.position = transform.position + new Vector3(move * runSpeed * Time.deltaTime, 0, 0);

    }

}