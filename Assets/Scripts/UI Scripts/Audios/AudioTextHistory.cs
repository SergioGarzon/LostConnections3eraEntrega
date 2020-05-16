using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTextHistory : MonoBehaviour
{
    public GameObject objectAudio;
    private AudioSource audioPrincipal;
    private float valorAux;



    void Start()
    {
        this.valorAux = 150;

        this.audioPrincipal = objectAudio.GetComponent<AudioSource>();


        this.audioPrincipal.Stop();
    }

    void Update()
    {
        float valor = PlayerPrefs.GetFloat("LevalAuxiliarAudios", 0.0f);

        if (valor != this.valorAux)
        {
            this.audioPrincipal.Stop();
            this.valorAux = valor;
            this.audioPrincipal.volume = (valor * 0.01f);
            this.audioPrincipal.Play(0);
        }
    }
}
