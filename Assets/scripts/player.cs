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
    public bool isdead = false;
    public float speed;
    public GameObject bullet;
    public GameObject shootboxobj;
    public GameObject playerobj;
    public GameObject GOscreen;
    public GameObject scorescript;
    void Start()
    {
        
    }

    void Update()
    {
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
            clone.transform.rotation = shootboxobj.transform.rotation;
            clone.GetComponent<Rigidbody>().velocity = shootboxobj.transform.forward * 9;
            Destroy(clone, 5.0f);
        }
    }

    void FixedUpdate()
    {
        gameObject.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward) * speed;

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
        if(other.gameObject.CompareTag("grid line"))
        {
            movementlock = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("grid line"))
        {
            movementlock = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("enemy"))
        {
            Destroy(playerobj.gameObject);
            Destroy(collision.gameObject);
            GOscreen.SetActive(true);
            scorescript.GetComponent<Score>().score = 0;
        }

        if(collision.gameObject.CompareTag("en bullet"))
        {
            Destroy(playerobj.gameObject);
            Destroy(collision.gameObject);
            GOscreen.SetActive(true);
            scorescript.GetComponent<Score>().score = 0;
        }

        if(collision.gameObject.CompareTag("top border"))
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - 11.3f);
        }

        if(collision.gameObject.CompareTag("bottom border"))
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + 11.3f);
        }

        if(collision.gameObject.CompareTag("left border"))
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + 22.5f, gameObject.transform.position.y, gameObject.transform.position.z);
        }

        if(collision.gameObject.CompareTag("right border"))
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x - 22.5f, gameObject.transform.position.y, gameObject.transform.position.z);
        }
    }
}
