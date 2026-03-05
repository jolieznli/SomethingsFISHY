using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/*Lets the player select Cube1 and spin the whole reel pivot in place. */
[RequireComponent(typeof(XRSimpleInteractable))]
public class XRReelHandle : MonoBehaviour
{
    [Header("Reel Rotation Target")]
    public Transform reelPivot;

    [Header("Line Controller (hook + line behavior)")]
    public XRReelLineController lineController;

    [Header("Spin Settings")]
    public Vector3 localSpinAxis = Vector3.forward;

    private XRBaseInteractor currentInteractor;
    private Vector3 previousDirection;
    private XRSimpleInteractable interactable;

    void Awake()
    {
        interactable = GetComponent<XRSimpleInteractable>();
        interactable.selectEntered.AddListener(OnSelectEntered);
        interactable.selectExited.AddListener(OnSelectExited);
    }

    void OnDestroy()
    {
        if (interactable != null)
        {
            interactable.selectEntered.RemoveListener(OnSelectEntered);
            interactable.selectExited.RemoveListener(OnSelectExited);
        }
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        currentInteractor = args.interactorObject as XRBaseInteractor;
        previousDirection = GetPlanarDirection();
    }

    private void OnSelectExited(SelectExitEventArgs args)
    {
        currentInteractor = null;
    }

    void Update()
    {
        if (currentInteractor == null || reelPivot == null) return;

        Vector3 currentDirection = GetPlanarDirection();
        if (currentDirection.sqrMagnitude < 0.0001f || previousDirection.sqrMagnitude < 0.0001f)
        {
            previousDirection = currentDirection;
            return;
        }

        Vector3 worldAxis = reelPivot.TransformDirection(localSpinAxis.normalized);
        float deltaAngle = Vector3.SignedAngle(previousDirection, currentDirection, worldAxis);

        /*Rotate the reel visuals. */
        reelPivot.Rotate(worldAxis, deltaAngle, Space.World);

        /*Apply the same delta to line length. */
        if (lineController != null)
        {
            lineController.ApplyReelDeltaDegrees(deltaAngle);
        }

        previousDirection = currentDirection;
    }

    private Vector3 GetPlanarDirection()
    {
        if (currentInteractor == null || reelPivot == null) return Vector3.zero;

        Vector3 worldAxis = reelPivot.TransformDirection(localSpinAxis.normalized);
        Vector3 handOffset = currentInteractor.transform.position - reelPivot.position;

        return Vector3.ProjectOnPlane(handOffset, worldAxis).normalized;
    }
}