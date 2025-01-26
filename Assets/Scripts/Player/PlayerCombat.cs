using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    public Animator anim;
    public LayerMask enemyLayer;
    public float weaponRange;
    public float cooldown = 1.5f;
    private float timer;
    public int damage = 2;
    public float knockbackForce = 20;
    public float knockbackTime = .15f;
    public float stunTime = 0.15f;

    public PlayerScore playerScore;
    public PlayerHealth playerHealth;
    private int lastCheckedScore;

    public AudioClip attackSoundClip;
    public AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = attackSoundClip;
    }
    private void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        scoreCheck();
    }

    public void scoreCheck()
    {
        int currentScore = playerScore.getCurrentScore();
        if (currentScore >= 10 && currentScore % 10 == 0 && currentScore > lastCheckedScore)
        {
            Debug.Log("Current score is = " + currentScore);
            playerHealth.changeHealth(2);
            lastCheckedScore = currentScore;
        }
    }

    public void Attack()
    {
        if(timer <= 0)
        {
            anim.SetBool("isAttacking", true);
            audioSource.Play();
            timer = cooldown;
        }
        
    }

    public void dealDamage()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, weaponRange, enemyLayer);

        if (enemies.Length > 0)
        {
            enemies[0].GetComponent<EnemyHealth>().changeHealth(-damage);
            enemies[0].GetComponent<EnemyKnockback>().knockback(transform, knockbackForce, knockbackTime, stunTime);
        }
        timer = cooldown;
    }

    public void finishAttacking()
    {
        anim.SetBool("isAttacking", false);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, weaponRange);
    }
}
