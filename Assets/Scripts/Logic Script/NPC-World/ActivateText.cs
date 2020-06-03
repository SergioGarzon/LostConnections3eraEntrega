using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateText : MonoBehaviour
{
	public TextAsset englishText;
	public TextAsset espanolText;

	public int lineaInicio;
	public int lineaFin;


	public GameObject objetoTextBoxManager;
	private TextBoxManager theTextBox;

	public int tipoNPC;


	private bool requieredMouseClick;
	private bool waitingClick;


	void Start()
	{
		theTextBox = this.objetoTextBoxManager.GetComponent<TextBoxManager>();
		this.requieredMouseClick = true;
	}

	// Update is called once per frame
	void Update()
	{

		if (!theTextBox.isActive && waitingClick && Input.GetMouseButtonDown(0) && !theTextBox.getActiveShop() && !theTextBox.getActiveButon())
		{
			this.dataTextGame();
		}

	}


	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			theTextBox.ActivateCollisionPanel();

			if (requieredMouseClick)
			{
				waitingClick = true;
				return;
			}

			this.dataTextGame();


		}
	}


	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			waitingClick = false;
			DesactivatePanel();
			theTextBox.SetTextPnlInformation();
			theTextBox.SetActiveShop(false);
		}
	}


	private int getValidateLanguage()
	{
		int language = PlayerPrefs.GetInt("LenguajeGuardado", 0);
		return language;
	}


	private void dataTextGame()
	{
		if (this.getValidateLanguage() == 0)
			theTextBox.ReloadScript(englishText);
		else
			theTextBox.ReloadScript(espanolText);

		theTextBox.setTipoNPC(tipoNPC);
		theTextBox.currentLine = lineaInicio;
		theTextBox.endAtLine = lineaFin;
		theTextBox.EnableTextBox();


		if (this.getValidateLanguage() == 0)
			theTextBox.ReloadScript(englishText);
		else
			theTextBox.ReloadScript(espanolText);

		if (theTextBox.getActiveShop())
		{
			waitingClick = false;
		}
	}


	public void setTipoNPC(int valor)
	{
		this.tipoNPC = valor;
	}

	private void DesactivatePanel()
	{
		this.theTextBox.DesactivatePanelDialog();
	}

	public void SetWaitingClick(bool value)
	{
		waitingClick = value;
	}

}
