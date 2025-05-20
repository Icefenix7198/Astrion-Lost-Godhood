using CleverCrow.Fluid.QuestJournals;
using CleverCrow.Fluid.QuestJournals.Examples;
using CleverCrow.Fluid.QuestJournals.Quests;
using EnemyHealthNamespace;
using Fungus;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestCompletionKill : MonoBehaviour
{
    public QuestDefinition questToComplete;
    private IQuestInstance m_questInstance;
    [SerializeField] private PrintQuestList m_activeQuestList;
    [SerializeField] private PrintQuestList m_completedQuestList;


    void Start()
    {
        QuestJournalManager.Instance.Quests.EventQuestComplete.AddListener(UpdateUIOnComplete);
    }

    public void CompleteQuest()
    {
        m_questInstance = QuestJournalManager.Instance.Quests.Get(questToComplete);

        Debug.Log($"Quest: {m_questInstance.Definition.DisplayName}, Status: {m_questInstance.Status}");

        m_questInstance.Complete();

        Debug.Log($"Quest: {m_questInstance.Definition.DisplayName}, Status: {m_questInstance.Status}");
    }


    public void UpdateUIOnComplete(IQuestInstance completedQuest)
    {
        m_activeQuestList.UpdateUI();
        m_completedQuestList.UpdateUI();
    }
}
