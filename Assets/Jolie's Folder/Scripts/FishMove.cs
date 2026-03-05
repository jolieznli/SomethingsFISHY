using UnityEngine;

public class FishMove : MonoBehaviour
{
    public float minSpeed = 0.3f;
    public float maxSpeed = 1.0f;

    public float minSize = 0.7f;
    public float maxSize = 1f;

    private float moveSpeed;
    private float direction;
    private Rigidbody rb;
    private bool isCaught = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        float randomSize = Random.Range(minSize, maxSize);
        transform.localScale *= randomSize;

        moveSpeed = Random.Range(minSpeed, maxSpeed);
        direction = Random.value > 0.5f ? 1f : -1f;

        if (direction < 0f)
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1f;
            transform.localScale = scale;
        }
    }

    void FixedUpdate()
    {
        if (isCaught) return;

        Vector3 delta = Vector3.right * direction * moveSpeed * Time.fixedDeltaTime;

        if (rb != null && !rb.isKinematic)
        {
            rb.MovePosition(rb.position + delta);
        }
        else
        {
            transform.position += delta;
        }
    }

    public void Catch(Transform hookAttachPoint)
    {
        isCaught = true;

        if (rb != null)
        {
            rb.isKinematic = true;
        }

        if (hookAttachPoint != null)
        {
            transform.SetParent(hookAttachPoint, true);
            transform.position = hookAttachPoint.position;
            transform.rotation = hookAttachPoint.rotation;
        }
    }
}