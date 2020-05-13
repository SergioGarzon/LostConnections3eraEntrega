using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownLanguage : MonoBehaviour
{
    public Text lblLabelLanguage, txtSound, lblActivateSound,
        txtVolumeSound, txtButtonText;
    public Dropdown ddLanguage;
    

    void Update()
    {
        int valor = PlayerPrefs.GetInt("LenguajeGuardado", 0);
        
        if (this.ddLanguage.value == 0)
            this.TextoIngles();
        else
            this.TextoEspanol();
    }



    private void TextoEspanol()
    {
        this.lblLabelLanguage.text = "Lenguaje";
        this.txtSound.text = "Sonido";
        this.lblActivateSound.text = "Activar";
        this.txtVolumeSound.text = "Volumen Sonido";
        this.txtButtonText.text = "VOLVER";

        this.SaveChanges(1);

    }

    private void TextoIngles()
    {
        this.lblLabelLanguage.text = "Languague";
        this.txtSound.text = "Sound";
        this.lblActivateSound.text = "Activate";
        this.txtVolumeSound.text = "Volume Sound";
        this.txtButtonText.text = "BACK";

        this.SaveChanges(0);

    }


    private void SaveChanges(int value) {
        PlayerPrefs.SetInt("LenguajeGuardado", value);
        PlayerPrefs.Save();
    }



}
