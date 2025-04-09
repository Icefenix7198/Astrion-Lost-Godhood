using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Collision : MonoBehaviour
{
    [SerializeField] Flowchart m_Flowchart; // It has to change to another flowchart when finishing

    // TODO Andreu: Faltaría hacer que cuando se ha hablado con un NPC, se cambie el flowchart con el típico de una frase, tengo que pensar como hacerlo.
    [SerializeField] Flowchart m_FlowchartAfterDialogue; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (m_Flowchart != null)
            {
                m_Flowchart.gameObject.SetActive(true);
            }

            // Implement logic to show the button to press in order to start the dialogue

            // Implement logic to disable the player
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
}
