using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideEnergyBattle : MonoBehaviour
{
    public Slider energyPlayerCharlie;
    public Slider energyPlayerAtif;
    public Slider energyBoot;

    public GameObject objectBattle;

    public ScoreData score;


    void Start()
    {
    }

    private void Update()
    {
        this.energyPlayerCharlie.value = score.hLife;
        this.energyPlayerAtif.value = score.mLife;
    }
}
