using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public float horizontalAxis = 0f;
    public float verticalAxis = 0f;
    public bool isAirbourne = false;
    public Rigidbody2D rig;

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
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(Vector2.Dot(collision.GetContact(0).normal, Vector2.up) < 0.1f)
        {
            isAirbourne = true;
        }
        else
        {
            isAirbourne = false;
        }
    }
}


