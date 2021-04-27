using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public GameObject enemyobj;
    GameObject[] enemyspawnref;
    GameObject enemyspawnpointt;
    public bool spawnenemy = false;
    Vector3 enemyspawnpoint = new Vector3 (0, 0.85f,0);
    float spawntimer;

    void Start()
    {
        enemyspawnref = GameObject.FindGameObjectsWithTag("ground block");
    }

    void Update()
    {
        int spawnnum = Random.Range(0, 200);
        spawntimer += Time.deltaTime;
        enemyspawnpointt = enemyspawnref[spawnnum];

        Debug.Log(spawntimer);

        if (spawntimer > 4.0f)
        {
            spawnenemy = true;
        }

        if (spawnenemy == true)
        {
            GameObject clone = Instantiate(enemyobj);
            clone.transform.position = enemyspawnpointt.transform.position + enemyspawnpoint;
            spawnenemy = false;
            spawntimer = 0f;
        }
    }

    void OnCollisionEnter (Collision collision)
    {
        if(collision.gameObject.CompareTag("bullet"))
        {
            Destroy(enemyobj);

        }

        if(collision.gameObject.CompareTag("top border"))
        {
            enemyobj.transform.position = new Vector3(enemyobj.gameObject.transform.position.x, enemyobj.gameObject.transform.position.y, enemyobj.gameObject.transform.position.z - 11.3f);
        }

        if(collision.gameObject.CompareTag("bottom border"))
        {
            enemyobj.transform.position = new Vector3(enemyobj.gameObject.transform.position.x, enemyobj.gameObject.transform.position.y, enemyobj.gameObject.transform.position.z + 11.3f);
        }

        if(collision.gameObject.CompareTag("left border"))
        {
            enemyobj.transform.position = new Vector3(enemyobj.gameObject.transform.position.x + 22.5f, enemyobj.gameObject.transform.position.y, enemyobj.gameObject.transform.position.z);
        }

        if(collision.gameObject.CompareTag("right border"))
        {
            enemyobj.transform.position = new Vector3(enemyobj.gameObject.transform.position.x - 22.5f, enemyobj.gameObject.transform.position.y, enemyobj.gameObject.transform.position.z);
        }
    }
}
