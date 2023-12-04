using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float moveSpeed; // float for movement speed

    // Update is called once per frame
    void Update()
    {
        // Move forward at a constant rate
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        // Destroy the projectile once it it goes off screen
        if (transform.position.x > 130 || transform.position.x < -130)
        {
            Destroy(gameObject);
        }
        if (transform.position.z > 80 || transform.position.z < -80)
        {
            Destroy(gameObject);
        }
    }
}
