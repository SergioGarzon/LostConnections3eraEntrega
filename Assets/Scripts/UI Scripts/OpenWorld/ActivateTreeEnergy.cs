using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateTreeEnergy : MonoBehaviour
{
    public GameObject objetoPanel;
    public GameObject objetoArboles;
    private ChargeLifeTree vidaArbol;
    public ScoreData scorePuntaje;
    public Text textoPressE;
    

    void Start()  
    {
        this.vidaArbol = this.objetoArboles.GetComponent<ChargeLifeTree>();
        this.RestaurarDatos();
    }


    void Update()
    {
        if (this.vidaArbol.VeracidadActivadorPanel() == 1)
        {
            this.objetoPanel.SetActive(true);


            if (Input.GetKey(KeyCode.E))
            {

                this.scorePuntaje.mLife = 100;
                this.scorePuntaje.hLife = 100;
            }

            if(this.scorePuntaje.mLife == 100 && this.scorePuntaje.hLife == 100) {
                int x = PlayerPrefs.GetInt("", 0);

                if (x == 0) this.textoPressE.text = "CHARGED ENERGY";
                else this.textoPressE.text = "ENERGIA CARGADA";
            }
        }


        if(this.vidaArbol.VeracidadActivadorPanel() == 2)
        {
            this.objetoPanel.SetActive(false);

            this.vidaArbol.SetValorColisionActivadorPanel(0);
        }

        
    }


    public void RestaurarDatos()
    { 
        this.textoPressE.gameObject.SetActive(true);
    }




}
