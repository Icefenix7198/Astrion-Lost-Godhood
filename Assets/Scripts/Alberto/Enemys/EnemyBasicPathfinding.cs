using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasicPathfinding : MonoBehaviour
{
    public float followSpeed;
    public bool followPlayer;
    public Transform target;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").gameObject;
        followPlayer = false;
    }

    private void FixedUpdate()
    {
        if (followPlayer)
        {
            Vector3 positionTarget = new Vector3();

            target = player.transform;

            positionTarget = Vector3.MoveTowards(this.transform.position, target.position, followSpeed);
            this.transform.position = new Vector3(positionTarget.x, this.transform.position.y, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Hit Player");
        }
    }
}
