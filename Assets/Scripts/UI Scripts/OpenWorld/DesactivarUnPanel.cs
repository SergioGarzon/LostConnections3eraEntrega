using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivarUnPanel : MonoBehaviour
{
    public GameObject panel1;
    private CameraPlayer camPlayer;
    private MovementPlayerNewWorld movPlayerWorld;

    void Start()
    {
        movPlayerWorld = GameObject.Find("ObjectsWorldScene/ObjectPlayers/AtifPrefab(Clone)").GetComponent<MovementPlayerNewWorld>();
    }

    public void ActivarPanelSolicitado()
    {
        this.panel1.SetActive(true);
    }

    public void DesactivarPanelSolicitado()
    {
        this.panel1.SetActive(false);
        camPlayer = Camera.main.GetComponent<CameraPlayer>();
        camPlayer.setCameraMovement(true);
        movPlayerWorld.SetMovementPlayer(true);

    }
}
