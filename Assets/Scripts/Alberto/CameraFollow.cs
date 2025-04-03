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
        if (target.position.y + cameraHeigth < cameraBounds.bounds.height && target.position.y - cameraHeigth > cameraBounds.bounds.y) 
        {
            targetY = target.position.y;
        }
        if (target.position.x + cameraWidth < cameraBounds.bounds.width && target.position.x - cameraWidth > cameraBounds.bounds.x)
        {
            targetX = target.position.x;
        }
        Vector3 pPosition = new Vector3(targetX, targetY, target.position.z);

        Vector3 targetPosition = pPosition + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
