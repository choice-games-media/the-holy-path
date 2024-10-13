using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndpointController : MonoBehaviour
{
    public int newScene;
    public bool isEnd;
    public TextMeshProUGUI victoryText = null;

    private void Start()
    {
        victoryText.enabled = false;
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collidedObject)
    {
        if (collidedObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            
            if (isEnd)
            {
                print("End!");
                victoryText.enabled = true;
                GameObject.FindGameObjectWithTag("Player").SetActive(false);
                return;
            }
            
            SceneManager.LoadScene(newScene);

        }
    }
}
