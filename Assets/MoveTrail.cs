using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrail : MonoBehaviour {

    public int movespeed = 1;

	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * Time.deltaTime * movespeed);
        Destroy(gameObject, 1);
    }

    /*
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit " + collision.gameObject.name);
        Destroy(gameObject);
        if (collision.gameObject.name != null)
        {
            Destroy(gameObject);
        }
    }
    */

}
