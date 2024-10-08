using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public float horizontalAxis = 0f;
    public bool isAirbourne = false;
    public float moveSpeed = 5.0f;
    public float jumpForce = 8.0f;
    Vector2 localScale = new (1,1);
    public Rigidbody2D rig2d;
    public AnimatorController animatorController;
    public Animator animator;
    public Transform rt;

    public void Start()
    {
        GetRigidBody();
    }

    void Update()
    {
        horizontalAxis = Input.GetAxis("Horizontal");

        if(MovingLeft())
        {
            rt.localScale = new Vector2(-localScale.x,localScale.y);
        } else if (MovingRight())
        {
            rt.localScale = new Vector2(localScale.x,localScale.y);
        }

        if(JumpPress() && !animator.GetBool("isAirbourne"))
        {
            animator.SetBool("isAirbourne", true);
            rig2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        else if(RightPress() && !animator.GetBool("isAirbourne"))
        {
            rig2d.velocity = new Vector2(horizontalAxis * moveSpeed, rig2d.velocity.y);
        }
        else if(LeftPress() && !animator.GetBool("isAirbourne"))
        {
            rig2d.velocity = new Vector2(horizontalAxis * moveSpeed, rig2d.velocity.y);
        }

    }
    public void GetRigidBody()
    {
        rig2d = gameObject.GetComponent<Rigidbody2D>();
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
    public bool MovingRight()
    {
        return horizontalAxis > 0;
    }
    public bool MovingLeft()
    {
        return horizontalAxis < 0;
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
            !animator.GetBool("isAirbourne");
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
            animator.SetBool("isAirbourne", false);
        }
    }
}


