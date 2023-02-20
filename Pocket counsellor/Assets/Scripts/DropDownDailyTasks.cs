using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropDownDailyTasks : MonoBehaviour
{

    public GameObject Task1;
    public GameObject Task2;
    public GameObject Task3;
    public GameObject Task4;
    public GameObject Task5;

    public void DropDownOptions(int index)
    {
        switch (index)
        {
            case 0: Task1.SetActive(true); Task2.SetActive(false); Task3.SetActive(false); Task4.SetActive(false); Task5.SetActive(false); break;
            case 1: Task1.SetActive(false); Task2.SetActive(true); Task3.SetActive(false); Task4.SetActive(false); Task5.SetActive(false); break;
            case 2: Task1.SetActive(false); Task2.SetActive(false); Task3.SetActive(true); Task4.SetActive(false); Task5.SetActive(false); break;
            case 3: Task1.SetActive(false); Task2.SetActive(false); Task3.SetActive(false); Task4.SetActive(true); Task5.SetActive(false); break;
            case 4: Task1.SetActive(false); Task2.SetActive(false); Task3.SetActive(false); Task4.SetActive(false); Task5.SetActive(true); break;

        }
    }

}
