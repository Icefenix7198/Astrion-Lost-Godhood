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
    private IQuestInstance _questInstance;
    [SerializeField] private PrintQuestList _activeQuestList;
    [SerializeField] private PrintQuestList _completedQuestList;

    [SerializeField] private string questName;
    [SerializeField] private Flowchart _flowchart;


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
        _questInstance = QuestJournalManager.Instance.Quests.Get(questToComplete);

        Debug.Log($"Quest: {_questInstance.Definition.DisplayName}, Status: {_questInstance.Status}");

        _questInstance.Complete();

        // Update flowchart
        _flowchart.SetBooleanVariable(questName, true);

        // Debug values
        List<string> a = _flowchart.GetVariableNames().ToList();
        Debug.Log($"Variable: {a.Find(name => name.Contains(questName))}, Value: {_flowchart.GetVariable(questName).GetValue()}");

        Debug.Log($"Quest: {_questInstance.Definition.DisplayName}, Status: {_questInstance.Status}");
    }

    public void UpdateUIOnComplete(IQuestInstance completedQuest)
    {
        _activeQuestList.UpdateUI();
        _completedQuestList.UpdateUI();
    }
}
