using UnityEngine;

public class ReelKeyboardTestZ : MonoBehaviour
{
    [Header("References")]
    public Transform rodTip;
    public Transform hook;
    public LineRenderer lineRenderer;

    [Header("Reel Settings")]
    public float degreesPerSecond = 180f;
    public float reelSensitivity = 0.01f;

    [Header("Line Length Limits")]
    public float minLineLength = 0.5f;
    public float maxLineLength = 3.0f;

    [Header("Visual Settings")]
    public int lineSegments = 12;
    public float sagStrength = 0.15f;
    public float swayStrength = 0.03f;
    public float swaySpeed = 2f;

    private float lastAngleZ;
    private float currentLineLength;

    void Start()
    {
        lastAngleZ = transform.localEulerAngles.z;

        currentLineLength = Vector3.Distance(rodTip.position, hook.position);
        currentLineLength = Mathf.Clamp(currentLineLength, minLineLength, maxLineLength);

        lineRenderer.useWorldSpace = true;
        lineRenderer.positionCount = lineSegments;
    }

    void Update()
    {
        // Spin reel for testing
        if (Input.GetKey(KeyCode.J))
            transform.Rotate(Vector3.forward, +degreesPerSecond * Time.deltaTime, Space.Self);

        if (Input.GetKey(KeyCode.L))
            transform.Rotate(Vector3.forward, -degreesPerSecond * Time.deltaTime, Space.Self);

        float currentAngleZ = transform.localEulerAngles.z;
        float deltaZ = Mathf.DeltaAngle(lastAngleZ, currentAngleZ);

        // Adjust line length
        currentLineLength -= deltaZ * reelSensitivity;
        currentLineLength = Mathf.Clamp(currentLineLength, minLineLength, maxLineLength);

        // Force hook directly below rod tip (world vertical)
        Vector3 newHookPos = rodTip.position;
        newHookPos.y -= currentLineLength;

        // Add subtle sway
        float sway = Mathf.Sin(Time.time * swaySpeed) * swayStrength;
        newHookPos.x += sway;

        hook.position = newHookPos;

        lastAngleZ = currentAngleZ;
    }

    void LateUpdate()
    {
        Vector3 start = rodTip.position;
        Vector3 end = hook.position;

        for (int i = 0; i < lineSegments; i++)
        {
            float t = i / (float)(lineSegments - 1);

            Vector3 point = Vector3.Lerp(start, end, t);

            // Natural sag curve
            float sag = Mathf.Sin(t * Mathf.PI) * currentLineLength * sagStrength;

            point.y -= sag;

            lineRenderer.SetPosition(i, point);
        }
    }
}