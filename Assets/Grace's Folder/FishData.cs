/// <summary>
/// This code was provided by Lucas to help streamline data
/// attached to each fish!
/// 
/// You can simply run: GetComponent<FishData>() to access the 
/// data of each fish. This should be attached to every fish prefab.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FishType
{
    Normal = 0,
    Invasive = 1,
    Endangered = 2
}

public enum FishAge
{
    Baby = 0,
    Adult = 1
}

public class FishData : MonoBehaviour
{

    public string FishName;
    [TextArea(2, 4)]
    public string FishDescription;
    public FishType FishType;
    public FishAge FishAge;

}
