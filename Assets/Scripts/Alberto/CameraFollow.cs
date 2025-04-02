using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    private Vector3 velocity = Vector3.zero;
    public float smoothTime = 0.25f;

    [SerializeField] private Transform target;
    [SerializeField] private Vector4 bounds; //Up = W,down = X, left = Y rigth = Z
    [SerializeField] private Transform downBounds;
    [SerializeField] private Transform leftBounds;
    [SerializeField] private Transform rigthBounds;

    // Start is called before the first frame update
    void Start()
    {
        bounds = GameObject.FindGameObjectWithTag("EditorOnly").GetComponent<CameraBounds>().bounds;
    }   
    // Update is called once per frame
    void Update()
    {
        float targetX = 0, targetY = 0;
        if (target.position.y < bounds.w && target.position.y > bounds.x) 
        {
            targetY = target.position.y;
        }
        if (target.position.x < bounds.z && target.position.x > bounds.y)
        {
            targetX = target.position.y;
        }
        Vector3 pPosition = new Vector3(targetX, targetY, target.position.z);

        Vector3 targetPosition = pPosition + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
