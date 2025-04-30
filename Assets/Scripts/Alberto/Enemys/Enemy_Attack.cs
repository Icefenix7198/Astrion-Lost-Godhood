using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack : MonoBehaviour
{
    SpriteRenderer sprite;
    

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sprite.flipX)
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x * -1, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        }
    }
}
