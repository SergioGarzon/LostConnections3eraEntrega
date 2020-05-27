using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateTreeEnergy : MonoBehaviour
{
    public GameObject objetoPanel;
    public GameObject objetoArboles;
    public ScoreData scorePuntaje;
    public Text textoPressE;
    

    void Start()  
    {
        this.RestaurarDatos();
    }


    void Update()
    {
    }


    public void RestaurarDatos()
    { 
        this.textoPressE.gameObject.SetActive(true);
    }




}
