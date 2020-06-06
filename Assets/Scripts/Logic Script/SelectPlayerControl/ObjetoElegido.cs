using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjetoElegido : MonoBehaviour
{

    public Text valorElegidoText;
    private int valueAux;
    private int x;

    void Awake()
    {
        PlayerPrefs.SetInt("ObjetoElegido", 0);
        
        valueAux = -1;

        ChangeNamePlayer();
    }


    public void ChangeNamePlayer()
    {
        x = PlayerPrefs.GetInt("ObjetoElegido", 0);

        if (x != valueAux)
        {
            valueAux = x;

            switch(x)
            {
                case 0: valorElegidoText.text = "ATIF"; break;
                case 1: valorElegidoText.text = "CHARLIE"; break;
                case 2: valorElegidoText.text = "BIOWARE"; break;
            }
        }

    }
}
