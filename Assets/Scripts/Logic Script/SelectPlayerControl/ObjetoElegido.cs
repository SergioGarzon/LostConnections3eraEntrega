using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjetoElegido : MonoBehaviour
{

    public Text valorElegidoText;
    private int valorAux;

    void Awake()
    {

        PlayerPrefs.SetInt("ObjetoElegido", 0);
    }

    void Start()
    {
        this.valorAux = 10;
    }


    void Update()
    {
        int x = PlayerPrefs.GetInt("ObjetoElegido", 0);

        if (x != valorAux)
        {
            this.valorAux = x;


            switch(x)
            {
                case 0: this.valorElegidoText.text = "ATIF"; break;
                case 1: this.valorElegidoText.text = "CHARLIE"; break;
                case 2:  this.valorElegidoText.text = "BIOWARE"; break;
            }
                

        }

    }
}
