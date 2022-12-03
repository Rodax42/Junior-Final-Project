using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left : MonoBehaviour
{
    [SerializeField]
    protected float speed = 30; // ENCAPSULATION
    [SerializeField]
    private float outOfBounds = -15; // ENCAPSULATION

    void Update()
    {
        if(PlayerMovement.player.gameOver) return;
        Move(); // ABSTRACTION
    }

    protected virtual void Move(){ // ABSTRACTION
        transform.Translate(Vector3.left*Time.deltaTime*speed);
        if(gameObject.tag == "Obstacle" && transform.position.x < outOfBounds){
            Destroy(gameObject);
        }
    }
}
