using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    private Vector3 velocity = Vector3.zero;
    public float smoothTime = 0.25f;

    [SerializeField] private Transform target;
    [SerializeField] private CameraBounds cameraBounds; //Up = W,down = X, left = Y rigth = Z

    //Camera size
    [SerializeField] float cameraHeigth;
    [SerializeField] float cameraWidth;

    //Temporal testing things
    [SerializeField] GameObject downBall;
    [SerializeField] GameObject upBall;


    // Start is called before the first frame update
    void Start()
    {
        cameraBounds = GameObject.FindGameObjectWithTag("EditorOnly").GetComponent<CameraBounds>();
        cameraHeigth = this.GetComponent<Camera>().orthographicSize;
        cameraWidth = cameraHeigth * Screen.width / Screen.height;
    }   
    // Update is called once per frame
    void Update()
    {
        float targetX = transform.position.x, targetY = transform.position.y;

        downBall.transform.position = new Vector3(0, gameObject.transform.position.y + cameraHeigth, 0);
        upBall.transform.position = new Vector3(0, gameObject.transform.position.y - cameraHeigth, 0);

        //Y camera position
        if (gameObject.transform.position.y + cameraHeigth < cameraBounds.bounds.height && gameObject.transform.position.y - cameraHeigth > cameraBounds.bounds.y) 
        {
            targetY = target.position.y;
            Debug.Log("Inside bounds, target is:" + targetY);
        }
        else if (gameObject.transform.position.y + cameraHeigth > cameraBounds.bounds.height) //If the camera is too high, move it to make its heigth the bound heigth
        {
            targetY = cameraBounds.bounds.height - 2 * cameraHeigth;
            Debug.Log("Outside bounds");
        }
        else if (gameObject.transform.position.y - cameraHeigth > cameraBounds.bounds.y) //If the camera is too low, move it to make its y the bound y
        {
            targetY = cameraBounds.bounds.y + 2 * cameraHeigth;
            Debug.Log("Outside bounds");
        }

        if (target.position.x + cameraWidth < cameraBounds.bounds.width && target.position.x - cameraWidth > cameraBounds.bounds.x)
        {
            targetX = target.position.x;
        }
        else if (target.position.x + cameraWidth > cameraBounds.bounds.width) //If the camera is too high, move it to make its heigth the bound heigth
        {
            targetX = cameraBounds.bounds.width - cameraWidth;
        }
        else if (target.position.x - cameraWidth > cameraBounds.bounds.x) //If the camera is too low, move it to make its y the bound y
        {
            targetX = cameraBounds.bounds.x + cameraWidth;
        }

        // Set camera position
        Vector3 targetPosition = new Vector3(targetX, targetY, target.position.z) + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        if(cameraHeigth != this.GetComponent<Camera>().orthographicSize) 
        {
            cameraHeigth = this.GetComponent<Camera>().orthographicSize;
        }
        if(cameraWidth != cameraHeigth * Screen.width / Screen.height) 
        {
            cameraWidth = cameraHeigth * Screen.width / Screen.height;
        }
    }
}
