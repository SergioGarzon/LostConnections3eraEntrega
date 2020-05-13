using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelPersonalAutorizadoShop : MonoBehaviour
{
    public GameObject panelInformationBridge;
    public GameObject brigeCollisionNoEnter;
    private CollisionValidateBuilding colisionBridge;


    void Start()
    {
        this.colisionBridge = this.brigeCollisionNoEnter.GetComponent<CollisionValidateBuilding>();
    }

    void Update()
    {
        if (this.colisionBridge.getActivateColisionBridge())
        {
            this.panelInformationBridge.gameObject.SetActive(true);
        }
        else
        {
            this.panelInformationBridge.gameObject.SetActive(false);
        }
    }
}
