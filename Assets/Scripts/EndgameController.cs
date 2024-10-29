using TMPro;
using UnityEngine;

public class EndgameController : MonoBehaviour
{
     public TextMeshProUGUI victoryText;
 
     private void Start()
     {
         victoryText.enabled = false;
         gameObject.SetActive(true);
     }
     
     /// <startedBy> Jason </startedBy>
     /// <summary>
     /// Upon collision, displays the ending text and hides the player.
     /// </summary>
     private void OnTriggerEnter2D(Collider2D collidedObject)
     {
         if (collidedObject.CompareTag("Player"))
         {
             Destroy(gameObject);
             victoryText.enabled = true;
             GameObject.FindGameObjectWithTag("Player").SetActive(false);
         }
     }
}
