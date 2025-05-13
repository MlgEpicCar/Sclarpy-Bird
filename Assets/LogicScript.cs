using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class LogicScript : MonoBehaviour
{
    public int playerCoins = 0;
    public int playerScore = 0;
    public int playerHighscore = 0;
    public Text coinsText;
    public Text scoreText;
    public Text highscoreText;
    public GameObject gameOverScreen;

    private void Start()
    {
        playerHighscore = PlayerPrefs.GetInt("playerHighscore", 0);
        highscoreText.text = "Highscore: " + playerHighscore.ToString();
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd) // you know what this does
    {
        playerScore += scoreToAdd;
        scoreText.text = "Score: " + playerScore.ToString();

        if (playerHighscore < playerScore)
        {
            PlayerPrefs.SetInt("playerHighscore", playerScore);
            highscoreText.text = "Highscore: " + playerScore.ToString();
        }
    }

    [ContextMenu("Increase Coins")]
    public void addCoins(int coinsToAdd)
    {
        playerCoins += coinsToAdd;
        scoreText.text = "Coins: " + playerCoins.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) // Press R to reset Highscore
        {
            PlayerPrefs.SetInt("playerHighscore", 0);
            playerHighscore = PlayerPrefs.GetInt("playerHighscore", 0);
            highscoreText.text = "Highscore: " + playerHighscore.ToString();
        }
    }
}
