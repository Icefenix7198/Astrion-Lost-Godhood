using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcCollision : MonoBehaviour
{
    [SerializeField] private Flowchart m_Flowchart; // It has to change to another flowchart when finishing

    [SerializeField] private Character_Controller m_CharacterControllerScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (m_Flowchart != null)
            {
                m_Flowchart.gameObject.SetActive(true);
            }

            // Implement logic to show the button to press in order to start the dialogue
            m_CharacterControllerScript = collision.GetComponent<Character_Controller>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (m_Flowchart != null)
            {
                m_Flowchart.gameObject.SetActive(false);
            }
        }
    }

    public void EnablePlayer(bool active)
    {
        if (m_CharacterControllerScript != null)
        {
            m_CharacterControllerScript.enabled = active;
        }
    }
}
