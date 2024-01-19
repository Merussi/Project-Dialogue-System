using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{

    [SerializeField] float timeToCompleteGame = 600; // Total time to complete the game
    [SerializeField] Image timerFillImage; // Reference to the UI image used for the timer fill
    [SerializeField] Sprite[] timerSprites; // Sprites for different stages of the timer
    [SerializeField] float fillSpeed = 0.5f; // Speed at which the timer fills
    [SerializeField] float orange; // Time value for the orange color transition
    [SerializeField] float yellow; // Time value for the yellow color transition
    [SerializeField] float red; // Time value for the red color transition

    private float timeValue; // Current time value
    private float currentTime = 0f; // Current time in the fill animation
    private int fillDirection = 1; // Direction of the fill animation

    private void Start()
    {
        timeValue = timeToCompleteGame; // Initialize the time value
    }

    void Update()
    {
        
        UpdateTimer(); // Update the timer logic
        UpdateFillAmount(); // Update the fill animation
    }

    void UpdateTimer()
    {
        timeValue -= Time.deltaTime; // Countdown the time value

        // End the game when time runs out
        if (timeValue <= 0)
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            gameManager.OnEndGame();
        }

       
    }

    void UpdateFillAmount()
    {
        currentTime += Time.deltaTime * fillSpeed * fillDirection;
        timerFillImage.fillAmount = currentTime / timeToCompleteGame; // Set the fill amount based on the time

        if (currentTime >= timeToCompleteGame || currentTime <= 0f)
        {
            // Reverse the fill direction when the animation reaches its limit
            fillDirection *= -1;
        }

        // Set the timer sprite based on the time value for different color transitions
        if (timeValue <= orange && timeValue >= yellow) // Orange transition
        {
            timerFillImage.sprite = timerSprites[2];
        }
        else if (timeValue <= yellow && timeValue >= red) // Yellow transition
        {
            timerFillImage.sprite = timerSprites[1];
        }
        else if(timeValue <= red) // Red transition
        { 
            timerFillImage.sprite= timerSprites[0];
        }
    }
}
