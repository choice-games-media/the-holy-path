using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    public TextMeshProUGUI healthText;
    
    public void TakeDamage(int amount)
    {
        print($"{health}: Taking {amount} damage");
        health -= amount;
        print(health);
        healthText.text = $"Lives: {health}";
    }
}
