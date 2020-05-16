using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAudios : MonoBehaviour
{
    //LevelAuxiliarVolume
    public AudioSource audioPrincipal;
    private float valorAux;

    void Start()
    {
        this.audioPrincipal = GetComponent<AudioSource>();
        this.valorAux = 150;

        PlayerPrefs.SetFloat("LevelVolume", 100f);
    }

    void Update()
    {
        float valor = PlayerPrefs.GetFloat("LevelVolume", 0.0f);

        if (valor != this.valorAux)
        {
            this.valorAux = valor;
            this.audioPrincipal.volume = (valor * 0.01f);
        }
    }

}
