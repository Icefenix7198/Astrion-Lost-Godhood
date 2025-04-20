using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class GenericCollisonEventCall : MonoBehaviour
{
    [SerializeField] UnityEvent OnEnter;

    [SerializeField] UnityEvent OnExit;

    [SerializeField] GameObject checker;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (checker != null) 
        {
            if(collision.gameObject == checker) 
            {
                OnEnter.Invoke();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (checker != null)
        {
            if (collision.gameObject == checker)
            {
                OnExit.Invoke();
            }
        }
    }
}
