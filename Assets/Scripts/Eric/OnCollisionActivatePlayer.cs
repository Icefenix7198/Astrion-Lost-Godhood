using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionActivateScript : MonoBehaviour
{
    //[SerializeField] MonoBehaviour script;
    public bool enable;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<CharacterController>() != null)
        {
            Debug.Log("Player Active UwU");
            collision.gameObject.GetComponent<CharacterController>().enabled = enable;
        }
    }
}
