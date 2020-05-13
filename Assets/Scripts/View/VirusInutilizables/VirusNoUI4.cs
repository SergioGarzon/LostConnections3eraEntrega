using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VirusNoUI4 : MonoBehaviour
{
    public GameObject panelVirus;

    public GameObject objetoVirusColision;
    private VirusInutilizables virusInutilizables;

    public Text textoMostrar;

    void Start()
    {
        this.virusInutilizables = this.objetoVirusColision.GetComponent<VirusInutilizables>();
    }

    void Update()
    {
        if (this.virusInutilizables.ValidacionDatos())
        {
            this.panelVirus.SetActive(true);

            int valor = PlayerPrefs.GetInt("LenguajeGuardado", 0);

            if (valor == 0)
                this.textoMostrar.text = "SLEEPING VIRUS";
            else
                this.textoMostrar.text = "VIRUS DORMIDO";
        }

        if (!this.virusInutilizables.ValidacionDatos())
        {
            this.panelVirus.gameObject.SetActive(false);
        }
    }
}
