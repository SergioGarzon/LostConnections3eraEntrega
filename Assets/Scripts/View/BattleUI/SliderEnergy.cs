using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderEnergy : MonoBehaviour
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




    // Update is called once per frame

    /*
void Update()
{
    /*
    if (!getLostGameBattleMachine())
        this.ActualiceSliderEnergy();*/


    //}
    /*
    private void ActualiceSliderEnergy()
    {
        float[] valor = this.batMachine.getValueBattle();
        Slider[] vectorSlider = { energyPlayerCharlie, energyPlayerAtif, energyVirusOne, energyVirusTwo };

        for (int i = 0; i < valor.Length; i++)
        {
            if (valor[i] > 0)
            {
                vectorSlider[i].value = valor[i];
            }
        }

    }

    /*
    public bool getLostGameBattleMachine()
    {
        return this.batMachine.getLostGame();
    }*/
    /*
    public void setComponenetesBattleUI(bool valor)
    {
        for(int i = 0; i < this.imageSlider.Length; i++)
        {
            this.imageSlider[i].gameObject.SetActive(valor);
        }
    }*/

}