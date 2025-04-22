using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class BoundsManager : MonoBehaviour
{
    public static event Action<Rect> changeBounds;

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

    void OnEnable()
    {
        changeBounds += ChangeBounds;
    }


    void OnDisable()
    {
        changeBounds -= ChangeBounds;
    }

    [ExecuteAlways]
    private void OnValidate()
    {
        transform.GetChild(0).position = new Vector3(transform.position.x, bounds.height, transform.position.z); //Up
        transform.GetChild(1).position = new Vector3(transform.position.x, bounds.y, transform.position.z); //Down
        transform.GetChild(2).position = new Vector3(bounds.x, transform.position.y, transform.position.z); //Left
        transform.GetChild(3).position = new Vector3(bounds.width, transform.position.y, transform.position.z); //Rigth
    }

    public void ChangeBounds(Rect rect) 
    {
        bounds = rect;

        transform.GetChild(0).position = new Vector3(transform.position.x, rect.height, transform.position.z); //Up
        transform.GetChild(1).position = new Vector3(transform.position.x, rect.y, transform.position.z); //Down
        transform.GetChild(2).position = new Vector3(rect.x, transform.position.y, transform.position.z); //Left
        transform.GetChild(3).position = new Vector3(rect.width, transform.position.y, transform.position.z); //Rigth
    }

    public void ChangeStringBoundsHYXW(String str) //String cause I dont know how the fuck 
    {
        string[] words = str.Split("/");
        float[] rect = new float[4];

        //Parse numbers
        rect[0] = float.Parse(words[0]); // H
        rect[1] = float.Parse(words[1]); // Y
        rect[2] = float.Parse(words[2]); // X
        rect[3] = float.Parse(words[3]); // W

        Debug.Log(rect[0] + " " + rect[1] + " " + rect[2] + " " + rect[3]);

        //Create rectangle
        Rect rectangle = new Rect(rect[2], rect[1], rect[3], rect[0]);
        ChangeBounds(rectangle);
    }
}


