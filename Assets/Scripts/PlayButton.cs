/* ARANZA I. ORTEGA S. DAM "O" NARANJA*/

using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public int points = 0;
    public int currentLevel = 1;

    public void LaunchGame() 
    { 
        SceneManager.LoadScene("Level1");
        FindObjectOfType<GameStatus>().points = points;
    }
}
