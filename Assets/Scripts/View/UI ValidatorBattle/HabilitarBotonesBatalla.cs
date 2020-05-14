using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HabilitarBotonesBatalla : MonoBehaviour
{
    public Button BtnEscapeBack, BtnCharlie, BtnAtif, BtnBack, BtnBug, BtnSteal, BtnPixel,
        BtnShock, BtnLighning, BtnElectricity;
    public Button btnAtaques;
    public ShopData shopd;

    public GameObject objetoBattalla;
    public int tipoBatalla;


    void Start()
    {
        BotonesIniciales();
    }

    public void BotonesIniciales()
    {
        this.PanelesVeracidadActivacion(false, true, true, false, false, false, false, false, false, false);

    }

    public void ActivarBotonesAtaqueCharlie()
    {
        this.PanelesVeracidadActivacion(false, false, false, true, true, true, true, false, false, false);

    }


    public void ActivarBotonesAtaquesAtif()
    {
        this.PanelesVeracidadActivacion(false, false, false, true, false, false, false, true, true, true);
    }

    public void ActivarBotonesMaquinaBatalla(int x)
    {
            BotonesIniciales();
    }


    public void PanelesVeracidadActivacion(bool pnlEsc, bool pnlCharlie, bool pnlAtif, bool pnlBack, bool pnlBug,
        bool pnlSteal, bool pnlPixel, bool pnlShock, bool pnlLight, bool pnlElect)
    {
        this.BtnEscapeBack.gameObject.SetActive(pnlEsc);
        this.BtnCharlie.gameObject.SetActive(pnlCharlie);
        this.BtnAtif.gameObject.SetActive(pnlAtif);
        this.BtnBack.gameObject.SetActive(pnlBack);
        this.BtnBug.gameObject.SetActive(pnlBug);
        this.BtnSteal.gameObject.SetActive(pnlSteal);
        this.BtnPixel.gameObject.SetActive(pnlPixel);
        this.BtnShock.gameObject.SetActive(pnlShock);
        this.BtnLighning.gameObject.SetActive(pnlLight);
        this.BtnElectricity.gameObject.SetActive(pnlElect);
    }
}
