using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcCollision : MonoBehaviour
{
    [SerializeField] private Flowchart m_Flowchart; // It has to change to another flowchart when finishing

    [SerializeField] private Character_Controller m_CharacterControllerScript;
    [SerializeField] private Combat m_CombatScript;

    [SerializeField] private GameObject m_iconGO;

    [SerializeField] private MCDialogueManager m_DialogueManager;

    private void Start()
    {
            m_DialogueManager = GetComponent<MCDialogueManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (m_Flowchart != null)
            {
                m_Flowchart.gameObject.SetActive(true);

                if (m_DialogueManager != null)
                {
                    m_DialogueManager.SetDialogue();
                }
            }

            // Implement logic to show the button to press in order to start the dialogue
            m_CharacterControllerScript = collision.GetComponent<Character_Controller>();
            m_CombatScript = collision.GetComponent<Combat>();

            if (m_iconGO != null)
            {
                m_iconGO.SetActive(true);
            }
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

            if (m_iconGO != null)
            {
                m_iconGO.SetActive(false);
            }
        }
    }

    public void EnablePlayer(bool active)
    {
        if (m_CharacterControllerScript != null && m_CombatScript != null)
        {
            m_CharacterControllerScript.enabled = active;
            m_CombatScript.enabled = active;

            if (m_iconGO != null)
            {
                m_iconGO.SetActive(active);
            }
        }
    }
}
