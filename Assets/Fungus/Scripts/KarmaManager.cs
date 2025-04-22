using Fungus;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KarmaManager : MonoBehaviour
{
    public static KarmaManager Instance { get; private set; }

    [SerializeField] private int m_Karma;
    [SerializeField] private TextMeshProUGUI m_text;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int GetKarma()
    {
        return m_Karma;
    }

    public void ModifyKarma(int amount, Flowchart flowchart)
    {
        m_Karma += amount;

        flowchart.SetIntegerVariable("playerKarma", m_Karma);

        if (m_text != null)
        {
            m_text.text = "Karma: " + m_Karma;
        }

        Debug.Log("Current Karma: " + m_Karma);
    }

    public void ResetKarma()
    {
        m_Karma = 0;
    }
}
