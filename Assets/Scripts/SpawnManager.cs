using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> obstacle = new List<GameObject>();
    private Vector3 spawnPos = new Vector3(25,1,0);
    private float spawnStart = 2f;
    private float spawnRepeat = 2f;

    void Start()
    {
        InvokeRepeating("SpawnObstacle", spawnStart, spawnRepeat);
    }

    public void SpawnObstacle(){
        if(PlayerMovement.player.gameOver) return;
        int index = Random.Range(0,2);
        Instantiate(obstacle[index],spawnPos,obstacle[index].transform.rotation);
    }
}
