using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Combat : MonoBehaviour
{
    public int damage = 1;
    public Transform attackPoint;
    public float weaponRange;
    public float knockBackForce;
    public float stunTime;
    public LayerMask playerLayer;

    /*
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().changeHealth(-damage);
        }
    }
    */

    public void attack()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, weaponRange, playerLayer);
        if(hits.Length > 0)
        {
            hits[0].GetComponent<PlayerHealth>().changeHealth(-damage);
            hits[0].GetComponent<PlayerMovement>().knockBack(transform, knockBackForce, stunTime);
        }
    }
}
