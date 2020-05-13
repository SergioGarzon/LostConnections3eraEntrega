using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CambiarColorTexto : MonoBehaviour
{

    public Text txtButton;

    void Start()
    {
    }

    public void CambiarElColorTexto()
    {
        this.txtButton.color = new Color(191f, 243f, 237f);
    }

    public void volverColorActual()
    {
        this.txtButton.color = new Color(191f, 243f, 237f);
    }

}
