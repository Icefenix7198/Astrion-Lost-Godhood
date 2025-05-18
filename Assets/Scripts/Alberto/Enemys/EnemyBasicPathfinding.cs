using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class EnemyBasicPathfinding : MonoBehaviour
{
    public float followSpeed;
    public bool followPlayer;
    public Transform target;
    public GameObject attackZone;
    GameObject player;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").gameObject;
        spriteRenderer = GetComponent<SpriteRenderer>();
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

        if (collision.gameObject.transform.position.x > this.transform.position.x)
        {
            spriteRenderer.flipX = true;
            attackZone.transform.localPosition = new Vector3(Mathf.Abs(attackZone.transform.localPosition.x), attackZone.transform.localPosition.y, attackZone.transform.localPosition.z);
        }
        else
        {
            spriteRenderer.flipX = false;
            attackZone.transform.localPosition = new Vector3(-Mathf.Abs(attackZone.transform.localPosition.x), attackZone.transform.localPosition.y, attackZone.transform.localPosition.z);
        }
    }
}
