using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GoInicio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(()=>OnButtonInventoryClick());  
    }
    void OnButtonInventoryClick(){
        Application.LoadLevel( "menuOptionsGame" );
    }
}
