using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextOptions : MonoBehaviour
{
    public Dropdown ddLanguage;

    public Text txtSelectLanguage;
    public Text txtPrincipalVolume;
    public Text txtAuxVolume;

    public Slider sldVolumePrincipal;
    public Slider sldVolumeAux;

    private int valor;  //Extrae el lenguaje por guardado, 0 Inglés, 1 Español
    private int valorAux;  //Variable del lenguaje auxiliar

    private float valueAuxSliderVolume;
    private float valueAuxSliderVolumeAux;

    void Start()
    {
        this.valorAux = 10;
        this.ddLanguage.value = 0;
        this.valueAuxSliderVolume = 150f;
        this.valueAuxSliderVolumeAux = 150f;

        this.sldVolumeAux.value = 100f;
        this.sldVolumePrincipal.value = 100f;
    }

    void Update()
    {
        valor = PlayerPrefs.GetInt("LenguajeGuardado", 0);

        if (valor != valorAux)
        {
            this.valorAux = this.valor;

            if (this.ddLanguage.value == 0)
                this.TextoIngles();

            if (this.ddLanguage.value == 1)
                this.TextoEspanol();
        }

        GuardarAudios();

    }


    private void GuardarAudios()
    {
        if (this.sldVolumePrincipal.value != this.valueAuxSliderVolume)
        {
            this.valueAuxSliderVolume = this.sldVolumePrincipal.value;
            PlayerPrefs.SetFloat("LevelVolume", this.valueAuxSliderVolume);
        }


        if (this.sldVolumeAux.value != this.valueAuxSliderVolumeAux)
        {
            this.valueAuxSliderVolumeAux = this.sldVolumeAux.value;
            PlayerPrefs.SetFloat("LevalAuxiliarAudios", this.valueAuxSliderVolumeAux);
        }
    }

    private void TextoEspanol()
    {
        this.ddLanguage.value = 1;
        this.txtSelectLanguage.text = "Lenguaje:";
        this.txtPrincipalVolume.text = "Volumen Músicas:";
        this.txtAuxVolume.text = "Volumen Sonidos:";
    }

    private void TextoIngles()
    {
        this.ddLanguage.value = 0;
        this.txtSelectLanguage.text = "Language:";
        this.txtPrincipalVolume.text = "Music Volume:";
        this.txtAuxVolume.text = "Sound Volume:";
    }

}
