using UnityEditor.Animations;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public float horizontalAxis = 0f;
    public float verticalAxis = 0f;
    public bool isAirbourne = false;
    public Rigidbody2D rig;
    public float moveSpeed = 1.0f;
    public float jumpForce = 5.0f;
    public AnimatorController animator;

    void Start()
    {
        GetRigidBody();
    }
    public void GetRigidBody()
    {
        rig = gameObject.GetComponent<Rigidbody2D>();
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
        gameObject.GetComponent<Animator>().SetTrigger("DownPress");
        return
            // Input.GetButtonDown("Down") ||
            Input.GetKey(KeyCode.DownArrow) ||
            Input.GetKey(KeyCode.S);
    }
    public bool LeftPress()
    {
        return
            // Input.GetButtonDown("Left") ||
            Input.GetKey(KeyCode.LeftArrow) ||
            Input.GetKey(KeyCode.A);
    }
    public bool RightPress()
    {
        return
            // Input.GetButtonDown("Right") ||
            Input.GetKey(KeyCode.RightArrow) ||
            Input.GetKey(KeyCode.D);
    }
    public bool JumpPress()
    {
        return
            // Input.GetButton("Jump") ||
            Input.GetKeyDown(KeyCode.Space) &&
            !isAirbourne;
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
    public bool TertiaryAttackPress()
    {
        return
            // Input.GetButtonDown("Fire2") ||
            Input.GetKeyDown(KeyCode.T);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(Vector2.Dot(collision.GetContact(0).normal, Vector2.up) > 0.8f)
        {
            isAirbourne = false;
        }
    }
}


