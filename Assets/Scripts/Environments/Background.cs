using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Background : MonoBehaviour
{
    public GameObject[] backgroundObjects;
    // public SpriteRenderer spriteRenderers;
    readonly FractionScale scrollProgress = new(0,128);
    public bool scrollLeft = true;
    float direction;
    Camera cam;
    float camHeight;
    float camWidth;
    float cameraFieldOfViewCosine;



    void Start()
    {
        direction = scrollLeft ? -1 : 1;

        cam = Camera.main;
        camHeight = 2f * cam.orthographicSize;
        camWidth = camHeight * cam.aspect;
        cameraFieldOfViewCosine = -math.cos(cam.fieldOfView);
    }

    void FixedUpdate()
    {
        Scroll();
    }

    void Scroll()
    {
        foreach (GameObject background in backgroundObjects)
        {
            RectTransform rect = background.GetComponent<RectTransform>();
            rect.position = new Vector2(
                direction * camWidth * cameraFieldOfViewCosine * scrollProgress.ToFloat(),
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

}
