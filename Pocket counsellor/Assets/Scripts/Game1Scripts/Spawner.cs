using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameManager gameStateCheck;

    public GameObject fruitPrefab;
    public Transform[] spawnPoints;

    public float minDelay = 0.1f;
    public float maxDelay = 1f;

    public int xSpeed;
    public int ySpeed;
    public int zSpeed;

    public int RadNum = 0;
    public bool isSwitch;



    public IEnumerator SpawnFruits ()
    {
        while (gameStateCheck.gamePlayState == true)
        {
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];

            GameObject spawnedFruit = Instantiate(fruitPrefab, spawnPoint.position, spawnPoint.rotation);
            Destroy(spawnedFruit, 5f);
        }
            
    }

    public void Update()
    {
        transform.Rotate( xSpeed * Time.deltaTime, ySpeed * Time.deltaTime, zSpeed * Time.deltaTime);

        //if it goes too far to the left change zspeed to go towards right
        if (transform.localEulerAngles.z >= 210 && isSwitch == false)
        {
            isSwitch = true;
            RandomRotation();
            Debug.LogWarning("30 angle reached");
            Debug.Log("30 angle reached");
        }

        //if it goes too far to the right change zspeed to go towards left
        if (transform.localEulerAngles.z <= 150 && isSwitch == true)
        {
            isSwitch = false;
            RandomRotation();
            Debug.LogWarning("-30 angle reached");
            Debug.Log("-30 angle reached");
        }
    }


    #region [Random Rotation for spawned objects]

    public void RandomRotation()
    {
        RadNum = Random.Range(1, 5);

        if (RadNum == 1 && isSwitch == true)
        {
            zSpeed = -2;
        }
        
        if (RadNum == 1 && isSwitch == false)
        {
            zSpeed = 2;
        }

        if (RadNum == 2 && isSwitch == true)
        {
            zSpeed = -4;
        }

        if (RadNum == 2 && isSwitch == false)
        {
            zSpeed = 4;
        }

        if (RadNum == 3 && isSwitch == true)
        {
            zSpeed = -6;
        }

        if (RadNum == 3 && isSwitch == false)
        {
            zSpeed = 6;
        }

        if (RadNum == 4 && isSwitch == true)
        {
            zSpeed = -8;
        }

        if (RadNum == 4 && isSwitch == false)
        {
            zSpeed = 8;
        }

        if (RadNum == 5 && isSwitch == true)
        {
            zSpeed = -10;
        }

        if (RadNum == 5 && isSwitch == false)
        {
            zSpeed = 10;
        }
    }
    #endregion

}
