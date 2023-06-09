using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPoints : MonoBehaviour
{
    public GameObject beatObject;
    private PlotController plotCo;
    public float offsetX = -59;
    public float speed = 5f; // Speed of the object
    public float height1 = 3;
    public float height2 = 6f;
    private void FixedUpdate()
    {
        //MakePoints(plotCo.peakPoint.transform);
    }

    public void MakePoints(Transform pointPos)
    {
        Instantiate(beatObject, pointPos);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Point"))
        {
            Debug.Log("GameObject exited the trigger collider.");

            Vector3 localPosition = new Vector3(other.transform.position.x - offsetX, other.transform.position.y, other.transform.position.z);
            Vector3 worldPosition = transform.TransformPoint(localPosition);
            Vector3 finalPos = new Vector3(worldPosition.x + (Random.Range(height1, height2)/10),worldPosition.y, worldPosition.z); 
            Quaternion rotation = Quaternion.identity; // Set the rotation to identity if you don't want any rotation change

            Instantiate(beatObject, finalPos, rotation);
        }

        //Debug.Log("hi");
    }

}
