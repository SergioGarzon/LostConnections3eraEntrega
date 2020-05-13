using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePrefab : MonoBehaviour
{
    public GameObject objectPrefab1;
    public GameObject objectPrefab2;

    void Start()
    {
        int x = PlayerPrefs.GetInt("ObjetoElegido", 0);  //0 Atif, 1 Charlie

        if (x == 0)
        {
            this.objectPrefab1.gameObject.SetActive(true); 
            this.objectPrefab2.gameObject.SetActive(false);
        }
        if(x == 1)
        {
            this.objectPrefab1.gameObject.SetActive(false);
            this.objectPrefab2.gameObject.SetActive(true);
        }            
    }


}
