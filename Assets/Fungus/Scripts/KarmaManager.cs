using Fungus;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarmaManager : MonoBehaviour
{
    public static KarmaManager Instance { get; private set; }

    [SerializeField] private int pm_Karma;
    [SerializeField] private Flowchart flowchart;

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

        UpdateFlowchart(); // For debugging, will be deleted from here.
    }

    public int GetKarma()
    {
        return pm_Karma;
    }

    public void ModifyKarma(int amount)
    {
        pm_Karma += amount;

        UpdateFlowchart();

        Debug.Log("Current Karma: " +  pm_Karma);   
    }

    private void UpdateFlowchart()
    {
        if (flowchart != null)
        {
            flowchart.SetIntegerVariable("playerKarma", pm_Karma);
        }
        else
        {
            Debug.LogWarning("Missing flowchart");
        }
    }

    public void ResetKarma()
    {
        pm_Karma = 0;
    }
}
