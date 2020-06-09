using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (menuName = "Shop/ShopData")]
public class ShopData : ScriptableObject
{
    [SerializeField] private bool resettingSoldBool = false;
    [SerializeField] private bool healSoldBool = false;
    [SerializeField] private bool electroshockSoldBool = false;
    [SerializeField] private bool deleteSoldBool = false;
    [SerializeField] private bool controlzSoldBool = false;
    [SerializeField] private bool updateSoldBool = false;
    [SerializeField] private bool superHitSoldBool = false;
    [SerializeField] private bool canyonSoldBool = false;
    [SerializeField] private bool scannerSoldBool = false;
    
    [NonSerialized] public bool resettingSold;
    [NonSerialized] public bool healSold;
    [NonSerialized] public bool electroshockSold;
    [NonSerialized] public bool deleteSold;
    [NonSerialized] public bool controlzSold;
    [NonSerialized] public bool updateSold;
    [NonSerialized] public bool superHitSold;
    [NonSerialized] public bool canyonSold;
    [NonSerialized] public bool scannerSold;
    
    public void UpdateFlags()
    {
        resettingSold = resettingSoldBool;
        healSold = healSoldBool;
        electroshockSold = electroshockSoldBool;
        deleteSold = controlzSoldBool;
        updateSold = updateSoldBool;
        superHitSold = superHitSoldBool;
        canyonSold = canyonSoldBool;
        scannerSold = scannerSoldBool;
    }
    public void Load() {
        //actualizar valores de Dante
        resettingSold = SessionData.Data.resettingSold;
        healSold = SessionData.Data.healSold;
        electroshockSold = SessionData.Data.electroshockSold;
        deleteSold = SessionData.Data.deleteSold;
        controlzSold = SessionData.Data.controlzSold;
        superHitSold = SessionData.Data.superHitSold;
        canyonSold = SessionData.Data.canyonSold;
        scannerSold = SessionData.Data.scannerSold;
        SessionData.LoadData();
    }

    public void Upgrade() {
        //Dante
        SessionData.Data.resettingSold = resettingSold;
        SessionData.Data.healSold = healSold;
        SessionData.Data.electroshockSold = electroshockSold;
        SessionData.Data.deleteSold = deleteSold;
        SessionData.Data.controlzSold = controlzSold;
        SessionData.Data.superHitSold = superHitSold;
        SessionData.Data.canyonSold = canyonSold;
        SessionData.Data.scannerSold = scannerSold;
        SessionData.SaveData();
    }
}
[Serializable]
public class SerializableFlags {
    private bool resettingSoldBool = false;
    private bool healSoldBool = false;
    private bool electroshockSoldBool = false;
    private bool deleteSoldBool = false;
    private bool controlzSoldBool = false;
    private bool updateSoldBool = false;
    private bool superHitSoldBool = false;
    private bool canyonSoldBool = false;
    private bool scannerSoldBool = false;
}

