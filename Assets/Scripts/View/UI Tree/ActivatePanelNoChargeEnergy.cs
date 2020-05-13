using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePanelNoChargeEnergy : MonoBehaviour
{
    public GameObject panelTextNoEnergy;
    public GameObject objectColliderTreeNoEnergy;
    private CollisionTreeNoLife scriptObjectCollider;

    void Start()
    {
        this.scriptObjectCollider = this.objectColliderTreeNoEnergy.GetComponent<CollisionTreeNoLife>();    
    }

    void Update()
    {
        if (this.scriptObjectCollider.getReturnCollision())
        {
            this.panelTextNoEnergy.gameObject.SetActive(true);
        }
        else
            this.panelTextNoEnergy.gameObject.SetActive(false);

    }



}

