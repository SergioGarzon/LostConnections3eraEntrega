using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour
{
	public GameObject textBox;

	public GameObject objetoPanel;
	public Text textPanelInformationClick;

	private int tipoNPC;
	private int lineasNPCViejita;
	private int lineasNPCGuardia;


	public Text theText;

	private TextAsset textFile;
	public string[] textLines;

	public int valorAsset;
	public int currentLine;
	public int endAtLine;

	public bool isActive;
	private bool isActiveShop;
	private bool isActiveButton;

	public int valorActivadorBotones;

	public GameObject objetoPanelShop;

	public Button btnYes;
	public Button btnNo;
	public Button btnIgnore;

	void Awake()
	{
		UnactiveButton();
	}


	void Start()
	{

		//player = FindObjectOfType<pcMovement>();

		if (textFile != null)
		{
			textLines = (textFile.text.Split('\n'));
		}

		if (endAtLine == 0)
		{
			endAtLine = textLines.Length - 1;
		}

		if (isActive)
		{
			EnableTextBox();
		}
		else
		{
			DisableTextBox();
		}

		isActiveShop = false;
	}

	// Update is called once per frame
	void Update()
	{
		if (isActive && Input.GetMouseButtonDown(0) && !getActiveButon())
		{
			this.textPanelInformationClick.text = "";
			advanceTextBox();
		}
	}

	public void advanceTextBox()
	{

		currentLine += 1;

		if (currentLine > endAtLine)
		{
			DisableTextBox();
		}
		else
		{
			theText.text = textLines[currentLine];
		}

		if(currentLine == 4 && tipoNPC == 1)
		{
			ActivateButton();
		}
		else
		{
			UnactiveButton();
		}
	}

	public void EnableTextBox()
	{
		this.textPanelInformationClick.text = "";
		textBox.gameObject.SetActive(true);
		theText.text = textLines[currentLine];
		StartCoroutine(delayActive());

	}

	private IEnumerator delayActive()
	{
		yield return new WaitForSeconds(0.0625f);
		isActive = true;
	}

	public void DisableTextBox()
	{
		textBox.SetActive(false);
		this.valorActivadorBotones = 0;

		this.objetoPanel.gameObject.SetActive(false);
		theText.text = "";



		if (this.objetoPanelShop != null && this.lineasNPCGuardia == 2)
		{
			isActiveShop = true;
			this.objetoPanelShop.gameObject.SetActive(true);
		}



		StartCoroutine(toggleActive());
	}

	public void ReloadScript(TextAsset theText)
	{
		if (theText != null)
		{
			textLines = new string[1];
			textLines = (theText.text.Split('\n'));
		}
	}

	private IEnumerator toggleActive()
	{
		yield return new WaitForSeconds(0.125f);

		isActive = false;
	}

	public void ActivateCollisionPanel()
	{
		this.objetoPanel.gameObject.SetActive(true);

		int value = PlayerPrefs.GetInt("LenguajeGuardado", 0);


		SetTextHelpUser();

	}

	public void setTipoNPC(int valorNPC)
	{
		this.tipoNPC = valorNPC;

		if (this.tipoNPC == 1)
		{
			this.lineasNPCViejita = 1;
			this.lineasNPCGuardia = 0;
		}

		if (this.tipoNPC == 2)
		{
			this.lineasNPCGuardia = 2;
			this.lineasNPCViejita = 0;
		}

	}

	public void UnactiveButton()
	{
		btnYes.gameObject.SetActive(false);
		btnNo.gameObject.SetActive(false);
		btnIgnore.gameObject.SetActive(false);

		isActiveButton = false;
	}

	public void ActivateButton()
	{
		btnYes.gameObject.SetActive(true);
		btnNo.gameObject.SetActive(true);
		btnIgnore.gameObject.SetActive(true);

		isActiveButton = true;

		SetTextHelpUser();
	}


	public void DesactivatePanelDialog()
	{
		this.objetoPanel.gameObject.SetActive(false);
	}


	public bool getActiveShop()
	{
		return isActiveShop;
	}

	public void SetActiveShop(bool value)
	{
		isActiveShop = value;
	}

	public string getTextPnlInformation()
	{
		return textPanelInformationClick.text;
	}

	public void SetTextPnlInformation()
	{
		textPanelInformationClick.text = "";
	}

	public void ButtonPress(int value)
	{

		switch (value)
		{
			case (1): endAtLine = 0;  
				break;
			case (2): isActiveButton = false; this.textPanelInformationClick.text = "";
				break;
			case (3): endAtLine = 0; 
				break;
		}

		advanceTextBox();
	}

	public bool getActiveButon()
	{
		return isActiveButton;
	}

	private void SetTextHelpUser()
	{

		int value  = PlayerPrefs.GetInt("LenguajeGuardado", 0);


		if (!isActiveButton)
			if (value == 0)
				this.textPanelInformationClick.text = "Click to Chat";
			else
				this.textPanelInformationClick.text = "Click para conversar";		
		else 
			if (value == 0)
				this.textPanelInformationClick.text = "Select Option";
			else
				this.textPanelInformationClick.text = "Seleccione una opción";
	}


	

}

