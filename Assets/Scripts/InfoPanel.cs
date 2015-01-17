using UnityEngine;
using System.Collections;

/// InfoPanel
/// Draw the Info panel that provides info on topics

public class InfoPanel : MonoBehaviour
{
	//===================================
	//===================================
	//		MODULE VARIABLES
	//===================================
	//===================================

	private bool newLevelFlag = true;
	private int currentLevel = 0;
	private bool backgroundIsLocked = false;
	
	private Rect overlayRect;
	private int currentScreen;
	private int difficultyLevel;
	private int soundEnable;
	private float soundVolume;
	private float pawRightFlag;
	
	// button styling
	private GUIStyle buttonStyle;	
	private GUIStyle buttonDownStyle;	
	private GUIStyle buttonDisabledStyle;	
	private GUIStyle bigButtonStyle;	
	private GUIStyle bigButtonDisabledStyle;
	private GUIStyle swapButtonStyle;

	// slider styling
	private GUISkin customSkin;
	private GUIStyle sliderBarStyle;
	private GUIStyle sliderThumbStyle;	

	// textures based on bitmap files
	private Texture2D logoTexture;
	private Texture2D backgroundTexture;
	private Texture2D pumaIconTexture;
	private Texture2D pumaIconShadowTexture;
	private Texture2D greenCheckTexture;	
	private Texture2D radioButtonTexture;
	private Texture2D radioSelectTexture;
	private Texture2D arrowTrayTexture;
	private Texture2D arrowTrayTopTexture;
	private Texture2D swapButtonTexture;
	private Texture2D swapButtonHoverTexture;
	private Texture2D sliderBarTexture;
	private Texture2D sliderThumbTexture;
	private Texture2D buckHeadTexture;
	private Texture2D doeHeadTexture;
	private Texture2D fawnHeadTexture;
	private Texture2D headshot1Texture;
	private Texture2D headshot2Texture;
	private Texture2D headshot3Texture;
	private Texture2D headshot4Texture;
	private Texture2D headshot5Texture;
	private Texture2D headshot6Texture;
	private Texture2D closeup1Texture;
	private Texture2D closeup2Texture;
	private Texture2D closeup3Texture;
	private Texture2D closeup4Texture;
	private Texture2D closeup5Texture;
	private Texture2D closeup6Texture;
	private Texture2D closeupBackgroundTexture;
	private Texture2D pumaCrossbonesDarkRedTexture;
	private Texture2D greenHeartTexture;

	private Texture2D iconFacebookTexture; 
	private Texture2D iconTwitterTexture; 
	private Texture2D iconGoogleTexture; 
	private Texture2D iconPinterestTexture; 
	private Texture2D iconYouTubeTexture; 
	private Texture2D iconLinkedInTexture; 
	private Texture2D logoFelidaeTexture; 
	private Texture2D logoBappTexture; 
	private Texture2D levelImage1Texture; 
	private Texture2D levelImage2Texture; 
	private Texture2D levelImage3Texture; 
	private Texture2D levelImage4Texture; 
	private Texture2D levelImage5Texture; 
	private Texture2D levelImage6Texture; 
	
	// external modules
	private GuiManager guiManager;
	private GuiComponents guiComponents;
	private GuiUtils guiUtils;
	private LevelManager levelManager;
	//private InputControls inputControls;
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
		guiUtils = GetComponent<GuiUtils>();
		levelManager = GetComponent<LevelManager>();
		//inputControls = GetComponent<InputControls>();
		scoringSystem = GetComponent<ScoringSystem>();
		
		// texture references from GuiManager
		logoTexture = guiManager.logoTexture;
		backgroundTexture = guiManager.backgroundTexture;
		pumaIconTexture = guiManager.pumaIconTexture;
		pumaIconShadowTexture = guiManager.pumaIconShadowTexture;
		greenCheckTexture = guiManager.greenCheckTexture;
		radioButtonTexture = guiManager.radioButtonTexture;
		radioSelectTexture = guiManager.radioSelectTexture;
		arrowTrayTexture = guiManager.arrowTrayTexture;
		arrowTrayTopTexture = guiManager.arrowTrayTopTexture;
		swapButtonTexture = guiManager.swapButtonTexture;
		swapButtonHoverTexture = guiManager.swapButtonHoverTexture;
		sliderBarTexture = guiManager.sliderBarTexture;
		sliderThumbTexture = guiManager.sliderThumbTexture;
		buckHeadTexture = guiManager.buckHeadTexture;
		doeHeadTexture = guiManager.doeHeadTexture;
		fawnHeadTexture = guiManager.fawnHeadTexture;
		headshot1Texture = guiManager.headshot1Texture;
		headshot2Texture = guiManager.headshot2Texture;
		headshot3Texture = guiManager.headshot3Texture;
		headshot4Texture = guiManager.headshot4Texture;
		headshot5Texture = guiManager.headshot5Texture;
		headshot6Texture = guiManager.headshot6Texture;
		closeup1Texture = guiManager.closeup1Texture;
		closeup2Texture = guiManager.closeup2Texture;
		closeup3Texture = guiManager.closeup3Texture;
		closeup4Texture = guiManager.closeup4Texture;
		closeup5Texture = guiManager.closeup5Texture;
		closeup6Texture = guiManager.closeup6Texture;
		closeupBackgroundTexture = guiManager.closeupBackgroundTexture;
		pumaCrossbonesDarkRedTexture = guiManager.pumaCrossbonesDarkRedTexture;		
		greenHeartTexture = guiManager.greenHeartTexture;		

		iconFacebookTexture = guiManager.iconFacebookTexture;
		iconTwitterTexture = guiManager.iconTwitterTexture;
		iconGoogleTexture = guiManager.iconGoogleTexture;
		iconPinterestTexture = guiManager.iconPinterestTexture;
		iconYouTubeTexture = guiManager.iconYouTubeTexture;
		iconLinkedInTexture = guiManager.iconLinkedInTexture;
		logoFelidaeTexture = guiManager.logoFelidaeTexture;
		logoBappTexture = guiManager.logoBappTexture;
		
		levelImage1Texture = guiManager.levelImage1Texture;
		levelImage2Texture = guiManager.levelImage2Texture;
		levelImage3Texture = guiManager.levelImage3Texture;
		levelImage4Texture = guiManager.levelImage4Texture;
		levelImage5Texture = guiManager.levelImage5Texture;
		levelImage6Texture = guiManager.levelImage6Texture;
		
		// custom button styling
		buttonStyle = new GUIStyle();
		buttonStyle.normal.textColor = new Color(0.99f, 0.7f, 0.2f, 1f);
		buttonStyle.hover.textColor = new Color(0.99f, 0.8f, 0.4f, 1f);
		buttonStyle.alignment = TextAnchor.MiddleCenter;
		buttonDownStyle = new GUIStyle();
		buttonDownStyle.normal.textColor = new Color(0.99f, 0.88f, 0.6f, 1f);
		buttonDownStyle.hover.textColor = new Color(0.99f, 0.88f, 0.6f, 1f);
		buttonDownStyle.alignment = TextAnchor.MiddleCenter;
		buttonDisabledStyle = new GUIStyle();
		buttonDisabledStyle.normal.textColor = new Color(0.3f, 0.3f, 0.3f, 1f);
		buttonDisabledStyle.hover.textColor = new Color(0.3f, 0.3f, 0.3f, 1f);
		buttonDisabledStyle.alignment = TextAnchor.MiddleCenter;
		bigButtonStyle = new GUIStyle();
		bigButtonStyle.normal.textColor = new Color(0.99f, 0.7f, 0.2f, 1f);
		bigButtonStyle.hover.textColor = new Color(0.99f, 0.8f, 0.4f, 1f);
		bigButtonStyle.alignment = TextAnchor.MiddleCenter;
		bigButtonDisabledStyle = new GUIStyle();
		bigButtonDisabledStyle.normal.textColor = new Color(0.4f, 0.4f, 0.4f, 1f);
		bigButtonDisabledStyle.hover.textColor = new Color(0.4f, 0.4f, 0.4f, 1f);
		bigButtonDisabledStyle.alignment = TextAnchor.MiddleCenter;
		swapButtonStyle = new GUIStyle();
		swapButtonStyle.normal.textColor = Color.white;
		swapButtonStyle.normal.background = swapButtonTexture;
		swapButtonStyle.hover.textColor = Color.white;
		swapButtonStyle.hover.background = swapButtonHoverTexture;
		swapButtonStyle.alignment = TextAnchor.MiddleCenter;

		// custom slider styling
		sliderBarStyle = new GUIStyle();
		sliderThumbStyle = new GUIStyle();
		sliderThumbStyle.normal.background = sliderThumbTexture;
		sliderThumbStyle.padding = new RectOffset(10,10,10,10);
		customSkin = (GUISkin)ScriptableObject.CreateInstance("GUISkin");
		customSkin.horizontalSlider = sliderBarStyle;
		customSkin.horizontalSliderThumb = sliderThumbStyle;	

