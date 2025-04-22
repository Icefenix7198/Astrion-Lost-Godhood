using CleverCrow.Fluid.QuestJournals;
using CleverCrow.Fluid.QuestJournals.Examples;
using CleverCrow.Fluid.QuestJournals.Quests;
using Fungus;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestCompletion : MonoBehaviour
{
    public QuestDefinition questToComplete;
    private IQuestInstance m_questInstance;
    [SerializeField] private PrintQuestList m_activeQuestList;
    [SerializeField] private PrintQuestList m_completedQuestList;

    [SerializeField] private string m_questName;
    [SerializeField] private Flowchart m_flowchart;


    private void Start()
    {
        QuestJournalManager.Instance.Quests.EventQuestComplete.AddListener(UpdateUIOnComplete);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CompleteQuest();
        }
    }

    public void CompleteQuest()
    {
        m_questInstance = QuestJournalManager.Instance.Quests.Get(questToComplete);

        Debug.Log($"Quest: {m_questInstance.Definition.DisplayName}, Status: {m_questInstance.Status}");

        m_questInstance.Complete();

        // Update flowchart
        m_flowchart.SetBooleanVariable(m_questName, true);

        // Debug values
        List<string> a = m_flowchart.GetVariableNames().ToList();
        Debug.Log($"Variable: {a.Find(name => name.Contains(m_questName))}, Value: {m_flowchart.GetVariable(m_questName).GetValue()}");

        Debug.Log($"Quest: {m_questInstance.Definition.DisplayName}, Status: {m_questInstance.Status}");

        GetComponent<SpriteRenderer>().enabled = false;
    }

    public void UpdateUIOnComplete(IQuestInstance completedQuest)
    {
        m_activeQuestList.UpdateUI();
        m_completedQuestList.UpdateUI();
    }
}
