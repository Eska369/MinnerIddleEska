using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LetMeSee : MonoBehaviour
{

    //CLICKER
    public Text DollarsText;
    public Text BitcoinText;
    public Text BTCPerSec;
    public float BTCEx = 0.000072f;
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

    public float am1 = 0.000072f;
    public float am2 = 0.000144f;
    public float am3 = 0.000216f;
    public float am4 = 0.000288f;
    public float am5 = 0.000360f;


    //UPGRADE HIT BUTTON
    public int upgradePrize;
    public Text upgradeText;

    //LEVELING
    public int level;
    public int EXP;
    public int expToNextLevel;
    public Text levelText;

    //ACHIEVEMENT
    public bool Achi1;
    public bool Achi2;
    public bool Achi3;
    public bool Achi4;
    public bool Achi5;
    public bool Achi6;

    public Image Ach1;
    public Image Ach2;
    public Image Ach3;
    public Image Ach4;
    public Image Ach5;
    public Image Ach6;


    void Start()
    {
        //CLICKER
        currentDollars = 0;
        currentBitcoins = 0;
        hitPower = 1;
        upgradePrize = 50;

        //SHOP ITEMS START PRIZE AND AMOUNT
        shop1prize = 25;
        shop2prize = 50;
        shop3prize = 75;
        shop4prize = 100;
        shop5prize = 125;

        amount1 = 0;
        amount1Profit = 0.0000072f;
        amount2 = 0;
        amount2Profit = 0.0000144f;
        amount3 = 0;
        amount3Profit = 0.0000216f;
        amount4 = 0;
        amount4Profit = 0.0000288f;
        amount5 = 0;
        amount5Profit = 0.0000360f;

        //LEVEL
        level = 1;
        expToNextLevel = 1;

        //PLACE FOR RESET LINE

        //PlayerPrefs.DeleteAll();

        //PLACE FOR LOAD
        currentDollars = PlayerPrefs.GetFloat("currentDollars", currentDollars);
        currentBitcoins = PlayerPrefs.GetFloat("currentBitcoins", currentBitcoins);
        DollarsPerSec = PlayerPrefs.GetFloat("DollarsPerSec", DollarsPerSec);
        DollarsIncreasedPerSecond = PlayerPrefs.GetFloat("DollarsIncreasedPerSecond", DollarsIncreasedPerSecond);
        BitcoinsPerSec = PlayerPrefs.GetFloat("BitcoinsPerSecond", BitcoinsPerSec);
        BitcoinIncreasedPerSecond = PlayerPrefs.GetFloat("BitcoinIncreasedPerSecond", BitcoinIncreasedPerSecond);
        hitPower = PlayerPrefs.GetFloat("hitPower", hitPower);

        amount1 = PlayerPrefs.GetInt("amount1", amount1);
        amount2 = PlayerPrefs.GetInt("amount2", amount2);
        amount3 = PlayerPrefs.GetInt("amount3", amount3);
        amount4 = PlayerPrefs.GetInt("amount4", amount4);
        amount5 = PlayerPrefs.GetInt("amount5", amount5);

        level = PlayerPrefs.GetInt("level", level);
        EXP = PlayerPrefs.GetInt("EXP", EXP);
        expToNextLevel = PlayerPrefs.GetInt("expToNextLevel", expToNextLevel);

        //BTC LOOP 
        StartCoroutine(Loop());
    }

    
    void Update()
    {
        //CLICKER
        DollarsText.text = (float)currentDollars + "$";
        BitcoinText.text = (float)currentBitcoins + "₿";

        DollarsIncreasedPerSecond = x * Time.deltaTime;
        BitcoinIncreasedPerSecond = x * Time.deltaTime;

        currentDollars += DollarsIncreasedPerSecond;
        currentBitcoins += BitcoinIncreasedPerSecond;

        //SHOP
        shop1text.text = "Tier 1: " + shop1prize + "$";
        shop2text.text = "Tier 2: " + shop2prize + "$";
        shop3text.text = "Tier 3: " + shop3prize + "$";
        shop4text.text = "Tier 4: " + shop4prize + "$";
        shop5text.text = "Tier 5: " + shop5prize + "$";

        //AMOUNT
        amount1Text.text = amount1 + " makes " + amount1Profit + "₿/s";
        amount2Text.text = amount2 + " makes " + amount2Profit + "₿/s";
        amount3Text.text = amount3 + " makes " + amount3Profit + "₿/s";
        amount4Text.text = amount4 + " makes " + amount4Profit + "₿/s";
        amount5Text.text = amount5 + " makes " + amount5Profit + "₿/s";

        //UPGRADE
        upgradeText.text = "Cost: " + upgradePrize + " $";

        //BTCPERSEC
        BTCPerSec.text = (float)BitcoinsPerSec + "₿/s";

        //LEVELING
        if (EXP >= expToNextLevel)
        {
            level++;
            EXP = 0;
            expToNextLevel *= 2;
        }
        levelText.text = level + "Level!";

        //SAVE HERE
        PlayerPrefs.SetFloat("currentDollars", (float)currentDollars);
        PlayerPrefs.SetFloat("currentBitcoins", (float)currentBitcoins);
        PlayerPrefs.SetFloat("DollarsPerSec", (float)DollarsPerSec);
        PlayerPrefs.SetFloat("DollarsIncreasedPerSecond", (float)DollarsIncreasedPerSecond);
        PlayerPrefs.SetFloat("BitcoinsPerSec", (float)BitcoinsPerSec);
        PlayerPrefs.SetFloat("BitcoinIncreasedPerSecond", (float)BitcoinIncreasedPerSecond);
        PlayerPrefs.SetFloat("hitPower", (float)hitPower);

        PlayerPrefs.SetFloat("amount1", (float)amount1);
        PlayerPrefs.SetFloat("amount2", (float)amount2);
        PlayerPrefs.SetFloat("amount3", (float)amount3);
        PlayerPrefs.SetFloat("amount4", (float)amount4);
        PlayerPrefs.SetFloat("amount5", (float)amount5);

        PlayerPrefs.SetFloat("upgradePrize", (float)upgradePrize);

        PlayerPrefs.SetInt("level", (int)level);
        PlayerPrefs.SetInt("EXP", (int)level);
        PlayerPrefs.SetInt("expToNextLevel", (int)expToNextLevel);

        //DODAC ZAPIS ACHIEVMENTSOW

        //ACHIEVEMENTS
        Achievement1();
        Achievement2();
        Achievement3();
        Achievement4();
        Achievement5();
        Achievement6();


    }

    public void SellBTC()
    {
        if (currentBitcoins > 0)
        {
            currentDollars += currentBitcoins / BTCEx;
            currentDollars = Mathf.Round(currentDollars * 100f) / 100f;
            currentBitcoins = 0;
        }
    }

    public void Hit()
    {
        currentDollars += hitPower;
        EXP++;
    }

    public void Shop1()
    {
        if (currentDollars >= shop1prize)
        {
            currentDollars -= shop1prize;
            amount1 += 1;
            amount1Profit += 0.000072f;
            shop1prize += 100;
        }
    }

    public void Shop2()
    {
        if (currentDollars >= shop2prize)
        {
            currentDollars -= shop2prize;
            amount2 += 1;
            amount2Profit += 0.000144f;
            shop2prize += 100;
        }
    }

    public void Shop3()
    {
        if (currentDollars >= shop3prize)
        {
            currentDollars -= shop3prize;
            amount3 += 1;
            amount3Profit += 0.000216f;
            shop3prize += 100;
        }
    }

    public void Shop4()
    {
        if (currentDollars >= shop4prize)
        {
            currentDollars -= shop4prize;
            amount4 += 1;
            amount4Profit += 0.000288f;
            shop4prize += 100;
        }
    }

    public void Shop5()
    {
        if (currentDollars >= shop5prize)
        {
            currentDollars -= shop5prize;
            amount5 += 1;
            amount5Profit += 0.000360f;
            shop5prize += 100;
        }
    }

    public void Upgrade()
    {
        if(currentDollars >= upgradePrize)
        {
            currentDollars -= upgradePrize;
            hitPower += 2;
            upgradePrize *= 5;
        }
    }

    private IEnumerator Loop()
    {
        while (true)
        {
            BitcoinsPerSec = (amount1*am1) + (amount2*am2) + (amount3*am3) + (amount4*am4) + (amount5*am5);
            currentBitcoins += BitcoinsPerSec;
            yield return new WaitForSeconds(1f);
        }
        yield return null;
    }


    public void Achievement1()
    {
        if(currentDollars >= 30f)
        {
            Achi1 = true;
        }

        if(Achi1 == true)
        {
            Ach1.color = new Color(0.2f, 0.2f, 0.2f, 0.2f);
        }
        else
        {
            Ach1.color = new Color(1f, 1f, 1f, 1f);
        }
    }

    public void Achievement2()
    {
        if (amount1 >= 3f)
        {
            Achi2 = true;
        }

        if (Achi2 == true)
        {
            Ach2.color = new Color(0.2f, 0.2f, 0.2f, 0.2f);
        }
        else
        {
            Ach2.color = new Color(1f, 1f, 1f, 1f);
        }
    }

    public void Achievement3()
    {
        if (level >= 10)
        {
            Achi3 = true;
        }

        if (Achi3 == true)
        {
            Ach3.color = new Color(0.2f, 0.2f, 0.2f, 0.2f);
        }
        else
        {
            Ach3.color = new Color(1f, 1f, 1f, 1f);
        }
    }

    public void Achievement4()
    {
        if (amount5 >= 10)
        {
            Achi4 = true;
        }

        if (Achi4 == true)
        {
            Ach4.color = new Color(0.2f, 0.2f, 0.2f, 0.2f);
        }
        else
        {
            Ach4.color = new Color(1f, 1f, 1f, 1f);
        }
    }

    public void Achievement5()
    {
        if (currentDollars >= 1000f)
        {
            Achi5 = true;
        }

        if (Achi5 == true)
        {
            Ach5.color = new Color(0.2f, 0.2f, 0.2f, 0.2f);
        }
        else
        {
            Ach5.color = new Color(1f, 1f, 1f, 1f);
        }
    }

    public void Achievement6()
    {
        if (currentBitcoins >= 1f)
        {
            Achi6 = true;
        }

        if (Achi6 == true)
        {
            Ach6.color = new Color(0.2f, 0.2f, 0.2f, 0.2f);
        }
        else
        {
            Ach6.color = new Color(1f, 1f, 1f, 1f);
        }
    }
}
