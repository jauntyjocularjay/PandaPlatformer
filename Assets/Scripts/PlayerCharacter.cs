using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerCharacter : MonoBehaviour
{
    public int horizontal = 0;
    public int vertical = 0;
    public bool airbourne = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public bool Up()
    {
        return
            Input.GetKeyDown(KeyCode.UpArrow) ||
            Input.GetKeyDown(KeyCode.W)
            // || Input.GetButtonDown("Up")
            ;
    }
    public bool DownPress()
    {
        return
            Input.GetKeyDown(KeyCode.DownArrow) ||
            Input.GetKeyDown(KeyCode.S)
            // || Input.GetButtonDown("Down")
            ;
    }
    public bool LeftPress()
    {
        return
            // Input.GetButtonDown("Left") ||
            Input.GetKeyDown(KeyCode.LeftArrow) ||
            Input.GetKeyDown(KeyCode.A);
    }
    public bool RightPress()
    {
        return
            // Input.GetButtonDown("Right") ||
            Input.GetKeyDown(KeyCode.RightArrow) ||
            Input.GetKeyDown(KeyCode.D);
    }
    public bool Jump()
    {
        return
            // Input.GetButtonDown("Jump") ||
            Input.GetKeyDown(KeyCode.Space);
    }
    public bool PrimaryAttackPress()
    {
        return
            // Input.GetButtonDown("Fire1") ||
            Input.GetKeyDown(KeyCode.F);
    }
    public bool SecondaryAttackPress()
    {
        return
            // Input.GetButtonDown("Fire2") ||
            Input.GetKeyDown(KeyCode.G);
    }
}

public interface IPlayerCharacter
{
    void Start(){}
    void Action(){}
}