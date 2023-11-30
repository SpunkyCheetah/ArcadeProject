using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);


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
