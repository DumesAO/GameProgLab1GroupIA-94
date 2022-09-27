using System.Collections.Generic;
using System.Threading;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public float speed = 20f;
    public float jump = 10f;
    private Rigidbody2D rb;
    private float moveX;
    private float moveY;
    private bool isOnGround;
    private bool isLeftWall;
    private bool isRightWall;
    public Transform player;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
   
    void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        if (moveX>0 && isRightWall)
        {
            moveX = 0;
        }
        if (moveX < 0 && isLeftWall)
        {
            moveX = 0;
        }
        Debug.Log(moveX);
        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            isOnGround = false;
            rb.velocity = new Vector2(rb.velocity.x, jump);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveX * speed * Time.deltaTime, rb.velocity.y);
        GroundCheck();
        RightWallCheck();
        LeftWallCheck();
    }

    private void GroundCheck()
    {
        isOnGround = Physics2D.OverlapBox(new Vector2(player.position.x,player.position.y-1),new Vector2(0.1f,0.1f),0);
    }

    private void RightWallCheck()
    {
        isRightWall = Physics2D.OverlapBox(new Vector2(player.position.x+0.5f, player.position.y), new Vector2(0.01f, 0.01f), 0);
    }
    private void LeftWallCheck()
    {
        isLeftWall = Physics2D.OverlapBox(new Vector2(player.position.x - 0.5f, player.position.y), new Vector2(0.01f, 0.01f), 0);
    }

}
