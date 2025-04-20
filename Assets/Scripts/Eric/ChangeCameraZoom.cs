using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraZoom : MonoBehaviour
{
    public bool startChange;

    float originZoom;
    public float targetZoom;

    float currentTime = 0f;
    public float timeForTransmition;
    [SerializeField] Camera camera;


    // Start is called before the first frame update
    void Start()
    {
        originZoom = camera.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        if(startChange) 
        {
            currentTime += Time.deltaTime;
            
            if(currentTime >= timeForTransmition) 
            {
                currentTime = timeForTransmition;
                startChange = false;
            }

            camera.orthographicSize = originZoom * (1 - currentTime / timeForTransmition) + targetZoom * (currentTime / timeForTransmition);

            
        }
    }

    public bool StartChange(bool state) 
    {
        startChange = state;
        originZoom = camera.orthographicSize;
        return startChange;
    }
    public bool StartChange(bool state, float targetSize)
    {
        startChange = state;
        targetZoom = targetSize;
        originZoom = camera.orthographicSize;
        return startChange;
    }
}
