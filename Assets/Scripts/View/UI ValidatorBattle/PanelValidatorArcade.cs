using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelValidatorArcade : MonoBehaviour
{

    public GameObject panelInformationValidator;
    public GameObject objetoValidadorPanel;
    private ValidatorArcade validArcade;
    public Text textoArcade;
    public Texture texturaEspanol;
    public Texture texturaIngles;
    public Texture texturaComun;
    public RawImage imagenInformation;

    void Start()
    {
        this.validArcade = this.objetoValidadorPanel.GetComponent<ValidatorArcade>();
    }

    void Update()
    {
        int lenguaje = PlayerPrefs.GetInt("LenguajeGuardado", 0);

        if (this.validArcade.getValidatorArcade())
        {
            int valorTarjeta = PlayerPrefs.GetInt("TarjetaAccesoArcade", 0);

            if (valorTarjeta == 4)
            {
                if (lenguaje == 0) //Ingles 
                {
                    this.textoArcade.text = "The Mini Games Arcade is currently " +
                        "\nunder renovation, please come back soon \nto enjoy the updates";
                }
                
                if(lenguaje == 1)
                {
                    this.textoArcade.text = "El Arcade de Mini Juegos se encuentra \n" +
                        "momentáneamente en remodelación, \n" +
                        "por favor vuelva pronto para disfrutar \nde las actualizaciones. ";
                }

                this.imagenInformation.texture = this.texturaComun;
            }
            else
            {
                if (lenguaje == 0) //Ingles 
                {
                    this.imagenInformation.texture = this.texturaEspanol;
                }

                if (lenguaje == 1)
                {
                    this.imagenInformation.texture = this.texturaIngles;
                }
            }

            this.panelInformationValidator.SetActive(true);


        }

        if (!this.validArcade.getValidatorArcade())
        {
            this.panelInformationValidator.SetActive(false);
        }
    }
}
