using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChangeDropDown : MonoBehaviour
{
    public Dropdown ddLanguage;
    private int valorAux;

    void Start()
    {
        this.valorAux = 10;
    }

    void Update()
    {
        if (this.ddLanguage.value != this.valorAux)
        {
            this.valorAux = this.ddLanguage.value;

            switch (ddLanguage.value)
            {
                case 0: UpdateLanguage(0); break;
                case 1: UpdateLanguage(1); break;
            }
        }
    }

    private void UpdateLanguage(int val)
    {
        PlayerPrefs.SetInt("LenguajeGuardado", val);
    }


}
