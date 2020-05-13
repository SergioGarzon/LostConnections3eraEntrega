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


	//Objeto que activa el panel de texto
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


		if (!theTextBox.isActive &&  waitingClick && Input.GetMouseButtonDown(0))		
			this.dataTextGame();		
	}


	void OnCollisionEnter(Collision other)
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


	void OnCollisionExit(Collision other)
	{
		if (other.gameObject.tag == "Player")
		{
			waitingClick = false;
			DesactivatePanel();
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
	}


	public void setTipoNPC(int valor)
	{
		this.tipoNPC = valor;
	}

	private void DesactivatePanel()
	{
		this.theTextBox.DesactivatePanelDialog();
	}
}
