using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivatePanelGeneral : MonoBehaviour
{
    public GameObject panel;
    public Text txtInformationPanel;

    public void ActivatePanel()
    {
        panel.gameObject.SetActive(true);
    }

    public void SetText(string text)
    {
        txtInformationPanel.text = text;
    }

    public void UnactivePanel()
    {
        panel.gameObject.SetActive(false);
    }

}
