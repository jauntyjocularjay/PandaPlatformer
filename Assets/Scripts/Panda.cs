using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panda : PlayerCharacter
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Action();
    }

    public void Action()
    {
        if(DownPress() && PrimaryAttackPress())
        {

        }
        else if(DownPress() && SecondaryAttackPress())
        {

        }
        else if(airbourne && LeftPress())
        {

        }
        else if(LeftPress())
        {

        }
        else if(airbourne && RightPress())
        {

        }
        else if(RightPress())
        {

        }
        else if(airbourne && DownPress() && PrimaryAttackPress())
        {

        }
        else if(airbourne && PrimaryAttackPress())
        {

        }
        else if(airbourne && SecondaryAttackPress())
        {

        }
        else if(PrimaryAttackPress())
        {

        }
        else if(SecondaryAttackPress())
        {

        }
        else if(DownPress())
        {

        }
    }

}
