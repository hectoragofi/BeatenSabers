using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantSpeedMovement : MonoBehaviour
{
    public float speed = 5f; // Speed of the object

    private void Update()
    {
        // Calculate the translation vector based on the speed and deltaTime
        Vector3 translation = transform.forward * speed * Time.deltaTime;

        // Move the object by translating its position
        transform.Translate(translation);
    }

}