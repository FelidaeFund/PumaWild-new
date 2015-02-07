using UnityEngine;
using System.Collections;

/// GameplayDisplay
/// Draw the heads up display that integrates with gameplay

public class GameplayDisplay : MonoBehaviour
{
	//===================================
	//===================================
	//		MODULE VARIABLES
	//===================================
	//===================================

	private float flashStartTime;
	
	// outside dimensions for deer head indicators
	private float indicatorMinX;
	private float indicatorMinY;
	private float indicatorMaxX;
	private float indicatorMaxY;

	// textures based on bitmap files
	private Texture2D arrowTrayTexture;
	private Texture2D arrowTrayTopTexture;
	private Texture2D arrowTrayFlippedTexture;
	private Texture2D arrowTrayTopFlippedTexture;
	private Texture2D arrowUpTexture;
	private Texture2D arrowDownTexture;
	private Texture2D arrowLeftTexture;
	private Texture2D arrowRightTexture;
	private Texture2D arrowTurnLeftTexture;
	private Texture2D arrowTurnRightTexture;
	private Texture2D pawDiagLeftTexture;
	private Texture2D pawDiagRightTexture;
	private Texture2D pawStraightTexture;
	private Texture2D controlRightIconsTexture;
	private Texture2D controlRightIconsLowerTexture;
	private Texture2D controlLeftJumpTexture;
	private Texture2D controlLeftExitTexture;
	private Texture2D controlLeftDiagLeftTexture;
	private Texture2D controlLeftDiagRightTexture;
	private Texture2D indicatorBuck; 
	private Texture2D indicatorDoe; 
	private Texture2D indicatorFawn; 
	private Texture2D indicatorBkgnd; 
	private Texture2D closeupBackgroundTexture;
	private Texture2D closeup1Texture;
	private Texture2D closeup2Texture;
	private Texture2D closeup3Texture;
	private Texture2D closeup4Texture;
	private Texture2D closeup5Texture;
	private Texture2D closeup6Texture;
	private Texture2D closeupSensesTexture;
	private Texture2D pumaStealthDarkTexture;
	private Texture2D pumaRunDarkTexture;

	// external modules
	private GuiManager guiManager;
	private GuiComponents guiComponents;
	private GuiUtils guiUtils;
	private LevelManager levelManager;
	private InputControls inputControls;

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
		inputControls = GetComponent<InputControls>();
		
