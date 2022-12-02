using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rbd;
    public float jumpForce = 100;
    public float gravity;
    public bool onGround, gameOver;
    public static PlayerMovement player;
    Animator anim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtSplatter;
    public AudioClip jumpS;
    public AudioClip crashS;
    AudioSource aS;

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
        if(PlayerMovement.player.gameOver) return;
        if(Input.GetKeyDown(KeyCode.Space) && onGround){
            rbd.AddForce(Vector3.up*jumpForce,ForceMode.Impulse);
            anim.SetTrigger("Jump_trig");
            onGround = false;
            dirtSplatter.Stop();
            aS.PlayOneShot(jumpS, 1f);
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Ground") && !gameOver){
            onGround = true;
            dirtSplatter.Play();
        }
        else if (other.gameObject.CompareTag("Obstacle")){
            anim.SetBool("Death_b",true);
            anim.SetInteger("DeathType_int",1);
            gameOver = true;
            Debug.Log("GameOver");
            explosionParticle.Play();
            dirtSplatter.Stop();
            aS.PlayOneShot(crashS, 1f);
        }
    }
}
