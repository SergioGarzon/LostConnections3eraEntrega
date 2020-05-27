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

	public int valorActivadorBotones;

	public GameObject objetoPanelShop;  //Descomentar esta linea de codigo

	// Use this for initialization
	void Start()
	{

		//player = FindObjectOfType<pcMovement>();

		if (textFile != null)
		{
			//grabs text and splits into lines
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
		if (isActive && Input.GetMouseButtonDown(0))
		{
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
			this.objetoPanelShop.gameObject.SetActive(true);
			isActiveShop = true;
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

		if (value == 0)
			this.textPanelInformationClick.text = "Click to Chat";
		else
			this.textPanelInformationClick.text = "Click para conversar";

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

}

