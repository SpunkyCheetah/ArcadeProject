using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour
{
    public int delay; // delay before destruction
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitThenDestroy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Wair a given number of seconds before destroying this object
    IEnumerator WaitThenDestroy()
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
