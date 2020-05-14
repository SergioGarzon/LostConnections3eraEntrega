using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSoundTree : MonoBehaviour
{
    public GameObject objectTree;
    private ChargeLifeTree scriptTreeLife;
    public AudioSource audio;
    public AudioClip audioClip;
    public bool activateSound;

    void Start()
    {
        this.scriptTreeLife = this.objectTree.GetComponent<ChargeLifeTree>();
        this.audio.clip = this.audioClip;        
    }

    void Update()
    {
        if (this.scriptTreeLife.VeracidadActivadorPanel() == 1 && this.activateSound)
        {
            this.audio.Play();
            this.activateSound = false;
        }

        if (this.scriptTreeLife.VeracidadActivadorPanel() == 2)
        {
            this.audio.Stop();
            SetActivateSound();
        }
    }

    public void SetActivateSound()
    {
        this.activateSound = true;
    }

}
