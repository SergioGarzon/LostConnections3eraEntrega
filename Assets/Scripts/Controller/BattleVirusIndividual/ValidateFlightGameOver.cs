using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValidateFlightGameOver : MonoBehaviour
{
    public GameObject panelBattle; //Panal de batalla
    public GameObject panelGameOver; //Panel game over

    public GameObject panelTarjetasGB;


    //Estos se debe a que se congela el movimiento del personaje
    public GameObject objetoPlayer;
    private MovementPlayerNewWorld movimientoPlayer;


    //Esto es porque le freeza el movimiento
    public Camera camaraPrincipal;
    private CameraPlayer camaraPlayer;

    public Canvas canvasLaura; //canvas de Laura


    public GameObject virusColisionPlayer;  //Objeto de la maquina de estados batalla
    private VirusColisionPlayer colisionVirus;


   

    private int valor; //Variable entera



    void Start()
    {

        this.movimientoPlayer = this.objetoPlayer.GetComponent<MovementPlayerNewWorld>();
        this.camaraPlayer = this.camaraPrincipal.GetComponent<CameraPlayer>();

        this.colisionVirus = this.virusColisionPlayer.GetComponent<VirusColisionPlayer>();

        this.valor = 0;
    }

    void Update()
    {

        if (this.valor != 0)  //No desactiva
        {
            this.panelBattle.gameObject.SetActive(false);  //aun no desactiva
            this.canvasLaura.gameObject.SetActive(true);
            this.panelTarjetasGB.gameObject.SetActive(true);
        }


        if (this.valor == 2)
        {
            this.canvasLaura.gameObject.SetActive(false);
            this.panelTarjetasGB.gameObject.SetActive(false);
        }


        if (this.colisionVirus.getLostGame())
        {
            this.panelGameOver.gameObject.SetActive(true);
            this.movimientoPlayer.setMovementPlayer(false);
            this.camaraPlayer.setCameraMovement(false);
            this.canvasLaura.gameObject.SetActive(false);
            this.panelTarjetasGB.gameObject.SetActive(false);
        }


        if (this.colisionVirus.getReturnColisionGame())
        {
            this.panelBattle.gameObject.SetActive(true);
            this.canvasLaura.gameObject.SetActive(false);
            this.panelTarjetasGB.gameObject.SetActive(false);
            this.valor = 0;
        }


    }

    public void setSalirBatalla()
    {
        this.valor = 1;
    }

    public void setCerrarCanvas()
    {
        this.valor = 2;
    }


}
