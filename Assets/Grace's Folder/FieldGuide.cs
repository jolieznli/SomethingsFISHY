using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldGuide : MonoBehaviour
{

    public Transform FishEntryParent;
    public GameObject UIFishEntry;

    public GameObject[] FishPrefabs;  // What to spawn inside the field guide

    public void Start()
    {
        foreach (GameObject obj in FishPrefabs)
        {
            GameObject uiEntry = Instantiate(UIFishEntry, FishEntryParent);
            FishData data = obj.GetComponent<FishData>();
            uiEntry.GetComponent<UIFishEntry>().SetFishData(data);
        }
    }

}
