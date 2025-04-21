using Adnc.Utility;
using CleverCrow.Fluid.QuestJournals.Quests;
using UnityEngine;
using UnityEngine.Events;

namespace CleverCrow.Fluid.QuestJournals.Examples
{
    public class PrintQuestList : MonoBehaviour {
        [SerializeField]
        private GenericButton _buttonPrefab;

        [SerializeField]
        private PrintQuestDetails _printQuest;

        [SerializeField]
        private UnityEvent<IQuestInstance> _onQuestClick;

        [SerializeField]
        private bool _showAllQuests = true;

        [ShowToggle("_showAllQuests", false)]
        [SerializeField]
        private QuestStatus _showQuestsWithStatus;

        private void Start () {
            foreach (Transform t in transform) {
                Destroy(t.gameObject);
            }

            var allQuests = QuestJournalManager.Instance.Quests.GetAll();
            allQuests.ForEach(quest => {
                if (!_showAllQuests && quest.Status != _showQuestsWithStatus) {
                    return;
                }

                var btn = Instantiate(_buttonPrefab, transform);
                btn.BindButton(() => ClickQuest(quest));
                btn.SetText(quest.Title);
            });

            _printQuest.SetQuest(allQuests[0]);

            QuestJournalManager.Instance.Quests.EventQuestAdd.AddListener(OnQuestAdded);
        }

        private void ClickQuest (IQuestInstance quest) {
            _onQuestClick.Invoke(quest);
        }

        private void OnQuestAdded(IQuestInstance addedQuest)
        {
            // Clear previous buttons if you're reloading the whole list
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }

            var allQuests = QuestJournalManager.Instance.Quests.GetAll();
            foreach (var quest in allQuests)
            {
                if (!_showAllQuests && quest.Status != _showQuestsWithStatus)
                {
                    continue;
                }

                var btn = Instantiate(_buttonPrefab, transform);
                btn.BindButton(() => ClickQuest(quest));
                btn.SetText(quest.Title);
            }

            if (allQuests.Count > 0)
            {
                _printQuest.SetQuest(allQuests[0]);
            }
        }
    }
}
