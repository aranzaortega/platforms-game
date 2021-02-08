/* ARANZA I. ORTEGA S. DAM "O" NARANJA*/

using UnityEngine;

public class BottomCollider : MonoBehaviour
{
    // When the player hits the bottom limit 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            FindObjectOfType<Player>().SendMessage("Reposition");
            FindObjectOfType<GameController>().SendMessage("LoseLife");
        }
    }
}
