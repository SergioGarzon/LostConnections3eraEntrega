using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SavePosition : MonoBehaviour
{

    public GameObject objetoPlayer;
    public static int cargarPosicionInicial = 0;
    private NavMeshAgent positionObject;
    public Camera camaraPosition;

    void Start()
    {
        objetoPlayer = GameObject.Find("ObjectsWorldScene/ObjectPlayers").transform.GetChild(0).gameObject;

        CargarPosition();
    }


    private void CargarPosition()
    {

        if (SavePosition.cargarPosicionInicial == 1)
        {
            objetoPlayer.transform.position = new Vector3(PlayerPrefs.GetFloat("x"),
            PlayerPrefs.GetFloat("y"), PlayerPrefs.GetFloat("z"));


            SavePosition.cargarPosicionInicial = 2;

        }




    }

    public void GuardarPosition()
    {
        PlayerPrefs.SetFloat("x", objetoPlayer.transform.position.x);
        PlayerPrefs.SetFloat("y", objetoPlayer.transform.position.y);
        PlayerPrefs.SetFloat("z", objetoPlayer.transform.position.z);

    }

}
