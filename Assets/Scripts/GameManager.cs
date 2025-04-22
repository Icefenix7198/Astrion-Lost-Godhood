using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject m_questMenu;

    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            m_questMenu.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.Tab))
        {
            m_questMenu.SetActive(false);
        }
    }
}
