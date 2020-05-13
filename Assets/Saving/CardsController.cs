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
            Debug.Log("Violet antes de cargar "+SessionData.Data.cardsAmount[0]);
            Debug.Log("Antes load:"+SessionData.Data.resettingSold);
            amount.Load();
        }
        //fijarse en esto
        scoreData.Load();
        shopData.Load();
        SavePosition.cargarPosicionInicial = 1;

        


        Debug.Log("Violet "+SessionData.Data.cardsAmount[0]);
        Debug.Log("despues load:"+SessionData.Data.resettingSold);

        SceneManager.LoadScene("SampleScene");
    }
    
    public void Save(int id) {
        Debug.Log("Antes save:"+shopData.resettingSold);
        Debug.Log("Violet antes de guardar "+SessionData.Data.cardsAmount[0]);
        _cards[id].Upgrade();
        shopData.Upgrade();
        scoreData.Upgrade();
        Debug.Log("Violet "+SessionData.Data.cardsAmount[0]);
        Debug.Log("despues Save:"+SessionData.Data.resettingSold);
    }
}
