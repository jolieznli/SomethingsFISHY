using UnityEngine;

/*Maintains hook position straight down from rod tip, and draws a saggy line. */
public class XRReelLineController : MonoBehaviour
{
    [Header("References")]
    public Transform rodTip;
    public Transform hook;
    public LineRenderer lineRenderer;

    [Header("Line Length Limits")]
    public float minLineLength = 0.5f;
    public float maxLineLength = 3.0f;

    [Header("Reel Settings")]
    public float reelSensitivity = 0.01f;

    [Header("Visual Settings")]
    public int lineSegments = 12;
    public float sagStrength = 0.15f;
    public float swayStrength = 0.03f;
    public float swaySpeed = 2f;

    /*Current line length in world space. */
    private float currentLineLength = 1.5f;

    void Start()
    {
        /*Initialize line length from current positions. */
        currentLineLength = Vector3.Distance(rodTip.position, hook.position);
        currentLineLength = Mathf.Clamp(currentLineLength, minLineLength, maxLineLength);

        /*Initialize line renderer. */
        lineRenderer.useWorldSpace = true;
        lineRenderer.positionCount = lineSegments;
    }

    /*Called by XRReelHandle with delta degrees turned this frame. */
    public void ApplyReelDeltaDegrees(float deltaDegrees)
    {
        /*Adjust line length based on reel turning. */
        currentLineLength -= deltaDegrees * reelSensitivity;
        currentLineLength = Mathf.Clamp(currentLineLength, minLineLength, maxLineLength);
    }

    void Update()
    {
        /*Force hook directly below rod tip (world vertical). */
        Vector3 newHookPos = rodTip.position;
        newHookPos.y -= currentLineLength;

        /*Add subtle sway. */
        float sway = Mathf.Sin(Time.time * swaySpeed) * swayStrength;
        newHookPos.x += sway;

        hook.position = newHookPos;
    }

    void LateUpdate()
    {
        /*Draw sagging line between rod tip and hook. */
        Vector3 start = rodTip.position;
        Vector3 end = hook.position;

        for (int i = 0; i < lineSegments; i++)
        {
            float t = i / (float)(lineSegments - 1);
            Vector3 point = Vector3.Lerp(start, end, t);

            /*Natural sag curve. */
            float sag = Mathf.Sin(t * Mathf.PI) * currentLineLength * sagStrength;
            point.y -= sag;

            lineRenderer.SetPosition(i, point);
        }
    }
}