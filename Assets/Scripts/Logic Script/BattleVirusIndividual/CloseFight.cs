using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseFight : MonoBehaviour
{
    public GameObject objetoPlayer;
    private MovementPlayerNewWorld movimientoMundo;

    public Camera camara;
    private CameraPlayer camPlayer;

    public GameObject objetoPanel;
    private ValidateFlightGameOver validacionGameOver;


    void Start()
    {
        this.movimientoMundo = this.objetoPlayer.GetComponent<MovementPlayerNewWorld>();
        this.camPlayer = this.camara.GetComponent<CameraPlayer>();
        this.validacionGameOver = this.objetoPanel.GetComponent<ValidateFlightGameOver>();
    }

    public void setMovimientoAndCamara()
    {
        this.movimientoMundo.setMovementPlayer(true);
        this.camPlayer.setCameraMovement(true);
        this.validacionGameOver.setSalirBatalla();

    }
}
