using UnityEngine;
using UnityEngine.SceneManagement;

public class EndpointController : MonoBehaviour
{
    public int newScene;
    
    private void OnTriggerEnter2D(Collider2D collidedObject)
    {
        if (collidedObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene(newScene);
        }
    }
}
