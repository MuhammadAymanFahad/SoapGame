using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public int enemyPoint;
    public PlayerScore playerScore;

    private void Start()
    {
        currentHealth = maxHealth;
    }
    public void changeHealth(int amount)
    {
        currentHealth += amount;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        else if(currentHealth <= 0)
        {
            Destroy(gameObject);
            playerScore.addScore(enemyPoint);
        }
    }
}
