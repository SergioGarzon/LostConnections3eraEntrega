using UnityEngine;
using System;

public class SessionData {

	private static GameDataSave GAME_DATA;

	public static bool LoadData() {
        var valid = false;

        var data = PlayerPrefs.GetString("data", "");
        if (data != "") {
	        var success = DESEncryption.TryDecrypt(data, out var original);
	        if (success) {
		        GAME_DATA = JsonUtility.FromJson<GameDataSave>(original);
		        GAME_DATA.LoadData();
		        valid = true;    
	        }
	        else {
		        GAME_DATA = new GameDataSave();
	        }
            
        } else {
            GAME_DATA = new GameDataSave();
        }

        return valid;
    }

    public static bool SaveData() {
        const bool valid = false;

        try {
            GAME_DATA.SaveData();
            var result = DESEncryption.Encrypt(JsonUtility.ToJson(SessionData.GAME_DATA));
            PlayerPrefs.SetString("data", result);
            Debug.Log("Saved");
            PlayerPrefs.Save();
        } catch (Exception ex) {
            Debug.LogError(ex.ToString());
        }

        return valid;
    }

    public static GameDataSave Data {
        get {
			if (GAME_DATA == null)
                LoadData();
			return GAME_DATA;
        }
    }

}


[Serializable]
public class GameDataSave {
	//Put attributes that you want to save during your game.

	public int xp;
	public int lifeHacker;
	public int lifeWizard;
	public int[] cardsAmount = { 0, 0 , 0 ,0, 0};
	public bool resettingSold;
	public bool healSold;
	public bool electroshockSold;
	public bool deleteSold;
	public bool controlzSold;
	public bool updateSold; 

	public GameDataSave()
	{
		lifeHacker = 200;
		cardsAmount[0] = 0;
		resettingSold = true;
	}

	public void SaveData() {
		
    }

	public void LoadData()
	{
		
	}
}