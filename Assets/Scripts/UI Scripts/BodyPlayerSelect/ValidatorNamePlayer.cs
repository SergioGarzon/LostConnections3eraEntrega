using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ValidatorNamePlayer : MonoBehaviour
{
    public Button btnPlayGame;
    public GameObject panelValidator;
    public Text personajeElegido;
    public InputField txtNombreIngresado;
    public Texture textureImage;
    public Text txtInformation;
    public RawImage imagenPanel;
    

    public void ValidarNombreIngresado()
    {
        if (this.txtNombreIngresado.text.Equals(""))
        {
            if (!PlayerPrefs.HasKey("LenguajeGuardado"))
            {
                PlayerPrefs.SetInt("LenguajeGuardado", 0); 
            }

            //0 Ingles, 1 Español
            int valor = PlayerPrefs.GetInt("LenguajeGuardado", 0);

            if (valor == 0)
                this.txtInformation.text = "<Please enter player name or your progress will not be saved>";
            else
                this.txtInformation.text = "<Por favor ingrese nombre de jugador sino su progreso no será guardado>";

            imagenPanel.texture = textureImage;
            this.panelValidator.SetActive(true);


            return;
        }


        SceneManager.LoadScene("SampleScene");
            
    }

}
