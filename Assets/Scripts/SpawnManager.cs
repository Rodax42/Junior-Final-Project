using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstacle;
    public Vector3 spawnPos = new Vector3(25,0,0);
    public float spawnStart = 2f;
    public float spawnRepeat = 2f;

    void Start()
    {
        InvokeRepeating("SpawnObstacle", spawnStart, spawnRepeat);
    }

    public void SpawnObstacle(){
        if(PlayerMovement.player.gameOver) return;
        Instantiate(obstacle,spawnPos,obstacle.transform.rotation);
    }
}
