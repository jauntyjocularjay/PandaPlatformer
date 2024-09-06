using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public ProjectileData projectile;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rig2d;
    Collider2D projectileCollider;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        projectileCollider = gameObject.GetComponent<PolygonCollider2D>();
        rig2d = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer.sprite = projectile.sprite;
    }
}
