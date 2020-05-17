using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyCard : MonoBehaviour
{

    [SerializeField] [Range(1, 6)] public int cardValue;
    public GameObject panel;
    public Texture spanishTexture;
    public Texture englishTexture;
    public RawImage imageTexture;
    //public InventoryItem Card;
    //private InventoryScript _inventoryScript;
    public GameObject inventary;

    private void Start()
    {
        // _inventoryScript = inventary.GetComponent<InventoryScript>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (this.VerificarLenguaje() == 0)
            {
                this.imageTexture.texture = this.englishTexture;
            }
            else
            {
                this.imageTexture.texture = this.spanishTexture;
            }

            this.gameObject.SetActive(true);
            panel.gameObject.SetActive(true);

            /*
            if (this.valorTarjeta == 8)
                Card.amount += 1;
            if (this.valorTarjeta == 7)
                Card.amount += 1;
            _inventoryScript.LoadCards();
            */
            Destroy(this.gameObject);

            /*
            if (this.valorTarjeta == 2)
                PlayerPrefs.SetInt("ValorGuardadoTarjeta", valorTarjeta);

            if (this.valorTarjeta == 4)
                PlayerPrefs.SetInt("TarjetaAccesoArcade", valorTarjeta);

            if (this.valorTarjeta == 5)
                PlayerPrefs.SetInt("TarjetaAccesoPanal", valorTarjeta);
                */

            if (this.cardValue == 6)
                GuardarValorTarjetaShop();
        }
    }

    private void GuardarValorTarjetaShop()
    {
        PlayerPrefs.SetInt("TarjetaShop", 1);
    }


    private int VerificarLenguaje()
    {
        int valor = 0;

        if (PlayerPrefs.HasKey("LenguajeGuardado"))
            valor = PlayerPrefs.GetInt("LenguajeGuardado", 0);

        return valor;
    }
}