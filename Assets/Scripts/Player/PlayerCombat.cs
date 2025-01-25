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

    private void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    public void Attack()
    {
        if(timer <= 0)
        {
            anim.SetBool("isAttacking", true);
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
