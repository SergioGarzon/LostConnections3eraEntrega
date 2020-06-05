using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LifePlayer : ScriptableObject
{
    public float hpPlayerOne;
    public float manaPlayerOne;

    //Por las dudas
    public float hpPlayerTwo;  
    public float manaPlayerTwo;

    public float hpPlayerThree;
    public float manaPlayerThree;

    public void Load()
    {
        hpPlayerTwo = SessionData.Data.hpPlayerOne;
        manaPlayerOne = SessionData.Data.manaPlayerOne;

        hpPlayerTwo = SessionData.Data.hpPlayerTwo;
        manaPlayerTwo = SessionData.Data.manaPlayerTwo;

        hpPlayerThree = SessionData.Data.hpPlayerThree;
        manaPlayerThree = SessionData.Data.manaPlayerThree;

        //Debug.Log(SessionData.Data.lifeHacker);
        SessionData.LoadData();
    }

    public void Upgrade()
    {
        SessionData.Data.hpPlayerOne = hpPlayerOne;
        SessionData.Data.manaPlayerOne = manaPlayerOne;
        SessionData.Data.hpPlayerTwo = hpPlayerTwo;
        SessionData.Data.manaPlayerTwo = manaPlayerTwo;
        SessionData.Data.hpPlayerThree = hpPlayerThree;
        SessionData.Data.manaPlayerThree = manaPlayerThree;



        //to save
        SessionData.SaveData();
    }

}
