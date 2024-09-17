using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Background : MonoBehaviour
{
    public GameObject[] gameObjects;
    public BackgroundData[] backgroundData;
    SpriteRenderer[] spriteRenderers;
    RectTransform[] rectTransforms;
    RectTransform rect;
    readonly FractionScale scrollProgress = new(0,512);
    public bool scrollLeft = true;
    float direction;
    Camera cam;
    float camHeight;
    float cameraWidth;
    float cameraFieldOfViewCosine;
    float spriteWidths = 0f;
    float viewOfFieldWidth;

    void Start()
    {
        direction = scrollLeft ? -1 : 1;

        cam = Camera.main;
        camHeight = 2f * cam.orthographicSize;
        cameraWidth = camHeight * cam.aspect;
        rectTransforms = gameObject.GetComponentsInChildren<RectTransform>();
        viewOfFieldWidth = cameraWidth * cameraFieldOfViewCosine;

        cameraFieldOfViewCosine = -math.cos(cam.fieldOfView);
    }

    void FixedUpdate()
    {
        ScrollC();
    }

    void IncrementOrReset(RectTransform rect)
    {
        if(scrollProgress.Full())
        {
            rect.position = new Vector2(0,0);
            scrollProgress.SetNumerator(0);
        }
        else
        {
            scrollProgress.Increment();
        }
    }

    void Scroll()
    {
        
        foreach (RectTransform rect in rectTransforms)
        {
            rect.position = new Vector2(
                direction * cameraWidth * cameraFieldOfViewCosine * scrollProgress.ToFloat(),
                0f
            );


        }



        
    }

    void ScrollB()
    /*
        backgroundA DeltaPostionX ~ > 40
        backgroundB DeltaPostionX ~ > 96
        
    */

    {
        float spriteLocalBoundsX = 0f;
        SpriteRenderer[] spriteRenderers;
        float scrollWidth;
        float xPosition;

        for(int i = 0; i < gameObjects.Length; i++)
        {
            spriteRenderers = gameObjects[i].GetComponentsInChildren<SpriteRenderer>();

            foreach(SpriteRenderer renderer in spriteRenderers)
            {
                spriteLocalBoundsX += renderer.localBounds.size.x;
            }

            scrollWidth = spriteLocalBoundsX - (cameraWidth * cameraFieldOfViewCosine % spriteLocalBoundsX);
            xPosition = direction * scrollWidth * scrollProgress.ToFloat();

            foreach(RectTransform rect in rectTransforms)
            {
                rect.position = new (
                    xPosition,
                    0f,
                    0f
                );
            }

            scrollWidth = 0f;

            Debug.Log(
                // $"scrollProgress: {scrollProgress} \n" + 
                $"spriteWidths: {spriteLocalBoundsX} \n" +
                $"cameraWidth: {cameraWidth * cameraFieldOfViewCosine} \n" +
                $"scrollWidth: {scrollWidth} \n" + 
                $"xPosition: {xPosition}"
            );
            


            if(scrollProgress.Full())
            {
                scrollProgress.SetNumerator(0);
                rectTransforms[i].position = new(0,0,0);
            }
            else
            {
                scrollProgress.Increment();
            }
        }

    }

    void ScrollC()
    {
        foreach(GameObject gameObj in gameObjects)
        {
            spriteRenderers = gameObj.GetComponentsInChildren<SpriteRenderer>();
            rect = gameObj.GetComponent<RectTransform>();

            foreach(SpriteRenderer renderer in spriteRenderers)
            {
                spriteWidths += renderer.sprite.texture.width;
            }

            float chopOff = spriteWidths % cameraWidth;

            int repeatsPerScroll = spriteWidths < cameraWidth
                ? (int) (cameraWidth / spriteWidths)
                : (int) (spriteWidths / cameraWidth);

            float scrollWidth =  0f;

            rect.position = new(
                direction * scrollWidth * scrollProgress.ToFloat(),
                0
            );
            IncrementOrReset(rect);

            Debug.Log(
                $"cameraWidth: {cameraWidth} \n"+
                $"fieldOfViewWidth: {viewOfFieldWidth} \n"+
                // $"fieldOfViewWidth: {viewOfFieldWidth} \n"+
                // $"fieldOfViewWidth: {viewOfFieldWidth} \n"+
                // $"fieldOfViewWidth: {viewOfFieldWidth} \n"+
                $"spriteWidths: {spriteWidths} \n" + 
                $"chopOff: {chopOff} \n" + 
                $"scrollWidth: {scrollWidth} \n" + 
                $"scrollProgress.ToFloat(): {scrollProgress.ToFloat()} \n" + 
                $"direction: {direction} \n"
            );


            spriteWidths = 0f;
        }
    }
    void ScrollD()
    {
        foreach(GameObject gameObj in gameObjects)
        {
            spriteRenderers = gameObj.GetComponentsInChildren<SpriteRenderer>();
            rect = gameObj.GetComponent<RectTransform>();
            float scrollDistance = 0f;

            SpriteRenderer renderer;

            foreach(SpriteRenderer sprite in spriteRenderers)
            {
                spriteWidths += sprite.size.x;
            }

            if(/* if there is only 1 SpriteRenderer and that renderer is tiled && adaptive */
                spriteRenderers.Length == 1 && 
                spriteRenderers[0].drawMode == SpriteDrawMode.Tiled &&
                spriteRenderers[0].tileMode == SpriteTileMode.Adaptive
            )
            {
                renderer = spriteRenderers[0];

                /* if the renderer is bigger or smaller than the cameraWidth */
                if(renderer.size.x > cameraWidth && renderer.size.x % cameraWidth < 0f)
                {
                    renderer.size = new Vector2(
                        2 * cameraWidth + (renderer.size.x - cameraWidth),
                        0
                    );

                }
                else if(renderer.size.x > cameraWidth && renderer.size.x % cameraWidth < 0f)
                {
                    renderer.size = new Vector2(
                        2 * (renderer.size.x / cameraWidth + 1),
                        0
                    );
                }

                scrollDistance = renderer.size.x - cameraWidth;

                rect.position = new Vector2(
                    direction * scrollDistance * scrollProgress.ToFloat(),
                    0f
                );
            }
            else if (spriteWidths > cameraWidth && spriteWidths % cameraWidth > 0)
            {
                scrollDistance = (spriteWidths / cameraWidth + 1);
                // rect.position = new Vector2(
                //     ,
                //     0
                // );

            }
            else
            {
                
            }



            float scrollWidth = 0;

            rect.position = new(
                direction * scrollWidth * scrollProgress.ToFloat(),
                0
            );
            IncrementOrReset(rect);
            spriteWidths = 0f;
        }
    }

}
