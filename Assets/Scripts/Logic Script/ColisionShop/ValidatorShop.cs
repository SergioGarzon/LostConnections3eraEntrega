using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidatorShop : MonoBehaviour
{
    private bool validatorActive;
    private string tipoShopText;
    public int valor;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.validatorActive = true;
            this.setTipoShop();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.validatorActive = false;
        }
    }

    public bool getValidatorActive()
    {
        return this.validatorActive;
    }

    public void setTipoShop()
    {
        this.tipoShopText = this.validarTextoLanguage(valor);
    }

    public string getTipoShop()
    {
        return this.tipoShopText;
    }

    private string validarTextoLanguage(int x)
    {
        string textoRetornar = "";

        int lenguage = PlayerPrefs.GetInt("LenguajeGuardado", 0);

        if (lenguage == 0)  //0 es inglés, 1 es español
        {
            textoRetornar = "You can't enter this place \nuntil you reach level " + x;
        }
        else
        {
            textoRetornar = "No puedes ingresar a este espacio \nhasta llegar al nivel " + x + ".";
        }

        return textoRetornar;
    }
}
