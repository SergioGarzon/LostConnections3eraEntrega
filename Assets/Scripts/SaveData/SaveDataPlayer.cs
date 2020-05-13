using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveDataPlayer
{
    public int xp;
    public int lifeHacker;
    public int lifeWizard;
    public int battlesWon;

    public int blueCardsamount;
    public int violetCardsamount;
    public int greenCardsamount;
    public int blackCardsamount;
    public int goldenCardsamount;

    public bool resettingSold;
    public bool healSold;
    public bool electroshockSold;
    public bool deleteSold;
    public bool controlzSold;
    public bool updateSold;

    private References references;
    
    public SaveDataPlayer(References references)
    
    {
        xp = references.xp;
        lifeHacker = references.lifeHacker;
        lifeWizard = references.lifeWizard;

        blackCardsamount = references.blackCardsamount;
        greenCardsamount = references.greenCardsamount;
        violetCardsamount = references.violetCardsamount;
        goldenCardsamount = references.goldenCardsamount;
        blueCardsamount = references.blueCardsamount;

        resettingSold = references.resettingSold;
        healSold = references.healSold;
        electroshockSold = references.electroshockSold;
        deleteSold = references.deleteSold;
        controlzSold = references.controlzSold;
        updateSold = references.updateSold;

    }
}