		// texture references from GuiManager
		arrowTrayTexture = guiManager.arrowTrayTexture;
		arrowTrayTopTexture = guiManager.arrowTrayTopTexture;
		arrowTrayFlippedTexture = guiManager.arrowTrayTexture;
		arrowTrayTopFlippedTexture = guiManager.arrowTrayTopTexture;
		arrowUpTexture = guiManager.arrowUpTexture;
		arrowDownTexture = guiManager.arrowDownTexture;
		arrowLeftTexture = guiManager.arrowLeftTexture;
		arrowRightTexture = guiManager.arrowRightTexture;
		arrowTurnLeftTexture = guiManager.arrowTurnLeftTexture;
		arrowTurnRightTexture = guiManager.arrowTurnRightTexture;
		pawDiagLeftTexture = guiManager.pawDiagLeftTexture;
		pawDiagRightTexture = guiManager.pawDiagRightTexture;
		pawStraightTexture = guiManager.pawStraightTexture;
		controlRightIconsTexture = guiManager.controlRightIconsTexture;
		controlRightIconsLowerTexture = guiManager.controlRightIconsLowerTexture;
		controlLeftJumpTexture = guiManager.controlLeftJumpTexture;
		controlLeftExitTexture = guiManager.controlLeftExitTexture;
		controlLeftDiagLeftTexture = guiManager.controlLeftDiagLeftTexture;
		controlLeftDiagRightTexture = guiManager.controlLeftDiagRightTexture;
		indicatorBuck = guiManager.indicatorBuck;
		indicatorDoe = guiManager.indicatorDoe;
		indicatorFawn = guiManager.indicatorFawn;
		indicatorBkgnd = guiManager.indicatorBkgnd;
		closeupBackgroundTexture = guiManager.closeupBackgroundTexture;
		closeup1Texture = guiManager.closeup1Texture;
		closeup2Texture = guiManager.closeup2Texture;
		closeup3Texture = guiManager.closeup3Texture;
		closeup4Texture = guiManager.closeup4Texture;
		closeup5Texture = guiManager.closeup5Texture;
		closeup6Texture = guiManager.closeup6Texture;
		closeupSensesTexture = guiManager.closeupSensesTexture;
		pumaStealthDarkTexture = guiManager.pumaStealthDarkTexture;
		pumaRunDarkTexture = guiManager.pumaRunDarkTexture;
	}

	//===================================
	//===================================
	//	  DRAW THE GAMEPLAY DISPLAY
	//===================================
	//===================================
	
	public void Draw(float movementControlsOpacity, float positionIndicatorBackgroundOpacity, float positionIndicatorOpacity, float positionIndicatorZoom, float statusDisplayOpacity) 
	{ 
		GUIStyle style = new GUIStyle();
		style.alignment = TextAnchor.MiddleCenter;

		float leftAreaX = Screen.height * 0.08f;
		float leftAreaY = Screen.height * 0.80f;
		float leftAreaWidth = Screen.height * 0.37f;
		float leftAreaHeight = Screen.height * 0.12f;

		float rightAreaY = Screen.height * 0.67f;
		float rightAreaWidth = Screen.height * 0.24f;
		float rightAreaHeight = Screen.height * 0.20f;
		float rightAreaExtraHeight = Screen.height * 0.05f;
		float rightAreaX = Screen.width - rightAreaWidth - leftAreaX;

		//guiUtils.DrawRect(new Rect(leftAreaX, leftAreaY, leftAreaWidth, leftAreaHeight), new Color(0f, 0f, 0f, 0.3f));
		//guiUtils.DrawRect(new Rect(rightAreaX, rightAreaY, rightAreaWidth, rightAreaHeight), new Color(0f, 0f, 0f, 0.3f));


		// establish scale factor for movement controls tray and health meter / exit button
		float boxWidth = Screen.height * 0.30f * 1.4f;
		float boxHeight = arrowTrayTexture.height * (boxWidth / arrowTrayTexture.width);

		//----------------------
		// MOVEMENT CONTROLS
		//----------------------
					
		// left paw

		float textureX = leftAreaX - leftAreaWidth * 0.027f;
		float textureY = leftAreaY - leftAreaHeight * 0.16f;			
		float textureWidth = leftAreaWidth * 0.47f;
		float textureHeight = leftAreaHeight * 1.25f;
		bool chasingFlag = levelManager.gameState == "gameStateChasing" || levelManager.gameState == "gameStateFeeding1" || levelManager.gameState == "gameStateFeeding1a";

		GUI.color = new Color(1f, 1f, 1f, 1f * movementControlsOpacity);
		if (movementControlsOpacity > 0f)
			inputControls.SetRectLeftButton(new Rect(leftAreaX, leftAreaY, leftAreaWidth * 0.41f, leftAreaHeight));

		Texture2D iconTexture = null;

		if (chasingFlag) {
			//GUI.color = new Color(1f, 1f, 1f, 0.65f * movementControlsOpacity);
			//GUI.DrawTexture(new Rect(textureX, textureY + textureHeight * 0.03f, textureWidth, textureHeight * 0.94f), arrowTrayTopFlippedTexture);
			//GUI.DrawTexture(new Rect(textureX + textureWidth * 0.1f, textureY + textureHeight * 0.05f, textureWidth * 0.8f, textureHeight * 0.9f), arrowTrayFlippedTexture);
			GUI.color = new Color(1f, 1f, 1f, 0.8f * movementControlsOpacity);
			textureWidth = pawStraightTexture.width * (textureHeight / pawStraightTexture.height);
			GUI.DrawTexture(new Rect(leftAreaX + leftAreaWidth * 0.0f, leftAreaY + leftAreaHeight * 0.07f, leftAreaWidth * 0.41f * 1.04f, leftAreaHeight * 1.04f), controlLeftJumpTexture);		
		}
		else  {
			GUI.color = new Color(1f, 1f, 1f, 0.8f * movementControlsOpacity);
			iconTexture = levelManager.PumaSideStalkDirectionIsLeft() == true ? pawDiagLeftTexture : pawDiagRightTexture;
			textureWidth = (iconTexture.width * (textureHeight / iconTexture.height)) * 1.1f;
			GUI.DrawTexture(new Rect(textureX + textureWidth * 0.10f, textureY + textureHeight * 0.2f, textureWidth * 0.8f, textureHeight * 0.94f * 0.8f), iconTexture);
			//GUI.color = new Color(1f, 1f, 1f, 0.6f * movementControlsOpacity);
			//GUI.DrawTexture(new Rect(leftAreaX, leftAreaY, leftAreaWidth * 0.41f, leftAreaHeight), levelManager.PumaSideStalkDirectionIsLeft() == true ? controlLeftDiagLeftTexture : controlLeftDiagRightTexture);		
		}


		// exit button
		GUI.color = new Color(1f, 1f, 1f, 0.8f * movementControlsOpacity);
		textureWidth = pawStraightTexture.width * (textureHeight / pawStraightTexture.height);
		GUI.DrawTexture(new Rect(leftAreaX + leftAreaWidth * 0.82f, leftAreaY + leftAreaHeight * 0.17f, leftAreaWidth * 0.41f * 0.8f, leftAreaHeight * 0.8f), pawStraightTexture);		
		if (movementControlsOpacity > 0f)
			inputControls.SetRectMiddleButton(new Rect(leftAreaX + leftAreaWidth * 0.82f, leftAreaY + leftAreaHeight * 0.2f, leftAreaWidth * 0.41f * 0.8f, leftAreaHeight * 0.8f));
		GUI.color = new Color(1f, 1f, 1f, 1f * movementControlsOpacity);
		style.fontSize = (int)(leftAreaWidth * 0.06f);
		style.fontStyle = FontStyle.Bold;
		style.normal.textColor = new Color(0f, 0f, 0f, 0.8f);
		GUI.Button(new Rect(leftAreaX + leftAreaWidth * 0.82f, leftAreaY + leftAreaHeight * 0.5f, leftAreaWidth * 0.41f * 0.8f, leftAreaHeight * 0.5f), "Menu", style);
		
		// right paw
	
		textureX = rightAreaX - rightAreaWidth * 0.065f;
		textureY = rightAreaY - rightAreaHeight * 0.16f;			
		textureWidth = rightAreaWidth * 1.14f;
		textureHeight = rightAreaHeight * 1.25f;
		
		GUI.color = new Color(1f, 1f, 1f, 0.8f * movementControlsOpacity);
		GUI.Box(new Rect(rightAreaX, rightAreaY, rightAreaWidth, rightAreaHeight), "");
		GUI.Box(new Rect(rightAreaX, rightAreaY + rightAreaHeight, rightAreaWidth, rightAreaExtraHeight), "");
		GUI.Box(new Rect(rightAreaX, rightAreaY + rightAreaHeight, rightAreaWidth, rightAreaExtraHeight), "");
		GUI.color = new Color(1f, 1f, 1f, 0.7f * movementControlsOpacity);
		//GUI.Box(new Rect(rightAreaX, rightAreaY + rightAreaHeight - rightAreaExtraHeight, rightAreaWidth, rightAreaExtraHeight), "");
		GUI.color = new Color(1f, 1f, 1f, 1f * movementControlsOpacity);
		
		GUI.color = new Color(1f, 1f, 1f, 0.65f * movementControlsOpacity);
		//GUI.DrawTexture(new Rect(textureX, textureY + textureHeight * 0.03f, textureWidth, textureHeight * 0.94f), arrowTrayTopTexture);
		//GUI.DrawTexture(new Rect(textureX + textureWidth * 0.1f, textureY + textureHeight * 0.05f, textureWidth * 0.8f, textureHeight * 0.9f), arrowTrayTexture);
		GUI.color = new Color(1f, 1f, 1f, 1f * movementControlsOpacity);
		//GUI.DrawTexture(new Rect(textureX, textureY, textureWidth, textureHeight), arrowLeftTexture);
		//GUI.DrawTexture(new Rect(textureX, textureY, textureWidth, textureHeight), arrowRightTexture);
		//GUI.DrawTexture(new Rect(textureX, textureY, textureWidth, textureHeight), arrowUpTexture);
		//GUI.DrawTexture(new Rect(textureX, textureY, textureWidth, textureHeight), arrowDownTexture);
		if (movementControlsOpacity > 0f)
			inputControls.SetRectRightButton(new Rect(rightAreaX, rightAreaY, rightAreaWidth, rightAreaHeight + rightAreaExtraHeight));
			
		GUI.color = new Color(1f, 1f, 1f, 0.7f * movementControlsOpacity);
		GUI.DrawTexture(new Rect(rightAreaX, rightAreaY - rightAreaExtraHeight*0.1f, rightAreaWidth, rightAreaHeight + rightAreaExtraHeight), controlRightIconsTexture);
		GUI.color = new Color(1f, 1f, 1f, 0.75f * movementControlsOpacity);
		GUI.DrawTexture(new Rect(rightAreaX, rightAreaY - rightAreaExtraHeight*0.1f, rightAreaWidth, rightAreaHeight + rightAreaExtraHeight), controlRightIconsLowerTexture);
					
		GUI.color = new Color(1f, 1f, 1f, 0.9f * movementControlsOpacity);
		iconTexture = chasingFlag ? pumaRunDarkTexture : pumaStealthDarkTexture;
		textureHeight = rightAreaExtraHeight * 1.5f;
		textureWidth = iconTexture.width * (textureHeight / iconTexture.height);
		GUI.DrawTexture(new Rect(rightAreaX + rightAreaWidth/2 - textureWidth*0.52f, rightAreaY + rightAreaHeight*0.0f, textureWidth, textureHeight), iconTexture);
		textureHeight = rightAreaExtraHeight * 0.9f;
		textureWidth = iconTexture.width * (textureHeight / iconTexture.height);
		GUI.DrawTexture(new Rect(rightAreaX + rightAreaWidth/2 - textureWidth*0.52f, rightAreaY + rightAreaHeight*0.75f, textureWidth, textureHeight), iconTexture);
			
						
		//----------------------
		// POSITION INDICATORS
		//----------------------
					
		// outer edge display
		GUI.color = new Color(1f, 1f, 1f, 0.9f * positionIndicatorBackgroundOpacity);
		int borderThickness = (int)(Screen.height * 0.06f);
		Color edgeColor = new Color(0f, 0f, 0f, 0.35f);	

		// initial onscreen rect
		indicatorMinX = Screen.width * 0.25f * (1f-positionIndicatorZoom);
		indicatorMinY = Screen.height * 0.05f * (1f-positionIndicatorZoom);
		indicatorMaxX = Screen.width - indicatorMinX;
		indicatorMaxY = Screen.height - (Screen.height * 0.45f * (1f-positionIndicatorZoom));

		float zoom = positionIndicatorZoom > 0.5f ? 1f : positionIndicatorZoom * 2f;
		float scaleFactor = 1f - (1f-zoom)*(1f-zoom);
		//float scaleFactor = zoom * zoom;
		//float scaleFactor = zoom;

		// background for indicator rect
		GUI.color = new Color(1f, 1f, 1f, 1f * positionIndicatorBackgroundOpacity * (1f - scaleFactor));
		GUI.Box(new Rect(indicatorMinX, indicatorMinY, indicatorMaxX - indicatorMinX, indicatorMaxY - indicatorMinY), "");
		GUI.color = new Color(0.4f, 0.4f, 0.4f, 0.6f * positionIndicatorBackgroundOpacity * (1f - scaleFactor));
		//GUI.DrawTexture(new Rect(indicatorMinX, indicatorMinY, indicatorMaxX - indicatorMinX, indicatorMaxY - indicatorMinY), closeupBackgroundTexture);
			
		// puma head with flashing nose and ear
		
		Texture2D closeupTexture = null;
		
		switch (guiManager.selectedPuma) {
		case 0:
			closeupTexture = closeup1Texture;
			break;
		case 1:
			closeupTexture = closeup2Texture;
			break;
		case 2:
			closeupTexture = closeup3Texture;
			break;
		case 3:
			closeupTexture = closeup4Texture;
			break;
		case 4:
			closeupTexture = closeup5Texture;
			break;
		case 5:
			closeupTexture = closeup6Texture;
			break;
		}
				
		textureWidth = (indicatorMaxX - indicatorMinX) * 0.2f;
		textureHeight = closeupTexture.height * (textureWidth / closeupTexture.width);
		textureX = (indicatorMaxX + indicatorMinX) / 2 - textureWidth/2;
		textureY = (indicatorMaxY + indicatorMinY) / 2 - textureHeight/2;
		
		GUI.color = new Color(1f, 1f, 1f, 0.82f * positionIndicatorBackgroundOpacity * (1f - scaleFactor));
		GUI.DrawTexture(new Rect(textureX, textureY, textureWidth, textureHeight), closeupTexture);
		float flashingPeriod = 0.5f;
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
		flashingOpacity = 0.3f + flashingOpacity * 0.5f;
		flashingOpacity = flashingOpacity * flashingOpacity;
		//flashingOpacity = 0f;
		GUI.color = new Color(1f, 1f, 1f, 0.5f * flashingOpacity * positionIndicatorBackgroundOpacity * (1f - scaleFactor));
		GUI.DrawTexture(new Rect(indicatorMinX, indicatorMinY, indicatorMaxX - indicatorMinX, indicatorMaxY - indicatorMinY), closeupSensesTexture);
		GUI.color = new Color(1f, 1f, 1f, 1f * positionIndicatorBackgroundOpacity);

		// indicator borders
		guiUtils.DrawRect(new Rect(indicatorMinX, indicatorMinY, indicatorMaxX-indicatorMinX, borderThickness), edgeColor);
		guiUtils.DrawRect(new Rect(indicatorMinX, indicatorMaxY-borderThickness, indicatorMaxX-indicatorMinX, borderThickness), edgeColor);
		guiUtils.DrawRect(new Rect(indicatorMinX, indicatorMinY + borderThickness, borderThickness, (indicatorMaxY-indicatorMinY)-(borderThickness*2)), edgeColor);
		guiUtils.DrawRect(new Rect(indicatorMaxX-borderThickness, indicatorMinY + borderThickness, borderThickness, (indicatorMaxY-indicatorMinY)-(borderThickness*2)), edgeColor);

		// deer head indicators
		if (levelManager.buck != null && levelManager.doe != null && levelManager.fawn != null ) {
			DrawIndicator(levelManager.mainHeading, levelManager.pumaObj, levelManager.buck.gameObj, levelManager.buck.type, borderThickness, positionIndicatorOpacity);
			DrawIndicator(levelManager.mainHeading, levelManager.pumaObj, levelManager.doe.gameObj, levelManager.doe.type, borderThickness, positionIndicatorOpacity);
			DrawIndicator(levelManager.mainHeading, levelManager.pumaObj, levelManager.fawn.gameObj, levelManager.fawn.type, borderThickness, positionIndicatorOpacity);
		}
	
		//----------------------
		// STATUS DISPLAYS
		//----------------------
		
		float statusPanelWidth = Screen.height * 0.11f;
		float statusPanelHeight = leftAreaHeight * 0.88f;
		float statusPanelX = leftAreaX + leftAreaWidth * 0.45f;
		float statusPanelY = leftAreaY + leftAreaHeight - statusPanelHeight - leftAreaHeight * 0.03f;
		GUI.color = new Color(1f, 1f, 1f, 0.4f * movementControlsOpacity);
		GUI.Box(new Rect(statusPanelX, statusPanelY, statusPanelWidth, statusPanelHeight), "");
		GUI.color = new Color(1f, 1f, 1f, 1f * statusDisplayOpacity);
		guiComponents.DrawStatusPanel(statusDisplayOpacity * 1f, statusPanelX, statusPanelY, statusPanelWidth, statusPanelHeight, false, true);
		GUI.color = new Color(1f, 1f, 1f, 1f * statusDisplayOpacity);

		
		//----------------------
		// CHEAT BUTTON
		//----------------------
		
		GUI.color = new Color(1f, 1f, 1f, 0f * statusDisplayOpacity);
		float killButtonX = Screen.width * 0.5f - Screen.height * 0.075f;
		float killButtonY = 0f;
		float killButtonWidth = Screen.height * 0.15f;
		float killButtonHeight = Screen.height * 0.15f;
		if (GUI.Button(new Rect(killButtonX,  killButtonY, killButtonWidth, killButtonHeight), "")) {
			levelManager.goStraightToFeeding = true;
		}
		GUI.color = new Color(1f, 1f, 1f, 1f * statusDisplayOpacity);
	}

	
	//===================================
	//===================================
	//	  POSITION INDICATORS
	//===================================
	//===================================

	void DrawIndicator(float mainHeading, GameObject pumaObj, GameObject deerObj, string type, int borderThickness, float guiOpacity)
    {
		float xPos = 0;
		float yPos = 0;
		float xOffset = 0;
		float yOffset = 0;
		float rangeX = (indicatorMaxX - indicatorMinX) - borderThickness;
		float rangeY = (indicatorMaxY - indicatorMinY) - borderThickness;
		float deerToPumaAngle = 0;
		float deerToPumaDistance = 0;

		//------------------------------------------
		// Determine onscreen position of indicator
		//------------------------------------------

		while (mainHeading < 0)
			mainHeading += 360;
		while (mainHeading > 360)
			mainHeading -= 360;
		
		// angle based on midpoint between camera and puma
		float refX = (pumaObj.transform.position.x + Camera.main.transform.position.x) / 2;
		float refY = (pumaObj.transform.position.z + Camera.main.transform.position.z) / 2;

		deerToPumaAngle = guiUtils.GetAngleFromOffset(refX, refY, deerObj.transform.position.x, deerObj.transform.position.z);
		deerToPumaDistance = Vector3.Distance(pumaObj.transform.position, deerObj.transform.position);

		xOffset = -(Mathf.Sin((mainHeading - deerToPumaAngle) * Mathf.PI / 180) * rangeY);
		yOffset = (Mathf.Cos((mainHeading - deerToPumaAngle) * Mathf.PI / 180) * rangeY);
		xOffset *= (rangeX/2) / rangeY; // adjust x offset to fit screen width			
			
		if (yOffset > 0) {
			// stretch out offsets to place deer head along screen edge
			float scaleVal;
			if (Mathf.Abs(xOffset / yOffset) > Mathf.Abs((rangeX/2) / rangeY)) {
				scaleVal = (rangeX/2) / Mathf.Abs(xOffset); // scale by X dimension
			}
			else {
				scaleVal = (rangeY) / Mathf.Abs(yOffset); // scale by Y dimension
			}
			xOffset *= scaleVal;
			yOffset *= scaleVal;
		}
		else {
			// clip y to keep deer head along lower edge
			yOffset = 0;
		}
					
		xPos = (Screen.width - borderThickness) / 2 + xOffset;
		yPos = indicatorMaxY - borderThickness - yOffset;

		//--------------------------------------------
		// Determine settings for distance indication
		//--------------------------------------------

		Color backdropColor;
		float fullRedDistance = 20f;
		float fullYellowDistance = 75f;
		float startYellowDistance = 175f;
		float transPercent;
				
		if (deerToPumaDistance < fullRedDistance) {
			backdropColor = new Color(1f, 0f, 0f, 1f * guiOpacity);
		}
		else if (deerToPumaDistance < fullYellowDistance) {
			transPercent = (fullYellowDistance - deerToPumaDistance) / (fullYellowDistance - fullRedDistance);
			backdropColor = new Color(1f, 0.5f - (transPercent/2), 0f, 1f * guiOpacity);
		}
		else if (deerToPumaDistance < startYellowDistance) {
			transPercent = (startYellowDistance - deerToPumaDistance) / (startYellowDistance - fullYellowDistance);
			backdropColor = new Color(1f, 0.5f, 0f, transPercent * guiOpacity);
		}
		else {
			backdropColor = new Color(0f, 0f, 0f, 0f * guiOpacity);
		}
			
		Color headColor;
		float fullHeadAlphaDistance = 150f;
		float startHeadAlphaDistance = 300f;

		if (deerToPumaDistance < fullHeadAlphaDistance) {
			headColor = new Color(1f, 1f, 1f, 1f * guiOpacity);
		}
		else if (deerToPumaDistance < startHeadAlphaDistance) {
			headColor = new Color(1f, 1f, 1f, (0.5f + ((startHeadAlphaDistance - deerToPumaDistance) / (startHeadAlphaDistance - fullHeadAlphaDistance) * 0.5f)) * guiOpacity);
		}
		else {
			headColor = new Color(1f, 1f, 1f, 0.5f * guiOpacity);
		}

		//--------------------------
		// Draw the indicator
		//--------------------------

		Texture2D headTexture = indicatorBkgnd;

		switch (type) {

		case "Buck":
			headTexture = indicatorBuck;
			break;

		case "Doe":
			headTexture = indicatorDoe;
			break;

		case "Fawn":
			headTexture = indicatorFawn;
			break;
		}

		GUI.color = backdropColor;
		GUI.DrawTexture(new Rect(xPos, yPos, borderThickness, borderThickness), indicatorBkgnd);
		GUI.color = headColor;
		GUI.DrawTexture(new Rect(xPos, yPos, borderThickness, borderThickness), headTexture);
	}

}