using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{
    private FadeController fadeController;

    private void Start()
    {
        fadeController = gameObject.GetComponent<FadeController>();
        fadeController.SetTransparency(0.0f);
    }

    public void StartGameStarter()
    {
        StartCoroutine(StartGame());
    }
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
