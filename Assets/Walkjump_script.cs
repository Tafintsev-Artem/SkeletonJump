using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Walkjump_script : MonoBehaviour
{
    public float walkSpeed;
    public float jumpforce;
    public Rigidbody2D rigitbody;
    public Animator anim;
    private bool isGrounded;
    public LayerMask groundMask;
    private float jumpTimer;
    public float statTime;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigitbody = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame

    void Update()
    {
        var delta = new Vector2(x: Input.GetAxis("Horizontal"), y: Input.GetAxis("Vertical"));
        rigitbody.MovePosition(rigitbody.position + new Vector2(delta.x, 0) * walkSpeed * Time.deltaTime);
        //CheckGround();
        if (delta.y > 0 && (jumpTimer > 0))
        {
            /*rigitbody.MovePosition(rigitbody.position + new Vector2(0, 1) * jumpforce * Time.deltaTime);*/
            rigitbody.AddForce(transform.up  * jumpforce);
            jumpTimer -= Time.deltaTime;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            //isGrounded = true;
            jumpTimer = statTime;
        }
        if (collision.collider.CompareTag("Death"))
        {
            //isGrounded = true;
            Destroy(gameObject, .5f);
        }
        if (collision.collider.CompareTag("Finish"))
        {
            //isGrounded = true;
            Time.timeScale = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            //isGrounded = false;
        }
    }

    /*
    private void CheckGround()
    {
        float rayLength = 10f;
        Vector3 rayStartPosition = transform.position;
        RaycastHit2D hit = Physics2D.Raycast(rayStartPosition, rayStartPosition + Vector3.down, rayLength, groundMask);
        Debug.DrawRay(rayStartPosition, rayStartPosition + Vector3.down, Color.red);
        if (hit.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }*/
}
