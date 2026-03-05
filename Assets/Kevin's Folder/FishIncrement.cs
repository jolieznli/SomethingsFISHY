using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FishIncrement : MonoBehaviour
{
    int fishCount = 0;
    public GameObject textObject;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "fish")
        {
            fishCount += 1;
            textObject.GetComponent<TextMeshProUGUI>().text = fishCount.ToString() + " Fish";
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "fish")
        {
            fishCount -= 1;
            textObject.GetComponent<TextMeshProUGUI>().text = fishCount.ToString() + " Fish";
        }
    }
}
