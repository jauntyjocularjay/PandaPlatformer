using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Background : MonoBehaviour
{
    public GameObject[] gameObjects;
    public BackgroundData[] backgroundData;
    RectTransform[] rectTransforms;
    readonly FractionScale scrollProgress = new(0,512);
    public bool scrollLeft = true;
    float direction;
    Camera cam;
    float camHeight;
    float cameraWidth;
    float cameraFieldOfViewCosine;

    void Start()
    {
        direction = scrollLeft ? -1 : 1;

        cam = Camera.main;
        camHeight = 2f * cam.orthographicSize;
        cameraWidth = camHeight * cam.aspect;
        cameraFieldOfViewCosine = -math.cos(cam.fieldOfView);
        rectTransforms = gameObject.GetComponentsInChildren<RectTransform>();
    }

    void FixedUpdate()
    {
        ScrollB();
    }

    void Scroll()
    {
        
        foreach (RectTransform rect in rectTransforms)
        {
            rect.position = new Vector2(
                direction * cameraWidth * cameraFieldOfViewCosine * scrollProgress.ToFloat(),
                0f
            );

            if(!scrollProgress.Full())
            {
                scrollProgress.Increment();
            }
            else
            {
                rect.position = new Vector2(0,0);
                scrollProgress.SetNumerator(0);
            }
        }



        
    }

    void ScrollB()
    {
        float spriteWidths = 0f;
        float rotation = 0f;
        SpriteRenderer[] spriteRenderers;

        for(int i = 0; i < gameObjects.Length; i++)
        {
            foreach(Sprite sprite in backgroundData[i].sprites)
            {
                rotation += sprite.bounds.size.x;
            }

            
        }

    }

}
