using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusInutilizables : MonoBehaviour
{
    private bool validarDatos;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            this.validarDatos = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            this.validarDatos = false;
        }
    }

    public bool ValidacionDatos()
    {
        return this.validarDatos;
    }

}
