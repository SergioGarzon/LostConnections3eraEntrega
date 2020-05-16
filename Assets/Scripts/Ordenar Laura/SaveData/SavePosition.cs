using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SavePosition : MonoBehaviour
{

    public GameObject objetoPlayer;
    public GameObject objetoPlayerTwo;
    public static int cargarPosicionInicial = 0;
    private NavMeshAgent positionObject;
    public Camera camaraPosition;

    void Start()
    {
        this.positionObject = this.objetoPlayerTwo.GetComponent<NavMeshAgent>();

        CargarPosition();
    }


    private void CargarPosition()
    {

        if (SavePosition.cargarPosicionInicial == 1)
        {
            objetoPlayer.transform.position = new Vector3(PlayerPrefs.GetFloat("x"),
            PlayerPrefs.GetFloat("y"), PlayerPrefs.GetFloat("z"));

            this.positionObject.destination = this.objetoPlayerTwo.transform.position;

            this.camaraPosition.transform.position = new Vector3(PlayerPrefs.GetFloat("xCam"),
            PlayerPrefs.GetFloat("yCam"), PlayerPrefs.GetFloat("zCam"));


            SavePosition.cargarPosicionInicial = 2;

        }




    }

    public void GuardarPosition()
    {
        PlayerPrefs.SetFloat("x", objetoPlayer.transform.position.x);
        PlayerPrefs.SetFloat("y", objetoPlayer.transform.position.y);
        PlayerPrefs.SetFloat("z", objetoPlayer.transform.position.z);

        PlayerPrefs.SetFloat("x2", objetoPlayerTwo.transform.position.x);
        PlayerPrefs.SetFloat("y2", objetoPlayerTwo.transform.position.y);
        PlayerPrefs.SetFloat("z2", objetoPlayerTwo.transform.position.z);

        PlayerPrefs.SetFloat("xCam", camaraPosition.transform.position.x);
        PlayerPrefs.SetFloat("yCam", camaraPosition.transform.position.y);
        PlayerPrefs.SetFloat("zCam", camaraPosition.transform.position.z);

        PlayerPrefs.SetFloat("rxCam", camaraPosition.transform.rotation.x);
        PlayerPrefs.SetFloat("ryCam", camaraPosition.transform.rotation.y);
        PlayerPrefs.SetFloat("rzCam", camaraPosition.transform.rotation.z);

    }

}
