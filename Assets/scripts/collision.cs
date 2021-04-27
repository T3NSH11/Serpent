using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    public GameObject enemyobj;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

        void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("bullet"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
