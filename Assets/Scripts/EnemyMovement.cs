using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : Left // INHERITANCE
{
    [SerializeField]
    private float jumpDistance; // ENCAPSULATION
    private bool onGround = true;
    protected float jumpForce = 900; 
    private Rigidbody rbd;
    private Animator anim;
    private bool death = false;

    private void Start() {
        direction = Vector3.forward;
        rbd = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    protected override void Move(){ // POLYMORPHISM
        if(transform.position.x < jumpDistance && onGround){
            onGround = false;
            rbd.AddForce(Vector3.up*jumpForce,ForceMode.Impulse);
            anim.SetTrigger("Jump_trig");
        }
        base.Move();
    }

     private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Player") && !death){
            anim.SetBool("Death_b",true);
            anim.SetInteger("DeathType_int",1);
            rbd.velocity = Vector3.zero;
        }
    }
}
