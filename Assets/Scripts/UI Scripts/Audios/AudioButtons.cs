using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioButtons : MonoBehaviour
{
    public GameObject objectAudio;
    private AudioSource audioPrincipal;
    private float valorAux;

    void Start()
    {
        this.audioPrincipal = this.objectAudio.GetComponent<AudioSource>();
        this.valorAux = 150;

    }

    void Update()
    {
        float valor = PlayerPrefs.GetFloat("LevalAuxiliarAudios", 0.0f);

        if (valor != this.valorAux)
        {
            this.valorAux = valor;
            this.audioPrincipal.volume = (valor * 0.01f);
        }
    }

    public void StartAudio()
    {
        this.audioPrincipal.Play(0);
    }

    public void StopAudio()
    {
        this.audioPrincipal.Stop();
    }
}
