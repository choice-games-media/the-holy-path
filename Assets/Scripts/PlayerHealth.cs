using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int startingLives;
    private int _lives;
    public TextMeshProUGUI healthText;
    public GameObject respawnPoint;

    private void Start()
    {
        _lives = startingLives;
        UpdateLifeCounter();
    }

    // https://medium.com/nerd-for-tech/implementing-a-life-system-unity-e2a9c6b44db5
    public void TakeDamage(int amount)
    {
        _lives -= amount;
        UpdateLifeCounter();

        if (_lives < 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            // gameObject.transform.localScale = new Vector3(0, 0, 0);
            // StartCoroutine(EnablePlayer());
        }
    }
    
    /*
    private IEnumerator EnablePlayer()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
        // gameObject.transform.localScale = new Vector3(1, 1, 1);
        // gameObject.transform.position = respawnPoint.transform.position;
    }
    */

    private void UpdateLifeCounter()
    {
        print(_lives);
        healthText.text = $"Lives: {_lives}";
    }
}
