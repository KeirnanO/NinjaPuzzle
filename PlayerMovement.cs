using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;

    public float movespeed;
    public float jumpForce;
    public float airForce;

    bool ground;

    int direction;

    public int maxJumps;
    int jumps;

    public int startShurikens;
    int shurikens;

    public GameObject shuriken;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        direction = 1;

        shurikens = startShurikens;

        Physics2D.IgnoreLayerCollision(0, 0);   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move(Input.GetAxisRaw("Horizontal"));
    }

    private void Update()
    {
        GetInput();
    }



    private void Move(float movement)
    {
        //Add Force
        rb.velocity = new Vector2(movespeed * movement, rb.velocity.y);


        if(movement > 0 && direction == -1)
        {
            direction = 1;

            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        }
        else if (movement < 0 && direction == 1)
        {
            direction = -1;

            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        }

        animator.SetFloat("speed", Mathf.Abs(movement));

    }

    void GetInput()
    {

        if (Input.GetKeyDown("joystick button 2"))
        {
            if (shurikens > 0)
            {
                Instantiate(shuriken, transform.position, Quaternion.identity);
                shurikens--;
            }
        }

        if (Input.GetKeyDown("joystick button 0"))
        {
            if (ground)
            {
                ground = false;
                StartCoroutine(Jump());
            }
            else if (jumps > 0)
            {
                jumps--;              
                StartCoroutine(AirJump());
            }
        }
    }

    IEnumerator Jump()
    {
        float jumpTime = 0f;

        while (Input.GetKey("joystick button 0"))
        {
            if(jumpTime > 0.3f)
            {
                break;
            }

            rb.velocity = new Vector2(rb.velocity.x, jumpForce * Input.GetAxis("Jump"));

            jumpTime += Time.deltaTime;
            yield return null;
        }
    }

    public IEnumerator AirJump()
    {
        animator.SetTrigger("Jump");
        float jumpTime = 0f;

        do
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce * 1.2f);

            jumpTime += Time.deltaTime;
            yield return null;
        }
        while (jumpTime < 0.1f);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("ground"))
        {
            ground = true;

            jumps = maxJumps;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.transform.tag.Equals("ground"))
        {
            ground = false;
        }
    }

    public int GetDirection()
    {
        return direction;
    }

    public void AddJump()
    {
        jumps++;
    }

    public void AddShuriken()
    {
        shurikens++;
    }

}
