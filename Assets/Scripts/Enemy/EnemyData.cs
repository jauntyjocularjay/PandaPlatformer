using System;
using UnityEditor.Animations;
using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObjects/EnemyData")]
public class EnemyData : ScriptableObject
{
    public String alias;
    public AnimatorController animatorController;
    public float moveSpeed;
    public float jumpForce;
    public float gravityScale;

    public void Movement()
    {

    }

}
