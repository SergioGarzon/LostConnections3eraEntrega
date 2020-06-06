using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateEnergySlider : MonoBehaviour
{
    public LifePlayer lifeP;
    public Slider sldEnergyPO;
    public Slider sldManaPO;
    public Slider sldEnergyPT;
    public Slider sldManaPT;

    private int objectSelected;

    private void Awake()
    {
        //SetEnergyTotal();
        objectSelected = PlayerPrefs.GetInt("ObjectoElegido", 0);  //0 Atif. 1 Charlie
    }


    //Sacar este Update
    public void Update()
    {
        if(objectSelected == 0)
        {
            sldEnergyPO.value = lifeP.hpPlayerOne;
            sldManaPO.value = lifeP.manaPlayerOne;
        } 
        else
        {
            sldEnergyPT.value = lifeP.hpPlayerTwo;
            sldManaPT.value = lifeP.manaPlayerTwo;
        }
    }

}
