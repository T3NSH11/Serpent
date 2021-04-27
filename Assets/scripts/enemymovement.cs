using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymovement : MonoBehaviour
{
    public bool goingup = false;
    public bool goingdown = false;
    public bool goingleft = false;
    public bool goingright = false;
    public bool movementlock = false;
    public bool shoot = false;
    public float speed;
    public GameObject rspfw;
    public GameObject rspbw;
    public GameObject rsprt;
    public GameObject rsplt;
    RaycastHit forwardr;
    RaycastHit backwardr;
    RaycastHit rightr;
    RaycastHit leftr;
    public GameObject enshootboxobj;
    public GameObject bullet;
    float dchangetimer;
    float shottimer;
    float shottime = 1.0f;
    int dchange;
    int layermask = 1 << 9;
    void Start()
    {
        
    }

    void Update()
    {
        dchangetimer += Time.deltaTime;
        shottimer += Time.deltaTime;
        float dchangetime = Random.Range(1, 3);

        if (dchangetimer > dchangetime)
        {
            dchange = Random.Range (1, 4);
            dchangetimer = 0;
        }

        if (dchange == 1)
        {
            goingup = true;
            goingdown = false;
            goingleft = false;
            goingright = false;
        }

        if (dchange == 2)
        {
            goingdown = true;
            goingup = false;
            goingleft = false;
            goingright = false;
        }

        if (dchange == 3)
        {
            goingup = false;
            goingdown = false;
            goingleft = true;
            goingright = false;
        }

        if (dchange == 4)
        {
            goingup = false;
            goingdown = false;
            goingleft = false;
            goingright = true;
        }

        if (Physics.Raycast(rspfw.transform.position, rspfw.transform.TransformDirection(Vector3.forward), out forwardr, Mathf.Infinity, layermask))
        {
            Debug.DrawRay(rspfw.transform.position, rspfw.transform.TransformDirection(Vector3.forward) *  forwardr.distance, Color.yellow);
            movementlock = true;
            shoot = true;
        }

        if (Physics.Raycast(rspbw.transform.position, rspbw.transform.TransformDirection(Vector3.back), out backwardr, Mathf.Infinity, layermask))
        {
            Debug.DrawRay(rspbw.transform.position, rspbw.transform.TransformDirection(Vector3.back) *  backwardr.distance, Color.yellow);
            gameObject.transform.eulerAngles = new Vector3(0,180,0);
            movementlock = true;
            shoot = true;
        }

        if (Physics.Raycast(rsprt.transform.position, rsprt.transform.TransformDirection(Vector3.right), out rightr, Mathf.Infinity, layermask))
        {
            Debug.DrawRay(rsprt.transform.position, rsprt.transform.TransformDirection(Vector3.right) *  rightr.distance, Color.yellow);
            gameObject.transform.eulerAngles = new Vector3(0,90,0);
            movementlock = true;
            shoot = true;
        }
        

        if (Physics.Raycast(rsplt.transform.position, rsplt.transform.TransformDirection(Vector3.left), out leftr, Mathf.Infinity, layermask))
        {
            Debug.DrawRay(rsplt.transform.position, rsplt.transform.TransformDirection(Vector3.left) *  leftr.distance, Color.yellow);
            movementlock = true;
            shoot = true;
        }
        else
        {
            shoot = false;
        }

        if (shoot == true && shottime < shottimer)
        {
            GameObject cloneb = Instantiate(bullet);
            cloneb.transform.position = enshootboxobj.transform.position;
            cloneb.transform.rotation = enshootboxobj.transform.rotation;
            cloneb.GetComponent<Rigidbody>().velocity = enshootboxobj.transform.forward * 8;
            Destroy(cloneb, 5.0f);
            shoot = false;
            shottimer = 0;
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
