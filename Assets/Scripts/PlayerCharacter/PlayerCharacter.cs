using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    string alias;
    float moveSpeed;
    float jumpForce;
    float horizontalAxis;
    Vector2 localScale = new (1,1);
    Vector2 FlippedScale = new(-1,1);
    AnimatorController animatorController;
    public PlayerData playerData;
    public Rigidbody2D rig2d;
    public Animator animator;
    public Transform rt;

    public void Start()
    {
        alias = playerData.alias;
        animatorController = playerData.animatorController;
        moveSpeed = playerData.moveSpeed;
        jumpForce = playerData.jumpForce;
        horizontalAxis = Input.GetAxis("Horizontal");

        rig2d = gameObject.GetComponent<Rigidbody2D>();
        rig2d.gravityScale = playerData.gravityScale;
    }
    void Update()
    {
        Movement();

    }
    public void Movement()
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
        else if(PressLeft() && !animator.GetBool("isAirbourne"))
        {
            rig2d.velocity = new Vector2(horizontalAxis * moveSpeed, rig2d.velocity.y);
        }
        else if(PressPrimaryAttack())
        {
            animator.SetTrigger("PrimaryAttack");
        }
        else if(PressSecondaryAttack())
        {
            animator.SetTrigger("SecondaryAttack");
        }
        else if(PressTertiaryAttack())
        {
            animator.SetTrigger("TertiaryAttack");
        }
    }
    public bool MovingRight()
    {
        return horizontalAxis > 0;
    }
    public bool MovingLeft()
    {
        return horizontalAxis < 0;
    }
    public bool PressUp()
    {
        return
            Input.GetKeyDown(KeyCode.UpArrow) ||
            Input.GetKeyDown(KeyCode.W)
            // || Input.GetButtonDown("Up")
            ;
    }
    public bool PressDown()
    {
        gameObject.GetComponent<Animator>().SetTrigger("DownPress");
        return
            // Input.GetButtonDown("Down") ||
            Input.GetKey(KeyCode.DownArrow) ||
            Input.GetKey(KeyCode.S);
    }
    public bool PressLeft()
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
            !animator.GetBool("isAirbourne");
    }
    public bool PressPrimaryAttack()
    {
        return
            // Input.GetButtonDown("Fire1") ||
            Input.GetKeyDown(KeyCode.F);
    }
    public bool PressSecondaryAttack()
    {
        return
            // Input.GetButtonDown("Fire2") ||
            Input.GetKeyDown(KeyCode.G);
    }
    public bool PressTertiaryAttack()
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


