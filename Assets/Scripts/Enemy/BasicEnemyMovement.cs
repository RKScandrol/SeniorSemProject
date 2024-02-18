using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BasicEnemyMovement : MonoBehaviour
{
    
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float threatRange;
    [SerializeField]
    GameObject player;

    private float distance;
    private Rigidbody2D rb;
    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance <= threatRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
            animator.SetFloat("Horizontal", rb.velocity.x);
        }
    }
}
