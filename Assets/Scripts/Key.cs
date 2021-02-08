/* ARANZA I. ORTEGA S. DAM "O" NARANJA*/

using UnityEngine;

public class Key : MonoBehaviour
{
    // Player's collision call to change scene
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            FindObjectOfType<GameController>().SendMessage("NextLevel");
        }
    }
}
