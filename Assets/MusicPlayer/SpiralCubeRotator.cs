using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralCubeRotator : MonoBehaviour
{
    public GameObject cubePrefab; // Assign your cube prefab here
    public int numberOfCubes = 10; // The number of cubes you want to create
    public float rotationSpeed = 10f; // The rotation speed of the first cube
    public float speedDecreaseFactor = 0.9f; // The factor by which the rotation speed decreases for each subsequent cube

    private List<GameObject> cubes = new List<GameObject>();

    void Start()
    {
        // Create the cubes
        for (int i = 0; i < numberOfCubes; i++)
        {
            GameObject cube = Instantiate(cubePrefab, transform);
            cube.transform.localPosition = new Vector3(0, 0, -i); // Position the cube behind the previous one
            cubes.Add(cube);
        }
    }

    void Update()
    {
        // Rotate the cubes
        for (int i = 0; i < cubes.Count; i++)
        {
            float speed = rotationSpeed * Mathf.Pow(speedDecreaseFactor, i); // Calculate the rotation speed for this cube
            cubes[i].transform.RotateAround(transform.position, Vector3.up, speed * Time.deltaTime); // Rotate the cube
        }
    }
}