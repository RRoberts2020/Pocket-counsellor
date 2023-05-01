using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{

    public int currentMoney = 500;


    public GameObject whiteBlade;
    public GameObject redBlade;
    public GameObject blueBlade;

    public GameObject buyRedBlade;
    public GameObject buyBlueBlade;

    public GameObject buttonRedBlade;
    public GameObject buttonBlueBlade;

    public bool isRedUnlocked;
    public bool isBlueUnlocked;

    public void BuyRed()
    {
        if (currentMoney >= 100)
        {
            buyRedBlade.SetActive(false);
            buttonRedBlade.SetActive(true);
            isRedUnlocked = true;

            currentMoney -= 100;
        }
    }

    public void BuyBlue()
    {
        if (currentMoney >= 100)
        {
            buyBlueBlade.SetActive(false);
            buttonBlueBlade.SetActive(true);
            isBlueUnlocked = true;

            currentMoney -= 100;
        }
    }   

    public void SetWhite()
    {
        whiteBlade.SetActive(true);
        redBlade.SetActive(false);
        blueBlade.SetActive(false);
    }

    public void SetRed()
    {
        if (isRedUnlocked == true)
        {
            whiteBlade.SetActive(false);
            redBlade.SetActive(true);
            blueBlade.SetActive(false);
        }
    }

    public void SetBlue()
    {
        if (isBlueUnlocked == true)
        {
            whiteBlade.SetActive(false);
            redBlade.SetActive(false);
            blueBlade.SetActive(true);
        }
    }

    public void AddMoney()
    {
        currentMoney++;
    }

}
