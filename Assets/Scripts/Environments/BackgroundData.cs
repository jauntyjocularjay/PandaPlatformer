using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
// using static FractionScale;



[CreateAssetMenu(menuName = "ScriptableObjects/BackgroundData")]
public class BackgroundData : ScriptableObject
{
    public string alias;
    public Sprite[] sprites;

    public float GetRotation()
    {
        float rotation = 0f;

        foreach(Sprite sprite in sprites)
            rotation += sprite.bounds.size.x;

        return rotation;
    }

}


