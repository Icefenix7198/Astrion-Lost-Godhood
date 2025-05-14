using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionActivateScript : MonoBehaviour
{
    //[SerializeField] MonoBehaviour script;
    public bool enable;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Character_Controller>() != null)
        {
            Debug.Log("Player Active");
            collision.gameObject.GetComponent<Character_Controller>().enabled = enable;
        }
    }
}
