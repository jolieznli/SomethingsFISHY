using UnityEngine;

public class FishingLine : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public Transform rodTip;
    public Transform hook;

    void Awake()
    {
        // Automatically grab the LineRenderer on this object
        lineRenderer = GetComponent<LineRenderer>();

        // Make sure we have exactly 2 points
        lineRenderer.positionCount = 2;

        // Force it into LOCAL mode
        lineRenderer.useWorldSpace = false;

        // Make it thin in code so inspector doesn’t mess it up
        lineRenderer.startWidth = 0.02f;
        lineRenderer.endWidth = 0.02f;
    }

    void LateUpdate()
    {
        // Draw in local space
        lineRenderer.SetPosition(0, rodTip.localPosition);
        lineRenderer.SetPosition(1, hook.localPosition);
    }
}