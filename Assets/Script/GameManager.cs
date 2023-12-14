using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isPlayerDead = false; // boolean to track if the player is dead
    public int score = 0; // int to keep track of the score
    public int livesLeft; // in to keep track of the number of lives the player has
    public TextMeshProUGUI scoreText; // the text that displays the score
    public TextMeshProUGUI highScoreText; // the text that displays the high score
    public TextMeshProUGUI livesText; // the text that displays the number of lives
    public TextMeshProUGUI deathText; // the text for the Death screen
    public TextMeshProUGUI gameOverText; // the text for the Game Over screem
    public Button respawnButton; // the button to respawn the player
    public Button restartButton; // the button to restart the game
    public GameObject player; // the player
    public GameObject spawnManager; // the spawn manager
    public float dificultyModifier; // float to track dificulty
    private FadeController fadeController; // allows game manager to cause fading
    private bool canRespawn;
    private bool canRestart;

    void Start()
    {
        // Attatch fade controller
        fadeController = gameObject.GetComponent<FadeController>();

        // Set highscore text to the correct value
        UpdateHighScore();

        // Set the screen to black in preperation for fading into the scene
        fadeController.SetTransparency(1f);

        // Fade into the scene
        fadeController.FadeOut();
    }

    void Update()
    {
        // make sure difficulty is set correctle based on score
        dificultyModifier = 1 + score / 200f;

        if (Input.GetButtonDown("Start"))
        {
            if (canRespawn)
            {
                Respawn();
            }
            else if (canRestart)
            {
                Restart();
            }
        }
    }

    // When the player dies, determine if this is a game over a retry and display correct UI elements
    public IEnumerator DeathScreen()
    {
        // player looses a life when destroyed
        UpdateLives(-1);

        // Check if this is a Death or Game Over
        if (livesLeft > 0)
        {
            // Display Death text and respawn button
            deathText.gameObject.SetActive(true);
            respawnButton.gameObject.SetActive(true);

            canRespawn = true;

            yield return null;
        }
        else
        {
            // Tell spawner to stop spawning
            spawnManager.GetComponent<SpawnManager>().isSpawning = false;

            // Fade screen
            fadeController.FadeIn();
            yield return new WaitForSeconds(fadeController.fadeDuration);

            // Display Game Over text and restart button
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);

            canRestart = true;
        }
    }

    // Respawn the player
    public void Respawn()
    {
        // Hide Death text and respawn button
        deathText.gameObject.SetActive(false);
        respawnButton.gameObject.SetActive(false);

        // Move player to the center of the screen
        player.transform.position = Vector3.zero;

        // Bring player back
        isPlayerDead = false;
        player.gameObject.SetActive(true);

        canRespawn = false;
    }

    // Go back to the title screen for restarting
    public void Restart()
    {
        // Reset the scene when told to restart the game
        SceneManager.LoadScene("TitleScreen");

        canRestart = false;
    }

    // Set the score display text to the correct value
    public void UpdateScore (int addScore)
    {
        // Update the score variable
        score += addScore;

        // Make sure the score is not negative
        if (score < 0)
        {
            score = 0;
        }

        // Update score text to current score
        scoreText.text = $"score: {score}";

        // Check if score has surpassed the highscore
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            // Change the highscore to match the score
            PlayerPrefs.SetInt("HighScore", score);
            UpdateHighScore();
        }
    }

    // Set the high score display text to the correct value
    public void UpdateHighScore()
    {
        // Update highscore text to current highscore
        highScoreText.text = $"highscore: {PlayerPrefs.GetInt("HighScore")}";
    }

    // Set the lives display text to the correct value
    public void UpdateLives(int looseLives)
    {
        // Update livesLeft variable
        livesLeft += looseLives;

        // Update lives text to current lives
        livesText.text = "lives: " + livesLeft;
    }
}
