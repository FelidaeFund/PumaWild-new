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
	}

	//===================================
	//===================================
	//		DRAW THE FEEDING DISPLAY
	//===================================
	//===================================

	public void Draw(float backgroundPanelOpacity, float mainContentOpacity, float okButtonOpacity, float pumaWinsOpacity) 
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
		GUI.Button(new Rect(feedingDisplayX + feedingDisplayWidth * 0.69f, feedingDisplayY + feedingDisplayHeight * (0.58f + panelOffsetY), feedingDisplayWidth * 0.1f, feedingDisplayHeight * 0.03f), "points -", style);
		
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
			if (pumaWinsOpacity > 0f) {
				guiManager.SetGuiState("guiStateLeavingPumaWins");
				levelManager.SetGameState("gameStateLeavingGameplay");
			}
			else {
				guiManager.SetGuiState("guiStateFeeding7");
				levelManager.SetGameState("gameStateFeeding5");
			}
		}	
		
		feedingDisplayX += feedingDisplayWidth * 0.02f;
		feedingDisplayY -= feedingDisplayHeight * 1.3f;
		

		//********************
		// PUMA WINS
		//********************
					
		GUI.color = new Color(1f, 1f, 1f, 1f * pumaWinsOpacity);

		
		float sourcePercent = 0f;
		float destPercent = 1f;

		// header title
		float titleX = feedingDisplayX + feedingDisplayWidth * 0.3f;
		float titleY = feedingDisplayY + feedingDisplayHeight * 0.136f;
		float titleW = feedingDisplayWidth * 0.4f;
		float titleH = feedingDisplayHeight * 0.03f;
		style.fontSize = (int)(fontRef * 0.22f);
		style.normal.textColor =  new Color(0f, 0.66f, 0f, 1f);
		style.fontStyle = FontStyle.Bold;
		//GUI.Button(new Rect(feedingDisplayX + feedingDisplayWidth * 0.3f + title1Offset, feedingDisplayY + feedingDisplayHeight * 0.135f, feedingDisplayWidth * 0.4f, feedingDisplayHeight * 0.03f), topString, style);
		style.fontSize = (int)(fontRef * 0.18f);
		GUI.Button(new Rect(titleX, titleY, titleW, titleH), "Yay! - This puma is at FULL HEATLH !!", style);
		
		// background box
		float boxX = feedingDisplayX + feedingDisplayWidth * (0.665f * sourcePercent + 0.3f * destPercent);
		float boxY = feedingDisplayY + feedingDisplayHeight * (0.3f * sourcePercent + 0.3f * destPercent);
		float boxW = feedingDisplayWidth * (0.3f * sourcePercent + 0.4f * destPercent);
		float boxH = feedingDisplayHeight * (0.62f * sourcePercent + 0.8f * destPercent);
		GUI.color = new Color(1f, 1f, 1f, 0.8f * pumaWinsOpacity);
		GUI.Box(new Rect(boxX, boxY, boxW, boxH), "");
		GUI.color = new Color(1f, 1f, 1f, 0.5f * pumaWinsOpacity);
		GUI.Box(new Rect(boxX, boxY, boxW, boxH), "");
		GUI.color = new Color(1f, 1f, 1f, 1f * pumaWinsOpacity);

		// left label
		float leftLabelX = feedingDisplayX + feedingDisplayWidth * 0.668f;
		float leftLabelY1 = feedingDisplayY + feedingDisplayHeight * (0.596f + panelOffsetY);
		float leftLabelY2 = feedingDisplayY + feedingDisplayHeight * (0.678f + panelOffsetY);
		float leftLabelW = feedingDisplayWidth * 0.1f;
		float leftLabelH = feedingDisplayHeight * 0.03f;
		style.normal.textColor = new Color(0.90f, 0.65f, 0f, 0.9f);
		style.fontSize = (int)(fontRef * 0.15f);
		GUI.Button(new Rect(leftLabelX, leftLabelY1, leftLabelW, leftLabelH), "Energy", style);
		style.fontSize = (int)(fontRef * 0.14f);
		GUI.Button(new Rect(leftLabelX, leftLabelY2, leftLabelW, leftLabelH), "Spent", style);

		// puma head
		textureX = feedingDisplayX + feedingDisplayWidth * 0.76f;
		textureY = feedingDisplayY + feedingDisplayHeight * (0.42f + panelOffsetY);
		textureWidth = feedingDisplayHeight * 0.39f;
		textureHeight = headshotTexture.height * (textureWidth / headshotTexture.width);
		GUI.DrawTexture(new Rect(textureX, textureY, textureWidth, textureHeight), headshotTexture);

		// puma name
		float nameX = feedingDisplayX + feedingDisplayWidth * 0.767f;
		float nameY = feedingDisplayY + feedingDisplayHeight * (0.78f + panelOffsetY);
		float nameW = feedingDisplayWidth * 0.1f;
		float nameH = feedingDisplayHeight * 0.03f;
		style.normal.textColor = new Color(0.99f * 0.9f, 0.63f * 0.8f, 0f, 1f);
		style.fontSize = (int)(fontRef * 0.13f);
		GUI.Button(new Rect(nameX, nameY, nameW, nameH), pumaName, style);

		// right label
		float rightLabelX = feedingDisplayX + feedingDisplayWidth * 0.86f;
		float rightLabelY1 = feedingDisplayY + feedingDisplayHeight * (0.60f + panelOffsetY);
		float rightLabelY2 = feedingDisplayY + feedingDisplayHeight * (0.68f + panelOffsetY);
		float rightLabelW = feedingDisplayWidth * 0.1f;
		float rightLabelH = feedingDisplayHeight * 0.03f;
		style.normal.textColor = new Color(0.78f, 0f, 0f, 1f);
		style.fontSize = (int)(fontRef * 0.18f);
		GUI.Button(new Rect(rightLabelX, rightLabelY1, rightLabelW, rightLabelH), caloriesExpended.ToString("n0"), style);
		style.fontSize = (int)(fontRef * 0.125f);
		GUI.Button(new Rect(rightLabelX, rightLabelY2, rightLabelW, rightLabelH), "points -", style);
		
		
		// health bar
		float barX = feedingDisplayX + feedingDisplayWidth * 0.670f + feedingDisplayHeight * 0.03f;
		float barY = feedingDisplayY + feedingDisplayHeight * 0.775f;
		float barW = feedingDisplayWidth * 0.29f - feedingDisplayHeight * 0.06f;
		float barH = feedingDisplayHeight * 0.11f;
		guiComponents.DrawPumaHealthBar(guiManager.selectedPuma, pumaWinsOpacity, barX, barY, barW, barH);
		
	}
	
}