using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalDollars : MonoBehaviour
{
    public static int DollarCount;
    public GameObject DollarsDisplay;
    public int InternalDollars = 0;

    void Update()
    {
        InternalDollars = DollarCount;
        DollarsDisplay.GetComponent<Text>().text = "" + InternalDollars;
    }
}
