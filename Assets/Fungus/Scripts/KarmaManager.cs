using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarmaManager : MonoBehaviour
{
    public static KarmaManager Instance { get; private set; }

    [SerializeField] private int pm_Karma;

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

    public void ModifyKarma(int amount)
    {
        pm_Karma += amount;
        Debug.Log("Current Karma: " +  pm_Karma);   
    }

    public void ResetKarma()
    {
        pm_Karma = 0;
    }
}
