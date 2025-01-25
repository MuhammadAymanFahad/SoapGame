using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public int damage;

    private void OnCollisionEnter2D(Collision2D other)
    {
        other.gameObject.GetComponent<PlayerHealth>().changeHealth(-damage);
    }

}
