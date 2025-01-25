using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnockback : MonoBehaviour
{
    private Rigidbody2D rb;
    private Enemy1Movement enemyMovement;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyMovement = GetComponent<Enemy1Movement>();
    }

    public void knockback(Transform playerTransform, float knockbackForce, float knockbackTime, float stunTime)
    {
        enemyMovement.changeState(EnemyState.Knockback);
        StartCoroutine(stunTimer(knockbackTime, stunTime));
        Vector2 direction = (transform.position - playerTransform.position).normalized;
        rb.velocity = direction * knockbackForce;
        Debug.Log("Knockback applied");
    }

    IEnumerator stunTimer(float knockbackTime, float stunTime)
    {
        yield return new WaitForSeconds(knockbackTime);
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(stunTime);
        enemyMovement.changeState(EnemyState.Idle);
    }
    
}
