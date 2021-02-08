/* ARANZA I. ORTEGA S. DAM "O" NARANJA*/

using UnityEngine;

public class GameStatus : MonoBehaviour
{
    public int points = 0;
    public int lives = 3;
    public int currentLevel = 1;
    public int highestLevel = 3;
    public float speedEnemy = 1;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
