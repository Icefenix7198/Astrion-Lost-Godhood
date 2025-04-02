using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    public Vector4 bounds;
    // Start is called before the first frame update

    private void Awake()
    {
        //Get the positio of all bounds into the vector
        bounds.w = transform.GetChild(0).position.y; //Up
        bounds.x = transform.GetChild(1).position.y; //Down
        bounds.y = transform.GetChild(2).position.x; //Left
        bounds.z = transform.GetChild(3).position.x; //Rigth
    }
}
