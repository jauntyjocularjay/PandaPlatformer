using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Background : MonoBehaviour
{
    List<RectTransform>[] backgroundRects;
    public GameObject[] backgroundObject;
    FractionScale scrollProgress = new(0,128);
    public bool scrollLeft = true;
    public float deltaX;
    // deltaX Background A: 30.42
    // deltaX Background A: 32
    Camera cam;
    float camHeight;
    float camWidth;

    void Start()
    {
        cam = Camera.main;
        camHeight = 2f * cam.orthographicSize;
        camWidth = camHeight * cam.aspect;

    }

    void FixedUpdate()
    {
        ScrollB();
    }
    void ScrollA()
    {
        // for(int i = 0; i < backgroundRects.Length; i++)
        // {
        //     backgroundRects[i].position = 
        //         new Vector2(
        //             scrollProgress.ToFloat() * -32,
        //             backgroundRects[i].position.y
        //         );
            
        //     if(scrollProgress.Full())
        //     {
        //         scrollProgress.SetNumerator(0);
        //         backgroundRects[i].position = 
        //             new Vector2(
        //                 0,
        //                 backgroundRects[i].position.y
        //             );
        //     }
        //     else 
        //     {
        //         scrollProgress.Increment(1);
        //     }
        // }
    }
    void ScrollB()
    {
        Vector2 newPosition;
        Vector2 currentPosition;
        float spriteWidth = 0f;
        float direction = scrollLeft ? -1 : 1;

        for(int i = 0; i < backgroundObject.Length; i++)
        {
            currentPosition = backgroundObject[i].GetComponent<RectTransform>().position;
            SpriteRenderer[] renderers = backgroundObject[i].GetComponentsInChildren<SpriteRenderer>();

            for(int j = 0; j < renderers.Length; j++)
            {
                spriteWidth += renderers[j].size.x;
            }

            newPosition = new Vector2(
                direction * deltaX * scrollProgress.ToFloat(),
                0f 
            );

            Debug.Log(
                $"direction: {direction} \n" +
                $"scrollProgress.ToFloat(): {scrollProgress} \n"
            );
            // Debug.Log($"scrollProgress: {scrollProgress}");
            // Debug.Log($"scrollProgress: {scrollProgress}");
            // Debug.Log($"scrollProgress: {scrollProgress}");
            // Debug.Log($"scrollProgress: {scrollProgress}");
            // Debug.Log($"scrollProgress: {scrollProgress}");
            backgroundObject[i].GetComponent<RectTransform>().position = newPosition;
        }

        if(scrollProgress.Full())
            scrollProgress.SetNumerator(0);
        else
            scrollProgress.Increment();

    }

}
