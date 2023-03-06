using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{

    public GameObject bladeTrailPrefab;
    public float minCuttingVelocity = 0.0001f;

    private GameObject currentBladeTrail;

    public bool isCutting = false;

    Vector2 preivousPosition;

    Rigidbody2D rb;
    Camera cam;
    CircleCollider2D circleCollider;

    private void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
    }


    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartCutting();
        }

        else if (Input.GetMouseButtonUp(0))
        {
            StopCutting();
        }

        if (isCutting)
        {
            UpdateCut();
        }
    }

    void StartCutting()
    {
        isCutting = true;
        currentBladeTrail = Instantiate(bladeTrailPrefab, transform);
        preivousPosition = cam.ScreenToViewportPoint(Input.mousePosition);  
        circleCollider.enabled = false;

    }

    void StopCutting()
    {
        isCutting = false;
        currentBladeTrail.transform.SetParent(null);
        Destroy(currentBladeTrail, 2f);
        circleCollider.enabled = false;
    }

    void UpdateCut()
    {
        //rb.position = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);     
        rb.position = newPosition;

        float velocity = (newPosition - preivousPosition).magnitude * Time.deltaTime;

        if (velocity > minCuttingVelocity)
        {
            circleCollider.enabled = true;
        }

        else
        {
            circleCollider.enabled = false;
        }

        preivousPosition = newPosition;
    }
}
