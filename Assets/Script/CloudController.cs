using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    public float moveSpeed = 10; // float for movement speed
    public float edgeOfScreen = 250;

    // Start is called before the first frame update
    void Start()
    {
        // Set clouds at a random position when the game starts
        transform.position = new Vector3(Random.Range(-350, 225), Random.Range(-15, -30), Random.Range(-100, 100));

        // Set a random speed for cloud
        moveSpeed = Random.Range(10, 20);
    }

    // Update is called once per frame
    void Update()
    {
        // Move forward at a constant rate
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        // If cloud goes off the egde of the screen, reset on the other side of the screen
        if (transform.position.x > edgeOfScreen)
        {
            transform.position = new Vector3(-edgeOfScreen, Random.Range(-15, -30), Random.Range(-100, 100));

            // Set new speed on reset
            moveSpeed = Random.Range(10, 20);
        }
    }
}
