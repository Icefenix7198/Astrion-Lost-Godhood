using CleverCrow.Fluid.QuestJournals;
using CleverCrow.Fluid.QuestJournals.Examples;
using CleverCrow.Fluid.QuestJournals.Quests;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public QuestDefinition questToComplete;
    private IQuestInstance _questInstance;
    [SerializeField] private PrintQuestList _activeQuestList;
    [SerializeField] private PrintQuestList _completedQuestList;

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

        Debug.Log($"Quest: {_questInstance.Definition.DisplayName}, Status: {_questInstance.Status}");
    }

    public void UpdateUIOnComplete(IQuestInstance completedQuest)
    {
        _activeQuestList.UpdateUI();
        _completedQuestList.UpdateUI();
    }
}
