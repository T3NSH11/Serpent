using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public GameObject enemyspawner;
    public GameObject HUD;
    public GameObject bullet;
    void Start()
    {
        player.GetComponent<player>().enabled = false;
        enemy.GetComponent<enemymovement>().enabled = false;
        enemy.GetComponent<collision>().enabled = false;
        enemyspawner.GetComponent<enemy>().enabled = false;
        HUD.GetComponent<Score>().enabled = false;
        bullet.GetComponent<bullet>().enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.GetComponent<player>().enabled = true;
            enemy.GetComponent<enemymovement>().enabled = true;
            enemy.GetComponent<collision>().enabled = true;
            enemyspawner.GetComponent<enemy>().enabled = true;
            HUD.GetComponent<Score>().enabled = true;
            bullet.GetComponent<bullet>().enabled = true;
            gameObject.GetComponent<start>().enabled = false;
            gameObject.SetActive(false);
            HUD.SetActive(true);
        }
    }
}
