using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trailCollision : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit " + collision.gameObject.name);
        Destroy(gameObject);
        if (collision.gameObject.name != null)
        {
            Destroy(gameObject);
        }
    }
}
