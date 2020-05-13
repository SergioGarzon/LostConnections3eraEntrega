using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionValidateBuilding : MonoBehaviour
{
    private bool activateCollisionBridgePanel;

    void Start()
    {
        this.activateCollisionBridgePanel = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            int valor = PlayerPrefs.GetInt("TarjetaShop", 0);

            if (valor == 0) //No esta activada
            {
                this.activateCollisionBridgePanel = true;
            }

            if (valor == 1) //Si esta activada
            {
                this.activateCollisionBridgePanel = false;
                Destroy(this.gameObject);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.activateCollisionBridgePanel = false;
        }

    }

    public bool getActivateColisionBridge()
    {
        return this.activateCollisionBridgePanel;
    }
}
