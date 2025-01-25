using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D playerRigidBody;
    [SerializeField] private Animator playerAnim;
    private bool isKnockedBack;
    

    private int facingDirection = 1;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);       
    }

    void FixedUpdate()
    {
        if(isKnockedBack == false)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            playerAnim.SetFloat("horizontal", Mathf.Abs(horizontal));
            playerAnim.SetFloat("vertical", Mathf.Abs(vertical));

            if (horizontal > 0 && transform.localScale.x < 0 || horizontal < 0 && transform.localScale.x > 0)
            {
                flip();
            }
            playerRigidBody.velocity = new Vector2(horizontal, vertical) * speed;
        }
        
    }

    void flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    public void knockBack(Transform enemy, float force, float stunTime)
    {
        isKnockedBack = true;
        Vector2 direction = (transform.position - enemy.position).normalized;
        playerRigidBody.velocity = direction * force;
        StartCoroutine(knockbackCounter(stunTime));
    }

    IEnumerator knockbackCounter(float stunTime)
    {
        yield return new WaitForSeconds(stunTime);
        playerRigidBody.velocity = Vector2.zero;
        isKnockedBack = false;
    }
}
