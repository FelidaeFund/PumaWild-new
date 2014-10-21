﻿using UnityEngine;
using System.Collections;

/// FeedingDisplay
/// Draw the scorecard that comes up after every kill

public class FeedingDisplay : MonoBehaviour
{
	//===================================
	//===================================
	//		MODULE VARIABLES
	//===================================
	//===================================

	float flashStartTime = 0f;
	
	// textures based on bitmap files
	private Texture2D buckHeadTexture;
	private Texture2D doeHeadTexture;
	private Texture2D fawnHeadTexture;
	private Texture2D closeup1Texture;
	private Texture2D closeup2Texture;
	private Texture2D closeup3Texture;
	private Texture2D closeup4Texture;
	private Texture2D closeup5Texture;
	private Texture2D closeup6Texture;
	private Texture2D greenCheckTexture;	
	private Texture2D greenOutlineRectTexture;	
	private Texture2D redXTexture;	

	// external modules
	private GuiManager guiManager;
	private GuiComponents guiComponents;
	private LevelManager levelManager;
	private ScoringSystem scoringSystem;

	//===================================
	//===================================
	//		INITIALIZATION
	//===================================
	//===================================

	void Start() 
	{	
		// connect to external modules
		guiManager = GetComponent<GuiManager>();
		guiComponents = GetComponent<GuiComponents>();
		levelManager = GetComponent<LevelManager>();
		scoringSystem = GetComponent<ScoringSystem>();

		// texture references from GuiManager
		buckHeadTexture = guiManager.buckHeadTexture;
		doeHeadTexture = guiManager.doeHeadTexture;
		fawnHeadTexture = guiManager.fawnHeadTexture;
		closeup1Texture = guiManager.closeup1Texture;
		closeup2Texture = guiManager.closeup2Texture;
		closeup3Texture = guiManager.closeup3Texture;
		closeup4Texture = guiManager.closeup4Texture;
		closeup5Texture = guiManager.closeup5Texture;
		closeup6Texture = guiManager.closeup6Texture;
		greenCheckTexture = guiManager.greenCheckTexture;
		greenOutlineRectTexture = guiManager.greenOutlineRectTexture;
		redXTexture = guiManager.redXTexture;
	}

	//===================================
	//===================================
	//		DRAW THE FEEDING DISPLAY
	//===================================
	//===================================

