using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    // Player attributes
    public float moveSpeed;


    public Animator animator;

    //Point of reference for attack
    public Transform attackPoint;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (gameObject.GetComponent<PlayerAttributes>() != null)
        {
            moveSpeed = gameObject.GetComponent<PlayerAttributes>().moveSpeed;
        }
        else {
            moveSpeed = 300.0f;
        }
    }


    void FixedUpdate()
    {   
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
       
        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);

        //Plays walk animation and updates attack point based on direction of movement and input
        if (rb.velocity.y > 1 && vertical > 0)
        {
            attackPoint.position = new Vector2(rb.transform.position.x, rb.position.y + 0.5f);
            animator.Play("player_walk_U");
        }
        else if (rb.velocity.y < -0.1 && rb.velocity.x > -1 && rb.velocity.x < 1 && vertical < 0) {
            attackPoint.position = new Vector2(rb.transform.position.x, rb.position.y - 0.5f);
            animator.Play("player_walk_D");
        }
        else if (rb.velocity.x < -0.1 && horizontal < 0)
        {
            attackPoint.position = new Vector2(rb.transform.position.x - 0.5f, rb.position.y);
            animator.Play("player_walk_L");
        }
        else if (rb.velocity.x > 0.1 && horizontal > 0)
        {
            attackPoint.position = new Vector2(rb.transform.position.x + 0.5f, rb.position.y);
            animator.Play("player_walk_R");
        }
        
        if (horizontal != 0 && vertical != 0)
        {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        //rb.velocity = new Vector2(horizontal * moveSpeed * Time.fixedDeltaTime * 5, vertical * moveSpeed * Time.fixedDeltaTime * 5);
        rb.AddForce(new Vector2(horizontal * moveSpeed * Time.fixedDeltaTime * 6, vertical * moveSpeed * Time.fixedDeltaTime * 6));
    }


    /*
        Boosts MoveSpeed by a Percentage
        Does not let MoveSpeed become greater than a max value
    */
    public float boostMoveSpeedByPercent(float percent) {

        float max = 700.00f;

        float increase = moveSpeed * percent;
        if (moveSpeed + increase > max) {
            moveSpeed = max;
        }
        else {
            moveSpeed += increase;
        }
        return moveSpeed;
    }

    /*
        Drops MoveSpeed by a Percentage
        Returns False if the MoveSpeed was not dropped due to it already being too low
        Returns True if the MoveSpeed was dropped
    */
    public bool dropMoveSpeedByPercent(float percent) {

        float min = 1.0f;

        if ( Math.Abs(moveSpeed - min) <= 0.01 ) {
            return false;
        }
        
        float decrease = moveSpeed * percent;

        if (moveSpeed - decrease < min) {
            moveSpeed = min;
            return true;
        }
        else {
            moveSpeed -= decrease;
            return true;
        }

    }
    
}