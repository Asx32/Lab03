using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float xSpeed = 3.0f;
    public float ySpeed = 4.0f;
    private float hDir;
    private float vDir;
    private Rigidbody2D rb;
    private bool isJumping = false;
    private bool doJump = false;
    private bool isClimbing = false;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        hDir = Input.GetAxisRaw("Horizontal");
        vDir = Input.GetAxisRaw("Vertical");
        //transform.position += new Vector3(1, 0, 0) * Time.deltaTime * Speed *hDir;
        if(Input.GetButtonDown("Jump"))
        {
            doJump = true;
        }

        animator.SetBool("Running",(hDir!=0)&&(!isJumping));
        animator.SetBool("Crouching",(vDir<0)&&(!isJumping));
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(hDir *xSpeed, rb.velocity.y);
        if(isClimbing)
            rb.velocity = new Vector2(rb.velocity.x, vDir*ySpeed);
        if(doJump)
        {
            if(!isJumping)
            {
                rb.AddForce(Vector2.up * ySpeed, ForceMode2D.Impulse);
                isJumping = true;
            }
            doJump = false;
        }
        if(rb.velocity.y == 0) isJumping = false;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Ladder")
        {
            isClimbing = true;
            rb.gravityScale = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Ladder")
        {
            isClimbing = false;
            rb.gravityScale = 1;
        }
    }
}
