using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraZoom : MonoBehaviour
{
    public bool startChange;
    public float targetZoom;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(startChange) 
        {
        
        }
    }

    public bool StartChange(bool state) 
    {
        startChange = state;
        return startChange;
    }
}
