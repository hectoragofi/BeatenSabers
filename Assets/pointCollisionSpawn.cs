using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointCollisionSpawn : MonoBehaviour
{

    public GameObject beatPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Spawn")) {
            Debug.LogWarning("hi");
            Instantiate(beatPoint,transform);

        }
        //Debug.Log("nooo");
    }

}