		// additional initialization
		currentScreen = 0;
		difficultyLevel = 1;
		soundEnable = 1;
		soundVolume = 0.5f;
		pawRightFlag = 1;
	}
	
	//===================================
	//===================================
	//	 PUBLIC ACCESS TO MODULE VARS
	//===================================
	//===================================
	
	public int GetCurrentScreen()
	{
		return currentScreen;
	}

	public void SetCurrentScreen(int newVal)
	{
		currentScreen = newVal;
	}
	
	public void SetNewLevelNumber(int levelNum)
	{
		currentLevel = levelNum;
	}
		
	public int GetLevelNumber()
	{
		return currentLevel;
	}
		
	public void SetNewLevelFlag(bool boolVal)
	{
		newLevelFlag = boolVal;
	}
		

	public void SetBackgroundIsLocked(bool lockedFlag)
	{
		backgroundIsLocked = lockedFlag;
	}
	
	

	//===================================
	//===================================
	//	  DRAW THE INFO PANEL
	//===================================
	//===================================
	
	public void Draw(float incomingInfoPanelOpacity, float backRectOpacity, float goButtonOpacity) 
	{ 
		float infoPanelOpacity = (backgroundIsLocked == true) ? 1f : incomingInfoPanelOpacity;

		// back rect happens before everything else
		GUI.color = new Color(1f, 1f, 1f, 1f * backRectOpacity);
		guiUtils.DrawRect(new Rect(0f, 0f, Screen.width, Screen.height), new Color(0.1f, 0.1f, 0.1f, 1f));	
		GUI.color = new Color(1f, 1f, 1f, 1f * infoPanelOpacity);
	

		// now do the rest

		overlayRect = guiManager.GetOverlayRect();
		
		float originalOverlayX = overlayRect.x;
		float originalOverlayWidth = overlayRect.width;
		overlayRect.x -= overlayRect.width * 0.06f;
		overlayRect.width += overlayRect.width * 0.12f;
	
		// background panel
		GUI.color = new Color(0f, 0f, 0f, 1f * infoPanelOpacity);
		GUI.Box(new Rect(overlayRect.x, overlayRect.y, overlayRect.width, overlayRect.height), "");
		//GUI.color = new Color(0f, 0f, 0f, 0.3f * infoPanelOpacity);
		//GUI.Box(new Rect(overlayRect.x, overlayRect.y, overlayRect.width, overlayRect.height), "");
		GUI.color = new Color(1f, 1f, 1f, 1f * infoPanelOpacity);
		
		//background image
		//GUI.color = new Color(1f, 1f, 1f, 0.75f * infoPanelOpacity);
		//GUI.color = new Color(1f, 1f, 1f, 0f * infoPanelOpacity);
		//GUI.DrawTexture(new Rect(overlayRect.x + 4, overlayRect.y + 4, overlayRect.width-8, overlayRect.height-8), backgroundTexture);
		//GUI.color = new Color(1f, 1f, 1f, 1f * infoPanelOpacity);
			
		GUIStyle style = new GUIStyle();
		style.alignment = TextAnchor.MiddleCenter;
		
		// MAIN TTTLE
		
		float upperItemsYShift = overlayRect.height * 0.01f;

		if (true) {
			// graphical logo
			float logoX = originalOverlayX + originalOverlayWidth * 0.36f;
			float logoY = overlayRect.y - overlayRect.height * 0.023f + upperItemsYShift;
			float logoWidth = originalOverlayWidth * 0.28f;
			float logoHeight = logoTexture.height * (logoWidth / logoTexture.width);
			//GUI.color = new Color(1f, 1f, 1f, 0.75f * infoPanelOpacity);
			GUI.color = new Color(0f, 0f, 0f, 1f * infoPanelOpacity);
			GUI.Box(new Rect(logoX, logoY + logoHeight * 0.2f, logoWidth, logoHeight * 0.6f), "");
			GUI.color = new Color(1f, 1f, 1f, 1f * infoPanelOpacity);			
			GUI.DrawTexture(new Rect(logoX, logoY, logoWidth, logoHeight), logoTexture);
			//GUI.color = new Color(1f, 1f, 1f, 1f * infoPanelOpacity);
		}
		else {
			// text-based logo -- for reference only		
			GUI.color = new Color(1f, 1f, 1f, 0.93f * infoPanelOpacity);
			float xPos = overlayRect.x + overlayRect.width * 0.349f;
			style.fontSize = (int)(overlayRect.width * 0.048f);
			style.fontStyle = FontStyle.BoldAndItalic;
			style.normal.textColor = new Color(0.2f, 0f, 0f, 1f);
			GUI.Button(new Rect(xPos - overlayRect.width * 0.003f, overlayRect.y + overlayRect.height * 0.008f + upperItemsYShift, overlayRect.width * 0.30f, overlayRect.height * 0.10f), "PumaWild", style);
			GUI.Button(new Rect(xPos + overlayRect.width * 0.003f, overlayRect.y + overlayRect.height * 0.008f + upperItemsYShift, overlayRect.width * 0.30f, overlayRect.height * 0.10f), "PumaWild", style);
			GUI.Button(new Rect(xPos - overlayRect.width * 0.003f, overlayRect.y + overlayRect.height * 0.016f + upperItemsYShift, overlayRect.width * 0.30f, overlayRect.height * 0.10f), "PumaWild", style);
			GUI.Button(new Rect(xPos + overlayRect.width * 0.003f, overlayRect.y + overlayRect.height * 0.016f + upperItemsYShift, overlayRect.width * 0.30f, overlayRect.height * 0.10f), "PumaWild", style);
			style.normal.textColor = new Color(0.88f, 0.55f, 0f, 1f);
			GUI.Button(new Rect(xPos, overlayRect.y + overlayRect.height * 0.012f + upperItemsYShift, overlayRect.width * 0.30f, overlayRect.height * 0.10f), "PumaWild", style);
			style.fontSize = (int)(overlayRect.width * 0.0228f);
			style.normal.textColor = new Color(0.2f, 0f, 0f, 1f);
			xPos = overlayRect.x + overlayRect.width * 0.351f;
			GUI.Button(new Rect(xPos - overlayRect.width * 0.001f, overlayRect.y + overlayRect.height * 0.084f + upperItemsYShift, overlayRect.width * 0.30f, overlayRect.height * 0.05f), "survival is not a given", style);
			GUI.Button(new Rect(xPos + overlayRect.width * 0.001f, overlayRect.y + overlayRect.height * 0.084f + upperItemsYShift, overlayRect.width * 0.30f, overlayRect.height * 0.05f), "survival is not a given", style);
			GUI.Button(new Rect(xPos - overlayRect.width * 0.001f, overlayRect.y + overlayRect.height * 0.088f + upperItemsYShift, overlayRect.width * 0.30f, overlayRect.height * 0.05f), "survival is not a given", style);
			GUI.Button(new Rect(xPos + overlayRect.width * 0.001f, overlayRect.y + overlayRect.height * 0.088f + upperItemsYShift, overlayRect.width * 0.30f, overlayRect.height * 0.05f), "survival is not a given", style);
			style.normal.textColor = new Color(0.88f, 0.55f, 0f, 1f);
			GUI.Button(new Rect(xPos, overlayRect.y + overlayRect.height * 0.086f + upperItemsYShift, overlayRect.width * 0.30f, overlayRect.height * 0.05f), "survival is not a given", style);
			GUI.color = new Color(1f, 1f, 1f, 1f * infoPanelOpacity);
		}


		//=====================================
		// ADD BUTTONS
		//=====================================
		


		// buttons...
		
		if (newLevelFlag == false && currentLevel != 6) {
			// user initiated info display
		
			// background rectangle
			GUI.color = new Color(0f, 0f, 0f, 1f * infoPanelOpacity);
			GUI.Box(new Rect(overlayRect.x + overlayRect.width * 0f, overlayRect.y + overlayRect.height * 0.926f, overlayRect.width * 1f, overlayRect.height * 0.074f), "");
			GUI.color = new Color(1f, 1f, 1f, 1f * infoPanelOpacity);

			buttonStyle.fontSize = buttonDownStyle.fontSize = (int)(overlayRect.width * 0.0225);
			buttonDisabledStyle.fontSize = buttonDownStyle.fontSize = (int)(overlayRect.width * 0.0225);
			float buttonWidth = overlayRect.width * 0.11f;
			float buttonGap = overlayRect.width * 0.012f;
			float buttonMargin = overlayRect.x + overlayRect.width * 0.135f;
			float buttonY = overlayRect.y + overlayRect.height * 0.924f;
			float buttonheight = overlayRect.height * 0.075f;
			float predationExtraMargin = overlayRect.width * 0.003f;
			
			float backgroundRectWidthAdjust = (currentScreen == 4) ? buttonWidth * 0.32f : ((currentScreen == 3) ? buttonWidth * 0.03f : ((currentScreen == 2) ? buttonWidth * 0.12f : 0f));
			float shiftRight = (currentScreen == 4) ? buttonGap * 0.8f : 0f;
			if (currentScreen == 2)
				shiftRight += predationExtraMargin;
			if (currentScreen == 3 || currentScreen == 4)
				shiftRight += predationExtraMargin*2;
		
			guiUtils.DrawRect(new Rect(buttonMargin + buttonWidth*currentScreen + buttonGap*currentScreen + buttonWidth*0.05f - backgroundRectWidthAdjust*0.5f + shiftRight, buttonY + buttonheight * 0.15f, buttonWidth - buttonWidth*0.1f + backgroundRectWidthAdjust, buttonheight - buttonheight * 0.29f), new Color(0f, 0f, 0f, 0.5f));	


			buttonDownStyle.normal.textColor = new Color(0.99f, 0.7f, 0.2f, 1f);
			buttonStyle.normal.textColor = new Color(0.99f, 0.88f, 0.6f, 1f);
			

			// 'Biology'
			if (GUI.Button(new Rect(buttonMargin, buttonY, buttonWidth, buttonheight), "Biology", (currentScreen == 0) ? buttonDownStyle : buttonStyle))
				currentScreen = 0;
			// 'Ecology'
			if (GUI.Button(new Rect(buttonMargin + buttonWidth + buttonGap, buttonY, buttonWidth, buttonheight), "Ecology", (currentScreen == 1) ? buttonDownStyle : buttonStyle))
				currentScreen = 1;
			// 'Predation'
			if (GUI.Button(new Rect(buttonMargin + buttonWidth*2f + buttonGap*2f + predationExtraMargin, buttonY, buttonWidth, buttonheight), "Predation", (currentScreen == 2) ? buttonDownStyle : buttonStyle))
				currentScreen = 2;
			// 'Survival'
			if (GUI.Button(new Rect(buttonMargin + buttonWidth*3f + buttonGap*3f + predationExtraMargin*2, buttonY, buttonWidth, buttonheight), "Survival", (currentScreen == 3) ? buttonDownStyle : buttonStyle))
				currentScreen = 3;
			// 'Take Action'
			if (GUI.Button(new Rect(buttonMargin + buttonWidth*4f + buttonGap*4.8f + predationExtraMargin*2, buttonY, buttonWidth, buttonheight), "Take Action", (currentScreen == 4) ? buttonDownStyle : buttonStyle))
				currentScreen = 4;

			buttonStyle.normal.textColor = new Color(0.99f, 0.7f, 0.2f, 1f);
			buttonDownStyle.normal.textColor = new Color(0.99f, 0.88f, 0.6f, 1f);

			// green check mark for donate button
			//GUI.color = new Color(1f, 1f, 1f, 0.6f * infoPanelOpacity);
			//GUI.DrawTexture(new Rect(buttonMargin + buttonWidth*4f + buttonGap*4.8f + buttonWidth* 1.07f, buttonY + buttonheight * 0.10f, buttonWidth * 0.26f, buttonheight * 0.4f), greenCheckTexture);
			//GUI.color = new Color(1f, 1f, 1f, 1f * infoPanelOpacity);



			overlayRect.width *= 0.9f;
			
			buttonStyle.normal.textColor = new Color(0.99f, 0.88f, 0.6f, 1f);
			buttonStyle.fontSize = buttonDownStyle.fontSize = (int)(overlayRect.width * 0.032);
			buttonDisabledStyle.fontSize = buttonDownStyle.fontSize = (int)(overlayRect.width * 0.023);
			buttonWidth = overlayRect.width * 0.12f;
	
			GUI.color = new Color(1f, 1f, 1f, 1f * infoPanelOpacity);
		

		
			if (levelManager.CheckCarCollision() == false && levelManager.CheckStarvation() == false) {
		
				// normal case

				// 'close'
				bigButtonStyle.fontSize = (int)(overlayRect.width * 0.032f);;
				bigButtonDisabledStyle.fontSize = (int)(overlayRect.width * 0.03f);;
				GUI.skin = guiManager.customGUISkin;
				guiManager.customGUISkin.button.fontSize = (int)(overlayRect.width * 0.030f);
				guiManager.customGUISkin.button.fontStyle = FontStyle.Normal;
				GUI.backgroundColor = new Color(1f, 1f, 1f, 1f);
				float startButtonX = overlayRect.x + overlayRect.width * 0.055f;
				float startButtonY = overlayRect.y + overlayRect.height * 0.937f;
				float startButtonWidth = overlayRect.width * 0.08f;
				float startButtonHeight = overlayRect.height * 0.05f;
				if (GUI.Button(new Rect(startButtonX, startButtonY, startButtonWidth, startButtonHeight), "", buttonStyle)) {
					guiManager.CloseInfoPanel(true);
				}
				if (GUI.Button(new Rect(startButtonX, startButtonY, startButtonWidth, startButtonHeight), "<", buttonStyle)) {
					guiManager.CloseInfoPanel(true);
				}


				// 'play'
				// background rectangle
				startButtonX = overlayRect.x + overlayRect.width * 0.917f;
				startButtonY = overlayRect.y + overlayRect.height * 0.932f;
				startButtonWidth = overlayRect.width * 0.15f;
				startButtonHeight = overlayRect.height * 0.06f;
				GUI.color = (guiManager.selectedPuma != -1) ? new Color(1f, 1f, 1f, 1f * infoPanelOpacity) : new Color(1f, 1f, 1f, 0.5f * infoPanelOpacity);
				bigButtonStyle.fontSize = (int)(overlayRect.width * 0.032f);;
				bigButtonDisabledStyle.fontSize = (int)(overlayRect.width * 0.03f);;
				GUI.skin = guiManager.customGUISkin;
				guiManager.customGUISkin.button.fontSize = (int)(overlayRect.width * 0.0225f);
				guiManager.customGUISkin.button.fontStyle = FontStyle.Bold;
				GUI.backgroundColor = new Color(1f, 1f, 1f, 1f);
				if (guiManager.selectedPuma != -1) {
					if (GUI.Button(new Rect(startButtonX, startButtonY, startButtonWidth, startButtonHeight), "")) {
						guiManager.CloseInfoPanel(true);
						guiManager.SetGuiState("guiStateLeavingOverlay");
						levelManager.SetGameState("gameStateLeavingGui");
					}
					if (GUI.Button(new Rect(startButtonX, startButtonY, startButtonWidth, startButtonHeight), "PLAY")) {
						guiManager.CloseInfoPanel(true);
						guiManager.SetGuiState("guiStateLeavingOverlay");
						levelManager.SetGameState("gameStateLeavingGui");
					}
				}
				else {
					GUI.Button(new Rect(startButtonX, startButtonY, startButtonWidth, startButtonHeight), "PLAY", bigButtonDisabledStyle);
				}
			}
			else {
				// coming from puma done screen
			
				// 'play'
				// background rectangle
				float startButtonX = overlayRect.x + overlayRect.width * 0.917f;
				float startButtonY = overlayRect.y + overlayRect.height * 0.932f;
				float startButtonWidth = overlayRect.width * 0.15f;
				float startButtonHeight = overlayRect.height * 0.06f;
				GUI.color = (guiManager.selectedPuma != -1) ? new Color(1f, 1f, 1f, 1f * infoPanelOpacity) : new Color(1f, 1f, 1f, 0.5f * infoPanelOpacity);
				bigButtonStyle.fontSize = (int)(overlayRect.width * 0.032f);;
				bigButtonDisabledStyle.fontSize = (int)(overlayRect.width * 0.03f);;
				GUI.skin = guiManager.customGUISkin;
				guiManager.customGUISkin.button.fontSize = (int)(overlayRect.width * 0.0225f);
				guiManager.customGUISkin.button.fontStyle = FontStyle.Bold;
				GUI.backgroundColor = new Color(1f, 1f, 1f, 1f);
				if (guiManager.selectedPuma != -1) {
					if (GUI.Button(new Rect(startButtonX, startButtonY, startButtonWidth, startButtonHeight), "")) {
						guiManager.CloseInfoPanel(true);
						guiManager.SetGuiState("guiStateLeavingPumaDoneAlt");
						if (levelManager.CheckCarCollision() == true)
							levelManager.EndCarCollision();
						else if (levelManager.CheckStarvation() == true)
							levelManager.EndStarvation();		
						levelManager.SetGameState("gameStateLeavingGameplay");
					}
					if (GUI.Button(new Rect(startButtonX, startButtonY, startButtonWidth, startButtonHeight), "GO")) {
						guiManager.CloseInfoPanel(true);
						guiManager.SetGuiState("guiStateLeavingPumaDoneAlt");
						if (levelManager.CheckCarCollision() == true)
							levelManager.EndCarCollision();
						else if (levelManager.CheckStarvation() == true)
							levelManager.EndStarvation();		
						levelManager.SetGameState("gameStateLeavingGameplay");
					}
				}
			}



			overlayRect.width /= 0.9f;		
		}

		else {
		
			if (currentLevel != 6) {
				// normal case: transition screen for next level			
				infoPanelOpacity = incomingInfoPanelOpacity;
		
				// background rectangle
				GUI.color = new Color(0f, 0f, 0f, 1f * infoPanelOpacity * goButtonOpacity);
				GUI.Box(new Rect(overlayRect.x + overlayRect.width * 0.415f, overlayRect.y + overlayRect.height * 0.892f, overlayRect.width * 0.17f, overlayRect.height * 0.098f), "");
				GUI.color = new Color(1f, 1f, 1f, 1f * infoPanelOpacity * goButtonOpacity);

				GUI.color = new Color(1f, 1f, 1f, 1f * infoPanelOpacity * goButtonOpacity);		
				// 'play'
				bigButtonStyle.fontSize = (int)(overlayRect.width * 0.032);;
				bigButtonDisabledStyle.fontSize = (int)(overlayRect.width * 0.03);;
				GUI.skin = guiManager.customGUISkin;
				guiManager.customGUISkin.button.fontSize = (int)(overlayRect.width * 0.028);
				guiManager.customGUISkin.button.fontStyle = FontStyle.Normal;
				GUI.backgroundColor = new Color(1f, 1f, 1f, 1f);
				float startButtonWidth = overlayRect.width * 0.12f;
				float startButtonX = overlayRect.x + overlayRect.width/2 - startButtonWidth/2;
				float startButtonY = overlayRect.y + overlayRect.height * 0.906f;
				float startButtonHeight = overlayRect.height * 0.07f;
				if (GUI.Button(new Rect(startButtonX, startButtonY, startButtonWidth, startButtonHeight), "")) {
					guiManager.CloseInfoPanel(true);
					guiManager.SetGuiState("guiStateStartApp2");
				}
				if (GUI.Button(new Rect(startButtonX, startButtonY, startButtonWidth, startButtonHeight), "Go")) {
					guiManager.CloseInfoPanel(true);
					guiManager.SetGuiState("guiStateStartApp2");
				}
			}
			else {
				// restarting new game at first level		
				infoPanelOpacity = incomingInfoPanelOpacity;
				float rightShift = overlayRect.width * 0.35f;
				float downShift = overlayRect.height * 0.01f;
		
				// background rectangle
				GUI.color = new Color(0f, 0f, 0f, 1f * infoPanelOpacity * goButtonOpacity);
				GUI.Box(new Rect(overlayRect.x + overlayRect.width * 0.415f + rightShift, overlayRect.y + overlayRect.height * 0.895f + downShift, overlayRect.width * 0.17f, overlayRect.height * 0.098f - downShift*2), "");
				GUI.color = new Color(1f, 1f, 1f, 1f * infoPanelOpacity * goButtonOpacity);

				GUI.color = new Color(1f, 1f, 1f, 1f * infoPanelOpacity * goButtonOpacity);		
				// 'play'
				bigButtonStyle.fontSize = (int)(overlayRect.width * 0.032);;
				bigButtonDisabledStyle.fontSize = (int)(overlayRect.width * 0.03);;
				GUI.skin = guiManager.customGUISkin;
				guiManager.customGUISkin.button.fontSize = (int)(overlayRect.width * 0.019);
				guiManager.customGUISkin.button.fontStyle = FontStyle.Normal;
				GUI.backgroundColor = new Color(1f, 1f, 1f, 1f);
				float startButtonWidth = overlayRect.width * 0.12f;
				float startButtonX = overlayRect.x + overlayRect.width/2 - startButtonWidth/2 + rightShift;
				float startButtonY = overlayRect.y + overlayRect.height * 0.909f + downShift;
				float startButtonHeight = overlayRect.height * 0.07f - downShift*2;
				if (GUI.Button(new Rect(startButtonX, startButtonY, startButtonWidth, startButtonHeight), "")) {
					guiManager.CloseInfoPanel(true);
					guiManager.SetGuiState("guiStateStartApp2");
				}
				if (GUI.Button(new Rect(startButtonX, startButtonY, startButtonWidth, startButtonHeight), "Play Again")) {
					guiManager.CloseInfoPanel(true);
					guiManager.SetGuiState("guiStateStartApp2");
				}
			}
		}
		
		infoPanelOpacity = incomingInfoPanelOpacity;

		GUI.color = new Color(1f, 1f, 1f, 1f * infoPanelOpacity);
	
		if (newLevelFlag == true) {	
			DrawLevelScreen(infoPanelOpacity);
		}
		else {
			// draw selected screen
			switch (currentScreen) {
			case 0:
				DrawBiologyScreen(infoPanelOpacity);
				break;		
			case 1:
				DrawBiologyScreen(infoPanelOpacity);
				break;
			case 2:
				DrawBiologyScreen(infoPanelOpacity);
				break;
			case 3:
				DrawBiologyScreen(infoPanelOpacity);
				break;
			case 4:
				DrawDonateScreen(infoPanelOpacity);
				break;
			}
		}	
	}




	//======================================================================
	//======================================================================
	//======================================================================
	//								NEW LEVEL
	//======================================================================
	//======================================================================
	//======================================================================
	
	void DrawLevelScreen(float panelOpacity)
	{ 
		float panelX = overlayRect.x + overlayRect.width * 0.06f;
		float panelY = overlayRect.y + overlayRect.height * 0.205f;
		float panelWidth = overlayRect.width * 0.88f;
		float panelHeight = overlayRect.height * 0.63f;
		float fontScale = 0.8f;

		GUIStyle style = new GUIStyle();
		style.alignment = TextAnchor.MiddleCenter;

		// background rectangle
		GUI.color = new Color(0f, 0f, 0f, 1f * panelOpacity);
		GUI.Box(new Rect(panelX - overlayRect.width * 0.02f, panelY - overlayRect.height * 0.025f, panelWidth + overlayRect.width * 0.04f, panelHeight + overlayRect.height * 0.05f + panelHeight * 0.005f), "");
		GUI.color = new Color(0f, 0f, 0f, 0.5f * panelOpacity);
		GUI.Box(new Rect(panelX, panelY, panelWidth, panelHeight + panelHeight * 0.005f), "");
		GUI.color = new Color(1f, 1f, 1f, 1f * panelOpacity);


		// level image
		Texture2D imageTexture = levelImage1Texture;
		float imageOpacity = 1f;
		
		switch (currentLevel) {
		case 0:
			imageTexture = levelImage1Texture;
			imageOpacity = 1f;
			break;
		case 1:
			imageTexture = levelImage2Texture;
			imageOpacity = 1f;
			break;
		case 2:
			imageTexture = levelImage3Texture;
			imageOpacity = 0.9f;
			break;
		case 3:
			imageTexture = levelImage4Texture;
			imageOpacity = 1f;
			break;
		case 4:
			imageTexture = levelImage5Texture;
			imageOpacity = 0.9f;
			break;
		case 5:
			imageTexture = levelImage6Texture;
			imageOpacity = 0.9f;
			break;
		}		
		
		float textureX = panelX + panelWidth * 0.03f;
		float textureY = panelY + panelHeight * 0.1f;
		float textureHeight = panelHeight * 0.8f;
		float textureWidth = imageTexture.width * (textureHeight / imageTexture.height);
		GUI.color = new Color(1f, 1f, 1f, imageOpacity * panelOpacity);
		GUI.DrawTexture(new Rect(textureX, textureY, textureWidth, textureHeight), imageTexture);
		GUI.color = new Color(1f, 1f, 1f, 1f * panelOpacity);
		
		
		// level text
		
		string titleText1 = "empty text";
		string titleText2 = "empty text";
		string landscapeText1 = "empty text";
		string landscapeText2 = "empty text";
		string survivalText1 = "empty text";
		string survivalText2 = "empty text";
		Color labelColor = new Color(0f, 0f, 0f);
		
		switch (currentLevel) {
		case 0:
			titleText1 = "Welcome to Level 1:";
			titleText2 = "WILD NATURE";
			labelColor = new Color(0.2f, 0.7f, 0.14f);
			landscapeText1 = "Natural pristine wilderness";
			landscapeText2 = "No human activity";
			survivalText1 = "Hunt efficiently for good health";
			survivalText2 = "Hunt poorly and you die";
			break;
		case 1:
			titleText1 = "Welcome to Level 2:";
			titleText2 = "HUMAN ARRIVAL";
			labelColor = new Color(0.85f, 0.66f, 0.0f);
			landscapeText1 = "First encroachment by humans";
			landscapeText2 = "Roads with light traffic";
			survivalText1 = "Cross roads carefully to chase prey";
			survivalText2 = "If a vehicle hits you - instant death";
			break;
		case 2:
			titleText1 = "Welcome to Level 3:";
			titleText2 = "DEVELOPMENT";
			labelColor = new Color(1f, 0.5f, 0.0f);
			landscapeText1 = "Humans have altered the landscape";
			landscapeText2 = "Bigger roads with faster traffic";
			survivalText1 = "Find bridges and cross underneath";
			survivalText2 = "Be extra careful crossing roads";
			break;
		case 3:
			titleText1 = "Welcome to Level 4:";
			titleText2 = "FRAGMENTATION";
			labelColor = new Color(1f, 0.2f, 0.0f);
			landscapeText1 = "Human activity and roads everywhere";
			landscapeText2 = "Roads impassible with heavy traffic";
			survivalText1 = "Cross under AND OVER bridges";
			survivalText2 = "Stay off the roads - or instant death";
			break;
		case 4:
			titleText1 = "Welcome to Level 5:";
			titleText2 = "CONGRATULATIONS!";
			labelColor = new Color(0.14f, 0.7f, 0.14f);
			landscapeText1 = "Humans have become good neighbors";
			landscapeText2 = "CONNECTIVITY is possible again";
			survivalText1 = "Travel easily over and under roads";
			survivalText2 = "You still need to stay clear of cars";
			break;
		case 5:
			titleText1 = "You've Made It...";
			titleText2 = "The Population Has Survived!";
			labelColor = new Color(0.19f, 0.65f, 0.19f);
			landscapeText1 = "Local pumas are in good health,";
			landscapeText2 = "And living in sustainable habitat";
			survivalText1 = "For Real Pumas, the threats remain";
			survivalText2 = "There's still time...but not much...";
			break;
		}

		style.alignment = TextAnchor.MiddleLeft;
		float colorScale = 0.74f;
		float xOffset = panelWidth * -0.017f;
		float yOffset = panelHeight * 0.042f;
		
		//

		style.fontSize = (int)(overlayRect.width * 0.020f);
		style.fontStyle = FontStyle.Italic;
		style.normal.textColor = new Color(0.99f * colorScale, 0.64f * colorScale, 0.13f * colorScale, 1f);
		GUI.Button(new Rect(xOffset + panelX + panelWidth * 0.58f, yOffset + panelY + panelHeight * 0.065f, panelWidth * 0.4f, panelHeight * 0.1f), titleText1, style);
		style.normal.textColor = labelColor;
		style.fontStyle = FontStyle.Bold;
		style.fontSize = (int)(overlayRect.width * 0.025f);
		GUI.Button(new Rect(xOffset + panelX + panelWidth * 0.58f, yOffset + panelY + panelHeight * 0.145f, panelWidth * 0.4f, panelHeight * 0.1f), titleText2, style);

		//

		style.fontSize = (int)(overlayRect.width * 0.024f);
		style.fontStyle = FontStyle.BoldAndItalic;
		style.normal.textColor = new Color(0.846f, 0.537f, 0.12f, 1f);
		GUI.Button(new Rect(xOffset + panelX + panelWidth * 0.58f, yOffset + panelY + panelHeight * 0.29f, panelWidth * 0.4f, panelHeight * 0.1f), (currentLevel == 5 ? "In Game" : "Landscape"), style);
		
		style.fontSize = (int)(overlayRect.width * 0.020f);
		style.fontStyle = FontStyle.Normal;
		style.normal.textColor = new Color(0.99f * colorScale, 0.88f * colorScale, 0.66f * colorScale, 1f);
		GUI.Button(new Rect(xOffset + panelX + panelWidth * 0.6f, yOffset + panelY + panelHeight * 0.37f, panelWidth * 0.4f, panelHeight * 0.1f), landscapeText1, style);
		GUI.Button(new Rect(xOffset + panelX + panelWidth * 0.6f, yOffset + panelY + panelHeight * 0.45f, panelWidth * 0.4f, panelHeight * 0.1f), landscapeText2, style);

		//

		style.fontSize = (int)(overlayRect.width * 0.024f);
		style.fontStyle = FontStyle.BoldAndItalic;
		style.normal.textColor = (currentLevel == 5 ? (new Color(0.95f * colorScale, 0.305f * colorScale, 0.0f * colorScale, 1f)) : (new Color(0.846f, 0.537f, 0.12f, 1f)));
		GUI.Button(new Rect(xOffset + panelX + panelWidth * 0.58f, yOffset + panelY + panelHeight * 0.59f, panelWidth * 0.4f, panelHeight * 0.1f), (currentLevel == 5 ? "Real World" : "Survival"), style);

		style.fontSize = (int)(overlayRect.width * 0.020f);
		style.fontStyle = FontStyle.Normal;
		style.normal.textColor = (currentLevel != 5) ? (new Color(0.99f * colorScale, 0.88f * colorScale, 0.66f * colorScale, 1f)) : (new Color(1f * colorScale, 0.32f * colorScale, 0.0f * colorScale, 1f));
		GUI.Button(new Rect(xOffset + panelX + panelWidth * 0.6f, yOffset + panelY + panelHeight * 0.67f, panelWidth * 0.4f, panelHeight * 0.1f), survivalText1, style);
		GUI.Button(new Rect(xOffset + panelX + panelWidth * 0.6f, yOffset + panelY + panelHeight * 0.75f, panelWidth * 0.4f, panelHeight * 0.1f), survivalText2, style);

		//

		style.alignment = TextAnchor.MiddleCenter;

		
	}	



	//======================================================================
	//======================================================================
	//======================================================================
	//								BIOLOGY
	//======================================================================
	//======================================================================
	//======================================================================
	
	void DrawBiologyScreen(float panelOpacity) 
	{ 
		float panelX = overlayRect.x + overlayRect.width * 0.06f;
		float panelY = overlayRect.y + overlayRect.height * 0.205f;
		float panelWidth = overlayRect.width * 0.88f;
		float panelHeight = overlayRect.height * 0.6575f;
		float fontScale = 0.8f;

		GUIStyle style = new GUIStyle();
		style.alignment = TextAnchor.MiddleCenter;

		float yOffset = overlayRect.height * 0.022f;

		// two labels at top of panel	
		GUI.color = new Color(0f, 0f, 0f, 1f * panelOpacity);
		GUI.Box(new Rect(panelX - overlayRect.width * 0.02f, yOffset + overlayRect.y + overlayRect.height * 0.095f, overlayRect.width * 0.14f, overlayRect.height * 0.064f), "");
		GUI.color = new Color(1f, 1f, 1f, 1f * panelOpacity);
		style.fontSize = (int)(overlayRect.width * 0.021f);
		style.fontStyle = FontStyle.BoldAndItalic;
		style.normal.textColor = new Color(0.816f, 0.537f, 0.18f, 1f);
		GUI.Button(new Rect(panelX - overlayRect.width * 0.02f, yOffset + overlayRect.y + overlayRect.height * 0.077f, overlayRect.width * 0.14f, overlayRect.height * 0.1f), "In Game", style);

		GUI.color = new Color(0f, 0f, 0f, 1f * panelOpacity);
		GUI.Box(new Rect(overlayRect.x + overlayRect.width - overlayRect.width * 0.2f, yOffset + overlayRect.y + overlayRect.height * 0.095f, overlayRect.width * 0.16f, overlayRect.height * 0.064f), "");
		GUI.color = new Color(1f, 1f, 1f, 1f * panelOpacity);
		style.fontSize = (int)(overlayRect.width * 0.021f);
		style.fontStyle = FontStyle.BoldAndItalic;
		style.normal.textColor = new Color(0.816f, 0.537f, 0.18f, 1f);
		GUI.Button(new Rect(overlayRect.x + overlayRect.width - overlayRect.width * 0.2f, yOffset + overlayRect.y + overlayRect.height * 0.077f, overlayRect.width * 0.16f, overlayRect.height * 0.1f), "Real World", style);


		// background rectangles
		float gapSize = overlayRect.width * 0.02f;
		
		GUI.color = new Color(0f, 0f, 0f, 1f * panelOpacity);
		GUI.Box(new Rect(panelX - overlayRect.width * 0.02f, panelY - overlayRect.height * 0.025f, panelWidth/2 + overlayRect.width * 0.02f - gapSize/2, panelHeight + overlayRect.height * 0.05f), "");
		GUI.color = new Color(0f, 0f, 0f, 0.5f * panelOpacity);
		GUI.Box(new Rect(panelX, panelY, panelWidth/2 - overlayRect.width * 0.02f - gapSize/2, panelHeight), "");
		GUI.color = new Color(1f, 1f, 1f, 1f * panelOpacity);

		GUI.color = new Color(0f, 0f, 0f, 1f * panelOpacity);
		GUI.Box(new Rect(panelX + panelWidth/2 + gapSize/2, panelY - overlayRect.height * 0.025f, panelWidth/2 + overlayRect.width * 0.02f - gapSize/2, panelHeight + overlayRect.height * 0.05f), "");
		GUI.color = new Color(0f, 0f, 0f, 0.5f * panelOpacity);
		GUI.Box(new Rect(panelX + panelWidth/2 + overlayRect.width * 0.02f + gapSize/2, panelY, panelWidth/2 - overlayRect.width * 0.02f - gapSize/2, panelHeight), "");
		GUI.color = new Color(1f, 1f, 1f, 1f * panelOpacity);
		
		
		
		// HEADER TEXT 
		
		string headerTextL = "empty text";
		string headerTextR = "empty text";
		
		switch (currentScreen) {
		case 0:
			headerTextL = "Stealth and Speed";
			headerTextR = "Physical Characteristics";
			break;
		case 1:
			headerTextL = "Scoring System";
			headerTextR = "Ecological Role";
			break;
		case 2:
			headerTextL = "Catching Deer";
			headerTextR = "Pumas and Prey";
			break;
		case 3:
			headerTextL = "Car Avoidance";
			headerTextR = "Survival Threats";
			break;
		}
		
		yOffset = overlayRect.height * 0.12f;
		float colorScale = 0.74f;
		
		GUI.color = new Color(1f, 1f, 1f, 1f * panelOpacity);
		style.fontSize = (int)(overlayRect.width * 0.022f);
		style.fontStyle = FontStyle.Normal;
		style.normal.textColor = new Color(0.99f * colorScale, 0.88f * colorScale, 0.66f * colorScale, 1f);
		GUI.Button(new Rect(panelX, yOffset + overlayRect.y + overlayRect.height * 0.077f, panelWidth/2 - overlayRect.width * 0.02f - gapSize/2, overlayRect.height * 0.1f), headerTextL, style);

		GUI.color = new Color(1f, 1f, 1f, 1f * panelOpacity);
		style.fontSize = (int)(overlayRect.width * 0.022f);
		style.fontStyle = FontStyle.Normal;
		style.normal.textColor = new Color(0.99f * colorScale, 0.88f * colorScale, 0.66f * colorScale, 1f);
		GUI.Button(new Rect(panelX + panelWidth/2 + overlayRect.width * 0.02f + gapSize/2, yOffset + overlayRect.y + overlayRect.height * 0.077f, panelWidth/2 - overlayRect.width * 0.02f - gapSize/2, overlayRect.height * 0.1f), headerTextR, style);

		
		
	}	
	

	//======================================================================
	//======================================================================
	//======================================================================
	//								DONATE
	//======================================================================
	//======================================================================
	//======================================================================
	
	void DrawDonateScreen(float panelOpacity)
	{ 
		float panelX = overlayRect.x + overlayRect.width * 0.06f;
		float panelY = overlayRect.y + overlayRect.height * 0.205f;
		float panelWidth = overlayRect.width * 0.88f;
		float panelHeight = overlayRect.height * 0.6575f;
		float fontScale = 0.8f;

		GUIStyle style = new GUIStyle();
		style.alignment = TextAnchor.MiddleCenter;

		// background rectangle
		GUI.color = new Color(0f, 0f, 0f, 1f * panelOpacity);
		GUI.Box(new Rect(panelX - overlayRect.width * 0.02f, panelY - overlayRect.height * 0.025f, panelWidth + overlayRect.width * 0.04f, panelHeight + overlayRect.height * 0.05f), "");
		GUI.color = new Color(0f, 0f, 0f, 0.5f * panelOpacity);
		GUI.Box(new Rect(panelX, panelY, panelWidth, panelHeight), "");
		GUI.color = new Color(1f, 1f, 1f, 1f * panelOpacity);


		if (newLevelFlag == false && currentLevel != 6) {
			// label at top of panel	
			float yOffset = overlayRect.height * 0.022f;
			GUI.color = new Color(0f, 0f, 0f, 1f * panelOpacity);
			GUI.Box(new Rect(overlayRect.x + overlayRect.width - overlayRect.width * 0.2f, yOffset + overlayRect.y + overlayRect.height * 0.095f, overlayRect.width * 0.16f, overlayRect.height * 0.064f), "");
			GUI.color = new Color(1f, 1f, 1f, 1f * panelOpacity);
			style.fontSize = (int)(overlayRect.width * 0.021f);
			style.fontStyle = FontStyle.BoldAndItalic;
			style.normal.textColor = new Color(0.816f, 0.537f, 0.18f, 1f);
			GUI.Button(new Rect(overlayRect.x + overlayRect.width - overlayRect.width * 0.2f, yOffset + overlayRect.y + overlayRect.height * 0.077f, overlayRect.width * 0.16f, overlayRect.height * 0.1f), "Real World", style);
		}

		// Help Pumas
		
		// title
		style.fontStyle = FontStyle.BoldAndItalic;
		style.alignment = TextAnchor.MiddleCenter;
		style.fontSize = (int)(panelWidth * 0.026f);
		style.normal.textColor = new Color(0.85f, 0.55f, 0.03f, 1f);
		GUI.Button(new Rect(panelX, panelY + panelHeight * 0.047f, panelWidth * 1f, panelHeight * 0.093f), "Pumas in the Real World need your help", style);

		style.fontStyle = FontStyle.BoldAndItalic;
		style.alignment = TextAnchor.MiddleCenter;
		style.fontSize = (int)(panelWidth * 0.019f);
		style.normal.textColor = new Color(0.6f, 0.6f, 0.6f, 1f);
		GUI.Button(new Rect(panelX + panelWidth * 0.4f, panelY + panelHeight * 0.135f, panelWidth * 0.2f, panelHeight * 0.06f), "Help support our work to study and protect pumas and their habitats", style);

		// donate button
		guiManager.customGUISkin.button.fontSize = (int)(overlayRect.width * 0.028);
		guiManager.customGUISkin.button.fontStyle = FontStyle.BoldAndItalic;
		guiManager.customGUISkin.button.normal.textColor = new Color(0.85f, 0.1f, 0f, 1f);
		Color defaultHoverColor = guiManager.customGUISkin.button.hover.textColor;
		guiManager.customGUISkin.button.hover.textColor = new Color(0.9f, 0.12f, 0f, 1f);
		guiUtils.DrawRect(new Rect(panelX + panelWidth * 0.36f + panelHeight * 0.01f, panelY + panelHeight * 0.30f + panelHeight * 0.01f, panelWidth * 0.28f - panelHeight * 0.02f, panelHeight * 0.19f - panelHeight * 0.023f), new Color(1f, 1f, 1f, 0.15f));	
		if (GUI.Button(new Rect(panelX + panelWidth * 0.36f, panelY + panelHeight * 0.295f, panelWidth * 0.28f, panelHeight * 0.19f), "Donate Now")) {
			Application.OpenURL("http://www.felidaefund.org/donate");
		}
		guiManager.customGUISkin.button.normal.textColor = new Color(0.90f, 0.65f, 0f, 1f);
		guiManager.customGUISkin.button.hover.textColor = defaultHoverColor;


		// "learn more" section

		guiManager.customGUISkin.button.normal.textColor = new Color(0.88f, 0.55f, 0f, 1f);

		style.fontStyle = FontStyle.BoldAndItalic;
		style.alignment = TextAnchor.MiddleCenter;
		style.fontSize = (int)(panelWidth * 0.018f);
		style.normal.textColor = new Color(0.6f, 0.6f, 0.6f, 1f);
		GUI.Button(new Rect(panelX + panelWidth * 0.4f, panelY + panelHeight * 0.620f , panelWidth * 0.2f, panelHeight * 0.06f), "Get involved...", style);

		GUI.color = new Color(1f, 1f, 1f, 0.9f * panelOpacity);

		guiManager.customGUISkin.button.fontSize = (int)(overlayRect.width * 0.016);
		guiManager.customGUISkin.button.fontStyle = FontStyle.BoldAndItalic;
		if (GUI.Button(new Rect(panelX + panelWidth * 0.04f, panelY + panelHeight * 0.55f, panelWidth * 0.28f, panelHeight * 0.188f), "")) {
			Application.OpenURL("http://www.felidaefund.org");
		}
	
		guiManager.customGUISkin.button.fontSize = (int)(overlayRect.width * 0.016);
		guiManager.customGUISkin.button.fontStyle = FontStyle.BoldAndItalic;
		if (GUI.Button(new Rect(panelX + panelWidth * 0.68f, panelY + panelHeight * 0.55f, panelWidth * 0.28f, panelHeight * 0.188f), "")) {
			Application.OpenURL("http://www.bapp.org");
		}	
		
		GUI.color = new Color(1f, 1f, 1f, 1f * panelOpacity);
		guiManager.customGUISkin.button.normal.textColor = new Color(0.90f, 0.65f, 0f, 1f);

		// felidae and bapp logos
		float textureHeight = panelHeight * 0.14f;
		float textureWidth = logoFelidaeTexture.width * (textureHeight / logoFelidaeTexture.height);
		float textureX = panelX + panelWidth * 0.058f;
		float textureY = panelY + panelHeight * 0.57f;
		GUI.color = new Color(1f, 1f, 1f, 0.7f * panelOpacity);
		GUI.DrawTexture(new Rect(textureX, textureY, textureWidth, textureHeight), logoFelidaeTexture);
		GUI.color = new Color(1f, 1f, 1f, 1f * panelOpacity);

		textureHeight = panelHeight * 0.158f;
		textureWidth = logoBappTexture.width * (textureHeight / logoBappTexture.height);
		textureX = panelX + panelWidth * 0.74f;
		textureY = panelY + panelHeight * 0.57f;
		GUI.color = new Color(1f, 1f, 1f, 0.6f * panelOpacity);
		GUI.DrawTexture(new Rect(textureX, textureY, textureWidth, textureHeight), logoBappTexture);
		GUI.color = new Color(1f, 1f, 1f, 1f * panelOpacity);


		GUI.color = new Color(1f, 1f, 1f, 0.7f * panelOpacity);
		// facebook
		textureHeight = panelHeight * 0.055f;
		textureWidth = iconFacebookTexture.width * (textureHeight / iconFacebookTexture.height);
		textureX = panelX + panelWidth * 0.333f;
		textureY = panelY + panelHeight * 0.825f;
		if (GUI.Button(new Rect(textureX, textureY, textureWidth, textureHeight), "")) {
			Application.OpenURL("http://www.facebook.com/felidaefund");
		}	
		GUI.DrawTexture(new Rect(textureX, textureY, textureWidth, textureHeight), iconFacebookTexture);
		// twitter
		textureWidth = iconTwitterTexture.width * (textureHeight / iconTwitterTexture.height);
		textureX += panelWidth * 0.06f;
		if (GUI.Button(new Rect(textureX, textureY, textureWidth, textureHeight), "")) {
			Application.OpenURL("http://www.twitter.com/felidaefund");
		}	
		GUI.DrawTexture(new Rect(textureX, textureY, textureWidth, textureHeight), iconTwitterTexture);
		// google
		textureWidth = iconGoogleTexture.width * (textureHeight / iconGoogleTexture.height);
		textureX += panelWidth * 0.06f;
		if (GUI.Button(new Rect(textureX, textureY, textureWidth, textureHeight), "")) {
			Application.OpenURL("http://plus.google.com/u/0/118124929806137459330/posts");
		}	
		GUI.DrawTexture(new Rect(textureX, textureY, textureWidth, textureHeight), iconGoogleTexture);
		// pinterest
		textureWidth = iconPinterestTexture.width * (textureHeight / iconPinterestTexture.height);
		textureX += panelWidth * 0.06f;
		if (GUI.Button(new Rect(textureX, textureY, textureWidth, textureHeight), "")) {
			Application.OpenURL("http://www.pinterest.com/felidaefund");
		}	
		GUI.DrawTexture(new Rect(textureX, textureY, textureWidth, textureHeight), iconPinterestTexture);
		// youtube
		textureWidth = iconYouTubeTexture.width * (textureHeight / iconYouTubeTexture.height);
		textureX += panelWidth * 0.06f;
		if (GUI.Button(new Rect(textureX, textureY, textureWidth, textureHeight), "")) {
			Application.OpenURL("http://www.youtube.com/felidaefund");
		}	
		GUI.DrawTexture(new Rect(textureX, textureY, textureWidth, textureHeight), iconYouTubeTexture);
		// linkedin
		textureWidth = iconLinkedInTexture.width * (textureHeight / iconLinkedInTexture.height);
		textureX += panelWidth * 0.06f;
		if (GUI.Button(new Rect(textureX, textureY, textureWidth, textureHeight), "")) {
			Application.OpenURL("http://www.linkedin.com/groups/Felidae-Conservation-Fund-1108927?gid=1108927&trk=hb_side_g");
		}	
		GUI.DrawTexture(new Rect(textureX, textureY, textureWidth, textureHeight), iconLinkedInTexture);
		GUI.color = new Color(1f, 1f, 1f, 1f * panelOpacity);
	}	
}






