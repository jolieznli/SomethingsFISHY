using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIFishEntry : MonoBehaviour
{

    public TextMeshProUGUI Title;

    public void SetFishData(FishData data)
    {
        Title.text = data.FishName;

        // Add other stuff here too - Lucas
    }

}
