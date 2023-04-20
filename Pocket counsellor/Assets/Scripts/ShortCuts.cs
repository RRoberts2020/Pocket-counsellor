using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShortCuts : MonoBehaviour
{

    public bool stressGoTo;
    public bool depressionGoTo;
    public bool phobiaGoTo;
    public bool hotlineGoTo;
    public bool gamesGoTo;

    public GameObject defaultScene;
    public GameObject currentScene;
    public GameObject stressScene;
    public GameObject depressionScene;
    public GameObject phobiaScene;
    public GameObject hotlineScene;
    public GameObject gamesScene;

    private void Start()
    {
        stressGoTo = false;
        depressionGoTo = false;
        phobiaGoTo = false;
        hotlineGoTo = false;
        gamesGoTo = false;
    }

    // Update is called once per frame
    public void Update()
    {
        if (stressGoTo == true)
        {
            StressSceneCutTo();
        }

        if (depressionGoTo == true)
        {
            DepressionSceneCutTo();
        }

        if (phobiaGoTo == true)
        {
            PhobiaSceneCutTo();
        }

        if (hotlineGoTo == true)
        {
            HotlineSceneCutTo();
        }

        if (gamesGoTo == true)
        {
            GamesSceneCutTo();
        }
    }

    public void StressSceneCutTo()
    {
        currentScene.SetActive(false);
        defaultScene.SetActive(false);
        stressScene.SetActive(true);
    }

    public void DepressionSceneCutTo()
    {
        currentScene.SetActive(false);
        defaultScene.SetActive(false);
        depressionScene.SetActive(true);
    }

    public void PhobiaSceneCutTo()
    {
        currentScene.SetActive(false);
        defaultScene.SetActive(false);
        phobiaScene.SetActive(true);
    }

    public void HotlineSceneCutTo()
    {
        currentScene.SetActive(false);
        defaultScene.SetActive(false);
        hotlineScene.SetActive(true);
    }

    public void GamesSceneCutTo()
    {
        currentScene.SetActive(false);
        defaultScene.SetActive(false);
        gamesScene.SetActive(true);
    }


}
