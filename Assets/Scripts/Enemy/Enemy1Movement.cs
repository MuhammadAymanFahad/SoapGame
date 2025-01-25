using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Movement : MonoBehaviour
{
    public float speed;
    public Rigidbody2D enemyRigidBody;
    public Transform playerTransform;
    public Animator enemyAnim;
    public int facingDirection = -1;
    private EnemyState enemyState;

    public void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody2D>();
        enemyAnim = GetComponent<Animator>();
        changeState(EnemyState.Idle);
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
        if (enemyState == EnemyState.Idle)
            enemyAnim.SetBool("isIdle", true);
        if (enemyState == EnemyState.Chasing)
            enemyAnim.SetBool("isChasing", true);
    }

    public void Update()
    {
        if (enemyState == EnemyState.Chasing)
        {

            if (playerTransform.position.x > transform.position.x && facingDirection == -1 || playerTransform.position.x < transform.position.x && facingDirection == 1)
            {
                flip();
            }
            Vector2 direction = (playerTransform.position - transform.position).normalized;
            enemyRigidBody.velocity = direction * speed;
        }
    }

    public void flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (playerTransform == null)
            {
                playerTransform = other.transform;
            }
            changeState(EnemyState.Chasing);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            enemyRigidBody.velocity = Vector2.zero;
            changeState(EnemyState.Idle);
        }
    }

}

public enum EnemyState
{
    Idle, Chasing, 
}
