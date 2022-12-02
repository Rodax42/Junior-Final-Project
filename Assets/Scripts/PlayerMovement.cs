using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    protected Rigidbody rbd;
    protected float jumpForce = 600;
    protected float gravity = 2;
    public bool onGround, gameOver;
    public static PlayerMovement player {get;private set;}
    protected Animator anim;
    [SerializeField]
    protected ParticleSystem explosionParticle;
    [SerializeField]
    protected ParticleSystem dirtSplatter;
    [SerializeField]
    protected AudioClip jumpS;
    [SerializeField]
    protected AudioClip crashS;
    protected AudioSource aS;

    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody>();
        Physics.gravity *= gravity;
        player = this;
        anim = GetComponent<Animator>();
        aS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver) return;
        if(Input.GetKeyDown(KeyCode.Space)){
            Jump();
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Ground") && !gameOver){
            Grounded();
        }
        else if (other.gameObject.CompareTag("Obstacle")){
            Crash();
        }
    }

    protected virtual void Jump(){
        if(!onGround) return;
        rbd.AddForce(Vector3.up*jumpForce,ForceMode.Impulse);
        anim.SetTrigger("Jump_trig");
        onGround = false;
        dirtSplatter.Stop();
        aS.PlayOneShot(jumpS, 1f);
    }

    protected void Crash(){
        if(gameOver) return;
        anim.SetBool("Death_b",true);
        anim.SetInteger("DeathType_int",1);
        gameOver = true;
        explosionParticle.Play();
        dirtSplatter.Stop();
        aS.PlayOneShot(crashS, 1f);
    }

    protected virtual void Grounded(){
        onGround = true;
        dirtSplatter.Play();
    }
}
