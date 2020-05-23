using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelUIBattle : MonoBehaviour
{
    public Button btnBack, btnInventory, btnPrefab;

    public Transform scrollContent;

    int lang;

    void Awake()
    {
        btnBack = transform.Find("ContainerBtn/BtnBack").GetComponent<Button>();
        btnInventory = transform.Find("ContainerBtn/BtnInventory").GetComponent<Button>();
        scrollContent = btnBack.transform.parent.Find("Scroll View/Viewport/Content");

        btnPrefab = Resources.Load<Button>("Prefabs/UI/BtnPowerBattleSystem");

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

        for (int i = 0; i < player.GetPowers().Count; i++)
        {
            GameObject button = Instantiate(btnPrefab.gameObject);
            button.transform.parent = scrollContent;

            FillButton(button, player, powersList[i]);
        }
    }

    public void CleanAttackButtons()
    {
        for (int i = 0; i < scrollContent.childCount; i++)
        {
            Debug.Log(scrollContent.GetChild(i).name);

            Destroy(scrollContent.GetChild(i).gameObject);
        }
    }

    public void OpenInventoryPanel(BattleMachine battleSystem)
    {
        btnInventory.onClick.AddListener(() => battleSystem.ActivateInventory());
    }

    public void SetScapeButton(BattleMachine battleSystem)
    {
        btnBack.onClick.AddListener(() => battleSystem.BattleEnd());
    }

}
