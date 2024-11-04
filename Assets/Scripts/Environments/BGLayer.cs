using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGLayer : MonoBehaviour
{
    SpriteRenderer[] spriteRenderers;
    public SpriteTileMode tileMode;
    public float layerWidth = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderers = gameObject.GetComponentsInChildren<SpriteRenderer>();
        SetTileMode();
        SetLayerWidth(layerWidth);
    }

    void SetLayerWidth(float desiredWidth)
    /*
        @method SetLayerWidth
            if the renderers are contunious, adds together and returns the combined widths of the 
            SpriteRenderers that make up the layer.
            if the renderers are adaptive, sets the width to the desired width.
    */
    {
        if(tileMode == SpriteTileMode.Adaptive)
        {
            foreach(SpriteRenderer renderer in spriteRenderers)
            {
                renderer.size = new (
                    desiredWidth,
                    renderer.size.y
                );
            }
        }
        else
        {
            foreach(SpriteRenderer renderer in spriteRenderers)
            {
                layerWidth += renderer.size.x;
            }
        }
    }

    void SetTileMode()
    /*
        @method SetTileMode
            determines how to treat the SpriteRenderers in a layer. If all of the layers are 
            adaptive, it will set to adaptive. If a single renderer is set to "continuous", 
            they will all be treated as continuous.
    */
    {
        foreach(SpriteRenderer renderer in spriteRenderers)
        {
            if(renderer.tileMode == SpriteTileMode.Adaptive)
            {
                tileMode = SpriteTileMode.Adaptive;
            }
            else
            {
                tileMode = SpriteTileMode.Continuous;
                return;
            }
        }
    }

}
