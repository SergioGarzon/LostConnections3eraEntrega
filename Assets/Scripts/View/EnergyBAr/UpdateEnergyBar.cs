using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateEnergyBar : MonoBehaviour
{

    public Slider sldEnergyPlayerOne;
    public Slider sldEnergyPlayerTwo;
    public ScoreData scoredata1;

    void Start()
    {
        
        scoredata1.hLife = 100;
        scoredata1.mLife = 100;
    }


    // Update is called once per frame
    void Update()
    {
        this.sldEnergyPlayerOne.value = scoredata1.hLife;
        this.sldEnergyPlayerTwo.value = scoredata1.mLife;
    }
}
