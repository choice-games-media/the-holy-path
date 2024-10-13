using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndpointController : MonoBehaviour
{
    public int newScene;
    public bool isEnd;
    public TextMeshProUGUI victoryText;

    private void Start()
    {
        victoryText.enabled = false;
        gameObject.SetActive(true);
    }
    
    /// <startedBy> Jason </startedBy>
    /// <summary>
    /// Upon collision, switches to the specified level. If the level has been marked as the end, instead display the
    /// ending text and hide the player.
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collidedObject)
    {
        if (collidedObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            
            if (isEnd)
            {
                victoryText.enabled = true;
                GameObject.FindGameObjectWithTag("Player").SetActive(false);
                return;
            }
            
            SceneManager.LoadScene(newScene);

        }
    }
}
