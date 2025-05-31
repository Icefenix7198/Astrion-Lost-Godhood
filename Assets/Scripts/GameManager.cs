using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject m_QuestMenu;
    [SerializeField] private GameObject m_NPCsGO;
    [SerializeField] private GameObject m_Canvas;
    
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(m_QuestMenu);
            DontDestroyOnLoad(m_NPCsGO);
            DontDestroyOnLoad(m_Canvas);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            m_QuestMenu.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.Tab))
        {
            m_QuestMenu.SetActive(false);
        }
    }
}
