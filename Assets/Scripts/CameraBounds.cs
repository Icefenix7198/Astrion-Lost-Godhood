using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    public Rect bounds;
    // Start is called before the first frame update

    [ExecuteAlways]
    private void Awake()
    {
        //Get the positio of all bounds into the vector
        bounds.height = transform.GetChild(0).position.y; //Up
        bounds.y = transform.GetChild(1).position.y; //Down
        bounds.x = transform.GetChild(2).position.x; //Left
        bounds.width = transform.GetChild(3).position.x; //Rigth
    }

    [ExecuteAlways]
    private void OnValidate()
    {
        transform.GetChild(0).position = new Vector3(transform.position.x, bounds.height, transform.position.z); //Up
        transform.GetChild(1).position = new Vector3(transform.position.x, bounds.y, transform.position.z); //Down
        transform.GetChild(2).position = new Vector3(bounds.x, transform.position.y, transform.position.z); //Left
        transform.GetChild(3).position = new Vector3(bounds.width, transform.position.y, transform.position.z); //Rigth
    }
}
