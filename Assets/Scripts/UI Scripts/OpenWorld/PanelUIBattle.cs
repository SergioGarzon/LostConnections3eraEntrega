using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelUIBattle : MonoBehaviour
{
    public Button btnBack, btnPrefab;

    public GameObject btnMenu;

    public Slider sldEnemy;
    public Slider sldPlayerOne;
    public Slider sldPlayerTwo;
    public Slider sldManaPlayerOne;
    public Slider sldManaPlayerTwo;


    public RawImage imgCharlie;
    public RawImage imgAtif;
    public RawImage imgVirus;
    public RawImage imgCardGoldenBlack;

    public Text txtInformationBattle;
    public Text TxtTarjetaBlack;
    public Text txtManaAtif;
    public Text txtManaCharlie;

    public Transform scrollContent;

    int lang;

    void Awake()
    {
        /*
        btnBack = transform.Find("ContainerBtn/BtnBack").GetComponent<Button>();

        scrollContent = btnBack.transform.parent.Find("Scroll View/Viewport/Content");

        btnPrefab = Resources.Load<Button>("Prefabs/UI/BtnPowerBattleSystem");


        //Esto es la llamada a los paneles que se desean activar o desactivar
        btnMenu = GameObject.Find("InventoryCanvas/OpenMenu");

        //Esto es para ir descontando las barras de energia
        sldEnemy = GameObject.Find("Canvas/PnlBattleUI/ImageVirus1/SldVirusOne").GetComponent<Slider>();
        sldPlayerOne = GameObject.Find("Canvas/PnlTarjetaGB/ImageCharlie/SldCharlie").GetComponent<Slider>();
        sldPlayerTwo = GameObject.Find("Canvas/PnlTarjetaGB/ImgAtif/SldAtif").GetComponent<Slider>();

        txtInformationBattle = GameObject.Find("Canvas/PnlBattleUI/TxtInformationBattle").GetComponent<Text>();

        imgCardBlack = GameObject.Find("Canvas/PnlTarjetaGB/Black").GetComponent<RawImage>();
        imgCardGolden = GameObject.Find("Canvas/PnlTarjetaGB/Golden").GetComponent<RawImage>();

        TxtTarjetaBlack = GameObject.Find("Canvas/PnlTarjetaGB/TxtTarjetaBlack").GetComponent<Text>();
        TxtTarjetaGolden = GameObject.Find("Canvas/PnlTarjetaGB/TxtTarjetaGolden").GetComponent<Text>();
        */
        //DEBUG = ONLY test
        //PlayerPrefs.SetInt("LenguajeGuardado", 0);

        lang = PlayerPrefs.GetInt("LenguajeGuardado", 0);

        
            
    }

    void Start()
    {
        //TODO - Llamar a EndBattle con este button
        //btnBack.onClick.AddListener();
        int playerSelected = PlayerPrefs.GetInt("ObjetoElegido", 0);

        if (playerSelected == 0)  //0 Atif 1 Charlie
        {
            imgCharlie.gameObject.SetActive(false);
            imgAtif.gameObject.SetActive(true);
        }
        else
        {
            imgCharlie.gameObject.SetActive(true);
            imgAtif.gameObject.SetActive(false);
        }

        gameObject.SetActive(false);
    }

    private void FillButton(GameObject button, PlayerBattleSystem player, PlayerBattleSystem.PlayerPowers power, Transform enemy)
    {
        //Image
        button.GetComponent<Image>().sprite = GetButtonImage(power);
        //OnClick
        button.GetComponent<Button>().onClick.AddListener(() => player.Attack(power, enemy));
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

    public void ShowAttackButtons(PlayerBattleSystem player, Transform enemy)
    {
        List<PlayerBattleSystem.PlayerPowers> powersList = player.GetPowers();

        for (int i = 0; i < player.GetPowers().Count; i++)
        {
            GameObject button = Instantiate(btnPrefab.gameObject);
            button.transform.parent = scrollContent;

            FillButton(button, player, powersList[i], enemy);
        }
    }

    public void CleanAttackButtons()
    {
        for (int i = 0; i < scrollContent.childCount; i++)
        {
            //Debug.Log(scrollContent.GetChild(i).name);

            Destroy(scrollContent.GetChild(i).gameObject);
        }
    }

    //Esto es para desactivar los paneles cuando inicia la batalla
    public void Unactivate()
    {
        btnMenu.SetActive(false);
    }

    public void UnenableImage()
    {
        imgCardGoldenBlack.enabled = false;
        TxtTarjetaBlack.enabled = false;
    }

    public void EnabledImage()
    {
        imgVirus.enabled = true;
        imgCardGoldenBlack.enabled = true;
        TxtTarjetaBlack.enabled = true;
        btnMenu.SetActive(true);

        //Hay que habilitar nuevamente las imagenes
    }

    public void SetScapeButton(BattleMachine battleSystem)
    {
        btnBack.onClick.AddListener(() => ClickButton(battleSystem));
    }

    //Este método es para descontar las barra de energia del enemigo en la escena
    public void SetEnergyEnemy(float dmg)
    {
        sldEnemy.value = dmg;
    }

    public void SetTextInformation(string dato)
    {
        txtInformationBattle.text = dato;
    }

    private void ClickButton(BattleMachine battleSystem)
    {
        battleSystem.BattleEnd();
    }

    public void SetSliderEnergyGeneral(float playerEnergy)
    {
        if (PlayerPrefs.GetInt("ObjetoElegido", 0) == 0)  //0 Atif 1 Charlie
        {
            sldPlayerOne.value = playerEnergy;
        }
        else
        {
            sldPlayerTwo.value = playerEnergy;
        }
    }

    public void SetSliderMana(float value)
    {
        if (PlayerPrefs.GetInt("ObjetoElegido", 0) == 0)  //0 Atif 1 Charlie
        {
            //sldManaPlayerOne.value = value;
            sldManaPlayerOne.value = value;
            txtManaAtif.text = sldManaPlayerOne.value + "%";
        }
        else
        {
            sldManaPlayerTwo.value = value;
            txtManaCharlie.text = sldManaPlayerTwo.value + "%";
        }
    }
}
