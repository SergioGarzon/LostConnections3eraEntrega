using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class AccessBattlePanal : MonoBehaviour
{
    [SerializeField] private Transform objectBattleOnePlayer; //Objeto de la posicion del player en batalla (Arriba del panal)
    [SerializeField] private Transform objectBattleTwoPlayer; //Objeto de la posicion del mago en batalla (Arriba del panal)
    [SerializeField] private Transform initialPosition;  //Objeto posicion inicial

    //Objetos personajes
    public GameObject objetoActivarBattleMachine; //Objeto que activa la batalla arriba del Panal
    public GameObject objetoPlayerOne;
    public GameObject objetoPlayerTwo;

    private bool accesoAutorizadoNO;
    private bool ingresarPanal;
    private bool chargeEnergy;
    private int valor;

    public ScoreData score;



    void Start()
    {
        this.accesoAutorizadoNO = false;
        this.ingresarPanal = false;
        this.chargeEnergy = true;
        this.valor = 0;
    }


    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            validarTarjetaAcceso();

            if (this.ingresarPanal)
            {
                if(this.score.mLife >= 100 && this.score.hLife >= 100)
                {
                    this.objetoPlayerOne.SetActive(false);
                    this.objetoPlayerTwo.SetActive(false);
                    this.chargeEnergy = false;
                    this.valor = 1;
                }                
                else
                {
                    this.chargeEnergy = true;
                }
            }
        }
    }

    public void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.accesoAutorizadoNO = false;
            this.chargeEnergy = false;
        }
    }

    public bool getAccesoAutorizadoNO()
    {
        return this.accesoAutorizadoNO;
    }

    public bool getIngresoPanal()
    {
        return this.ingresarPanal;
    }

    public bool getChargeEnergy()
    {
        return this.chargeEnergy;
    }

    public int getValorReturn()
    {
        return this.valor;
    }

    private void validarTarjetaAcceso()
    {
        int tarjetaAccesoPanal = PlayerPrefs.GetInt("TarjetaAccesoPanal", 0);

        if (tarjetaAccesoPanal != 5)
            this.accesoAutorizadoNO = true;
        else
        {
            this.ingresarPanal = true;
            this.accesoAutorizadoNO = false;
        }
    }





}
