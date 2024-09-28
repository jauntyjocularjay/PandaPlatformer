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
    public SpriteRenderer[] backgroundSegmentA;
    public SpriteRenderer[] backgroundSegmentB;
    List<SpriteRenderer[]> backgroundSegment;
    SpriteRenderer[] spriteRenderers;
    RectTransform[] rectTransforms;
    RectTransform rect;
    readonly FractionScale scrollProgress = new FractionScale(0,512);
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
        
        backgroundSegment.Add(backgroundSegmentA);
        backgroundSegment.Add(backgroundSegmentB);

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

    static float CalculateSegment(SpriteRenderer[] renderers)
    {
        float segmentWidth = 0f;
        
        foreach(SpriteRenderer renderer in renderers)
        {
            segmentWidth += renderer.size.x;
        }
        
        return segmentWidth;
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

    void ScrollC()
	{
		int i = 0;
        foreach(GameObject gameObj in gameObjects)
        {
            spriteRenderers = gameObj.GetComponentsInChildren<SpriteRenderer>();
            rect = gameObj.GetComponent<RectTransform>();

            foreach(SpriteRenderer renderer in spriteRenderers)
            {
                spriteWidths += renderer.sprite.texture.width;
            }

	        float scrollWidth =  0f;
            
	        float rotation = scrollWidth >= cameraWidth
	        	? scrollWidth - (scrollWidth % cameraWidth)
	        	: cameraWidth - (cameraWidth % scrollWidth);

	        if(scrollWidth > cameraWidth){
                rect.position = new Vector2(
                    direction * cameraWidth * scrollProgress.ToFloat(),
                    0
                );
            }
            else
            {
                
            }
            
            
            
            
            IncrementOrReset(rect);

            spriteWidths = 0f;
        }
    }
}


