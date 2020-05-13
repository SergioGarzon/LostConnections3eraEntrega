using System;
using System.Collections;
   using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
   
   public class ToSave : MonoBehaviour
   {
       public ScoreData scoreData;
   
       public ShopData shopData;
   
       public InventoryItem blueCard;
       public InventoryItem greenCard;
       public InventoryItem violetCard;
       public InventoryItem blackCard;
       public InventoryItem goldenCard;

       private void Awake()
       {
           scoreData= ScriptableObject.CreateInstance<ScoreData>();
           shopData=ScriptableObject.CreateInstance<ShopData>();
           blueCard=ScriptableObject.CreateInstance<InventoryItem>();
           greenCard=ScriptableObject.CreateInstance<InventoryItem>();
           violetCard=ScriptableObject.CreateInstance<InventoryItem>();
           blackCard=ScriptableObject.CreateInstance<InventoryItem>();
           goldenCard=ScriptableObject.CreateInstance<InventoryItem>();
          
       }

       public void SaveData(References references)
       {
           Debug.Log("SE EJECUTA");
           Debug.Log(references.xp);
           Debug.Log(references.deleteSold);
           SaveSystem.SavePlayer(references);
       }
   
       public void LoadData()
       {
           SaveDataPlayer data = SaveSystem.LoadPlayer();

           scoreData.xp = data.xp;
           scoreData.hLife = data.lifeHacker;
           scoreData.mLife = data.lifeWizard;

           shopData.controlzSold = data.controlzSold;
           shopData.updateSold = data.updateSold;
           shopData.deleteSold = data.deleteSold;
           shopData.electroshockSold = data.electroshockSold;
           shopData.healSold = data.healSold;
           shopData.resettingSold = data.resettingSold;
           
           blueCard.amount = data.blueCardsamount;
           greenCard.amount = data.greenCardsamount;
           violetCard.amount = data.violetCardsamount;
           blackCard.amount = data.blackCardsamount;
           goldenCard.amount = data.goldenCardsamount;

       }
   }