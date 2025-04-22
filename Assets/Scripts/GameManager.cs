using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject m_questMenu;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            m_questMenu.SetActive(!m_questMenu.activeSelf);
        }
    }
}
