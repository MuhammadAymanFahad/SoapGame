using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int currentHealth;
    [SerializeField] private int maxHealth;
    [SerializeField] private UIManager uiManager;

    public void changeHealth(int amount)
    {
        currentHealth += amount;
        Debug.Log("Current Health = " + currentHealth);
        uiManager.UpdateLives(currentHealth);

        if(currentHealth <= 0)
        {
            gameObject.SetActive(false);

        }
    }
}
