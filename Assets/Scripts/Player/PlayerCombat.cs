using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    [SerializeField]
    public float attackRange;
    public float knockbackForce;
    Rigidbody2D player;
    public int attackDamage;
    public LayerMask enemyLayer;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    void Attack() {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            Vector2 direction = (enemy.transform.position - attackPoint.transform.position).normalized;
            enemy.attachedRigidbody.AddForce(direction * knockbackForce);
            enemy.gameObject.GetComponent<EnemyAttributes>().takeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
