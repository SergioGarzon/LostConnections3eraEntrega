using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateButtons : MonoBehaviour
{
    public Button btnBack, btnFirst;

    int lang;

    void Awake()
    {
        btnBack = transform.Find("ContainerBtn/BtnBack").GetComponent<Button>();
        btnFirst = transform.Find("ContainerBtn/Scroll View/Viewport/Content/BtnFirst").GetComponent<Button>();

        //DEBUG = ONLY test
        //PlayerPrefs.SetInt("LenguajeGuardado", 0);

        lang = PlayerPrefs.GetInt("LenguajeGuardado", 0);
    }

    void Start()
    {
        //TODO - Llamar a EndBattle con este button
        //btnBack.onClick.AddListener();

        gameObject.SetActive(false);
    }

    private void FillButton(GameObject button, PlayerBattleSystem player, PlayerBattleSystem.PlayerPowers power)
    {
        //Image
        button.GetComponent<Image>().sprite = GetButtonImage(power);
        //OnClick
        button.GetComponent<Button>().onClick.AddListener(() => player.Attack(power));
        //Name
        button.name = power.ToString();
    }

    private Sprite GetButtonImage(PlayerBattleSystem.PlayerPowers power)
    {
        Sprite image = null;
        string powerName = power.ToString();

        if (lang == 0)
        {
            //0 es en Ingles
            image = Resources.Load<Sprite>("Textures/TextureBattleButton/English/" + powerName);
        }
        else
        {
            //1 en Español
            image = Resources.Load<Sprite>("Textures/TextureBattleButton/Espanol/" + powerName);
        }

        return image;
    }

    public void ShowAttackButtons(PlayerBattleSystem player)
    {
        List<PlayerBattleSystem.PlayerPowers> powersList = player.GetPowers();

        btnBack.gameObject.SetActive(true);

        FillButton(btnFirst.gameObject, player, powersList[0]);

        for (int i = 1; i < player.GetPowers().Count; i++)
        {
            GameObject button = Instantiate(btnFirst.gameObject);
            button.transform.parent = btnFirst.transform.parent;

            FillButton(button, player, powersList[i]);
        }

    }
}
