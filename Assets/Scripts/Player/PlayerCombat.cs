using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    [SerializeField]
    public float attackRange;
    public float knockbackForce;
    public Rigidbody2D player;
    public int attackDamage;
    public LayerMask enemyLayer;
    private bool isAttacking = false;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isAttacking)
        {
            Attack();
        }
    }

    void Attack() {
        StartCoroutine(freezeMovement());
        
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            Vector2 direction = (enemy.transform.position - attackPoint.transform.position).normalized;
            enemy.attachedRigidbody.AddForce(direction * knockbackForce);
            enemy.gameObject.GetComponent<EnemyAttributes>().takeDamage(attackDamage);
        }
    }

    IEnumerator freezeMovement() {
        isAttacking = true;
        player.constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitForSeconds(0.3f);
        isAttacking = false;
        player.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
