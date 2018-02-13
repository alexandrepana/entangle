using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class entanglement : MonoBehaviour {

    public Rigidbody2D rb;
    public Transform obj1;
    public Transform obj2;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {


        int children = transform.childCount;
        for (int i = 0; i < children; ++i){
            if (i == 0){
                obj1 = transform.GetChild(i);
            }
            else if (i == children - 1){
                obj2 = transform.GetChild(i);
            }

        }

        obj1.transform.parent = obj2.transform;

        for (int i = 0; i < children; ++i)
        {
            if (i == 0)
            {
                transform.GetChild(i) = obj1;
            }
            else if (i == children - 1)
            {
                obj2 = transform.GetChild(i);
            }

        }


        //gameObject.transform.GetChild(0).parent = gameObject.transform.GetChild(1);

    }
}
