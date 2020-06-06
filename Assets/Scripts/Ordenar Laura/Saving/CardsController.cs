using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CardsController : MonoBehaviour
{
    [SerializeField] private List<InventoryItem> _cards;
    [SerializeField] private ShopData shopData;
    [SerializeField] private ScoreData scoreData;

    private void Start() {
        
    }


    public void Load()
    {
        foreach (var amount in _cards) {
            amount.Load();
        }
        //fijarse en esto
        scoreData.Load();
        shopData.Load();
        SavePosition.cargarPosicionInicial = 1;

        

        SceneManager.LoadScene("SampleScene");
    }
    
    public void Save(int id) {
        _cards[id].Upgrade();
        shopData.Upgrade();
        scoreData.Upgrade();
    }
}
