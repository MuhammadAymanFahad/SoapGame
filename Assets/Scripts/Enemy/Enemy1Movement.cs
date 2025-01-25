using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Movement : MonoBehaviour
{
    public float speed;
    public float attackRange = 2;
    public float attackCooldown;
    public float attackCooldownTimer;
    public float playerDetectRange = 5;
    public Transform detectionPoint;
    public LayerMask playerLayer;

    public Rigidbody2D rb;
    public Transform playerTransform;
    public Animator enemyAnim;
    public int facingDirection = -1;
    public EnemyState enemyState;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyAnim = GetComponent<Animator>();
        changeState(EnemyState.Idle);
    }

    public void Update()
    {
        if(enemyState != EnemyState.Knockback)
        {
            checkForPlayer();
            if (attackCooldownTimer > 0)
            {
                attackCooldownTimer -= Time.deltaTime;
            }
            if (enemyState == EnemyState.Chasing)
            {
                chase();
            }
            else if (enemyState == EnemyState.Attacking)
            {
                rb.velocity = Vector2.zero;
            }
        }
        
    }

    public void chase()
    {
        if (Vector2.Distance(playerTransform.position, playerTransform.position) <= attackRange && attackCooldownTimer <= 0)
        {
            attackCooldownTimer = attackCooldown;
            changeState(EnemyState.Attacking);
        }

        else if (playerTransform.position.x > transform.position.x && facingDirection == -1 || playerTransform.position.x < transform.position.x && facingDirection == 1)
        {
            flip();
        }
        Vector2 direction = (playerTransform.position - transform.position).normalized;
        rb.velocity = direction * speed;
    }

    public void changeState(EnemyState newState)
    {
        //exit anim
        if (enemyState == EnemyState.Idle)
            enemyAnim.SetBool("isIdle", false);
        if (enemyState == EnemyState.Chasing)
            enemyAnim.SetBool("isChasing", false);
        if (enemyState == EnemyState.Attacking)
            enemyAnim.SetBool("isAttacking", false);

        enemyState = newState;

        //enter anim
        if (enemyState == EnemyState.Idle)
            enemyAnim.SetBool("isIdle", true);
        if (enemyState == EnemyState.Chasing)
            enemyAnim.SetBool("isChasing", true);
        if (enemyState == EnemyState.Attacking)
            enemyAnim.SetBool("isAttacking", true);
    }


    public void flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    public void checkForPlayer()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(detectionPoint.position, playerDetectRange, playerLayer);
        if(hits.Length > 0)
        {
            playerTransform = hits[0].transform;
            if (Vector2.Distance(transform.position, playerTransform.position) <= attackRange && attackCooldownTimer <= 0)
            {
                attackCooldownTimer = attackCooldown;
                changeState(EnemyState.Attacking);
            }
            else if(Vector2.Distance(transform.position, playerTransform.position) > attackRange && enemyState != EnemyState.Attacking) 
            {
                changeState(EnemyState.Chasing);
            }
            //changeState(EnemyState.Chasing);
        }
        else
        {
            rb.velocity = Vector2.zero;
            changeState(EnemyState.Idle);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(detectionPoint.position, playerDetectRange);
    }
}

public enum EnemyState
{
    Idle, Chasing, Attacking, Knockback, 
}
