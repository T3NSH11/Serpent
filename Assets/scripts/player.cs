using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public bool goingup = false;
    public bool goingdown = false;
    public bool goingleft = false;
    public bool goingright = false;
    public bool movementlock = false;
    public float speed;
    public GameObject bullet;
    public GameObject shootboxobj;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown("w"))
        {
            goingup = true;
            goingdown = false;
            goingleft = false;
            goingright = false;
        }

        if (Input.GetKeyDown("s"))
        {
            goingdown = true;
            goingup = false;
            goingleft = false;
            goingright = false;
        }

        if (Input.GetKeyDown("a"))
        {
            goingup = false;
            goingdown = false;
            goingleft = true;
            goingright = false;
        }

        if (Input.GetKeyDown("d"))
        {
            goingup = false;
            goingdown = false;
            goingleft = false;
            goingright = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject clone = Instantiate(bullet);
            clone.transform.position = shootboxobj.transform.position;
            clone.GetComponent<Rigidbody>().velocity = shootboxobj.transform.forward * 15;
        }
    }

    void FixedUpdate()
    {
        gameObject.GetComponent<Rigidbody>().velocity = transform.forward * speed;

        if (goingup == true && movementlock == false)
        {
            gameObject.transform.eulerAngles = new Vector3(0,0,0);
        }

        if (goingdown == true && movementlock == false)
        {
            gameObject.transform.eulerAngles = new Vector3(0,180,0);
        }

        if (goingleft == true && movementlock == false)
        {
            gameObject.transform.eulerAngles = new Vector3(0,-90,0);
        }

        if (goingright == true && movementlock == false)
        {
            gameObject.transform.eulerAngles = new Vector3(0,90,0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        movementlock = true;
    }

    void OnTriggerExit(Collider other)
    {
        movementlock = false;
    }

    void OnCollisionEnter()
    {

    }
}