/*



using UnityEngine;
using System.Collections;

/// InfoPanel
/// Popup panel for scientific and conservation info

public class InfoPanel : MonoBehaviour
{
	//===================================
	//===================================
	//		MODULE VARIABLES
	//===================================
	//===================================

	private int infoPanelPage;
	private bool infoPanelIntroFlag;
	private Rect overlayRect;
	
	// textures based on bitmap files
	private Texture2D buckHeadTexture;
	private Texture2D doeHeadTexture;
	private Texture2D fawnHeadTexture;
	private Texture2D forestTexture; 
	private Texture2D closeup1Texture;
	private Texture2D closeup2Texture;
	private Texture2D closeup3Texture;
	private Texture2D closeup4Texture;
	private Texture2D closeup5Texture;
	private Texture2D closeup6Texture;
	private Texture2D closeupBackgroundTexture;
	private Texture2D iconFacebookTexture; 
	private Texture2D iconTwitterTexture; 
	private Texture2D iconGoogleTexture; 
	private Texture2D iconPinterestTexture; 
	private Texture2D iconYouTubeTexture; 
	private Texture2D iconLinkedInTexture; 

	// external modules
	private GuiManager guiManager;
	//private GuiComponents guiComponents;
	private GuiUtils guiUtils;
	//private LevelManager levelManager;
	//private ScoringSystem scoringSystem;

	//===================================
	//===================================
	//		INITIALIZATION
	//===================================
	//===================================

	void Start() 
	{	
		// connect to external modules
		guiManager = GetComponent<GuiManager>();
		//guiComponents = GetComponent<GuiComponents>();
		guiUtils = GetComponent<GuiUtils>();
		//levelManager = GetComponent<LevelManager>();
		//scoringSystem = GetComponent<ScoringSystem>();

		// texture references from GuiManager
		buckHeadTexture = guiManager.buckHeadTexture;
		doeHeadTexture = guiManager.doeHeadTexture;
		fawnHeadTexture = guiManager.fawnHeadTexture;
		forestTexture = guiManager.forestTexture;
		closeup1Texture = guiManager.closeup1Texture;
		closeup2Texture = guiManager.closeup2Texture;
		closeup3Texture = guiManager.closeup3Texture;
		closeup4Texture = guiManager.closeup4Texture;
		closeup5Texture = guiManager.closeup5Texture;
		closeup6Texture = guiManager.closeup6Texture;
		closeupBackgroundTexture = guiManager.closeupBackgroundTexture;
		iconFacebookTexture = guiManager.iconFacebookTexture;
		iconTwitterTexture = guiManager.iconTwitterTexture;
		iconGoogleTexture = guiManager.iconGoogleTexture;
		iconPinterestTexture = guiManager.iconPinterestTexture;
		iconYouTubeTexture = guiManager.iconYouTubeTexture;
		iconLinkedInTexture = guiManager.iconLinkedInTexture;
		
		// additional initialization
		infoPanelPage = 0;
		infoPanelIntroFlag = true;
	}
	
	//===================================
	//===================================
	//		UTILITY FUNCTIONS
	//===================================
	//===================================

	public int GetCurrentPage()
	{
		return infoPanelPage;
	}
	
	public void SetCurrentPage(int newPageNum)
	{
		infoPanelPage = newPageNum;
	}
	
	public void ClearIntroFlag()
	{
		infoPanelIntroFlag = false;
	}
	
	//===================================
	//===================================
	//		DRAW THE INFO PANEL
	//===================================
	//===================================

	public void Draw(float infoPanelOpacity) 
	{ 
		overlayRect = guiManager.GetOverlayRect();
	
		GUIStyle style = new GUIStyle();

		float infoPanelX = Screen.width * 0.5f - Screen.height * 0.75f;
		float infoPanelWidth = Screen.height * 1.5f;
		float infoPanelY = Screen.height * 0.025f;
		float infoPanelHeight = Screen.height * 0.95f;

		float popupInnerRectX = infoPanelX + infoPanelWidth * 0.01f;
		float popupInnerRectY = infoPanelY + infoPanelWidth * 0.01f;
		float popupInnerRectWidth = infoPanelWidth - infoPanelWidth * 0.02f;
		float popupInnerRectHeight = infoPanelHeight - infoPanelWidth * 0.02f;

		//backdrop
		GUI.color = new Color(1f, 1f, 1f, 1f * infoPanelOpacity);
		GUI.Box(new Rect(infoPanelX, infoPanelY, infoPanelWidth, infoPanelHeight), "");
		//guiUtils.DrawRect(new Rect(infoPanelX + infoPanelWidth * 0.01f, infoPanelY + infoPanelWidth * 0.01f, infoPanelWidth * 0.98f, infoPanelHeight - infoPanelWidth * 0.02f), new Color(0.22f, 0.21f, 0.20f, 1f));	
		guiUtils.DrawRect(new Rect(popupInnerRectX, popupInnerRectY, popupInnerRectWidth, popupInnerRectHeight * 0.07f), new Color(0.205f, 0.21f, 0.19f, 1f));	
		guiUtils.DrawRect(new Rect(popupInnerRectX, popupInnerRectY + popupInnerRectHeight * 0.11f, popupInnerRectWidth, popupInnerRectHeight - popupInnerRectHeight * 0.11f - popupInnerRectHeight * 0.09f), new Color(0.205f, 0.21f, 0.19f, 1f));	
				
				
		// main title & page contents
		
		float textureX;
		float textureY;
		float textureHeight;
		float textureWidth;
		
		string titleString = "not specified";
		switch (infoPanelPage) {

		case 0:
			titleString = "";
			// chapter title
			style.fontStyle = FontStyle.BoldAndItalic;
			style.alignment = TextAnchor.MiddleCenter;
			style.fontSize = (int)(popupInnerRectWidth * 0.024f);
			style.normal.textColor = new Color(0.88f, 0.55f, 0f, 1f);
			style.normal.textColor = new Color(0.65f, 0.60f, 0.50f, 1f);
			GUI.Button(new Rect(popupInnerRectX, popupInnerRectY + popupInnerRectHeight * 0.13f, popupInnerRectWidth, popupInnerRectHeight * 0.093f), "Chapter 1: Natural Wilderness", style);
			// left side text
			popupInnerRectY -= popupInnerRectWidth * 0.01f;
			style.fontStyle = FontStyle.BoldAndItalic;
			style.alignment = TextAnchor.MiddleCenter;
			style.fontSize = (int)(popupInnerRectWidth * 0.023f);
			style.normal.textColor = new Color(0.99f, 0.66f, 0f, 1f);
			GUI.Button(new Rect(popupInnerRectX + popupInnerRectWidth * 0.015f, popupInnerRectY + popupInnerRectHeight * 0.24f, popupInnerRectWidth * 0.5f, popupInnerRectHeight * 0.093f), "A Regional Population of Pumas", style);
			style.fontStyle = FontStyle.BoldAndItalic;
			style.alignment = TextAnchor.MiddleCenter;
			style.fontSize = (int)(popupInnerRectWidth * 0.017f);
			style.normal.textColor = new Color(0.65f * 1.05f, 0.60f * 1.05f, 0.50f * 1.05f, 1f);
			GUI.Button(new Rect(popupInnerRectX + popupInnerRectWidth * 0.015f, popupInnerRectY + popupInnerRectHeight * 0.28f, popupInnerRectWidth * 0.5f, popupInnerRectHeight * 0.093f), "6 pumas with varying strengths and skills", style);
			// right side text
			style.fontStyle = FontStyle.BoldAndItalic;
			style.alignment = TextAnchor.MiddleCenter;
			style.fontSize = (int)(popupInnerRectWidth * 0.023f);
			style.normal.textColor = new Color(0.99f, 0.66f, 0f, 1f);
			GUI.Button(new Rect(popupInnerRectX + popupInnerRectWidth * 0.49f, popupInnerRectY + popupInnerRectHeight * 0.24f, popupInnerRectWidth * 0.5f, popupInnerRectHeight * 0.093f), "A Pristine Natural Environment", style);
			style.fontStyle = FontStyle.BoldAndItalic;
			style.alignment = TextAnchor.MiddleCenter;
			style.fontSize = (int)(popupInnerRectWidth * 0.017f);
			style.normal.textColor = new Color(0.65f * 1.05f, 0.60f * 1.05f, 0.50f * 1.05f, 1f);
			GUI.Button(new Rect(popupInnerRectX + popupInnerRectWidth * 0.49f, popupInnerRectY + popupInnerRectHeight * 0.28f, popupInnerRectWidth * 0.5f, popupInnerRectHeight * 0.093f), "Catch prey efficiently to survive and thrive", style);	
			// puma heads
			GUI.color = new Color(1f, 1f, 1f, 0.4f * infoPanelOpacity);
			textureX = popupInnerRectX + popupInnerRectWidth * 0.052f;
			textureY = popupInnerRectY + popupInnerRectHeight * 0.32f;
			textureHeight = popupInnerRectHeight * 0.55f;
			textureWidth = forestTexture.width * (textureHeight / forestTexture.height);
			GUI.DrawTexture(new Rect(textureX, textureY, textureWidth, textureHeight), forestTexture);
			GUI.color = new Color(1f, 1f, 1f, 1f * infoPanelOpacity);
			textureX = popupInnerRectX + popupInnerRectWidth * 0.08f;
			textureY = popupInnerRectY + popupInnerRectHeight * 0.38f;
			textureHeight = popupInnerRectHeight * 0.15f;
			textureWidth = closeup1Texture.width * (textureHeight / closeup1Texture.height);
			GUI.DrawTexture(new Rect(textureX, textureY, textureWidth, textureHeight), closeup1Texture);
			textureX = popupInnerRectX + popupInnerRectWidth * 0.08f;
			textureY = popupInnerRectY + popupInnerRectHeight * 0.56f;
			textureHeight = popupInnerRectHeight * 0.15f;
			textureWidth = closeup2Texture.width * (textureHeight / closeup2Texture.height);
			GUI.DrawTexture(new Rect(textureX, textureY, textureWidth, textureHeight), closeup2Texture);
			textureX = popupInnerRectX + popupInnerRectWidth * 0.20f;
			textureY = popupInnerRectY + popupInnerRectHeight * 0.38f;
			textureHeight = popupInnerRectHeight * 0.15f;
			textureWidth = closeup3Texture.width * (textureHeight / closeup3Texture.height);
			GUI.DrawTexture(new Rect(textureX, textureY, textureWidth, textureHeight), closeup3Texture);
			textureX = popupInnerRectX + popupInnerRectWidth * 0.20f;
			textureY = popupInnerRectY + popupInnerRectHeight * 0.56f;
			textureHeight = popupInnerRectHeight * 0.15f;
			textureWidth = closeup4Texture.width * (textureHeight / closeup4Texture.height);
			GUI.DrawTexture(new Rect(textureX, textureY, textureWidth, textureHeight), closeup4Texture);
			textureX = popupInnerRectX + popupInnerRectWidth * 0.32f;
			textureY = popupInnerRectY + popupInnerRectHeight * 0.38f;
			textureHeight = popupInnerRectHeight * 0.15f;
			textureWidth = closeup5Texture.width * (textureHeight / closeup5Texture.height);
			GUI.DrawTexture(new Rect(textureX, textureY, textureWidth, textureHeight), closeup5Texture);
			textureX = popupInnerRectX + popupInnerRectWidth * 0.32f;
			textureY = popupInnerRectY + popupInnerRectHeight * 0.56f;
			textureHeight = popupInnerRectHeight * 0.15f;
			textureWidth = closeup6Texture.width * (textureHeight / closeup6Texture.height);
			GUI.DrawTexture(new Rect(textureX, textureY, textureWidth, textureHeight), closeup6Texture);
			// deer heads
			GUI.color = new Color(1f, 1f, 1f, 0.4f * infoPanelOpacity);
			textureX = popupInnerRectX + popupInnerRectWidth * 0.53f;
			textureY = popupInnerRectY + popupInnerRectHeight * 0.32f;
			textureHeight = popupInnerRectHeight * 0.55f;
			textureWidth = forestTexture.width * (textureHeight / forestTexture.height);
			GUI.DrawTexture(new Rect(textureX, textureY, textureWidth, textureHeight), forestTexture);
			GUI.color = new Color(1f, 1f, 1f, 1f * infoPanelOpacity);
			textureX = popupInnerRectX + popupInnerRectWidth * 0.56f;
			textureY = popupInnerRectY + popupInnerRectHeight * 0.39f;
			textureHeight = popupInnerRectHeight * 0.28f;
			textureWidth = buckHeadTexture.width * (textureHeight / buckHeadTexture.height);
			GUI.DrawTexture(new Rect(textureX, textureY, textureWidth, textureHeight), buckHeadTexture);
			textureX = popupInnerRectX + popupInnerRectWidth * 0.70f;
			textureY = popupInnerRectY + popupInnerRectHeight * 0.35f;
			textureHeight = popupInnerRectHeight * 0.24f;
			textureWidth = doeHeadTexture.width * (textureHeight / doeHeadTexture.height);
			GUI.DrawTexture(new Rect(textureX, textureY, textureWidth, textureHeight), doeHeadTexture);
			textureX = popupInnerRectX + popupInnerRectWidth * 0.80f;
			textureY = popupInnerRectY + popupInnerRectHeight * 0.45f;
			textureHeight = popupInnerRectHeight * 0.22f;
			textureWidth = fawnHeadTexture.width * (textureHeight / fawnHeadTexture.height);
			GUI.DrawTexture(new Rect(textureX, textureY, textureWidth, textureHeight), fawnHeadTexture);
			popupInnerRectY += popupInnerRectWidth * 0.01f;
			// logo
			float xPos = popupInnerRectX;
			float yPos = popupInnerRectY + popupInnerRectHeight * -0.0225f;
			style.fontSize = (int)(overlayRect.width * 0.04f);
			style.fontStyle = FontStyle.BoldAndItalic;
			style.alignment = TextAnchor.MiddleCenter;
			style.normal.textColor = new Color(0.2f, 0f, 0f, 1f);
			GUI.Button(new Rect(xPos - overlayRect.width * 0.003f, yPos + overlayRect.height * 0.008f, popupInnerRectWidth, overlayRect.height * 0.10f), "PumaWild", style);
			GUI.Button(new Rect(xPos + overlayRect.width * 0.003f, yPos + overlayRect.height * 0.008f, popupInnerRectWidth, overlayRect.height * 0.10f), "PumaWild", style);
			GUI.Button(new Rect(xPos - overlayRect.width * 0.003f, yPos + overlayRect.height * 0.016f, popupInnerRectWidth, overlayRect.height * 0.10f), "PumaWild", style);
			GUI.Button(new Rect(xPos + overlayRect.width * 0.003f, yPos + overlayRect.height * 0.016f, popupInnerRectWidth, overlayRect.height * 0.10f), "PumaWild", style);
			style.normal.textColor = new Color(0.88f, 0.55f, 0f, 1f);
			GUI.Button(new Rect(xPos, yPos + overlayRect.height * 0.012f, popupInnerRectWidth, overlayRect.height * 0.10f), "PumaWild", style);
			style.fontSize = (int)(overlayRect.width * 0.0245f);
			style.normal.textColor = new Color(0.2f, 0f, 0f, 1f);
			xPos = popupInnerRectX;
			yPos = popupInnerRectY + popupInnerRectHeight * 0.715f;
			//GUI.Button(new Rect(xPos - overlayRect.width * 0.001f, yPos + overlayRect.height * 0.084f, popupInnerRectWidth, overlayRect.height * 0.05f), "Survival is Not a Given...", style);
			//GUI.Button(new Rect(xPos + overlayRect.width * 0.001f, yPos + overlayRect.height * 0.084f, popupInnerRectWidth, overlayRect.height * 0.05f), "Survival is Not a Given...", style);
			//GUI.Button(new Rect(xPos - overlayRect.width * 0.001f, yPos + overlayRect.height * 0.088f, popupInnerRectWidth, overlayRect.height * 0.05f), "Survival is Not a Given...", style);
			//GUI.Button(new Rect(xPos + overlayRect.width * 0.001f, yPos + overlayRect.height * 0.088f, popupInnerRectWidth, overlayRect.height * 0.05f), "Survival is Not a Given...", style);
			style.normal.textColor = new Color(0.88f, 0.55f, 0f, 1f);
			GUI.Button(new Rect(xPos, yPos + overlayRect.height * 0.086f, popupInnerRectWidth, overlayRect.height * 0.05f), "Survival is not a given...", style);
			GUI.color = new Color(1f, 1f, 1f, 1f * infoPanelOpacity);
			break;

		case 1:
			titleString = "Puma Biology";
			break;
			
		case 2:
			titleString = "Puma Ecology";
			break;
			
		case 3:
			titleString = "Catching Prey";
			break;
			
		case 4:
			titleString = "Survival Threats";
			break;
			
		case 5:
			titleString = "Help Pumas";
			break;
		}

		style.fontStyle = FontStyle.BoldAndItalic;
		style.alignment = TextAnchor.MiddleCenter;
		style.fontSize = (int)(popupInnerRectWidth * 0.03f);
		style.normal.textColor = new Color(0.88f, 0.55f, 0f, 1f);
		GUI.Button(new Rect(popupInnerRectX, popupInnerRectY, popupInnerRectWidth, popupInnerRectHeight * 0.07f), titleString, style);

		///////////////////
		// buttons
		///////////////////

		float buttonSideGap = popupInnerRectWidth * 0.005f;
		float buttonGap = popupInnerRectWidth * 0.02f;
		float buttonBorderWidth = popupInnerRectWidth * 0.005f;
		float buttonX = popupInnerRectX + buttonSideGap;
		float buttonY = popupInnerRectY + popupInnerRectHeight * 0.935f;
		float buttonWidth = (popupInnerRectWidth - buttonGap * 6 - buttonSideGap * 2) / 7;
		float buttonHeight = overlayRect.height * 0.06f;

		if (infoPanelIntroFlag == false) {
		
			// DRAW SELECT BUTTONS AT BOTTOM
		
			guiManager.customGUISkin.button.fontSize = (int)(overlayRect.width * 0.0196);
		
			// introduction
			
			GUI.color = new Color(1f, 1f, 1f, 0.15f * infoPanelOpacity);
			if (infoPanelPage != 0)
				guiUtils.DrawRect(new Rect(buttonX - buttonBorderWidth, buttonY - buttonBorderWidth, buttonWidth + buttonBorderWidth * 2f, buttonHeight + buttonBorderWidth * 2f), new Color(1f, 1f, 1f, 1f));	
			GUI.skin = guiManager.customGUISkin;
			guiManager.customGUISkin.button.fontStyle = FontStyle.BoldAndItalic;
			GUI.color = new Color(1f, 1f, 1f, 1f * infoPanelOpacity);
			GUI.backgroundColor = new Color(1f, 1f, 1f, 1f);
			if (infoPanelPage != 0)
				guiManager.customGUISkin.button.normal.textColor = new Color(0.7f, 0.7f, 0.7f, 1f);
			else
				guiManager.customGUISkin.button.normal.textColor = new Color(0.88f, 0.55f, 0f, 1f);
			if (GUI.Button(new Rect(buttonX, buttonY, buttonWidth, buttonHeight), "")) {
				infoPanelPage = 0;
			}
			if (GUI.Button(new Rect(buttonX, buttonY, buttonWidth, buttonHeight), "Overview")) {
				infoPanelPage = 0;
			}
			GUI.color = new Color(1f, 1f, 1f, 1f * infoPanelOpacity);
			guiManager.customGUISkin.button.normal.textColor = new Color(0.90f, 0.65f, 0f, 1f);

			// puma biology
			
			buttonX += buttonWidth + buttonGap;
			
			GUI.color = new Color(1f, 1f, 1f, 0.15f * infoPanelOpacity);
			if (infoPanelPage != 1)
				guiUtils.DrawRect(new Rect(buttonX - buttonBorderWidth, buttonY - buttonBorderWidth, buttonWidth + buttonBorderWidth * 2f, buttonHeight + buttonBorderWidth * 2f), new Color(1f, 1f, 1f, 1f));	
			GUI.skin = guiManager.customGUISkin;
			guiManager.customGUISkin.button.fontStyle = FontStyle.BoldAndItalic;
			GUI.color = new Color(1f, 1f, 1f, 1f * infoPanelOpacity);
			GUI.backgroundColor = new Color(1f, 1f, 1f, 1f);
			if (infoPanelPage != 1)
				guiManager.customGUISkin.button.normal.textColor = new Color(0.7f, 0.7f, 0.7f, 1f);
			else
				guiManager.customGUISkin.button.normal.textColor = new Color(0.88f, 0.55f, 0f, 1f);
			if (GUI.Button(new Rect(buttonX, buttonY, buttonWidth, buttonHeight), "")) {
				infoPanelPage = 1;
			}
			if (GUI.Button(new Rect(buttonX, buttonY, buttonWidth, buttonHeight), "Biology")) {
				infoPanelPage = 1;
			}
			GUI.color = new Color(1f, 1f, 1f, 1f * infoPanelOpacity);
			guiManager.customGUISkin.button.normal.textColor = new Color(0.90f, 0.65f, 0f, 1f);

			// puma ecology
			
			buttonX += buttonWidth + buttonGap;
			
			GUI.color = new Color(1f, 1f, 1f, 0.15f * infoPanelOpacity);
			if (infoPanelPage != 2)
				guiUtils.DrawRect(new Rect(buttonX - buttonBorderWidth, buttonY - buttonBorderWidth, buttonWidth + buttonBorderWidth * 2f, buttonHeight + buttonBorderWidth * 2f), new Color(1f, 1f, 1f, 1f));	
			GUI.skin = guiManager.customGUISkin;
			guiManager.customGUISkin.button.fontStyle = FontStyle.BoldAndItalic;
			GUI.color = new Color(1f, 1f, 1f, 1f * infoPanelOpacity);
			GUI.backgroundColor = new Color(1f, 1f, 1f, 1f);
			if (infoPanelPage != 2)
				guiManager.customGUISkin.button.normal.textColor = new Color(0.7f, 0.7f, 0.7f, 1f);
			else
				guiManager.customGUISkin.button.normal.textColor = new Color(0.88f, 0.55f, 0f, 1f);
			if (GUI.Button(new Rect(buttonX, buttonY, buttonWidth, buttonHeight), "")) {
				infoPanelPage = 2;
			}
			if (GUI.Button(new Rect(buttonX, buttonY, buttonWidth, buttonHeight), "Ecology")) {
				infoPanelPage = 2;
			}
			GUI.color = new Color(1f, 1f, 1f, 1f * infoPanelOpacity);
			guiManager.customGUISkin.button.normal.textColor = new Color(0.90f, 0.65f, 0f, 1f);

			// catching prey
			
			buttonX += buttonWidth + buttonGap;
			
			GUI.color = new Color(1f, 1f, 1f, 0.15f * infoPanelOpacity);
			if (infoPanelPage != 3)
				guiUtils.DrawRect(new Rect(buttonX - buttonBorderWidth, buttonY - buttonBorderWidth, buttonWidth + buttonBorderWidth * 2f, buttonHeight + buttonBorderWidth * 2f), new Color(1f, 1f, 1f, 1f));	
			GUI.skin = guiManager.customGUISkin;
			guiManager.customGUISkin.button.fontStyle = FontStyle.BoldAndItalic;
			GUI.color = new Color(1f, 1f, 1f, 1f * infoPanelOpacity);
			GUI.backgroundColor = new Color(1f, 1f, 1f, 1f);
			if (infoPanelPage != 3)
				guiManager.customGUISkin.button.normal.textColor = new Color(0.7f, 0.7f, 0.7f, 1f);
			else
				guiManager.customGUISkin.button.normal.textColor = new Color(0.88f, 0.55f, 0f, 1f);
			if (GUI.Button(new Rect(buttonX, buttonY, buttonWidth, buttonHeight), "")) {
				infoPanelPage = 3;
			}
			if (GUI.Button(new Rect(buttonX, buttonY, buttonWidth, buttonHeight), "Predation")) {
				infoPanelPage = 3;
			}
			GUI.color = new Color(1f, 1f, 1f, 1f * infoPanelOpacity);
			guiManager.customGUISkin.button.normal.textColor = new Color(0.90f, 0.65f, 0f, 1f);

			// survival threats
			
			buttonX += buttonWidth + buttonGap;
			
			GUI.color = new Color(1f, 1f, 1f, 0.15f * infoPanelOpacity);
			if (infoPanelPage != 4)
				guiUtils.DrawRect(new Rect(buttonX - buttonBorderWidth, buttonY - buttonBorderWidth, buttonWidth + buttonBorderWidth * 2f, buttonHeight + buttonBorderWidth * 2f), new Color(1f, 1f, 1f, 1f));	
			GUI.skin = guiManager.customGUISkin;
			guiManager.customGUISkin.button.fontStyle = FontStyle.BoldAndItalic;
			GUI.color = new Color(1f, 1f, 1f, 1f * infoPanelOpacity);
			GUI.backgroundColor = new Color(1f, 1f, 1f, 1f);
			if (infoPanelPage != 4)
				guiManager.customGUISkin.button.normal.textColor = new Color(0.7f, 0.7f, 0.7f, 1f);
			else
				guiManager.customGUISkin.button.normal.textColor = new Color(0.88f, 0.55f, 0f, 1f);
			if (GUI.Button(new Rect(buttonX, buttonY, buttonWidth, buttonHeight), "")) {
				infoPanelPage = 4;
			}
			if (GUI.Button(new Rect(buttonX, buttonY, buttonWidth, buttonHeight), "Mortality")) {
				infoPanelPage = 4;
			}
			GUI.color = new Color(1f, 1f, 1f, 1f * infoPanelOpacity);
			guiManager.customGUISkin.button.normal.textColor = new Color(0.90f, 0.65f, 0f, 1f);

			// help pumas
			
			buttonX += buttonWidth + buttonGap;
			
			GUI.color = new Color(1f, 1f, 1f, 0.15f * infoPanelOpacity);
			if (infoPanelPage != 5)
				guiUtils.DrawRect(new Rect(buttonX - buttonBorderWidth, buttonY - buttonBorderWidth, buttonWidth + buttonBorderWidth * 2f, buttonHeight + buttonBorderWidth * 2f), new Color(1f, 1f, 1f, 1f));	
			GUI.skin = guiManager.customGUISkin;
			guiManager.customGUISkin.button.fontStyle = FontStyle.BoldAndItalic;
			GUI.color = new Color(1f, 1f, 1f, 1f * infoPanelOpacity);
			GUI.backgroundColor = new Color(1f, 1f, 1f, 1f);
			if (infoPanelPage != 5)
				guiManager.customGUISkin.button.normal.textColor = new Color(0.7f, 0.7f, 0.7f, 1f);
			else
				guiManager.customGUISkin.button.normal.textColor = new Color(0.88f, 0.55f, 0f, 1f);
			if (GUI.Button(new Rect(buttonX, buttonY, buttonWidth, buttonHeight), "")) {
				infoPanelPage = 5;
			}
			if (GUI.Button(new Rect(buttonX, buttonY, buttonWidth, buttonHeight), "How to Help")) {
				infoPanelPage = 5;
			}
			GUI.color = new Color(1f, 1f, 1f, 1f * infoPanelOpacity);
			guiManager.customGUISkin.button.normal.textColor = new Color(0.90f, 0.65f, 0f, 1f);
			
			// DONE
			
			buttonX += buttonWidth + buttonGap;
			
			GUI.color = new Color(1f, 1f, 1f, 0.15f * infoPanelOpacity);
			if (infoPanelPage != 6)
				guiUtils.DrawRect(new Rect(buttonX - buttonBorderWidth, buttonY - buttonBorderWidth, buttonWidth + buttonBorderWidth * 2f, buttonHeight + buttonBorderWidth * 2f), new Color(1f, 1f, 1f, 1f));	
			GUI.skin = guiManager.customGUISkin;
			guiManager.customGUISkin.button.fontStyle = FontStyle.BoldAndItalic;
			GUI.color = new Color(1f, 1f, 1f, 1f * infoPanelOpacity);
			GUI.backgroundColor = new Color(1f, 1f, 1f, 1f);
			if (infoPanelPage != 6)
				guiManager.customGUISkin.button.normal.textColor = new Color(0.7f, 0.7f, 0.7f, 1f);
			else
				guiManager.customGUISkin.button.normal.textColor = new Color(0.88f, 0.55f, 0f, 1f);
			if (GUI.Button(new Rect(buttonX, buttonY, buttonWidth, buttonHeight), "")) {
				guiManager.CloseInfoPanel(true);
			}
			if (GUI.Button(new Rect(buttonX, buttonY, buttonWidth, buttonHeight), "CLOSE   X")) {
				guiManager.CloseInfoPanel(true);
			}
			GUI.color = new Color(1f, 1f, 1f, 1f * infoPanelOpacity);
			guiManager.customGUISkin.button.normal.textColor = new Color(0.90f, 0.65f, 0f, 1f);
			
		}
		else {
		
			// DRAW 'OK' BUTTON FOR WELCOME SCREEN
			
			buttonY -= buttonHeight * 0.15f;
			buttonHeight *= 1.3f;

			buttonWidth *= 1.2f;
			buttonX = popupInnerRectX + popupInnerRectWidth * 0.5f - buttonWidth * 0.5f;

			GUI.color = new Color(1f, 1f, 1f, 0.15f * infoPanelOpacity);
			if (infoPanelPage != 0)
				guiUtils.DrawRect(new Rect(buttonX - buttonBorderWidth, buttonY - buttonBorderWidth, buttonWidth + buttonBorderWidth * 2f, buttonHeight + buttonBorderWidth * 2f), new Color(1f, 1f, 1f, 1f));	
			GUI.skin = guiManager.customGUISkin;
			guiManager.customGUISkin.button.fontSize = (int)(overlayRect.width * 0.026);
			guiManager.customGUISkin.button.fontStyle = FontStyle.BoldAndItalic;
			GUI.color = new Color(1f, 1f, 1f, 1f * infoPanelOpacity);
			GUI.backgroundColor = new Color(1f, 1f, 1f, 1f);
			if (GUI.Button(new Rect(buttonX, buttonY, buttonWidth, buttonHeight), "")) {
				guiManager.CloseInfoPanel(true);
				guiManager.SetGuiState("guiStateStartApp2");
			}
			if (GUI.Button(new Rect(buttonX, buttonY, buttonWidth, buttonHeight), "GO")) {
				guiManager.CloseInfoPanel(true);
				guiManager.SetGuiState("guiStateStartApp2");
			}
			GUI.color = new Color(1f, 1f, 1f, 1f * infoPanelOpacity);
		}
		
		
		if (infoPanelIntroFlag == true || infoPanelPage == 0) {
		
		
		
		}
		else if (infoPanelPage != 5) {
		
			// vertical divider
			//guiUtils.DrawRect(new Rect(popupInnerRectX + popupInnerRectWidth * 0.4965f, popupInnerRectY + popupInnerRectHeight * 0.19f, popupInnerRectWidth * 0.0035f, popupInnerRectHeight * 0.69f), new Color(0.31f, 0.305f, 0.30f, 1f));	
			//guiUtils.DrawRect(new Rect(popupInnerRectX + popupInnerRectWidth * 0.500f, popupInnerRectY + popupInnerRectHeight * 0.19f, popupInnerRectWidth * 0.005f, popupInnerRectHeight * 0.69f), new Color(0.13f, 0.125f, 0.12f, 1f));	
			
			// left and right titles

			style.fontStyle = FontStyle.BoldAndItalic;
			style.alignment = TextAnchor.MiddleCenter;
			style.fontSize = (int)(popupInnerRectWidth * 0.021f);
			style.normal.textColor = new Color(0.88f, 0.55f, 0f, 1f);
			GUI.Button(new Rect(popupInnerRectX, popupInnerRectY + popupInnerRectHeight * 0.06f, popupInnerRectWidth * 0.4f, popupInnerRectHeight * 0.06f), "In the Game", style);
			GUI.Button(new Rect(popupInnerRectX + popupInnerRectWidth * 0.5f, popupInnerRectY + popupInnerRectHeight * 0.06f, popupInnerRectWidth * 0.6f, popupInnerRectHeight * 0.06f), "the Real World", style);
		}
		else {
			// Help Pumas
		
			// title
			style.fontStyle = FontStyle.BoldAndItalic;
			style.alignment = TextAnchor.MiddleCenter;
			style.fontSize = (int)(popupInnerRectWidth * 0.024f);
			style.normal.textColor = new Color(0.88f, 0.55f, 0f, 1f);
			GUI.Button(new Rect(popupInnerRectX, popupInnerRectY + popupInnerRectHeight * 0.17f, popupInnerRectWidth * 1f, popupInnerRectHeight * 0.093f), "Pumas in the Real World need your help", style);

			style.fontStyle = FontStyle.BoldAndItalic;
			style.alignment = TextAnchor.MiddleCenter;
			style.fontSize = (int)(popupInnerRectWidth * 0.018f);
			style.normal.textColor = new Color(0.6f, 0.6f, 0.6f, 1f);
			GUI.Button(new Rect(popupInnerRectX + popupInnerRectWidth * 0.4f, popupInnerRectY + popupInnerRectHeight * 0.25f, popupInnerRectWidth * 0.2f, popupInnerRectHeight * 0.06f), "Help support our work to study and protect pumas and their habitats", style);

			// donate button
			guiManager.customGUISkin.button.fontSize = (int)(overlayRect.width * 0.032);
			guiManager.customGUISkin.button.fontStyle = FontStyle.BoldAndItalic;
			guiManager.customGUISkin.button.normal.textColor = new Color(0.8f, 0.1f, 0f, 1f);
			Color defaultHoverColor = guiManager.customGUISkin.button.hover.textColor;
			guiManager.customGUISkin.button.hover.textColor = new Color(0.9f, 0.12f, 0f, 1f);
			guiUtils.DrawRect(new Rect(popupInnerRectX + popupInnerRectWidth * 0.35f + popupInnerRectHeight * 0.01f, popupInnerRectY + popupInnerRectHeight * 0.423f + popupInnerRectHeight * 0.01f, popupInnerRectWidth * 0.3f - popupInnerRectHeight * 0.02f, popupInnerRectHeight * 0.15f - popupInnerRectHeight * 0.023f), new Color(1f, 1f, 1f, 0.15f));	
			if (GUI.Button(new Rect(popupInnerRectX + popupInnerRectWidth * 0.35f, popupInnerRectY + popupInnerRectHeight * 0.42f, popupInnerRectWidth * 0.3f, popupInnerRectHeight * 0.15f), "Make a Donation")) {
				Application.OpenURL("http://www.felidaefund.org/donate");
			}
			guiManager.customGUISkin.button.normal.textColor = new Color(0.90f, 0.65f, 0f, 1f);
			guiManager.customGUISkin.button.hover.textColor = defaultHoverColor;
		}

		// "learn more" section

		if (infoPanelIntroFlag == false && infoPanelPage != 0) {
		
			float yOffsetForPage5 = infoPanelPage == 5 ? (popupInnerRectHeight * -0.12f) : 0f;
		
			if (infoPanelPage == 5)
				guiManager.customGUISkin.button.normal.textColor = new Color(0.88f, 0.55f, 0f, 1f);
			else
				guiManager.customGUISkin.button.normal.textColor = new Color(0.7f, 0.7f, 0.7f, 1f);

			style.fontStyle = FontStyle.BoldAndItalic;
			style.alignment = TextAnchor.MiddleCenter;
			style.fontSize = (int)(popupInnerRectWidth * 0.014f);
			style.normal.textColor = new Color(0.6f, 0.6f, 0.6f, 1f);
			if (infoPanelPage == 5)
				GUI.Button(new Rect(popupInnerRectX + popupInnerRectWidth * 0.4f, popupInnerRectY + popupInnerRectHeight * 0.765f + yOffsetForPage5, popupInnerRectWidth * 0.2f, popupInnerRectHeight * 0.06f), "Get involved...", style);
			else
				GUI.Button(new Rect(popupInnerRectX + popupInnerRectWidth * 0.4f, popupInnerRectY + popupInnerRectHeight * 0.765f, popupInnerRectWidth * 0.2f, popupInnerRectHeight * 0.06f), "Learn more at...", style);

			GUI.color = new Color(1f, 1f, 1f, 0.9f * infoPanelOpacity);

			guiManager.customGUISkin.button.fontSize = (int)(overlayRect.width * 0.016);
			guiManager.customGUISkin.button.fontStyle = FontStyle.BoldAndItalic;
			if (GUI.Button(new Rect(popupInnerRectX + popupInnerRectWidth * 0.312f, popupInnerRectY + popupInnerRectHeight * 0.835f + yOffsetForPage5, popupInnerRectWidth * 0.17f, popupInnerRectHeight * 0.045f), "Felidae Fund")) {
				Application.OpenURL("http://www.felidaefund.org");
			}
		
			guiManager.customGUISkin.button.fontSize = (int)(overlayRect.width * 0.016);
			guiManager.customGUISkin.button.fontStyle = FontStyle.BoldAndItalic;
			if (GUI.Button(new Rect(popupInnerRectX + popupInnerRectWidth * 0.518f, popupInnerRectY + popupInnerRectHeight * 0.835f + yOffsetForPage5, popupInnerRectWidth * 0.17f, popupInnerRectHeight * 0.045f), "Bay Area Puma Project")) {
				Application.OpenURL("http://www.bapp.org");
			}	
			
			GUI.color = new Color(1f, 1f, 1f, 1f * infoPanelOpacity);
			guiManager.customGUISkin.button.normal.textColor = new Color(0.90f, 0.65f, 0f, 1f);


			if (infoPanelPage == 5) {

				// facebook
				textureHeight = popupInnerRectHeight * 0.055f;
				textureWidth = iconFacebookTexture.width * (textureHeight / iconFacebookTexture.height);
				textureX = popupInnerRectX + popupInnerRectWidth * 0.333f;
				textureY = popupInnerRectY + popupInnerRectHeight * 0.8f;
				if (GUI.Button(new Rect(textureX, textureY, textureWidth, textureHeight), "")) {
					Application.OpenURL("http://www.facebook.com/felidaefund");
				}	
				GUI.DrawTexture(new Rect(textureX, textureY, textureWidth, textureHeight), iconFacebookTexture);
				// twitter
				textureWidth = iconTwitterTexture.width * (textureHeight / iconTwitterTexture.height);
				textureX += popupInnerRectWidth * 0.06f;
				if (GUI.Button(new Rect(textureX, textureY, textureWidth, textureHeight), "")) {
					Application.OpenURL("http://www.twitter.com/felidaefund");
				}	
				GUI.DrawTexture(new Rect(textureX, textureY, textureWidth, textureHeight), iconTwitterTexture);
				// google
				textureWidth = iconGoogleTexture.width * (textureHeight / iconGoogleTexture.height);
				textureX += popupInnerRectWidth * 0.06f;
				if (GUI.Button(new Rect(textureX, textureY, textureWidth, textureHeight), "")) {
					Application.OpenURL("http://plus.google.com/u/0/118124929806137459330/posts");
				}	
				GUI.DrawTexture(new Rect(textureX, textureY, textureWidth, textureHeight), iconGoogleTexture);
				// pinterest
				textureWidth = iconPinterestTexture.width * (textureHeight / iconPinterestTexture.height);
				textureX += popupInnerRectWidth * 0.06f;
				if (GUI.Button(new Rect(textureX, textureY, textureWidth, textureHeight), "")) {
					Application.OpenURL("http://www.pinterest.com/felidaefund");
				}	
				GUI.DrawTexture(new Rect(textureX, textureY, textureWidth, textureHeight), iconPinterestTexture);
				// youtube
				textureWidth = iconYouTubeTexture.width * (textureHeight / iconYouTubeTexture.height);
				textureX += popupInnerRectWidth * 0.06f;
				if (GUI.Button(new Rect(textureX, textureY, textureWidth, textureHeight), "")) {
					Application.OpenURL("http://www.youtube.com/felidaefund");
				}	
				GUI.DrawTexture(new Rect(textureX, textureY, textureWidth, textureHeight), iconYouTubeTexture);
				// linkedin
				textureWidth = iconLinkedInTexture.width * (textureHeight / iconLinkedInTexture.height);
				textureX += popupInnerRectWidth * 0.06f;
				if (GUI.Button(new Rect(textureX, textureY, textureWidth, textureHeight), "")) {
					Application.OpenURL("http://www.linkedin.com/groups/Felidae-Conservation-Fund-1108927?gid=1108927&trk=hb_side_g");
				}	
				GUI.DrawTexture(new Rect(textureX, textureY, textureWidth, textureHeight), iconLinkedInTexture);
			}
		}
	}
	
}



*/