using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public GameObject enemyobj;
    GameObject[] enemyspawnref;
    GameObject enemyspawnpointt;
    public bool spawnenemy = false;
    Vector3 enemyspawnpoint = new Vector3 (0, 1.5f,0);
    float spawntimer;
    void Start()
    {
        enemyspawnref = GameObject.FindGameObjectsWithTag("ground block");
    }

    // Update is called once per frame
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
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("bullet"))
        {
            Destroy(enemyobj);
        }
    }
}
