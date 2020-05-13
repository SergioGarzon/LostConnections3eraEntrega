using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OpenMenu : MonoBehaviour
{
    public GameObject menuPanel;
    public Button _buttonBack;
    private GameObject[] panelsMenu;
    private GameObject buttonMenu;
    

    private void Start()
    {
        buttonMenu = this.gameObject;
        GetComponent<Button>().onClick.AddListener(()=>OnButtonInventoryClick());
        _buttonBack.onClick.AddListener((() => OnButtonInventoryBack()));
       // panelsMenu = GameObject.FindGameObjectsWithTag("Menu");
    }

    void OnButtonInventoryClick(){
        menuPanel.SetActive(true);
        buttonMenu.SetActive(false);
    }

    void OnButtonInventoryBack()
    {
        menuPanel.SetActive(false);
        buttonMenu.SetActive(true);
       /* foreach (var panel in panelsMenu)
        {
            if (panel.active = true)
            {
                panel.SetActive(false);
            }
            return;
        }*/
    }

}
