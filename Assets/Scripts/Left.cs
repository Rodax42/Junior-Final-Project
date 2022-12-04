using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left : MonoBehaviour
{
    [SerializeField]
    protected float speed = 30; // ENCAPSULATION
    [SerializeField]
    protected float outOfBounds = -15; // ENCAPSULATION
    protected Vector3 direction;

    private void Start() {
        direction = Vector3.left;
    }

    void Update()
    {
        if(PlayerMovement.player.gameOver) return;
        Move(); // ABSTRACTION
    }

    protected virtual void Move(){ // ABSTRACTION
        transform.Translate(direction*Time.deltaTime*speed);
        if(gameObject.tag == "Obstacle" && transform.position.x < outOfBounds){
            Destroy(gameObject);
        }
    }
}
