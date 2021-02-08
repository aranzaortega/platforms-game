/* ARANZA I. ORTEGA S. DAM "O" NARANJA*/

using UnityEngine;

public class Diamond : MonoBehaviour
{
    // Player's collision call and diamond's death
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            FindObjectOfType<GameController>().SendMessage("PointsCounter"); 
            Destroy(gameObject);
        }
    }
}
