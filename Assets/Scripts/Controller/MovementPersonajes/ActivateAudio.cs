using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ActivateAudio : MonoBehaviour
{
    public GameObject objetoPlayer;
    public AudioSource audio;
    public AudioClip audioClip;
    public GameObject objeto;


    void Start()
    {
        this.audio = GetComponent<AudioSource>();
        this.audio.clip = this.audioClip;
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject == this.objetoPlayer)
        {
            this.objeto.SetActive(false);
            this.audio.Play();
            
        }
    }


    private void OnTriggerExit(Collider other)
    {
        
        if (other.gameObject == this.objetoPlayer)
        {

            this.audio.Stop();
            this.objeto.SetActive(true);
        }
    }





}
