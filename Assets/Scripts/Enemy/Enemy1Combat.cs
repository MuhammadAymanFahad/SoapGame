using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Combat : EnemyCombat
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().changeHealth(-damage);
        }
    }
}
