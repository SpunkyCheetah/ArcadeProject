using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{
    private FadeController fadeController; // lets this script control fading
    private AudioSource audioSource; // the audio source
    public AudioClip buttonAudio; // sound effect for button presses

    private void Start()
    {
        // Attatch components
        fadeController = gameObject.GetComponent<FadeController>();
        audioSource = GetComponent<AudioSource>();

        // Set the fade to transparent so the screen can be seen
        fadeController.SetTransparency(0.0f);
    }

    void Update()
    {
        // When start button is pressed start the game
        if (Input.GetButtonDown("Start"))
        {
            StartGameStarter();
        }
    }

    // Method for buttons to tell this script to start the game
    public void StartGameStarter()
    {
        audioSource.PlayOneShot(buttonAudio);
        StartCoroutine(StartGame());
    }

    // Actually Start the game
    public IEnumerator StartGame()
    {
        // Tell the fade script to start fading
        fadeController.FadeIn();
        // Wait for fading to finish
        yield return new WaitForSeconds(fadeController.fadeDuration);
        // Switch to gameplay screen
        SceneManager.LoadScene("GameScene");
    }
}
