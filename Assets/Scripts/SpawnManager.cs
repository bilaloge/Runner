using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstacleprafabs;
    private Vector3 spawnPosition = new Vector3(25,0,0);
    private float startDelay = 2;
    private float repeatRate = 2;
    private PlayerController playerControllerScript;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        playerControllerScript=GameObject.Find("Player").GetComponent<PlayerController>();
    }
    void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
            int ramNum = Random.Range(0, obstacleprafabs.Length);
            Instantiate(obstacleprafabs[ramNum], spawnPosition, obstacleprafabs[ramNum].transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
