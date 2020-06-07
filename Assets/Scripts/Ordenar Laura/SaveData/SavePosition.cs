using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SavePosition : MonoBehaviour
{

    public GameObject objetoPlayer;
    public static int cargarPosicionInicial = 0;
    //private NavMeshAgent positionObject;   //Esto no hace falta ya que hay 1 player por momentos en la escena
    public Camera camaraPosition;
    
    void Start()
    {
        objetoPlayer = GameObject.Find("ObjectsWorldScene/ObjectPlayers").transform.GetChild(0).gameObject;
        CargarPosition();
    }

    private void Update()
    {
        if (SavePosition.cargarPosicionInicial != 0)        
            GuardarPosition();        
    }


    private void CargarPosition()
    {
        switch(SavePosition.cargarPosicionInicial)
        {
            case 1:
                objetoPlayer.transform.position = new Vector3(PlayerPrefs.GetFloat("x"),
                PlayerPrefs.GetFloat("y"), PlayerPrefs.GetFloat("z"));
                break;
            case 2:
                objetoPlayer.transform.position = new Vector3(PlayerPrefs.GetFloat("x") - 30,
                PlayerPrefs.GetFloat("y"), PlayerPrefs.GetFloat("z") - 30);
                break;
        }

        SavePosition.cargarPosicionInicial = 0;
    }

    public void GuardarPosition()
    {
        PlayerPrefs.SetFloat("x", objetoPlayer.transform.position.x);
        PlayerPrefs.SetFloat("y", objetoPlayer.transform.position.y);
        PlayerPrefs.SetFloat("z", objetoPlayer.transform.position.z);

        SavePosition.cargarPosicionInicial = 0;
    }

}
