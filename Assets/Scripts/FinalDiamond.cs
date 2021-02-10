using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDiamond : MonoBehaviour
{
    // Player's collision call to back to main menu
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            FindObjectOfType<GameController>().SendMessage("WinGame");
        }
    }
}
