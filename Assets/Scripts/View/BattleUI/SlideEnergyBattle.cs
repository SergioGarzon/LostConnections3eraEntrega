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
    private BattleMachine batMachine;

    public ScoreData score;


    void Start()
    {
        this.batMachine = this.objectBattle.GetComponent<BattleMachine>();
    }

    private void Update()
    {
        this.energyPlayerCharlie.value = score.hLife;
        this.energyPlayerAtif.value = score.mLife;
        this.energyBoot.value = batMachine.getRetornarVidaEnemigo();
    }
}
