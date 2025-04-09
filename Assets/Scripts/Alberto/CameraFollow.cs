using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    private Vector3 velocity = Vector3.zero;
    public float smoothTime = 0.25f;

    [SerializeField] private Transform target;
    float targetX = 0, targetY = 0;

    //Bounds
    [SerializeField] private BoundsManager camWorldBounds; //Up = W,down = X, left = Y rigth = Z
    [SerializeField] bool cameraBounded; //True while the camera is on a camera bound
    [SerializeField] private BoundsManager pullBounds; //Internal bounds of the camera that determinates if the camera must move or stay still

    //Camera size
    [SerializeField] float cameraHeigth;
    [SerializeField] float cameraWidth;

    //Temporal testing things
    [SerializeField] GameObject downBall;
    [SerializeField] GameObject upBall;
    [SerializeField] GameObject targetBall;

    // Start is called before the first frame update
    void Start()
    {
        camWorldBounds = GameObject.FindGameObjectWithTag("EditorOnly").GetComponent<BoundsManager>();
        cameraHeigth = this.GetComponent<Camera>().orthographicSize;
        cameraWidth = cameraHeigth * Screen.width / Screen.height;
    }   
    // Update is called once per frame
    void Update()
    {
        downBall.transform.position = new Vector3(0, gameObject.transform.position.y + cameraHeigth, 0);
        upBall.transform.position = new Vector3(0, gameObject.transform.position.y - cameraHeigth, 0);
        targetBall.transform.position = target.position;

        //Y camera position
        {
            if (gameObject.transform.position.y + cameraHeigth <= camWorldBounds.bounds.height && gameObject.transform.position.y - cameraHeigth >= camWorldBounds.bounds.y)
            {
                cameraBounded = false;
                targetY = target.position.y;
                Debug.Log("Inside bounds, target is:" + targetY);
            }
            else
            {
                cameraBounded = true;
            }

            if (cameraBounded)
            {
                if (gameObject.transform.position.y + cameraHeigth > camWorldBounds.bounds.height && gameObject.transform.position.y - cameraHeigth < camWorldBounds.bounds.y) //If both outside bounds camera static allways
                {
                    targetY = camWorldBounds.bounds.height - cameraHeigth; //Lower bound has priority
                }
                else
                {
                    
                    if (gameObject.transform.position.y + cameraHeigth > camWorldBounds.bounds.height) //If the camera is too high, move it to make its heigth the bound heigth
                    {
                        targetY = camWorldBounds.bounds.height - cameraHeigth;
                        Debug.Log("Outside bounds");
                    }
                    else if (gameObject.transform.position.y - cameraHeigth < camWorldBounds.bounds.y) //If the camera is too low, move it to make its y the bound y
                    {
                        targetY = camWorldBounds.bounds.y + cameraHeigth;
                        Debug.Log("Outside bounds");
                    }
                    
                    if ((target.position.y > pullBounds.bounds.y || target.position.y < pullBounds.bounds.height) && (gameObject.transform.position.y + cameraHeigth < camWorldBounds.bounds.height && gameObject.transform.position.y - cameraHeigth > camWorldBounds.bounds.y)) //If player inside bounds and camera not outside world bounds stops being locked down
                    {
                        cameraBounded = false;
                        targetY = target.position.y;
                        Debug.Log("Reentred bounds");
                    }
                }

            }
        }
        
        

        if (target.position.x + cameraWidth < camWorldBounds.bounds.width && target.position.x - cameraWidth > camWorldBounds.bounds.x)
        {
            targetX = target.position.x;
        }
        else if (target.position.x + cameraWidth > camWorldBounds.bounds.width) //If the camera is too high, move it to make its heigth the bound heigth
        {
            targetX = camWorldBounds.bounds.width - cameraWidth;
        }
        else if (target.position.x - cameraWidth > camWorldBounds.bounds.x) //If the camera is too low, move it to make its y the bound y
        {
            targetX = camWorldBounds.bounds.x + cameraWidth;
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
