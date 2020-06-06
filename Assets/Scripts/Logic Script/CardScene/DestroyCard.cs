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
    public ParticleSystem particlesCard;


    private CameraPlayer camPlayer;

    private void Start()
    {
        // _inventoryScript = inventary.GetComponent<InventoryScript>();
        camPlayer = Camera.main.GetComponent<CameraPlayer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            MovementPlayerNewWorld player = other.gameObject.GetComponent<MovementPlayerNewWorld>();
            player.SetMovementPlayer(false);

            camPlayer.setCameraMovement(false);



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

            particlesCard.gameObject.SetActive(false);
            Destroy(this.gameObject);
            
            switch(cardValue)
            {
                case 4: PlayerPrefs.SetInt("ArcadeGame", 1); break;
                case 5: PlayerPrefs.SetInt("TarjetaPanal", 1); break;
                case 6: PlayerPrefs.SetInt("TarjetaShop", 1); break;                    
            }

        }
    }


    private int VerificarLenguaje()
    {
        int valor = 0;

        if (PlayerPrefs.HasKey("LenguajeGuardado"))
            valor = PlayerPrefs.GetInt("LenguajeGuardado", 0);

        return valor;
    }
}