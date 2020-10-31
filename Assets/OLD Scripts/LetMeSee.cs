using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetMeSee : MonoBehaviour
{

    //CLICKER
    public Text DollarsText;
    public Text BitcoinText;
    public float currentDollars;
    public float DollarsPerSec;
    public float DollarsIncreasedPerSecond;
    public float currentBitcoins;
    public float BitcoinsPerSec;
    public float BitcoinIncreasedPerSecond;
    public float hitPower;
    public float x;


    //SHOP
    public int shop1prize;
    public Text shop1text;

    public int shop2prize;
    public Text shop2text;

    public int shop3prize;
    public Text shop3text;

    public int shop4prize;
    public Text shop4text;

    public int shop5prize;
    public Text shop5text;

    //AMOUNT
    public Text amount1Text;
    public int amount1;
    public float amount1Profit;

    public Text amount2Text;
    public int amount2;
    public float amount2Profit;

    public Text amount3Text;
    public int amount3;
    public float amount3Profit;

    public Text amount4Text;
    public int amount4;
    public float amount4Profit;

    public Text amount5Text;
    public int amount5;
    public float amount5Profit;


    //UPGRADE HIT BUTTON
    public int upgradePrize;
    public Text upgradeText;

    void Start()
    {
        //CLICKER
        currentDollars = 0;
        currentBitcoins = 0;
        hitPower = 1;

        //SHOP ITEMS START PRIZE AND AMOUNT
        shop1prize = 25;
        shop2prize = 50;
        shop3prize = 75;
        shop4prize = 100;
        shop5prize = 125;

        amount1 = 0;
        amount1Profit = 0.000072f;
        amount2 = 0;
        amount2Profit = 0.000072f;
        amount3 = 0;
        amount3Profit = 0.000072f;
        amount4 = 0;
        amount4Profit = 0.000072f;
        amount5 = 0;
        amount5Profit = 0.000072f;

        //PLACE FOR RESET LINE

        //Player.Prefs.DeleteAll();

        //PLACE FOR LOAD
        currentDollars = PlayerPrefs.GetFloat("currentDollars", currentDollars);
    }

    
    void Update()
    {
        //CLICKER
        DollarsText.text = (int)currentDollars + "$";
        BitcoinText.text = (int)currentBitcoins + "₿";

        DollarsIncreasedPerSecond = x * Time.deltaTime;
        BitcoinIncreasedPerSecond = x * Time.deltaTime;

        currentDollars = currentDollars + DollarsIncreasedPerSecond;
        currentBitcoins = currentBitcoins + BitcoinIncreasedPerSecond;

        //SHOP
        shop1text.text = "Tier 1: " + shop1prize + "$";
        shop2text.text = "Tier 2: " + shop2prize + "$";
        shop3text.text = "Tier 3: " + shop3prize + "$";
        shop4text.text = "Tier 4: " + shop4prize + "$";
        shop5text.text = "Tier 5: " + shop5prize + "$";

        //AMOUNT
        amount1Text.text = "Tier 1: " + amount1 + "arts ₿: " + amount1Profit + "/s";
        amount2Text.text = "Tier 2: " + amount2 + "arts ₿: " + amount2Profit + "/s";
        amount3Text.text = "Tier 3: " + amount3 + "arts ₿: " + amount3Profit + "/s";
        amount4Text.text = "Tier 4: " + amount4 + "arts ₿: " + amount4Profit + "/s";
        amount5Text.text = "Tier 5: " + amount5 + "arts ₿: " + amount5Profit + "/s";

        //UPGRADE
        upgradeText.text = "Cost: " + upgradePrize + " $";

        //SAVE HERE
        PlayerPrefs.SetFloat("currentDollars", (float)currentDollars);
    }

    public void Hit()
    {
        currentDollars += hitPower;
    }

    public void Shop1()
    {
        if (currentDollars >= shop1prize)
        {
            currentDollars -= shop1prize;
            amount1 += 1;
            amount1Profit += 25;
            shop1prize += 100;
        }
    }

    public void Shop2()
    {
        if (currentDollars >= shop2prize)
        {
            currentDollars -= shop2prize;
            amount2 += 1;
            amount2Profit += 50;
            shop2prize += 100;
        }
    }

    public void Shop3()
    {
        if (currentDollars >= shop3prize)
        {
            currentDollars -= shop3prize;
            amount3 += 1;
            amount3Profit += 75;
            shop3prize += 100;
        }
    }

    public void Shop4()
    {
        if (currentDollars >= shop4prize)
        {
            currentDollars -= shop4prize;
            amount4 += 1;
            amount4Profit += 100;
            shop4prize += 100;
        }
    }

    public void Shop5()
    {
        if (currentDollars >= shop5prize)
        {
            currentDollars -= shop5prize;
            amount5 += 1;
            amount5Profit += 25;
            shop5prize += 100;
        }
    }

    public void Upgrade()
    {
        if(currentDollars >= upgradePrize)
        {
            currentDollars -= upgradePrize;
            hitPower *= 2;
            upgradePrize *= 3;
        }
    }
}
