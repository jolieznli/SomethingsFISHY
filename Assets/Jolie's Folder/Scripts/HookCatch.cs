using UnityEngine;

/*Detects fish via trigger and attaches the fish to the hook. */
public class HookCatch : MonoBehaviour
{
    /*Where the fish should snap to when caught. */
    public Transform fishAttachPoint;

    /*Only allow one fish at a time. */
    public bool allowOnlyOneFish = true;

    /*Track the currently caught fish. */
    private FishMove caughtFish = null;

    private void OnTriggerEnter(Collider other)
    {
        /*If we already have a fish and only allow one, ignore. */
        if (allowOnlyOneFish && caughtFish != null) return;

        /*Try to find FishMove on the collider or its parent. */
        FishMove fish = other.GetComponent<FishMove>();
        if (fish == null)
        {
            fish = other.GetComponentInParent<FishMove>();
        }

        /*If this is not a fish, do nothing. */
        if (fish == null) return;

        /*Catch the fish and attach it. */
        caughtFish = fish;
        fish.Catch(fishAttachPoint);
    }

    /*Optional: call this if you want to release the fish later. */
    public void Release()
    {
        if (caughtFish == null) return;

        /*Unparent fish so it is no longer attached to the hook. */
        caughtFish.transform.SetParent(null, worldPositionStays: true);

        /*Clear reference. */
        caughtFish = null;
    }
}