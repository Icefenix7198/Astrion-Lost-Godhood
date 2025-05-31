using Fungus;
using UnityEngine;

public class MCDialogueManager : MonoBehaviour
{
    [SerializeField] private Flowchart m_Flowchart; 
    [SerializeField] private int m_DialogueId = 0;

    public void SetDialogue()
    {
        m_Flowchart.SetIntegerVariable("Dialogue", m_DialogueId);
    }
}
