using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLightRot : MonoBehaviour
{
    public float rotationSpeed = 1f;
    public float minWaitTime = 1f;
    public float maxWaitTime = 5f;

    private Quaternion targetRotation;
    private float currentLerpTime;
    private float lerpDuration;
    private Quaternion initialRotation;

    private void Start()
    {
        // Store the initial rotation of the object
        initialRotation = transform.rotation;

        // Choose the initial target rotation
        ChooseRandomRotation();
    }

    private void Update()
    {
        // Update the lerp time
        currentLerpTime += Time.deltaTime;

        // Check if the lerping is complete
        if (currentLerpTime >= lerpDuration)
        {
            // Choose a new target rotation
            ChooseRandomRotation();
        }

        // Calculate the lerp progress
        float t = currentLerpTime / lerpDuration;

        // Lerp towards the target rotation
        transform.rotation = Quaternion.Lerp(initialRotation, targetRotation, t);
    }

    private void ChooseRandomRotation()
    {
        // Store the current rotation as the initial rotation for lerping
        initialRotation = transform.rotation;

        // Generate a new target rotation
        targetRotation = Random.rotation;

        // Randomize the duration for lerping to the new rotation
        lerpDuration = Random.Range(minWaitTime, maxWaitTime);

        // Reset the lerp time
        currentLerpTime = 0f;
    }
}