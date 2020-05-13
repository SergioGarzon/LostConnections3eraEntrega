using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelUIShop : MonoBehaviour
{
    public GameObject objectPanel;  //Panel que se activara para mostrar la imagen    
    public Text txtMessage;

    public GameObject objectShopCollider;  //Objeto 2
    private ValidatorShop validadorColider;  //Se utiliza la misma clase ya que cumple la misma función

    public GameObject objectShopCollider2;
    private ValidatorShop validadorColider2;

    public GameObject objectShopCollider3;
    private ValidatorShop validadorColider3;


    void Start()
    {
        this.validadorColider = this.objectShopCollider.GetComponent<ValidatorShop>();
        this.validadorColider2 = this.objectShopCollider2.GetComponent<ValidatorShop>();
        this.validadorColider3 = this.objectShopCollider3.GetComponent<ValidatorShop>();
    }
    void Update()
    {
        this.validadColision1();
        this.validadColision2();
        this.validadColision3();

        if (!this.validadorColider.getValidatorActive() && !this.validadorColider2.getValidatorActive() &&
            !this.validadorColider3.getValidatorActive())
        {
            this.objectPanel.gameObject.SetActive(false);
        }
    }

    private void validadColision1()
    {
        if (this.validadorColider.getValidatorActive())
        {
            Debug.Log(this.validadorColider.getTipoShop());
            this.txtMessage.text = this.validadorColider.getTipoShop();
            this.objectPanel.SetActive(true);
        }

        /*
        if (!this.validadorColider.getValidatorActive())
        {
            this.objectPanel.SetActive(false);
        }*/
    }

    private void validadColision2()
    {
        if (this.validadorColider2.getValidatorActive())
        {
            this.txtMessage.text = this.validadorColider2.getTipoShop();
            this.objectPanel.SetActive(true);
        }

        /*
        if (!this.validadorColider2.getValidatorActive())
        {
            this.objectPanel.SetActive(false);
        }*/
    }

    private void validadColision3()
    {
        if (this.validadorColider3.getValidatorActive())
        {
            Debug.Log("Hasta aqui ingresa");
            Debug.Log(this.validadorColider3.getTipoShop());
            this.txtMessage.text = this.validadorColider3.getTipoShop();
            this.objectPanel.SetActive(true);
        }

        /*
        if (!this.validadorColider3.getValidatorActive())
        {
            this.objectPanel.SetActive(false);
        }*/
    }
}