	public void Draw(float backgroundPanelOpacity, float mainContentOpacity, float levelCompleteOpacity, float okButtonOpacity) 
	{ 
		float feedingDisplayX = (Screen.width / 2) - (Screen.height * 0.7f);
		float feedingDisplayY = Screen.height * 0.025f;
		float feedingDisplayWidth = Screen.height * 1.4f;
		float feedingDisplayHeight = Screen.height * 0.37f;
		
		GUIStyle style = new GUIStyle();
		style.alignment = TextAnchor.MiddleCenter;
		
		//********************
		// BACKGROUND CONTENT
		//********************

		// panel background
		GUI.color = new Color(1f, 1f, 1f, 0.8f * backgroundPanelOpacity);
		GUI.Box(new Rect(feedingDisplayX, feedingDisplayY + feedingDisplayHeight * 0.06f, feedingDisplayWidth, feedingDisplayHeight * 1.2f - feedingDisplayHeight * 0.06f), "");
		GUI.color = new Color(1f, 1f, 1f, 0.3f * backgroundPanelOpacity);
		GUI.Box(new Rect(feedingDisplayX, feedingDisplayY + feedingDisplayHeight * 0.06f, feedingDisplayWidth, feedingDisplayHeight * 1.2f - feedingDisplayHeight * 0.06f), "");
		GUI.color = new Color(1f, 1f, 1f, 1f * backgroundPanelOpacity);
	
		// main text
		Color topColor;
		Color midColor;
		Color bottomColor;
		string topString;
		string midString;
		int efficiencyLevel;
		string bottomString1;
		string bottomString2;
		float title1Offset = feedingDisplayWidth * -0.215f;
		float title2Offset = feedingDisplayWidth * 0.06f;
		float backgroundOffset = feedingDisplayWidth * 0f;

		float lastKillExpense = scoringSystem.GetLastKillExpense(guiManager.selectedPuma);
		float lastKillCaloriesEaten = scoringSystem.GetLastKillCaloriesEaten();
		
		if (lastKillExpense > 1.2f * lastKillCaloriesEaten)
			efficiencyLevel = 0;
		else if (lastKillExpense > lastKillCaloriesEaten)
			efficiencyLevel = 1;
		else if (lastKillExpense > 0.8 * lastKillCaloriesEaten)
			efficiencyLevel = 2;
		else
			efficiencyLevel = 3;
				
		float calorieChange = lastKillCaloriesEaten - lastKillExpense;
		if (calorieChange < 0)
			calorieChange = -calorieChange;
		int calorieDisplay = (int)calorieChange;

		switch (efficiencyLevel) {
		case 0:
			topColor = new Color(0.8f, 0f, 0f, 1f);
			midColor = new Color(0.82f, 0f, 0f, 1f);
			bottomColor = new Color(0.8f, 0f, 0f, 1f);
			topString = "WARNING:";
			midString = "WARNING: Your hunt was very inefficient";
			bottomString1 = "NET  LOSS -";
			bottomString2 = calorieDisplay.ToString("n0"); // + " calories";
			title1Offset = feedingDisplayWidth * -0.163f;
			title2Offset = feedingDisplayWidth * 0.075f;
			backgroundOffset = feedingDisplayWidth * 0.03f;
			break;
		
		case 1:
			topColor = new Color(0.83f, 0.78f, 0f, 1f);
			midColor = new Color(0.85f, 0.80f, 0f, 1f);
			bottomColor = new Color(0.8f, 0f, 0f, 1f);
			topString = "CAREFUL -";
			midString = "CAREFUL - Your hunt was somewhat inefficient";
			bottomString1 = "NET  LOSS -";
			bottomString2 = calorieDisplay.ToString("n0"); // + " calories";
			title1Offset = feedingDisplayWidth * -0.195f;
			title2Offset = feedingDisplayWidth * 0.08f;
			break;
		
		case 2:
			topColor = new Color(0.83f, 0.78f, 0f, 1f);
			midColor = new Color(0.85f, 0.80f, 0f, 1f);
			bottomColor = new Color(0f, 0.66f, 0f, 1f);
			topString = "WELL DONE -";
			midString = "WELL DONE - Your hunt was slightly efficient";
			bottomString1 = "NET  GAIN +";
			bottomString2 = calorieDisplay.ToString("n0"); // + " calories";
			title1Offset = feedingDisplayWidth * -0.18f;
			title2Offset = feedingDisplayWidth * 0.09f;
			backgroundOffset = feedingDisplayWidth * 0.01f;
			break;
		
		default:
			topColor = new Color(0f, 0.66f, 0f, 1f);
			midColor = new Color(0f, 0.70f, 0f, 1f);
			bottomColor = new Color(0f, 0.66f, 0f, 1f);
			topString = "CONGRATS!";
			midString = "CONGRATS! Your hunt was very efficient";
			bottomString1 = "NET  GAIN +";
			bottomString2 = calorieDisplay.ToString("n0"); // + " calories";
			title1Offset = feedingDisplayWidth * -0.158f;
			title2Offset = feedingDisplayWidth * 0.0845f;
			backgroundOffset = feedingDisplayWidth * 0.035f;
			break;
		}
		
		float fontRef = feedingDisplayHeight * 0.5f;
		style.fontStyle = FontStyle.BoldAndItalic;

		// main title

		GUI.color = new Color(1f, 1f, 1f, 0.8f * backgroundPanelOpacity);
		GUI.Box(new Rect(feedingDisplayX, feedingDisplayY + feedingDisplayHeight * 0.06f, feedingDisplayWidth, feedingDisplayHeight * 0.17f), "");
		GUI.color = new Color(1f, 1f, 1f, 1f * backgroundPanelOpacity);

		GUI.color = new Color(1f, 1f, 1f, 0.9f * backgroundPanelOpacity);
		GUI.Box(new Rect(feedingDisplayX + feedingDisplayWidth * 0.22f + backgroundOffset, feedingDisplayY + feedingDisplayHeight * 0.1f, feedingDisplayWidth * 0.56f - backgroundOffset * 02f, feedingDisplayHeight * 0.11f), "");
		GUI.color = new Color(1f, 1f, 1f, 1f * backgroundPanelOpacity);

		GUI.color = new Color(1f, 1f, 1f, 0.1f * backgroundPanelOpacity);
		//GUI.Box(new Rect(feedingDisplayX + feedingDisplayWidth * 0.23f + backgroundOffset, feedingDisplayY + feedingDisplayHeight * 0.1f, feedingDisplayWidth * 0.54f - backgroundOffset * 02f, feedingDisplayHeight * 0.11f), "");


		//********************
		// MAIN CONTENT
		//********************

		GUI.color = new Color(1f, 1f, 1f, 1f * mainContentOpacity);

		style.fontSize = (int)(fontRef * 0.22f);
		style.normal.textColor =  topColor;
		style.fontStyle = FontStyle.Bold;
		//GUI.Button(new Rect(feedingDisplayX + feedingDisplayWidth * 0.3f + title1Offset, feedingDisplayY + feedingDisplayHeight * 0.135f, feedingDisplayWidth * 0.4f, feedingDisplayHeight * 0.03f), topString, style);
		style.fontSize = (int)(fontRef * 0.18f);
		GUI.Button(new Rect(feedingDisplayX + feedingDisplayWidth * 0.3f, feedingDisplayY + feedingDisplayHeight * 0.136f, feedingDisplayWidth * 0.4f, feedingDisplayHeight * 0.03f), midString, style);

		style.normal.textColor = midColor;
		style.fontStyle = FontStyle.BoldAndItalic;
		//GUI.Button(new Rect(feedingDisplayX + feedingDisplayWidth * 0.25f, feedingDisplayY + feedingDisplayHeight * 0.18f, feedingDisplayWidth * 0.5f, feedingDisplayHeight * 0.03f), midString, style);

		
		// "main menu" and "hunting tips" buttons
		
		GUI.skin = guiManager.customGUISkin;
		guiManager.customGUISkin.button.fontSize = (int)(feedingDisplayHeight * 0.067);
		guiManager.customGUISkin.button.fontStyle = FontStyle.Normal;
		guiManager.customGUISkin.button.fontStyle = FontStyle.Bold;
		guiManager.customGUISkin.button.normal.textColor = new Color(0.88f, 0.55f, 0f, 1f);

		if (GUI.Button(new Rect(feedingDisplayX + feedingDisplayWidth * 0.035f,  feedingDisplayY + feedingDisplayHeight * 0.095f, feedingDisplayWidth * 0.14f, feedingDisplayHeight * 0.11f), "")) {
			guiManager.SetGuiState("guiStateLeavingGameplay");
			levelManager.SetGameState("gameStateLeavingGameplay");
		}	
		if (GUI.Button(new Rect(feedingDisplayX + feedingDisplayWidth * 0.035f,  feedingDisplayY + feedingDisplayHeight * 0.095f, feedingDisplayWidth * 0.14f, feedingDisplayHeight * 0.11f), "Main Menu")) {
			guiManager.SetGuiState("guiStateLeavingGameplay");
			levelManager.SetGameState("gameStateLeavingGameplay");
		}	
		
		GUI.skin = guiManager.customGUISkin;
		guiManager.customGUISkin.button.fontSize = (int)(feedingDisplayHeight * 0.0635);
		guiManager.customGUISkin.button.fontStyle = FontStyle.Normal;
		guiManager.customGUISkin.button.fontStyle = FontStyle.Bold;
		if (GUI.Button(new Rect(feedingDisplayX + feedingDisplayWidth * 0.825f,  feedingDisplayY + feedingDisplayHeight * 0.095f, feedingDisplayWidth * 0.14f, feedingDisplayHeight * 0.11f), "")) {
			guiManager.OpenInfoPanel(3);
		}
		if (GUI.Button(new Rect(feedingDisplayX + feedingDisplayWidth * 0.825f,  feedingDisplayY + feedingDisplayHeight * 0.095f, feedingDisplayWidth * 0.14f, feedingDisplayHeight * 0.11f), "Hunting Tips")) {
			guiManager.OpenInfoPanel(3);
		}
		
		guiManager.customGUISkin.button.normal.textColor = new Color(1f, 0f, 0f, 1f);
		
		guiManager.customGUISkin.button.normal.textColor = new Color(0.90f, 0.65f, 0f, 1f);
		
		

		// center panel

		GUI.color = new Color(1f, 1f, 1f, 0.8f * mainContentOpacity);
		GUI.Box(new Rect(feedingDisplayX + feedingDisplayWidth * 0.335f, feedingDisplayY + feedingDisplayHeight * 0.3f, feedingDisplayWidth * 0.33f, feedingDisplayHeight * 0.30f), "");
		GUI.Box(new Rect(feedingDisplayX + feedingDisplayWidth * 0.335f, feedingDisplayY + feedingDisplayHeight * 0.3f, feedingDisplayWidth * 0.33f, feedingDisplayHeight * 0.30f), "");
		GUI.color = new Color(1f, 1f, 1f, 0.9f * mainContentOpacity);
		GUI.Box(new Rect(feedingDisplayX + feedingDisplayWidth * 0.43f, feedingDisplayY + feedingDisplayHeight * 0.43f, feedingDisplayWidth * 0.14f, feedingDisplayHeight * 0.127f), "");
		//GUI.color = new Color(1f, 1f, 1f, 0.4f * mainContentOpacity);
		//GUI.Box(new Rect(feedingDisplayX + feedingDisplayWidth * 0.43f, feedingDisplayY + feedingDisplayHeight * 0.43f, feedingDisplayWidth * 0.14f, feedingDisplayHeight * 0.127f), "");

		style.fontSize = (int)(fontRef * 0.145f);
		style.normal.textColor = new Color(0.90f, 0.65f, 0f, 1f);
		style.normal.textColor =  bottomColor;
		GUI.color = new Color(1f, 1f, 1f, 1f * mainContentOpacity);
		GUI.Button(new Rect(feedingDisplayX + feedingDisplayWidth * 0.255f, feedingDisplayY + feedingDisplayHeight * 0.355f, feedingDisplayWidth * 0.5f, feedingDisplayHeight * 0.03f), bottomString1, style);

		style.fontSize = (int)(fontRef * 0.197f);
		style.normal.textColor = new Color(0.90f, 0.65f, 0f, 1f);
		style.normal.textColor =  midColor;
		GUI.Button(new Rect(feedingDisplayX + feedingDisplayWidth * 0.25f, feedingDisplayY + feedingDisplayHeight * 0.478f, feedingDisplayWidth * 0.5f, feedingDisplayHeight * 0.03f), bottomString2, style);
		
		// deer head & status info
		
		float panelOffsetY = -0.1f;

		GUI.color = new Color(1f, 1f, 1f, 0.8f * mainContentOpacity);
		GUI.Box(new Rect(feedingDisplayX + feedingDisplayWidth * 0.035f, feedingDisplayY + feedingDisplayHeight * 0.3f, feedingDisplayWidth * 0.3f, feedingDisplayHeight * 0.62f), "");
		GUI.color = new Color(1f, 1f, 1f, 0.5f * mainContentOpacity);
		GUI.Box(new Rect(feedingDisplayX + feedingDisplayWidth * 0.035f, feedingDisplayY + feedingDisplayHeight * 0.3f, feedingDisplayWidth * 0.3f, feedingDisplayHeight * 0.62f), "");
		GUI.color = new Color(1f, 1f, 1f, 1f * mainContentOpacity);

		//style.fontSize = (int)(fontRef * 0.28f);
		//style.normal.textColor = new Color(0.99f, 0.63f, 0f, 0.95f);
		//GUI.Button(new Rect(feedingDisplayX + feedingDisplayWidth * 0.15f, feedingDisplayY + feedingDisplayHeight * 0.6f, feedingDisplayWidth * 0.1f, feedingDisplayHeight * 0.03f), "|", style);
		//style.normal.textColor = new Color(0.90f, 0.65f, 0f, 1f);
		style.normal.textColor = new Color(0.90f, 0.65f, 0f,  0.8f);
		int meatJustEaten = (int)scoringSystem.GetLastKillMeatEaten();
		style.fontSize = (int)(fontRef * 0.16f);
		GUI.Button(new Rect(feedingDisplayX + feedingDisplayWidth * 0.200f, feedingDisplayY + feedingDisplayHeight * (0.705f + panelOffsetY), feedingDisplayWidth * 0.1f, feedingDisplayHeight * 0.03f), "meat", style);
		style.fontSize = (int)(fontRef * 0.125f);
		GUI.Button(new Rect(feedingDisplayX + feedingDisplayWidth * 0.200f, feedingDisplayY + feedingDisplayHeight * (0.784f + panelOffsetY), feedingDisplayWidth * 0.1f, feedingDisplayHeight * 0.03f), meatJustEaten.ToString() + " lbs", style);

		Texture2D displayHeadTexture = buckHeadTexture;
		string displayHeadLabel = "unnamed";
				
		switch (scoringSystem.GetLastKillDeerType()) {
			case "Buck":
				displayHeadTexture = buckHeadTexture;
				displayHeadLabel = "Buck";
				break;
			case "Doe":
				displayHeadTexture = doeHeadTexture;
				displayHeadLabel = "Doe";
				break;
			case "Fawn":
				displayHeadTexture = fawnHeadTexture;
				displayHeadLabel = "Fawn";
				break;		
		}

		
		float textureX = feedingDisplayX + feedingDisplayWidth * 0.075f;
		float textureWidth = feedingDisplayHeight * 0.4f;
		float textureHeight = displayHeadTexture.height * (textureWidth / displayHeadTexture.width);
		float textureY = feedingDisplayY + feedingDisplayHeight * (0.32f + panelOffsetY);
		GUI.DrawTexture(new Rect(textureX, textureY, textureWidth, textureHeight), displayHeadTexture);

		style.normal.textColor = new Color(0.99f * 0.9f, 0.63f * 0.8f, 0f, 1f);
		style.fontSize = (int)(fontRef * 0.13f);
		GUI.Button(new Rect(feedingDisplayX + feedingDisplayWidth * 0.087f, feedingDisplayY + feedingDisplayHeight * (0.78f + panelOffsetY), feedingDisplayWidth * 0.1f, feedingDisplayHeight * 0.03f), displayHeadLabel, style);

		//style.fontSize = (int)(fontRef * 0.28f);
		//style.normal.textColor = new Color(0.99f, 0.63f, 0f, 0.95f);
		//GUI.Button(new Rect(feedingDisplayX + feedingDisplayWidth * 0.35f, feedingDisplayY + feedingDisplayHeight * 0.6f, feedingDisplayWidth * 0.1f, feedingDisplayHeight * 0.03f), "|", style);
		//style.normal.textColor = new Color(0.90f, 0.65f, 0f, 1f);
		style.normal.textColor = new Color(0.1f, 0.70f, 0.1f, 1f);
		//style.fontSize = (int)(fontRef * 0.33f);
		//GUI.Button(new Rect(feedingDisplayX + feedingDisplayWidth * 0.30f, feedingDisplayY + feedingDisplayHeight * 0.50f, feedingDisplayWidth * 0.1f, feedingDisplayHeight * 0.03f), "+", style);
		style.fontSize = (int)(fontRef * 0.18f);
		int caloriesGained = (int)scoringSystem.GetLastKillCaloriesEaten();
		GUI.Button(new Rect(feedingDisplayX + feedingDisplayWidth * 0.203f, feedingDisplayY + feedingDisplayHeight * (0.50f + panelOffsetY), feedingDisplayWidth * 0.1f, feedingDisplayHeight * 0.03f), caloriesGained.ToString("n0"), style);
		style.fontSize = (int)(fontRef * 0.12f);
		GUI.Button(new Rect(feedingDisplayX + feedingDisplayWidth * 0.205f, feedingDisplayY + feedingDisplayHeight * (0.58f + panelOffsetY), feedingDisplayWidth * 0.1f, feedingDisplayHeight * 0.03f), "calories +", style);
		
		guiComponents.DrawMeatBar(mainContentOpacity, feedingDisplayX + feedingDisplayWidth * 0.040f + feedingDisplayHeight * 0.03f, feedingDisplayY + feedingDisplayHeight * 0.77f, feedingDisplayWidth * 0.29f - feedingDisplayHeight * 0.06f, feedingDisplayHeight * 0.12f);
		
		// puma head & status info

		
		GUI.color = new Color(1f, 1f, 1f, 0.8f * mainContentOpacity);
		GUI.Box(new Rect(feedingDisplayX + feedingDisplayWidth * 0.665f, feedingDisplayY + feedingDisplayHeight * 0.3f, feedingDisplayWidth * 0.3f, feedingDisplayHeight * 0.62f), "");
		GUI.color = new Color(1f, 1f, 1f, 0.5f * mainContentOpacity);
		GUI.Box(new Rect(feedingDisplayX + feedingDisplayWidth * 0.665f, feedingDisplayY + feedingDisplayHeight * 0.3f, feedingDisplayWidth * 0.3f, feedingDisplayHeight * 0.62f), "");
		GUI.color = new Color(1f, 1f, 1f, 1f * mainContentOpacity);

		style.normal.textColor = new Color(0.90f, 0.65f, 0f, 0.8f);
		style.fontSize = (int)(fontRef * 0.14f);
		GUI.Button(new Rect(feedingDisplayX + feedingDisplayWidth * 0.683f, feedingDisplayY + feedingDisplayHeight * (0.705f + panelOffsetY), feedingDisplayWidth * 0.1f, feedingDisplayHeight * 0.03f), "hunting", style);
		style.fontSize = (int)(fontRef * 0.13f);
		GUI.Button(new Rect(feedingDisplayX + feedingDisplayWidth * 0.683f, feedingDisplayY + feedingDisplayHeight * (0.778f + panelOffsetY), feedingDisplayWidth * 0.1f, feedingDisplayHeight * 0.03f), "effort", style);


		// puma identity
		Texture2D headshotTexture = closeup1Texture;
		string pumaName = "no name";
		switch (guiManager.selectedPuma) {
		case 0:
			headshotTexture = closeup1Texture;
			pumaName = "Eric";
			break;
		case 1:
			headshotTexture = closeup2Texture;
			pumaName = "Palo";
			break;
		case 2:
			headshotTexture = closeup3Texture;
			pumaName = "Mitch";
			break;
		case 3:
			headshotTexture = closeup4Texture;
			pumaName = "Trish";
			break;
		case 4:
			headshotTexture = closeup5Texture;
			pumaName = "Liam";
			break;
		case 5:
			headshotTexture = closeup6Texture;
			pumaName = "Barb";
			break;
		}


		// puma head
		//float statusPanelOpacityDrop = 1f - statusPanelOpacity;
		//mainContentOpacity = 1f - (statusPanelOpacityDrop * 0.25f);
		//GUI.color = new Color(1f, 1f, 1f, 1f * mainContentOpacity);
		textureX = feedingDisplayX + feedingDisplayWidth * 0.81f;
		textureY = feedingDisplayY + feedingDisplayHeight * (0.42f + panelOffsetY);
		textureWidth = feedingDisplayHeight * 0.39f;
		textureHeight = headshotTexture.height * (textureWidth / headshotTexture.width);
		GUI.DrawTexture(new Rect(textureX, textureY, textureWidth, textureHeight), headshotTexture);
		//mainContentOpacity = mainContentOpacity * statusPanelOpacity;
		//GUI.color = new Color(1f, 1f, 1f, 1f * mainContentOpacity);

		// puma name
		//mainContentOpacity = 1f - (statusPanelOpacityDrop * 0.75f);
		//GUI.color = new Color(1f, 1f, 1f, 1f * mainContentOpacity);
		style.normal.textColor = new Color(0.99f * 0.9f, 0.63f * 0.8f, 0f, 1f);
		style.fontSize = (int)(fontRef * 0.13f);
		GUI.Button(new Rect(feedingDisplayX + feedingDisplayWidth * 0.817f, feedingDisplayY + feedingDisplayHeight * (0.78f + panelOffsetY), feedingDisplayWidth * 0.1f, feedingDisplayHeight * 0.03f), pumaName, style);
		//mainContentOpacity = mainContentOpacity * statusPanelOpacity;
		//GUI.color = new Color(1f, 1f, 1f, 1f * mainContentOpacity);

		
		style.normal.textColor = new Color(0.65f, 0f, 0f, 1f);
		//style.fontSize = (int)(fontRef * 0.12f);
		//GUI.Button(new Rect(feedingDisplayX + feedingDisplayWidth * 0.85f, feedingDisplayY + feedingDisplayHeight * 0.51f, feedingDisplayWidth * 0.1f, feedingDisplayHeight * 0.03f), "minus", style);
		style.fontSize = (int)(fontRef * 0.18f);
		int caloriesExpended = (int)scoringSystem.GetLastKillExpense(guiManager.selectedPuma);
		GUI.Button(new Rect(feedingDisplayX + feedingDisplayWidth * 0.685f, feedingDisplayY + feedingDisplayHeight * (0.50f + panelOffsetY), feedingDisplayWidth * 0.1f, feedingDisplayHeight * 0.03f), caloriesExpended.ToString("n0"), style);
		style.fontSize = (int)(fontRef * 0.125f);
		GUI.Button(new Rect(feedingDisplayX + feedingDisplayWidth * 0.69f, feedingDisplayY + feedingDisplayHeight * (0.58f + panelOffsetY), feedingDisplayWidth * 0.1f, feedingDisplayHeight * 0.03f), "effort -", style);
		
		guiComponents.DrawPumaHealthBar(guiManager.selectedPuma, mainContentOpacity, feedingDisplayX + feedingDisplayWidth * 0.670f + feedingDisplayHeight * 0.03f, feedingDisplayY + feedingDisplayHeight * 0.775f, feedingDisplayWidth * 0.29f - feedingDisplayHeight * 0.06f, feedingDisplayHeight * 0.11f);

		
		// population bar
		
		GUI.color = new Color(1f, 1f, 1f, 0.8f * mainContentOpacity);
		GUI.Box(new Rect(feedingDisplayX + feedingDisplayWidth * 0.37f, feedingDisplayY + feedingDisplayHeight * 0.71f, feedingDisplayWidth * 0.26f, feedingDisplayHeight * 0.28f), "");
		GUI.color = new Color(1f, 1f, 1f, 0.4f * mainContentOpacity);
		GUI.Box(new Rect(feedingDisplayX + feedingDisplayWidth * 0.37f, feedingDisplayY + feedingDisplayHeight * 0.71f, feedingDisplayWidth * 0.26f, feedingDisplayHeight * 0.28f), "");
		GUI.color = new Color(1f, 1f, 1f, 0.4f * mainContentOpacity);
		GUI.Box(new Rect(feedingDisplayX + feedingDisplayWidth * 0.37f, feedingDisplayY + feedingDisplayHeight * 0.71f, feedingDisplayWidth * 0.26f, feedingDisplayHeight * 0.28f), "");
	
		GUI.color = new Color(1f, 1f, 1f, 0.4f * mainContentOpacity);
		GUI.Box(new Rect(feedingDisplayX + feedingDisplayWidth * 0.035f, feedingDisplayY + feedingDisplayHeight * 0.99f, feedingDisplayWidth * 0.93f, feedingDisplayHeight * 0.145f), "");
		GUI.color = new Color(1f, 1f, 1f, 1f * mainContentOpacity);
		guiComponents.DrawPopulationHealthBar(mainContentOpacity, feedingDisplayX + feedingDisplayWidth * 0.035f, feedingDisplayY + feedingDisplayHeight * 0.99f, feedingDisplayWidth * 0.93f, feedingDisplayHeight * 0.145f, true, true);
		

		//********************
		// LEVEL DISPLAY
		//********************

		float levelDisplayX = feedingDisplayX + feedingDisplayWidth * 0.74f;
		float levelDisplayY = feedingDisplayY + feedingDisplayHeight * 1.294f;
		float levelDisplayW = feedingDisplayWidth * 0.24f; 
		float levelDisplayH = feedingDisplayHeight * 0.55f;
		
		float borderPercent = 0.05f;
		float innerX = levelDisplayX + levelDisplayW * borderPercent;
		float innerY = levelDisplayY + levelDisplayW * borderPercent;
		float innerW = levelDisplayW - levelDisplayW * borderPercent * 2f; 
		float innerH = levelDisplayH - levelDisplayW * borderPercent * 2f;
		
		// background boxes
		GUI.color = new Color(1f, 1f, 1f, 0.8f * levelCompleteOpacity);
		GUI.Box(new Rect(levelDisplayX, levelDisplayY, levelDisplayW, levelDisplayH), "");
		GUI.color = new Color(1f, 1f, 1f, 0.4f * levelCompleteOpacity);
		GUI.Box(new Rect(levelDisplayX, levelDisplayY, levelDisplayW, levelDisplayH), "");
		GUI.color = new Color(1f, 1f, 1f, 1f * levelCompleteOpacity);

		// text background
		GUI.color = new Color(1f, 1f, 1f, 0.8f * levelCompleteOpacity);
		GUI.Box(new Rect(innerX, innerY, innerW, innerH * 0.45f), "");
		GUI.color = new Color(1f, 1f, 1f, 0.4f * levelCompleteOpacity);
		GUI.Box(new Rect(innerX, innerY, innerW, innerH * 0.45f), "");
		GUI.color = new Color(1f, 1f, 1f, 1f * levelCompleteOpacity);
		
		// text labels
		style.normal.textColor = new Color(0.90f, 0.65f, 0f, 0.8f);
		style.fontSize = (int)(fontRef * 0.135f);
		GUI.Button(new Rect(levelDisplayX, levelDisplayY + levelDisplayH * 0.03f, levelDisplayW, levelDisplayH * 0.3f), "3 good hunts in a row", style);
		style.normal.textColor = new Color(0.85f, 0.75f, 0f, 0.8f);
		style.fontSize = (int)(fontRef * 0.12f);
		GUI.Button(new Rect(levelDisplayX, levelDisplayY + levelDisplayH * 0.185f, levelDisplayW, levelDisplayH * 0.3f), "opens the next level", style);

		// hunt stat backgrounds
		float gapSize = innerW * 0.03f;
		GUI.color = new Color(1f, 1f, 1f, 0.8f * levelCompleteOpacity);
		GUI.Box(new Rect(innerX, innerY + innerH * 0.50f, (innerW - gapSize * 2f) *  0.33333f, innerH * 0.50f), "");
		GUI.color = new Color(1f, 1f, 1f, 0.4f * levelCompleteOpacity);
		GUI.Box(new Rect(innerX, innerY + innerH * 0.50f, (innerW - gapSize * 2f) *  0.33333f, innerH * 0.50f), "");
		GUI.color = new Color(1f, 1f, 1f, 1f * levelCompleteOpacity);

		GUI.color = new Color(1f, 1f, 1f, 0.8f * levelCompleteOpacity);
		GUI.Box(new Rect(innerX + innerW * 0.33333f + gapSize/4, innerY + innerH * 0.50f, (innerW - gapSize * 2f) *  0.33333f, innerH * 0.50f), "");
		GUI.color = new Color(1f, 1f, 1f, 0.4f * levelCompleteOpacity);
		GUI.Box(new Rect(innerX + innerW * 0.33333f + gapSize/4, innerY + innerH * 0.50f, (innerW - gapSize * 2f) *  0.33333f, innerH * 0.50f), "");
		GUI.color = new Color(1f, 1f, 1f, 1f * levelCompleteOpacity);

		GUI.color = new Color(1f, 1f, 1f, 0.8f * levelCompleteOpacity);
		GUI.Box(new Rect(innerX + innerW * 0.66666f + gapSize/2, innerY + innerH * 0.50f, (innerW - gapSize * 2f) *  0.33333f, innerH * 0.50f), "");
		GUI.color = new Color(1f, 1f, 1f, 0.4f * levelCompleteOpacity);
		GUI.Box(new Rect(innerX + innerW * 0.666666f + gapSize/2, innerY + innerH * 0.50f, (innerW - gapSize * 2f) *  0.33333f, innerH * 0.50f), "");
		GUI.color = new Color(1f, 1f, 1f, 1f * levelCompleteOpacity);

		// hunt indicators
		int successCount = scoringSystem.GetHuntSuccessCount();
		float inset = innerW * 0.04f;
		switch (successCount) {
		case 0:
			GUI.DrawTexture(new Rect(inset + innerX, inset + innerY + innerH * 0.50f, (innerW - gapSize * 2f) *  0.33333f - inset*2, innerH * 0.50f - inset*2), redXTexture);
			break;
		case 1:
			GUI.DrawTexture(new Rect(inset + innerX, inset + innerY + innerH * 0.50f, (innerW - gapSize * 2f) *  0.33333f - inset*2, innerH * 0.50f - inset*2), greenCheckTexture);
			break;
		case 2:
			GUI.DrawTexture(new Rect(inset + innerX, inset + innerY + innerH * 0.50f, (innerW - gapSize * 2f) *  0.33333f - inset*2, innerH * 0.50f - inset*2), greenCheckTexture);
			GUI.DrawTexture(new Rect(inset + innerX + innerW * 0.33333f + gapSize/4, inset + innerY + innerH * 0.50f, (innerW - gapSize * 2f) *  0.33333f - inset*2, innerH * 0.50f - inset*2), greenCheckTexture);
			break;
		case 3:
			GUI.DrawTexture(new Rect(inset + innerX, inset + innerY + innerH * 0.50f, (innerW - gapSize * 2f) *  0.33333f - inset*2, innerH * 0.50f - inset*2), greenCheckTexture);
			GUI.DrawTexture(new Rect(inset + innerX + innerW * 0.33333f + gapSize/4, inset + innerY + innerH * 0.50f, (innerW - gapSize * 2f) *  0.33333f - inset*2, innerH * 0.50f - inset*2), greenCheckTexture);
			GUI.DrawTexture(new Rect(inset + innerX + innerW * 0.66666f + gapSize/2, inset + innerY + innerH * 0.50f, (innerW - gapSize * 2f) *  0.33333f - inset*2, innerH * 0.50f - inset*2), greenCheckTexture);
			break;
		}
		
		// hunt success flashing rect	
		if (successCount == 3) {
			float flashingPeriod = 0.4f;
			float flashingOpacity = 0f;
			if (Time.time > flashStartTime + flashingPeriod) {
				flashStartTime = Time.time;
			}
			if (Time.time < flashStartTime + flashingPeriod * 0.3f) {
				// first half
				flashingOpacity = (Time.time - flashStartTime) / (flashingPeriod * 0.3f);
			}
			else {
				// second half
				flashingOpacity = 1f - ((Time.time - flashStartTime - flashingPeriod * 0.3f) / (flashingPeriod * 0.7f));			
			}	
			flashingOpacity = 0.3f + flashingOpacity * 0.7f;
			flashingOpacity = flashingOpacity * flashingOpacity;
			GUI.color = new Color(1f, 1f, 1f, flashingOpacity * 0.8f * levelCompleteOpacity);
			GUI.DrawTexture(new Rect(levelDisplayX, levelDisplayY, levelDisplayW, levelDisplayH), greenOutlineRectTexture);
			GUI.color = new Color(1f, 1f, 1f, 1f * levelCompleteOpacity);
		}

		// hunt cheat buttons

		GUI.color = new Color(1f, 1f, 1f, 0f);

		if (GUI.Button(new Rect(inset + innerX, inset + innerY + innerH * 0.50f, (innerW - gapSize * 2f) *  0.33333f - inset*2, innerH * 0.50f - inset*2), "")) {
			scoringSystem.SetHuntSuccessCount(1);
		}
		if (GUI.Button(new Rect(inset + innerX + innerW * 0.33333f + gapSize/4, inset + innerY + innerH * 0.50f, (innerW - gapSize * 2f) *  0.33333f - inset*2, innerH * 0.50f - inset*2), "")) {
			scoringSystem.SetHuntSuccessCount(2);
		}
		if (GUI.Button(new Rect(inset + innerX + innerW * 0.66666f + gapSize/2, inset + innerY + innerH * 0.50f, (innerW - gapSize * 2f) *  0.33333f - inset*2, innerH * 0.50f - inset*2), "")) {
			scoringSystem.SetHuntSuccessCount(3);
		}

		GUI.color = new Color(1f, 1f, 1f, 1f * okButtonOpacity);




		
		
		

		
		//********************
		// 'OK' BUTTON
		//********************
					
		feedingDisplayX -= feedingDisplayWidth * 0.02f;
		feedingDisplayY += feedingDisplayHeight * 1.3f;

		GUI.color = new Color(1f, 1f, 1f, 0.8f * okButtonOpacity);
		GUI.Box(new Rect(feedingDisplayX + feedingDisplayWidth * 0.78f, feedingDisplayY + feedingDisplayHeight * 0.67f, feedingDisplayWidth * 0.20f, feedingDisplayHeight * 0.37f), "");
		GUI.color = new Color(1f, 1f, 1f, 0.6f * okButtonOpacity);
		GUI.Box(new Rect(feedingDisplayX + feedingDisplayWidth * 0.78f, feedingDisplayY + feedingDisplayHeight * 0.67f, feedingDisplayWidth * 0.20f, feedingDisplayHeight * 0.37f), "");
		GUI.color = new Color(1f, 1f, 1f, 1f * okButtonOpacity);

		GUI.color = new Color(1f, 1f, 1f, 0.8f * okButtonOpacity);
		GUI.Box(new Rect(feedingDisplayX + feedingDisplayWidth * 0.81f,  feedingDisplayY + feedingDisplayHeight * 0.727f, feedingDisplayWidth * 0.14f, feedingDisplayHeight * 0.25f), "");
		GUI.color = new Color(1f, 1f, 1f, 0.8f * okButtonOpacity);
		GUI.Box(new Rect(feedingDisplayX + feedingDisplayWidth * 0.81f,  feedingDisplayY + feedingDisplayHeight * 0.727f, feedingDisplayWidth * 0.14f, feedingDisplayHeight * 0.25f), "");
		GUI.color = new Color(1f, 1f, 1f, 1f * okButtonOpacity);

		GUI.skin = guiManager.customGUISkin;
		guiManager.customGUISkin.button.fontSize = (int)(feedingDisplayHeight * 0.14);
		guiManager.customGUISkin.button.fontStyle = FontStyle.Normal;
		if (GUI.Button(new Rect(feedingDisplayX + feedingDisplayWidth * 0.81f,  feedingDisplayY + feedingDisplayHeight * 0.727f, feedingDisplayWidth * 0.14f, feedingDisplayHeight * 0.25f), "Go")) {
			if (scoringSystem.GetHuntSuccessCount() >= 3) {
				// use keyboard to go to next level
				guiManager.SetGuiState("guiStateLeavingFeeding");
				levelManager.SetGameState("gameStateLeavingGameplay");
			}
			else {
				// use keyboard to resume gameplay
				guiManager.SetGuiState("guiStateFeeding7");
				levelManager.SetGameState("gameStateFeeding5");
			}
		}	
		
		feedingDisplayX += feedingDisplayWidth * 0.02f;
		feedingDisplayY -= feedingDisplayHeight * 1.3f;
	}
	
}