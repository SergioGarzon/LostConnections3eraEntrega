using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    //Creo un vector de GameObject
    public GameObject[] characterList;
    private int index;


    private void Start()
    {
        //transform.childCount es cuando no se la cantidad de elementos del vector
        this.characterList = new GameObject[transform.childCount];


        //Fill the array with out model
        //Recorrer el transform.childCount es igual a vector.length pero en C#
        for (int i = 0; i < transform.childCount; i++)
        {
            //Esto es asignar al vector[posicion] = transform.get(i).toString()
            characterList[i] = transform.GetChild(i).gameObject;
        }

        //We toggle of their renderer
        foreach (GameObject go in characterList)
        {
            go.SetActive(false);
        }

        //We toggle on the first index
        if (characterList[0])
        {
            characterList[0].SetActive(true);
        }

    }


    public void ToggleLeft()
    {
        if(index > 0)
        {
            characterList[index].SetActive(false);

            index--;

            characterList[index].SetActive(true);

            switch (index)
            {
                case 0: GuardarPlayerPref(0); break;
                case 1: GuardarPlayerPref(1); break;
                case 2: GuardarPlayerPref(2); break;
            }
        }


    }

    public void ToggleRight()
    {

        if(index < 2)
        {
            characterList[index].SetActive(false);

            index++;

            characterList[index].SetActive(true);

            switch (index)
            {
                case 0: GuardarPlayerPref(0); break;
                case 1: GuardarPlayerPref(1); break;
                case 2: GuardarPlayerPref(2); break;
            }
        }
       
    }

    private void GuardarPlayerPref(int valor)
    {
        PlayerPrefs.SetInt("ObjetoElegido", valor);
        PlayerPrefs.Save();
    }
}
