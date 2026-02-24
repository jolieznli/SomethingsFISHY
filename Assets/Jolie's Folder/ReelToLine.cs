using UnityEngine;

public class ReelToLine : MonoBehaviour
{
    public Transform hook;

    public float reelSensitivity = 0.003f; // hook movement per degree
    public float minY = -3f;
    public float maxY = -0.2f;

    private float lastAngle;

    void Start()
    {
        lastAngle = transform.localEulerAngles.y;
    }

    void Update()
    {
        float currentAngle = transform.localEulerAngles.y;
        float delta = Mathf.DeltaAngle(lastAngle, currentAngle);

        // Positive delta reels in by default. Flip sign if needed.
        Vector3 p = hook.localPosition;
        p.y += delta * reelSensitivity;
        p.y = Mathf.Clamp(p.y, minY, maxY);
        hook.localPosition = p;

        lastAngle = currentAngle;
    }
}