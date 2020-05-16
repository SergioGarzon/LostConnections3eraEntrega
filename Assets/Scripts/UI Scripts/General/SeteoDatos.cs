using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeteoDatos : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetInt("ValorGuardadoTarjeta", 0);
        PlayerPrefs.SetInt("TarjetaShop", 0);
        PlayerPrefs.SetInt("TarjetaAccesoArcade", 0);
        PlayerPrefs.SetInt("TarjetaAccesoPanal", 0);
    }

}
