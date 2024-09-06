using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/ProjectileData")]
public class ProjectileData : ScriptableObject
{
    public string alias;
    public AnimatorController animatorController;
    public Sprite sprite;
    public float moveSpeed;
    public float gravityScale;
}