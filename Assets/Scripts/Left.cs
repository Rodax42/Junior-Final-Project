using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left : MonoBehaviour
{
    public float speed = 30;
    public float outOfBounds = -15;

    void Update()
    {
        if(PlayerMovement.player.gameOver) return;
        transform.Translate(Vector3.left*Time.deltaTime*speed);
        if(gameObject.tag == "Obstacle" && transform.position.x < outOfBounds){
            Destroy(gameObject);
        }
    }
}
