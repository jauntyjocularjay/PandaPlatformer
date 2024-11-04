using Unity.Mathematics;
using UnityEngine;

public class Background : MonoBehaviour
{
    public Segment[] segmentData;
    public SpriteRenderer[] backgroundSegmentRenderer;
    public RectTransform[] rectTransform;
    public int increments;
    UFractionScale scrollProgress;
    public bool scrollLeft = true;
    private float direction;
    Camera cam;
    float widthOfView;

    void Start()
    {
        scrollProgress = new UFractionScale(0, increments);

        direction = scrollLeft ? -1.0f : 1.0f;

        rectTransform = gameObject.GetComponentsInChildren<RectTransform>();
        
        widthOfView = WidthOfView();
    }

    float WidthOfView()
    {
        cam = Camera.main;
        float camHeight = 2.0f * cam.orthographicSize;
        float cameraWidth = camHeight * cam.aspect;
        float cameraFieldOfViewCosine = -math.cos(cam.fieldOfView);
        return cameraWidth * cameraFieldOfViewCosine;
    }

    void FixedUpdate()
    {

    }

    static float CalculateSegment(SpriteRenderer[] renderers)
    {
        // Get the segment width

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
        
        foreach (RectTransform rect in rectTransform)
        {
            rect.position = new Vector2(
                direction * widthOfView * scrollProgress.ToFloat(),
                0f
            );
        }        
    }

    void ScrollA()
	{
    }
}


