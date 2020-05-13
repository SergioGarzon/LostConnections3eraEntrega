using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScoreGB : MonoBehaviour
{
    [SerializeField] [Range(1, 3)] public int valorTarjeta;  //1 Tarjeta Black, 2 - Tarjeta Golden
    public InventoryItem Card;
    private InventoryScript _inventoryScript;
    public GameObject inventary;

    private void Start()
    {
        _inventoryScript = inventary.GetComponent<InventoryScript>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (this.valorTarjeta == 1)
                Card.amount += 1;
            if (this.valorTarjeta == 2)
                Card.amount += 1;
            if (this.valorTarjeta == 3)
                GuardarValorTarjetaShop();
            
            _inventoryScript.LoadCards();
            
            Destroy(this.gameObject);

        }
    }

    private void GuardarValorTarjetaShop()
    {
        PlayerPrefs.SetInt("TarjetaShop", 1);
    }
}
