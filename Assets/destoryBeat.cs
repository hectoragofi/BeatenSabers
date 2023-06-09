using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destoryBeat : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= 500){
            Debug.Log("boom");
            Destroy(gameObject);
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger is the one you want to delete
        if (other.CompareTag("Beat"))
        {
            // Destroy the object that entered the trigger
            Destroy(other.gameObject);
        }
    }
}
