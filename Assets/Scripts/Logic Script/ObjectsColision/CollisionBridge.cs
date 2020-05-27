using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBridge : MonoBehaviour
{
    private ActivatePanelGeneral activatePanel;
    private int language;
    private string textSend;


    void Start()
    {
        activatePanel = GameObject.Find("Canvas/TextBoxManager").GetComponent<ActivatePanelGeneral>();

        language = PlayerPrefs.GetInt("LenguajeGuardado", 0);

        if (language == 0)
            textSend = "SOLO PERSONAL AUTORIZADO";
        else
            textSend = "Authorized personal only";

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CollisionShop"))
        {
            int x = PlayerPrefs.GetInt("TarjetaShop", 0);

            if(x == 0)
            {
                activatePanel.ActivatePanel();
                activatePanel.SetText(textSend);
            }
            else
            {
                Destroy(other.gameObject);
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CollisionShop"))
        {
            activatePanel.UnactivePanel();

            activatePanel.SetText("");
        }
    }
}
