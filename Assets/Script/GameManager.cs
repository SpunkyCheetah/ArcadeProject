using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isPlayerDead = false;
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI deathText;
    public TextMeshProUGUI gameOverText;
    public Button respawnButton;
    public Button restartButton;
    public int livesLeft;
    public GameObject player;
    public GameObject spawnManager;
    public int dificulty;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame(int setDificulty)
    {
        dificulty = setDificulty;
        spawnManager.GetComponent<SpawnManager>().spawnDelay /= dificulty;
    }

    public void DeathScreen()
    {
        UpdateLives(-1);
        if (livesLeft >= 0)
        {
            deathText.gameObject.SetActive(true);
            UpdateScore(-10);
            if (livesLeft < 1)
            {
                score = 0;
                UpdateScore(0);
            }
            respawnButton.gameObject.SetActive(true);
        }
        else
        {
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
        }
    }

    public void Respawn()
    {
        deathText.gameObject.SetActive(false);
        respawnButton.gameObject.SetActive(false);
        player.transform.position = Vector3.zero;
        isPlayerDead = false;
        player.gameObject.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UpdateScore (int addScore)
    {
        score += addScore;
        if (score < 0)
        {
            score = 0;
        }
        scoreText.text = "score: " + score;
    }

    public void UpdateLives(int looseLives)
    {
        livesLeft += looseLives;
        livesText.text = "lives: " + livesLeft;
    }
}
