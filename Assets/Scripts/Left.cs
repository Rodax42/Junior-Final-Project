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
    [SerializeField]
    private ParticleSystem explosion;

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

    private void OnDestroy() {
        if(gameObject.tag == "Obstacle"){
            ParticleSystem particle = Instantiate(explosion,transform.position,explosion.transform.rotation);
            particle.Play();
        }
    }
}
