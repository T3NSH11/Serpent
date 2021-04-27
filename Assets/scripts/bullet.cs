using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public GameObject shootboxobj;
    void Start()
    {
        
    }

    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("top border"))
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - 11.3f);
            gameObject.GetComponent<Rigidbody>().velocity = transform.forward * 15;
        }

        if(collision.gameObject.CompareTag("bottom border"))
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + 11.3f);
            gameObject.GetComponent<Rigidbody>().velocity = transform.forward * 15;
        }

        if(collision.gameObject.CompareTag("left border"))
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + 22.5f, gameObject.transform.position.y, gameObject.transform.position.z);
            gameObject.GetComponent<Rigidbody>().velocity = transform.forward * 15;
        }

        if(collision.gameObject.CompareTag("right border"))
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x - 22.5f, gameObject.transform.position.y, gameObject.transform.position.z);
            gameObject.GetComponent<Rigidbody>().velocity = transform.forward * 15;
        }
    }
}
