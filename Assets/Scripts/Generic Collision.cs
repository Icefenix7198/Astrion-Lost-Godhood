using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class GenericCollisonEventCall : MonoBehaviour
{
    public UnityEvent OnEnter;

    public UnityEvent OnExit;

    [SerializeField] GameObject checker;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (checker != null) 
        {
            if(collision.gameObject.name == checker.name) 
            {
                Debug.Log("Generic Trigger Activated On Enter of" + this.gameObject.name);
                OnEnter?.Invoke();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (checker != null)
        {
            Debug.Log("Generic Trigger Activated On Exit of" + this.gameObject.name);
            if (collision.gameObject.name == checker.name)
            {
                OnExit?.Invoke();
            }
        }
    }
}
