using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    private Vector3 velocity = Vector3.zero;
    public float smoothTime = 0.25f;

    [SerializeField] private Transform target;

    //Bounds
    [SerializeField] private BoundsManager camWorldBounds; //Up = W,down = X, left = Y rigth = Z
    [SerializeField] float cameraDistance;
    float lastPlayerPositionX;
    float lastPlayerPositionY;
    float cameraPosition;

    //Camera size
    [SerializeField] float cameraHeigth;
    [SerializeField] float cameraWidth;

    // Start is called before the first frame update
    void Start()
    {
        camWorldBounds = GameObject.FindGameObjectWithTag("EditorOnly").GetComponent<BoundsManager>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        cameraHeigth = this.GetComponent<Camera>().orthographicSize;
        cameraWidth = cameraHeigth * Screen.width / Screen.height;

        lastPlayerPositionX = target.transform.position.x;
        lastPlayerPositionY = target.transform.position.y;
    }   
    // Update is called once per frame
    void Update()
    {
        if (target == null) 
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    private void LateUpdate()
    {
        float smoothModifier = 1;

        float xTarget = target.transform.position.x;
        if (lastPlayerPositionX < target.transform.position.x)
        {
            cameraPosition += 0.01f;
            cameraPosition = Mathf.Min(1, cameraPosition);
        }
        else if (lastPlayerPositionX > target.transform.position.x)
        {
            cameraPosition -= 0.01f;
            cameraPosition = Mathf.Max(-1, cameraPosition);
        }

        lastPlayerPositionX = target.transform.position.x;
        //Debug.Log(cameraPosition);
        xTarget += cameraDistance * cameraPosition * cameraWidth * 2;
        
        float yTarget = target.transform.position.y;

        yTarget = target.transform.position.y;

        //Limit camera by bounds
        xTarget = Mathf.Min(camWorldBounds.bounds.width - cameraWidth, xTarget);
        xTarget = Mathf.Max(camWorldBounds.bounds.x + cameraWidth, (xTarget));
        yTarget = Mathf.Min(camWorldBounds.bounds.height - cameraHeigth, yTarget);
        yTarget = Mathf.Max(camWorldBounds.bounds.y + cameraHeigth, (yTarget));

        //Debug.Log(xTarget - cameraWidth);

        //Set position
        Vector3 targetPosition = new Vector3
            (
            xTarget,
            yTarget,
            target.transform.position.z - 10f
            );

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, (smoothTime * smoothModifier));
    }
}
