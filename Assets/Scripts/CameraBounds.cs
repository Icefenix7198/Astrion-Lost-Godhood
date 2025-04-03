using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    public Vector4 bounds;
    // Start is called before the first frame update

    [ExecuteAlways]
    private void Awake()
    {
        //Get the positio of all bounds into the vector
        bounds.w = transform.GetChild(0).position.y; //Up
        bounds.x = transform.GetChild(1).position.y; //Down
        bounds.y = transform.GetChild(2).position.x; //Left
        bounds.z = transform.GetChild(3).position.x; //Rigth
    }

    [ExecuteAlways]
    private void OnValidate()
    {
        transform.GetChild(0).position = new Vector3(transform.position.x, bounds.w, transform.position.z);
        transform.GetChild(1).position = new Vector3(transform.position.x, bounds.x, transform.position.z);
        transform.GetChild(2).position = new Vector3(bounds.y, transform.position.y, transform.position.z);
        transform.GetChild(3).position = new Vector3(bounds.z, transform.position.y, transform.position.z);
    }
}
