using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DropDownController : MonoBehaviour
{
    public ShopData ShopData;
    Dropdown m_Dropdown;
    public List<string> CharlieOptions = new List<string>(){};
    int m_DropdownValue;

    [Header("Flags")]
    public static bool bugSelected=false;
    public static bool pixelSelected=false;
    public static bool stealSelected=false;
    public static bool ctrolzSelected=false;
    public static bool resetSelected=false;
    public static bool deleteSelected=false;
    
    
    private void Start()
    {
        
        m_Dropdown = GetComponent<Dropdown>();
        m_Dropdown.options.Clear ();
        foreach (string t in CharlieOptions)
        {
            m_Dropdown.options.Add (new Dropdown.OptionData(){text=t});
        }

    }

     void Update()
    {
        m_DropdownValue = m_Dropdown.value;
        if(ShopData.resettingSold) CharlieOptions.Add("Reset");
        if(ShopData.controlzSold) CharlieOptions.Add("Ctrol-z");
        if(ShopData.deleteSold) CharlieOptions.Add("Delete");
        
        //to atif 
       /*if(ShopData.healSold) CharlieOptions.Add("Reset");
        if(ShopData.electroshockSold) CharlieOptions.Add("Reset");
        if(ShopData.updateSold) CharlieOptions.Add("Reset");*/
    }


    public void OnValueChangedCharlie()
    {
        if (m_Dropdown.itemText.text== "Bug")
        {
            bugSelected = true;
            Debug.Log("Bug");
        }
        else if (m_Dropdown.itemText.text== "Pixel")
        {
            pixelSelected = true;
            Debug.Log("Pixel");
        }
        else if (m_Dropdown.itemText.text == "Steal")
        {
            stealSelected = true;
            Debug.Log("Steal");
        }
        else if (m_Dropdown.name=="Reset")
        {
            resetSelected = true;
        }
        else if (m_Dropdown.name == "Ctrol-z")
        {
            ctrolzSelected = true;
        }
        else if (m_Dropdown.name=="Delete")
        {
            deleteSelected = true;
        }
        
        /*switch (m_DropdownValue)
        {
            case 0:
               bugSelected = true;
                Debug.Log("Bug");
                break;
            case 1:
                pixelSelected = true;
                Debug.Log("Pixel");
                break;
            case 2:
                stealSelected = true;
                Debug.Log("Steal");
                break;
            default:
                
                if (m_Dropdown.name=="Reset")
                {
                    resetSelected = true;
                }
                else if (m_Dropdown.name == "Ctrol-z")
                {
                    ctrolzSelected = true;
                }
                else if (m_Dropdown.name=="Delete")
                {
                    deleteSelected = true;
                }
                break;


        }*/
    }
    
}
