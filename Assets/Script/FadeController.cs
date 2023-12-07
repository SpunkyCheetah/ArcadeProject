using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration;
    public bool isFading = false;

    // Start is called before the first frame update
    void Start()
    {
        // Sets fade to transparent at the start
        Color imageColor = fadeImage.color;
        imageColor.a = 0.0f; // set alpha ('a') to zero ('0.0f')
        fadeImage.color = imageColor;
    }

    public void SetTransparency(float targetAlpha)
    {
        Color imageColor = fadeImage.color;
        imageColor.a = targetAlpha;
        fadeImage.color = imageColor;
    }

    public void FadeIn()
    {
        // Checks that it isn't already fading
        if (!isFading)
        {
            // Starts fading from transparent to opaque
            StartCoroutine(FadeImage(0.0f, 1.0f));
        }
    }

    public void FadeOut()
    {
        // Checks that it isn't already fading
        if (!isFading)
        {
            // Starts fading from opaque to transparent
            StartCoroutine(FadeImage(1.0f, 0.0f));
        }
    }

    private IEnumerator FadeImage(float startAlpha, float targetAlpha) // takes floats for the starting transparency and end goal transparency
    {
        // Updates isFading so it doesn't try to fade multiple times at once
        isFading = true;

        // not entirely sure what this does, we haven't been taught any of this yet
        Color imageColor = fadeImage.color;
        float elapsedTime = 0.0f;

        // Loop fading for the appropriate amount of time
        while (elapsedTime < fadeDuration)
        {
            // This chunk of code causes a step of the fading? Somehow?
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / fadeDuration); // Ah :D math :D lots of math :D I know what this does! (/lie)
            imageColor.a = alpha; // 'alpha' means transparency usually, I assume that's what that means here
            fadeImage.color = imageColor;

            // Update by how much time has passed on this itteraton of the loop
            elapsedTime += Time.deltaTime;
            yield return null; // i'm sure there's some technical reason for this
        }

        // Sets transparancy to desired levels in case fading didn't get it quite right
        imageColor.a = targetAlpha;
        fadeImage.color = imageColor;

        // isFading set back to false for next time it needs to fade
        isFading = false;
    }
}
