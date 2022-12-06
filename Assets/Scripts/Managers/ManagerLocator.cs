using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ManagerLocator : MonoBehaviour
{

    public static ManagerLocator Instance { get; private set; }
    public LotManager LotManager {get; private set;}
    public UIManager UIManager {get; private set;}

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        
        LotManager = GetComponentInChildren<LotManager>();
        UIManager = GetComponentInChildren<UIManager>();

        if (!LotManager)
        {
            throw new Exception("No LotManager found");
        }

        if (!UIManager)
        {
            throw new Exception("No UIManager found");
        }
    }

}
