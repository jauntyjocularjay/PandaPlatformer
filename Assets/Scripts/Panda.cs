using System;
using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;



public class Panda : PlayerCharacter
{
    Animator panda;
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Animator>().runtimeAnimatorController = animator;
        panda = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }

    void Update()
    {
        Movement();
    }

    public void Movement()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");

        if(rig.velocity.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if(rig.velocity.x > 0)
        {
            spriteRenderer.flipX = false;
        }

        
        if(JumpPress() && !isAirbourne)
        {
            isAirbourne = true;
            rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        else if(LeftPress() && !isAirbourne)
        {
            rig.velocity = new Vector2(moveInput * moveSpeed, rig.velocity.y);
        }
        else if(RightPress() && !isAirbourne)
        {
            rig.velocity = new Vector2(moveInput * moveSpeed, rig.velocity.y);
        }
        else if(PrimaryAttackPress() && !isAirbourne)
        {
            panda.SetTrigger("PrimaryAttack");
        }
/*
        else if(isAirbourne && DownPress() && PrimaryAttackPress())
        {

        }
*/
/*
        else if(DownPress() && PrimaryAttackPress())
        {

        }
*/
/*
        else if(DownPress() && SecondaryAttackPress())
        {

        }
*/
        else if(SecondaryAttackPress())
        {
            panda.SetTrigger("SecondaryAttack");
        }
/*
        else if(DownPress())
        {

        }
*/
        else if(isAirbourne && PrimaryAttackPress())
        {

        }
        else if(isAirbourne && SecondaryAttackPress())
        {

        }
        else if(isAirbourne && TertiaryAttackPress())
        {

        }
        
    }

}
