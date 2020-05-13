using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlayerSelectPrincipalBattle : MonoBehaviour
{
    public GameObject objetoActivadorBotones;
    private HabilitarBotonesBatalla botones;

    void Start()
    {
        this.botones = this.objetoActivadorBotones.GetComponent<HabilitarBotonesBatalla>();
    }

    public void ActivarAtaquesCharlie()
    {
        this.botones.ActivarBotonesAtaqueCharlie();
    }

    public void ActivarAtaquesAtif()
    {
        this.botones.ActivarBotonesAtaquesAtif();
    }

    public void ActivarAtaqueBug()
    {
        this.botones.ActivarBotonesMaquinaBatalla(3);
    }

    public void ActivarSteal()
    {
        this.botones.ActivarBotonesMaquinaBatalla(4);
    }

    public void ActivarPixel()
    {
        this.botones.ActivarBotonesMaquinaBatalla(5);
    }

    public void ActivarShock()
    {
        this.botones.ActivarBotonesMaquinaBatalla(6);
    }

    public void ActivarElectricity()
    {
        this.botones.ActivarBotonesMaquinaBatalla(7);
    }

    public void ActivarLighting()
    {
        this.botones.ActivarBotonesMaquinaBatalla(8);
    }
}
