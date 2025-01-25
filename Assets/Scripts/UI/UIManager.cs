using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Image livesImage;
    [SerializeField] private Sprite[] liveSprites;

    // Start is called before the first frame update
    void Start()
    {
        UpdateLives(6);
    }

    public void UpdateLives(int currentLives)
    {
        livesImage.sprite = liveSprites[currentLives];
    }
}
