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
	private Texture2D indicatorBuck; 
	private Texture2D indicatorDoe; 
	private Texture2D indicatorFawn; 
	private Texture2D indicatorBkgnd; 

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
		indicatorBuck = guiManager.indicatorBuck;
		indicatorDoe = guiManager.indicatorDoe;
		indicatorFawn = guiManager.indicatorFawn;
		indicatorBkgnd = guiManager.indicatorBkgnd;
	}

	//===================================
	//===================================
	//	  DRAW THE GAMEPLAY DISPLAY
	//===================================
	//===================================
	
	public void Draw(float movementControlsOpacity, float positionIndicatorOpacity, float statusDisplayOpacity) 
	{ 
		GUIStyle style = new GUIStyle();
		style.alignment = TextAnchor.MiddleCenter;

		float leftAreaX = Screen.height * 0.10f;
		float leftAreaY = Screen.height * 0.75f;
		float leftAreaWidth = Screen.height * 0.45f;
		float leftAreaHeight = Screen.height * 0.15f;

		float rightAreaY = Screen.height * 0.65f;
		float rightAreaWidth = Screen.height * 0.30f;
		float rightAreaHeight = Screen.height * 0.25f;
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

		GUI.color = new Color(1f, 1f, 1f, 0.65f * movementControlsOpacity);
		GUI.DrawTexture(new Rect(textureX, textureY + textureHeight * 0.03f, textureWidth, textureHeight * 0.94f), arrowTrayTopFlippedTexture);
		GUI.DrawTexture(new Rect(textureX + textureWidth * 0.1f, textureY + textureHeight * 0.05f, textureWidth * 0.8f, textureHeight * 0.9f), arrowTrayFlippedTexture);
		GUI.color = new Color(1f, 1f, 1f, 1f * movementControlsOpacity);
		if (movementControlsOpacity > 0f)
			inputControls.SetRectLeftButton(new Rect(leftAreaX, leftAreaY, leftAreaWidth * 0.41f, leftAreaHeight));

		
		// right paw
	
		textureX = rightAreaX - rightAreaWidth * 0.065f;
		textureY = rightAreaY - rightAreaHeight * 0.16f;			
		textureWidth = rightAreaWidth * 1.14f;
		textureHeight = rightAreaHeight * 1.25f;
		
		GUI.color = new Color(1f, 1f, 1f, 0.65f * movementControlsOpacity);
		GUI.DrawTexture(new Rect(textureX, textureY + textureHeight * 0.03f, textureWidth, textureHeight * 0.94f), arrowTrayTopTexture);
		GUI.DrawTexture(new Rect(textureX + textureWidth * 0.1f, textureY + textureHeight * 0.05f, textureWidth * 0.8f, textureHeight * 0.9f), arrowTrayTexture);
		GUI.color = new Color(1f, 1f, 1f, 1f * movementControlsOpacity);
		//GUI.DrawTexture(new Rect(textureX, textureY, textureWidth, textureHeight), arrowLeftTexture);
		//GUI.DrawTexture(new Rect(textureX, textureY, textureWidth, textureHeight), arrowRightTexture);
		//GUI.DrawTexture(new Rect(textureX, textureY, textureWidth, textureHeight), arrowUpTexture);
		//GUI.DrawTexture(new Rect(textureX, textureY, textureWidth, textureHeight), arrowDownTexture);
		if (movementControlsOpacity > 0f)
			inputControls.SetRectRightButton(new Rect(rightAreaX, rightAreaY, rightAreaWidth, rightAreaHeight));
						
		//----------------------
		// POSITION INDICATORS
		//----------------------
						
		// outer edge display
		GUI.color = new Color(1f, 1f, 1f, 0.9f * positionIndicatorOpacity);
		int borderThickness = (int)(Screen.height * 0.06f);
		Color edgeColor = new Color(0f, 0f, 0f, 0.35f);	
		guiUtils.DrawRect(new Rect(0, 0, Screen.width, borderThickness), edgeColor);
		guiUtils.DrawRect(new Rect(0, Screen.height-borderThickness, Screen.width, borderThickness), edgeColor);
		guiUtils.DrawRect(new Rect(0, borderThickness, borderThickness, Screen.height-(borderThickness*2)), edgeColor);
		guiUtils.DrawRect(new Rect(Screen.width-borderThickness, borderThickness, borderThickness, Screen.height-(borderThickness*2)), edgeColor);

		// deer head indicators
		if (levelManager.buck != null && levelManager.doe != null && levelManager.fawn != null ) {
			DrawIndicator(levelManager.mainHeading, levelManager.pumaObj, levelManager.buck.gameObj, levelManager.buck.type, borderThickness, positionIndicatorOpacity);
			DrawIndicator(levelManager.mainHeading, levelManager.pumaObj, levelManager.doe.gameObj, levelManager.doe.type, borderThickness, positionIndicatorOpacity);
			DrawIndicator(levelManager.mainHeading, levelManager.pumaObj, levelManager.fawn.gameObj, levelManager.fawn.type, borderThickness, positionIndicatorOpacity);
		}
		
		//----------------------
		// STATUS DISPLAYS
		//----------------------
		
		float statusPanelWidth = Screen.height * 0.23f;
		float statusPanelHeight = leftAreaHeight * 0.88f;
		float statusPanelX = leftAreaX + leftAreaWidth * 0.52f;
		float statusPanelY = leftAreaY + leftAreaHeight - statusPanelHeight - leftAreaHeight * 0.05f;
		guiComponents.DrawStatusPanel(statusDisplayOpacity * 1f, statusPanelX, statusPanelY, statusPanelWidth, statusPanelHeight, false, true);

		
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
		float rangeX = Screen.width - borderThickness;
		float rangeY = Screen.height - borderThickness;
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
		yPos = Screen.height - borderThickness - yOffset;

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