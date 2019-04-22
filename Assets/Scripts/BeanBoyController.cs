using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanBoyController : MonoBehaviour
{

    [HideInInspector]
    public bool facingRight = true;
    [HideInInspector]
    public bool jump = false;

    public float moveForce = 365f;

    public float maxSpeed = 5f;

    public float jumpForce = 1000f;

    public Transform groundCheck;

    private bool grounded = false;
    private Animator anim;
    private Rigidbody2D rigidbody2D;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1
            << LayerMask.NameToLayer("Ground"));


        if (Input.GetButtonDown("Jump") == true && grounded == true)
        {
            jump = true;

        }
    }




    private void FixedUpdate()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(horizontalAxis));

        if (horizontalAxis * rigidbody2D.velocity.x < maxSpeed)
        {
            rigidbody2D.AddForce(Vector2.right * horizontalAxis * moveForce);

        }

        if (Mathf.Abs(rigidbody2D.velocity.x) > maxSpeed)
        {
            rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);

        }

        if (horizontalAxis > 0 && !facingRight == true)
        {
            Flip();

        }

        else if (horizontalAxis < 0 && facingRight == true)
        {
            Flip();
        }

        if (jump == true)
        {
            anim.SetTrigger("Jump");

            rigidbody2D.AddForce(new Vector2(0f, jumpForce));

            jump = false;
        }



    }   
    
    private void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;

        theScale.x *= -1;

        transform.localScale = theScale;
    }

}