using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjetoElegido : MonoBehaviour
{

    public Text valorElegidoText;
    private int valorAux;

    void Start()
    {
        this.valorAux = 10;
        PlayerPrefs.SetInt("ObjetoElegido", 1);
    }


    void Update()
    {
        int x = PlayerPrefs.GetInt("ObjetoElegido", 0);

        if (x != valorAux)
        {
            this.valorAux = x;


            if (x == 1)
                this.valorElegidoText.text = "ATIF";
            else
                this.valorElegidoText.text = "CHARLIE";

        }

    }
}
