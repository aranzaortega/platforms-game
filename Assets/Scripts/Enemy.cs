/* ARANZA I. ORTEGA S. DAM "O" NARANJA*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Enemy's movement
    [SerializeField] List<Transform> wayPoints;
    private float speed; 
    private byte nextPosition;
    private float changeDistance;

    // Start is called before the first frame update
    private void Start()
    {
        nextPosition = 0;
        speed = FindObjectOfType<GameStatus>().speedEnemy;
        changeDistance = 0.2f;
    }

    // Update is called once per frame
    private void Update()
    {
        // Calculate a new position that is between the current and the next one
        transform.position = Vector3.MoveTowards(
            transform.position,
            wayPoints[nextPosition].transform.position,
            speed * Time.deltaTime);

        // Change of direction according to waypoints
        if (Vector3.Distance(transform.position,
                wayPoints[nextPosition].transform.position) < changeDistance)
        {
            nextPosition++;
            if (nextPosition >= wayPoints.Count)
                nextPosition = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // When the player collides with it
        if (collision.tag == "Player")
        {
            FindObjectOfType<GameController>().SendMessage("LoseLife");
        }
    }
}
