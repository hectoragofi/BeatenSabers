using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using static DSPLib.DSP;
using static UnityEngine.Rendering.DebugUI;
using static UnityEngine.UIElements.UxmlAttributeDescription;
using UnityEngine.PlayerLoop;

public class rotateCube : MonoBehaviour
{
    public float rotationSpeed = 1f;
    public float minWaitTime = 1f;
    public float maxWaitTime = 5f;

    private float targetRotationX;
    private float currentLerpTime;
    private float lerpDuration;
    private Quaternion initialRotation;

    private void Start()
    {
        // Store the initial rotation of the object
        initialRotation = transform.rotation;

        // Choose the initial target rotation on the X-axis
        ChooseRandomRotation();
    }

    private void Update()
    {
        // Update the lerp time
        currentLerpTime += Time.deltaTime;

        // Check if the lerping is complete
        if (currentLerpTime >= lerpDuration)
        {
            // Choose a new target rotation on the X-axis
            ChooseRandomRotation();
        }

        // Calculate the lerp progress
        float t = currentLerpTime / lerpDuration;

        // Lerp towards the target rotation on the X-axis
        Quaternion targetRotation = Quaternion.Euler(targetRotationX, 90f, 0f);
        transform.rotation = Quaternion.Lerp(initialRotation, targetRotation, t);
    }

    private void ChooseRandomRotation()
    {
        // Store the current rotation as the initial rotation for lerping
        initialRotation = transform.rotation;

        // Generate a new random rotation on the X-axis
        targetRotationX = Random.Range(-180f, 180f);

        // Randomize the duration for lerping to the new rotation
        lerpDuration = Random.Range(minWaitTime, maxWaitTime);

        // Reset the lerp time
        currentLerpTime = 0f;
    }
}