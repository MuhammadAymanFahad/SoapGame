using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Movement : EnemyMovement
{
    private EnemyState enemyState;

    public override void Start()
    {
        changeState(EnemyState.Idle);
        enemyRigidBody = GetComponent<Rigidbody2D>();
        enemyAnim = GetComponent<Animator>();
    }

    void changeState(EnemyState newState)
    {
        //exit anim
        if (enemyState == EnemyState.Idle)
            enemyAnim.SetBool("isIdle", false);
        if (enemyState == EnemyState.Chasing)
            enemyAnim.SetBool("isChasing", false);

        enemyState = newState;

        //enter anim
        if(enemyState == EnemyState.Idle)
            enemyAnim.SetBool("isIdle", true);
        if (enemyState == EnemyState.Chasing)
            enemyAnim.SetBool("isChasing", true);
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (playerTransform == null)
            {
                playerTransform = other.transform;
            }
            isChasing = true;
            changeState(EnemyState.Chasing);
        }
    }

    public override void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            enemyRigidBody.velocity = Vector2.zero;
            isChasing = false;
            changeState(EnemyState.Idle);
        }
    }
}

public enum EnemyState
{
    Idle, Chasing, 
}
