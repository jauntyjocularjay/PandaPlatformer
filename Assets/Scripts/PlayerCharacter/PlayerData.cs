using System;
using UnityEditor.Animations;
using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObjects/PlayerData")]
public class PlayerData : ScriptableObject
{
    public String alias;
    public AnimatorController animatorController;
    public float moveSpeed;
    public float jumpForce;
    public float gravityScale;
    public bool isAirbourne = false;

    public void Movement()
    {

    }

}
