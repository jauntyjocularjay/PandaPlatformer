using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public RectTransform[] backgrounds;
    FractionScale scrollProgress = new(0,512);
    void Start()
    {
        // backgrounds = gameObject.GetComponentsInChildren<RectTransform>();
    }

    void FixedUpdate()
    {
        for(int i = 0; i < backgrounds.Length; i++)
        {
            backgrounds[i].position = 
                new Vector2(
                    scrollProgress.ToFloat() * -32,
                    backgrounds[i].position.y
                );
            if(scrollProgress.Full())
            {
                scrollProgress.SetNumerator(0);
                backgrounds[i].position = 
                    new Vector2(
                        0,
                        backgrounds[i].position.y
                    );
            }
            else 
            {
                scrollProgress.Increment(1);
            }
            Debug.Log($"{backgrounds[i].position.ToString()}");
            Debug.Log(scrollProgress.ToString());
        }




    }


}
