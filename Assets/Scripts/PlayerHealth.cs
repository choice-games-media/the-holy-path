using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    public TextMeshProUGUI healthText;
    
    public void TakeDamage(int amount)
    {
        health -= amount;
        healthText.text = $"Lives: {health}";
    }
}
