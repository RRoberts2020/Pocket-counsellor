using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTrigger : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Fruit"))
        {
            FindObjectOfType<GameManager>().LoseLive();

            Debug.Log("Lost a life");

        }
    }
}
