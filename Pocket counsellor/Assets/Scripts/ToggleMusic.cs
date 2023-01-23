using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleMusic : MonoBehaviour
{
    [SerializeField] private Toggle toggle1, toggle2, toggle3, toggle4;
    private ToggleGroup allowSwitch;

    void Awake()
    {
        if (PlayerPrefs.GetInt("ToggleSelected") == 0)
        {
            toggle1.isOn = true;
            toggle2.isOn = false;
            toggle3.isOn = false;
            toggle4.isOn = false;
        }

        else if (PlayerPrefs.GetInt("ToggleSelected") == 1)
        {
            toggle1.isOn = false;
            toggle2.isOn = true;
            toggle3.isOn = false;
            toggle4.isOn = false;
        }
        else if (PlayerPrefs.GetInt("ToggleSelected") == 2)
        {
            toggle1.isOn = false;
            toggle2.isOn = false;
            toggle3.isOn = true;
            toggle4.isOn = false;
        }
        else if (PlayerPrefs.GetInt("ToggleSelected") == 3)
        {
            toggle1.isOn = false;
            toggle2.isOn = false;
            toggle3.isOn = false;
            toggle4.isOn = true;
        }
    }

    public void Toggle1Selected()
    {
        PlayerPrefs.SetInt("ToggleSelected", 0);
    }
    public void Toggle2Selected()
    {
        PlayerPrefs.SetInt("ToggleSelected", 1);
    }
    public void Toggle3Selected()
    {
        PlayerPrefs.SetInt("ToggleSelected", 2);
    }
    public void Toggle4Selected()
    {
        PlayerPrefs.SetInt("ToggleSelected", 3);
    }

}
