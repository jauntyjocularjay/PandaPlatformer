using Unity.Mathematics;
using UnityEngine;

public class Background : MonoBehaviour
{
    public BGLayer[] layers;
    public RectTransform[] rectTransforms;
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
        rectTransforms = gameObject.GetComponentsInChildren<RectTransform>();
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
        
        foreach (RectTransform rectTransform in rectTransforms)
        {
            rectTransform.position = new Vector2(
                direction * widthOfView * scrollProgress.ToFloat(),
                0f
            );
        }        
    }

    void ScrollA()
	{
    }
}


