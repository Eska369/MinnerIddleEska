using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellBitcoin : MonoBehaviour
{
    public GameObject textBox;

    public void ClickTheButton()
    {
        GlobalDollars.DollarCount += 1;
    }
}
