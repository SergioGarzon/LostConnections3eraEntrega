using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeGame : MonoBehaviour
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
        if (other.CompareTag("Arcade"))
        {
            int x = PlayerPrefs.GetInt("ArcadeGame", 0);

            if (x == 0)
            {
                activatePanel.ActivatePanel();
                activatePanel.SetText(textSend);
            }
            else
            {
               
                    if (language == 0)
                        textSend = "NO ARCADE";
                    else
                        textSend = "NO ARCADE!";

                    activatePanel.ActivatePanel();
                    activatePanel.SetText(textSend);
                
            }

            

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Arcade"))
        {
            activatePanel.UnactivePanel();

            activatePanel.SetText("");
        }
    }


}
