using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    protected Rigidbody rbd;
    protected float jumpForce = 600; 
    protected float gravity = 2; 
    public bool onGround, gameOver;
    public static PlayerMovement player {get;private set;} // ENCAPSULATION
    protected Animator anim;
    [SerializeField]
    protected ParticleSystem explosionParticle; // ENCAPSULATION
    [SerializeField]
    protected ParticleSystem dirtSplatter; // ENCAPSULATION
    [SerializeField]
    protected AudioClip jumpS; // ENCAPSULATION
    [SerializeField]
    protected AudioClip crashS; // ENCAPSULATION
    protected AudioSource aS; 
    [SerializeField]
    private bool hasShield; // ENCAPSULATION

    void Start()
    {
        rbd = GetComponent<Rigidbody>();
        Physics.gravity *= gravity;
        player = this;
        anim = GetComponent<Animator>();
        aS = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(gameOver) return;
        if(Input.GetKeyDown(KeyCode.Space)){
            Jump(); // ABSTRACTION
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Ground") && !gameOver){
            Grounded(); // ABSTRACTION
        }
        else if (other.gameObject.CompareTag("Obstacle")){
            if(hasShield){
                Crash(other); // ABSTRACTION
            } else {
                Crash(); // ABSTRACTION
            }
        }
    }

    protected virtual void Jump(){ //POLYMORPHISM
        if(!onGround) return;
        rbd.AddForce(Vector3.up*jumpForce,ForceMode.Impulse);
        anim.SetTrigger("Jump_trig");
        onGround = false;
        dirtSplatter.Stop();
        aS.PlayOneShot(jumpS, 1f);
    }

    protected void Crash(){ //POLYMORPHISM
        if(gameOver) return;
        anim.SetBool("Death_b",true);
        anim.SetInteger("DeathType_int",1);
        gameOver = true;
        explosionParticle.Play();
        dirtSplatter.Stop();
        aS.PlayOneShot(crashS, 1f);
    }

    protected void Crash(Collision other){ //POLYMORPHISM
        if(gameOver) return;
        hasShield = false;
        Destroy(other.gameObject);
    }

    protected virtual void Grounded(){ //POLYMORPHISM
        onGround = true;
        dirtSplatter.Play();
    }
}
