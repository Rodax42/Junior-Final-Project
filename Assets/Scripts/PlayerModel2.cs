using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel2 : PlayerMovement
{
    int jumpCount = 0;

    protected override void Grounded()
    {
        jumpCount = 0;
        base.Grounded();
    }

    protected override void Jump()
    {
        if(jumpCount>1) return;
        jumpCount++;
        rbd.AddForce(Vector3.up*jumpForce,ForceMode.Impulse);
        anim.SetTrigger("Jump_trig");
        onGround = false;
        dirtSplatter.Stop();
        aS.PlayOneShot(jumpS, 1f);
    }
}
