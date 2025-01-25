using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    [SerializeField] private UIManager uiManager;

    public void changeHealth(int amount)
    {
        currentHealth += amount;
        uiManager.UpdateLives(currentHealth);

        if(currentHealth <= 0)
        {
            gameObject.SetActive(false);

        }
    }
}
