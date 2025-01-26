using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public AudioClip damagedSoundClip;
    public AudioSource audioSource;

    [SerializeField] private UIManager uiManager;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = damagedSoundClip;
    }

    public void changeHealth(int amount)
    {
        if(amount < 0)
        {
            audioSource.Play();
        }

        currentHealth += amount;
        uiManager.UpdateLives(currentHealth);

        if(currentHealth <= 0)
        {
            gameObject.SetActive(false);

        }
    }

    public int getCurrentHealth()
    {
        return this.currentHealth;
    }
}
