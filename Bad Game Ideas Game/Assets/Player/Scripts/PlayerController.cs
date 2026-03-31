
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    [SerializeField] public bool player1;
    [SerializeField] private Animator _animator;
    

    public Groundcheck groundcheck;


    public float speed;
    public float jumpHeight;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player1)
        {
            Control1();
        } else
        {
            Control2();
        }
    }

    public void Control1()
    {
        
        if (Input.GetKey(KeyCode.A))
        {
            Move(-speed);
        } else if (Input.GetKey(KeyCode.D))
        {
            Move(speed);
        } else
        {
            Move(0);
        }
        
        if (Input.GetKey(KeyCode.W))
        {
            Jump(jumpHeight);
        } 

        if (Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.D))
        {
            _animator.SetBool("isrunning", true);
        }
        else
        {
            _animator.SetBool("isrunning", false);
        }

    }
        

    public void Control2()
    {        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Jump(jumpHeight);
            _animator.SetBool("isrunning", true);
        } else if (Input.GetKey(KeyCode.DownArrow))
        {
            Jump(-jumpHeight);
            _animator.SetBool("isrunning", true);
        } else
        {
            _animator.SetBool("isrunning", false);
            Jump(0);
        }
        
        _animator.SetBool("isrunning", true);
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Move(-speed);
            _animator.SetBool("isrunning", true);
        } else if (Input.GetKey(KeyCode.RightArrow))
        {
            Move(speed);
            _animator.SetBool("isrunning", true);
        } else
        {
            Move(0);
            _animator.SetBool("isrunning", false);
        }
    }

    public void Move(float speed)
    {
        rb.velocityX = Mathf.Lerp(rb.velocityX, speed, Time.deltaTime*15);

        if (speed > 0.1)
        {
            sprite.flipX = false;
        } 
        else if (speed < -0.1)
        {
            sprite.flipX = true;
        }
    }

    public void Jump(float jumpHeight)
    {
        if (!player1 || groundcheck.grounded)
        {
            rb.velocityY = jumpHeight;
        }
    }
    
}
