using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    string alias;
    float moveSpeed;
    float jumpForce;
    float horizontalAxis;
    Vector2 localScale = new (1,1);
    Vector2 FlippedScale = new(-1,1);
    AnimatorController animatorController;
    public EnemyData enemyData;
    public Rigidbody2D rig2d;
    public Animator animator;
    public Transform rt;

    public void Start()
    {
        alias = enemyData.alias;
        animatorController = enemyData.animatorController;
        moveSpeed = enemyData.moveSpeed;
        jumpForce = enemyData.jumpForce;
        horizontalAxis = Input.GetAxis("Horizontal");

        rig2d = gameObject.GetComponent<Rigidbody2D>();
        rig2d.gravityScale = enemyData.gravityScale;
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

        /*
        if(true)
        {
            animator.SetBool("isAirbourne", true);
            rig2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        else if(true)
        {
            rig2d.velocity = new Vector2(horizontalAxis * moveSpeed, rig2d.velocity.y);
        }
        else if(true)
        {
            rig2d.velocity = new Vector2(horizontalAxis * moveSpeed, rig2d.velocity.y);
        }
        else if(true)
        {
            Attack();
        }
        */
    }
    public bool MovingRight()
    {
        return horizontalAxis > 0;
    }
    public bool MovingLeft()
    {
        return horizontalAxis < 0;
    }
    public void Drop()
    {
        animator.SetTrigger("drop");
    }
    public void Charge()
    {
        animator.SetTrigger("charge");
    }
    public void Jump()
    {
        animator.SetTrigger("jump");
    }
    public void Attack()
    {
        animator.SetTrigger("attack");
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(Vector2.Dot(collision.GetContact(0).normal, Vector2.up) > 0.8f)
        {
            animator.SetBool("isAirbourne", false);
        }
    }
}


