using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class ActivateHiddenMenu : MonoBehaviour
{
    public GameObject panelMenuHelp, panelController, panelHideenMenu, panelUIBattle, pnlInventaryCards;

    void Update()
    {
        if (Input.GetKey(KeyCode.F1))
            this.ActivatePaneles(true, false, false, false, false);
        if (Input.GetKey(KeyCode.F2))
            this.ActivatePaneles(false, true, false, false, false);
        if (Input.GetKey(KeyCode.F3))
            this.ActivatePaneles(false, false, false, false, true);
        if (Input.GetKey(KeyCode.F5))
            this.ActivatePaneles(false, false, false, false, false);
        if (Input.GetKey(KeyCode.F12))
            this.ActivatePaneles(false, false, true, false, false);
        if (Input.GetKey(KeyCode.F7))
            this.ActivatePaneles(false, false, false, true, false);
    }
    public void ActivatePaneles(bool pn1, bool pn2, bool pn3, bool pn4, bool pn5)
    {
        if (this.panelMenuHelp != null)
            this.panelMenuHelp.SetActive(pn1);

        if (this.panelController != null)
            this.panelController.SetActive(pn2);

        if (this.panelHideenMenu != null)
            this.panelHideenMenu.SetActive(pn3);

        if (this.panelUIBattle != null)
            this.panelUIBattle.SetActive(pn4);

        if (this.pnlInventaryCards != null)
            this.pnlInventaryCards.SetActive(pn5);
    }

    public void BtnContinuar()
    {
        this.ActivatePaneles(false, false, false, false, false);
    }
}
