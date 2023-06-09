using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : MonoBehaviour
{
    //public ParticleSystem particles;

    void OnCollision(Collision collision)
    {
        if (collision.gameObject.CompareTag("Particles"))
        {
            Debug.Log("Should delete particle");
            Destroy(collision.gameObject);
        }
    }
}
