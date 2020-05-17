using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using UnityEngine;
public class References: MonoBehaviour
{

        public ScoreData scoreData;

        [SerializeField]public ShopData shopData;

        public InventoryItem blueCard;
        public InventoryItem greenCard;
        public InventoryItem violetCard;
        public InventoryItem blackCard;
        public InventoryItem goldenCard;
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
        void Update()
        {
            xp = scoreData.xp;
            lifeHacker = scoreData.hLife;
            lifeWizard = scoreData.mLife;

            blackCardsamount = blackCard.amount;
            greenCardsamount = greenCard.amount;
            violetCardsamount = violetCard.amount;
            goldenCardsamount = goldenCard.amount;
            blueCardsamount = blueCard.amount;

            resettingSold = shopData.resettingSold;
            healSold = shopData.healSold;
            electroshockSold = shopData.electroshockSold;
            deleteSold = shopData.deleteSold;
            controlzSold = shopData.controlzSold;
            updateSold = shopData.updateSold;
        }
    }
[System.Serializable]
public class GameController
{
    public References references= GameObject.Find("References").GetComponent<References>();
    
    public int Xp;
    public int lifeHacker;
    public int lifeWizard;

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
    
}





// Update is called once per frame
