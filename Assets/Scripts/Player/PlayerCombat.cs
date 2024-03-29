using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange;
    public float knockbackForce;
    public Rigidbody2D player;
    public int attackDamage;
    public LayerMask enemyLayer;
    private bool isAttacking = false;
    public float attackStartup;
    public float attackDuration;
    public Animator animator;
    
    void Start()
    {
        animator.SetFloat("AtkStartSpeed", 1/attackStartup);
        animator.SetFloat("AtkActiveSpeed", 1/attackDuration);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isAttacking)
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack() {
        //Sets status of player to currently attacking, freezes movement, plays animation
        isAttacking = true;
        player.constraints = RigidbodyConstraints2D.FreezeAll;
        animator.SetTrigger("Attacking");
        yield return new WaitForSeconds(attackStartup);

        //After attack startup, damage and knockback applied to enemies within range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            Vector2 direction = (enemy.transform.position - attackPoint.transform.position).normalized;
            enemy.attachedRigidbody.AddForce(direction * knockbackForce);
            enemy.gameObject.GetComponent<EnemyAttributes>().takeDamage(attackDamage);
        }

        //Waits for attack duration to complete
        yield return new WaitForSeconds(attackDuration);

        //Frees player movement, ends attack animation, resets attacking status
        player.constraints = RigidbodyConstraints2D.FreezeRotation;
        animator.ResetTrigger("Attacking");
        isAttacking = false;
    }

    void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
