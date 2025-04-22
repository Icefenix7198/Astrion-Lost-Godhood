using CleverCrow.Fluid.QuestJournals;
using CleverCrow.Fluid.QuestJournals.Quests;
using UnityEngine;

public class NpcQuest : MonoBehaviour
{
    public QuestDefinition questToAdd;

    public void AddQuest()
    {
        var allQuests = QuestJournalManager.Instance.Quests.GetAll();

        foreach (var quest in allQuests)
        {
            Debug.Log($"Quest: {quest.Definition.DisplayName}, Status: {quest.Status}");
        }

        QuestJournalManager.Instance.Quests.Add(questToAdd);

        allQuests = QuestJournalManager.Instance.Quests.GetAll();

        foreach (var quest in allQuests)
        {
            Debug.Log($"Quest: {quest.Definition.DisplayName}, Status: {quest.Status}");
        }
    }
}
