using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    #region variables
    Rigidbody2D rb;
    public float speed, jump;
    public LayerMask canJumpMask;
    public Transform jumpController;

    #endregion

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Jump();
        
    }
    private void FixedUpdate()
    {
        Movement();
    }

    public float h = 0;
    void Movement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            h = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            h = -1;
        }
        else
        {
            h = 0;
        }

        rb.velocity = new Vector2(h * speed * Time.deltaTime, rb.velocity.y);

        //Scale
        if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector2(1, 1);
        }
         
        if(rb.velocity.x < 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
      
    }

    bool _canjump;
    void Jump()
    {
         _canjump = Physics2D.OverlapCircle(jumpController.position, .1f, canJumpMask);

        if (Input.GetButtonDown("Jump") && _canjump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
          
        }

        
    }



  












}
