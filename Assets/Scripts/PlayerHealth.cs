using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int startingLives;
    private int _lives;
    public TextMeshProUGUI healthText;

    private void Start()
    {
        _lives = startingLives;
        UpdateLifeCounter();
    }
    
    /// <startedBy> Jason </startedBy>
    /// <summary>
    /// Adapted from: https://medium.com/nerd-for-tech/implementing-a-life-system-unity-e2a9c6b44db5
    /// Restarts the level. The life counter is currently unused.
    /// </summary>
    /// <param name="amount">The amount of lives to be taken away - currently unused.</param>
    public void TakeDamage(int amount)
    {
        _lives -= amount;
        UpdateLifeCounter();

        if (_lives < 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void UpdateLifeCounter()
    {
        healthText.text = $"Lives: {_lives}";
    }
}
