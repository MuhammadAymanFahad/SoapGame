using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody2D enemyRigidBody;
    public Transform playerTransform;
    public Animator enemyAnim;
    public int facingDirection;
    public bool isChasing;

    public virtual void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody2D>();
        enemyAnim = GetComponent<Animator>();
    }

    public void Update()
    {
        if(isChasing)
        {
            if (isChasing)
            {
                if(playerTransform.position.x > transform.position.x && facingDirection == -1 || playerTransform.position.x < transform.position.x && facingDirection == 1)
                {
                    flip();
                }
            }
            Vector2 direction = (playerTransform.position - transform.position).normalized;
            enemyRigidBody.velocity = direction * speed;
        }
    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(playerTransform == null)
            {
                playerTransform = other.transform;
            }
            isChasing = true;
        }
    }

    public virtual void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            enemyRigidBody.velocity = Vector2.zero;
            isChasing = false;
        }
    }

    public void flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}
