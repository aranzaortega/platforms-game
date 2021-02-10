/* ARANZA I. ORTEGA S. DAM "O" NARANJA*/

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private int points;
    private int lives;
    private int currentLevel;
    private int itemsLeft;
    private float speedEnemy;

    [SerializeField] Transform key;
    [SerializeField] Vector3 keyPosition;

    [SerializeField] Transform finalDiamond;
    [SerializeField] Vector3 finalDiamondPosition;

    [SerializeField] Text gameOverText;
    [SerializeField] Text gameInfoText;
    [SerializeField] Text winnerText;

    // Start is called before the first frame update
    void Start()
    {
        points = FindObjectOfType<GameStatus>().points;
        lives = FindObjectOfType<GameStatus>().lives;
        currentLevel = FindObjectOfType<GameStatus>().currentLevel;
        itemsLeft = FindObjectsOfType<Diamond>().Length;

        ChangeInfoText();
    }

    // Changing info text
    public void ChangeInfoText()
    {
        gameInfoText.text = "Level: " + currentLevel;
        gameInfoText.text += "\nLives: " + lives;
        gameInfoText.text += "\nPoints: " + points;
        gameInfoText.text += "\nItems left: " + itemsLeft;
    }

    public void SetWinnerText()
    {
        winnerText.text = "YOU WIN, CONGRATS!";
        winnerText.text += "\nTotal points:";
        winnerText.text += "\n" + points;
    }

    // Winning points
    public void PointsCounter()
    {
        points += 10;
        FindObjectOfType<GameStatus>().points = points;
        ItemsLeftCounter();
        ChangeInfoText();
    }

    // Remaning items (diamonds)
    public void ItemsLeftCounter()
    {
        itemsLeft--;
        if (itemsLeft <= 0) 
        { 
            if (currentLevel >= FindObjectOfType<GameStatus>().highestLevel)
            {
                finalDiamond = Instantiate(finalDiamond, finalDiamondPosition, Quaternion.identity);
            }
            else
            {
                key = Instantiate(key, keyPosition, Quaternion.identity);
            }
        }
    }

    // Changing level
    public void NextLevel()
    {
        currentLevel++;
        FindObjectOfType<GameStatus>().currentLevel = currentLevel;

        speedEnemy++;
        FindObjectOfType<GameStatus>().speedEnemy = speedEnemy;

        SceneManager.LoadScene("Level" + currentLevel);
    }

    // Losing lives
    public void LoseLife()
    {
        lives--;
        FindObjectOfType<Player>().SendMessage("Reposition");
        ChangeInfoText();

        if (lives <= 0)
        {
            GameOver();
        }
    }

    // Ending game
    public void GameOver()
    {
        gameOverText.enabled = true;
        gameOverText.gameObject.SetActive(true);
        StartCoroutine(BackToMainMenu());
    }

    // Winning game
    public void WinGame()
    {
        SetWinnerText();
        winnerText.enabled = true;
        winnerText.gameObject.SetActive(true);
        StartCoroutine(BackToMainMenu());
    }

    // Return to main menu
    private IEnumerator BackToMainMenu()
    {
        Time.timeScale = 0.5f;
        yield return new WaitForSeconds(1);
        Time.timeScale = 1f;

        SceneManager.LoadScene("Menu");
    }

}
