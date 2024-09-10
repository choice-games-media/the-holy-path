using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    
    public void TakeDamage(int amount)
    {
        health -= amount;
        print(health);
    }
}
