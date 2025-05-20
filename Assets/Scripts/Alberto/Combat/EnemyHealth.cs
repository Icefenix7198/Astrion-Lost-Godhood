using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EnemyHealthNamespace
{
    public class EnemyHealth : MonoBehaviour
    {
        [Header("Life Variables")]
        public float life;

        public bool unlocksDoor;
        public GameObject door;

        private QuestCompletionKill m_QuestKill;

        private void Start()
        {
              m_QuestKill = GetComponent<QuestCompletionKill>();
        }

        private void Update()
        {
            if (life <= 0)
            {
                if (m_QuestKill != null)
                {
                    m_QuestKill.CompleteQuest();
                }

                Destroy(gameObject);

                if (unlocksDoor)
                {
                    Destroy(door);
                }
            }
        }

        public void RecieveDamage(float damage)
        {
            life -= damage;
        }
    }

    //[CustomEditor(typeof(EnemyHealth))]
    //public class EnemyHealth_Editor : Editor
    //{
    //    public override void OnInspectorGUI()
    //    {
    //        var script = (EnemyHealth)target;

    //        script.life = EditorGUILayout.FloatField(label: "Life", script.life);
    //        script.unlocksDoor = EditorGUILayout.Toggle(label:"Unlocks Door", script.unlocksDoor);

    //        if (script.unlocksDoor == false)
    //            return;

    //        script.door = EditorGUILayout.ObjectField(label:"Door Gameobject", script.door, typeof(GameObject),true) as GameObject;
    //    }
    //}
}
