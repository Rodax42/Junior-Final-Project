using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : Left // INHERITANCE
{
    [SerializeField]
    float jumpDistance;
    bool onGround = true;
    protected float jumpForce = 900; 
    Rigidbody rbd;
    Animator anim;

    private void Start() {
        direction = Vector3.forward;
        rbd = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    protected override void Move(){ // ABSTRACTION
        if(transform.position.x < jumpDistance && onGround){
            onGround = false;
            rbd.AddForce(Vector3.up*jumpForce,ForceMode.Impulse);
            anim.SetTrigger("Jump_trig");
        }
        base.Move();
    }
}
