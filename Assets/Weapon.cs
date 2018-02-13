using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public float fireRate = 0;
    public LayerMask whatToHit;

    public Transform ShotTrailPrefab;
    public Transform Entangled;

    private Transform firePoint;

    public GameObject obj1;
    public GameObject obj2;



    // Use this for initialization
    void Awake () {
        firePoint = transform.Find("FirePoint");
        if(firePoint == null)
        {
            Debug.LogError("No firePoint");
        }
	}
	
	// Update is called once per frame
	void Update () {
        //Shoot();
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot(1);
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            Shoot(2);
        }
        else if (Input.GetButtonDown("Fire3"))
        {
            Detangle();
        }
    }

    void Shoot(int o)
    {
        Vector2 mousePos = new Vector2 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePos = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePoint.position, mousePos - firePos, 100, whatToHit);

        Effect();

        Debug.DrawLine (firePos, (mousePos - firePos) * 1000, Color.cyan);

        if (hit.collider != null)
        {
            //Debug.DrawLine(firePos, hit.point, Color.red);
            Debug.Log("Hit " + hit.collider.name);

            //hit.transform.SetParent(Entangled);
            
            if (obj1 != null && o == 1)
            {
                //Debug.Log("Detangling " + obj1.name);

                //obj1.GetComponent<FixedJoint2D>()).connectedBody = null;
                Destroy(obj1.GetComponent<FixedJoint2D>());
            }


            if (o == 1 && obj2 != hit.transform.gameObject)                               //Sets hit objects to be entangled
            {
                obj1 = hit.transform.gameObject;
            }
            else if (o == 2 && obj1 != hit.transform.gameObject)
            {
                obj2 = hit.transform.gameObject;
            }

            if (obj1 != null && obj2 != null)
            {
                Destroy(obj1.GetComponent<FixedJoint2D>());
                Debug.Log("Entangling " + obj1.name + " and " + obj2.name);
                Entangle();
            }

        }

    }

    void Effect()
    {
        //Gets mouse location
        Vector2 mousePos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

        //Substracts the location the shot is coming from from it
        mousePos.x = mousePos.x - firePoint.position.x;
        mousePos.y = mousePos.y - firePoint.position.y;
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        //Turns it into a quaternion
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        
        //Done
        Instantiate(ShotTrailPrefab, firePoint.position, rotation);
    }

    void Entangle()
    {
        obj1.AddComponent<FixedJoint2D>();
        (obj1.GetComponent<FixedJoint2D>()).connectedBody = obj2.GetComponent<Rigidbody2D>();
    }

    void Detangle()
    {
        if (obj1 != null)
            Destroy(obj1.GetComponent<FixedJoint2D>());
        obj1 = null;
        obj2 = null;
    }

}
