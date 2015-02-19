using UnityEngine;
using System.Collections;

/// PumaDoneDisplay
/// Draw the screen that comes up when puma dies or reaches full health

public class PumaDoneDisplay : MonoBehaviour
{
	//===================================
	//===================================
	//		MODULE VARIABLES
	//===================================
	//===================================

	private bool USE_NEW_GUI = true;	
	private float flashStartTime;

	// textures based on bitmap files
	private Texture2D closeup1Texture;
	private Texture2D closeup2Texture;
	private Texture2D closeup3Texture;
	private Texture2D closeup4Texture;
	private Texture2D closeup5Texture;
	private Texture2D closeup6Texture;
	private Texture2D pumaCrossbonesRedTexture;
	private Texture2D greenHeartTexture;

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
		closeup1Texture = guiManager.closeup1Texture;
		closeup2Texture = guiManager.closeup2Texture;
		closeup3Texture = guiManager.closeup3Texture;
		closeup4Texture = guiManager.closeup4Texture;
		closeup5Texture = guiManager.closeup5Texture;
		closeup6Texture = guiManager.closeup6Texture;
		pumaCrossbonesRedTexture = guiManager.pumaCrossbonesRedTexture;		
		greenHeartTexture = guiManager.greenHeartTexture;		
	}

	//===================================
	//===================================
	//		DRAW THE PUMA DONE DISPLAY
	//===================================
	//===================================

	public void Draw(float backgroundPanelOpacity, float carCollisionOpacity, float starvedOpacity, float okButtonOpacity) 
	{ 





	
	


		//if (USE_NEW_GUI == true)
			//return; 
		
		
		//////////////////////////////////
		//////////////////////////////////
		
		// LEGACY DRAW CODE

		//////////////////////////////////
		//////////////////////////////////

		
		float pumaDoneDisplayX = (Screen.width / 2) - (Screen.height * 0.6f);
		float pumaDoneDisplayY = Screen.height * 0.025f;
		float pumaDoneDisplayWidth = Screen.height * 1.2f;
		float pumaDoneDisplayHeight = Screen.height * 0.37f;
		
		int caloriesExpended = (int)scoringSystem.GetLastKillExpense(guiManager.selectedPuma);
		
		GUIStyle style = new GUIStyle();
		style.alignment = TextAnchor.MiddleCenter;
		
		float panelOffsetY = -0.1f;
		
		float textureX = pumaDoneDisplayX + pumaDoneDisplayWidth * 0.075f;
		float textureWidth = pumaDoneDisplayHeight * 0.4f;
		float textureHeight;
		float textureY = pumaDoneDisplayY + pumaDoneDisplayHeight * (0.32f + panelOffsetY);
		
		
		
		float titleX = pumaDoneDisplayX + pumaDoneDisplayWidth * 0.3f;
		float titleY = pumaDoneDisplayY + pumaDoneDisplayHeight * 0.136f;
		float titleW = pumaDoneDisplayWidth * 0.4f;
		float titleH = pumaDoneDisplayHeight * 0.03f;

		float boxX;
		float boxY;
		float boxW;
		float boxH;
		
		
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

		float sourcePercent = 0f;
		float destPercent = 1f;
		
		float leftShiftAmount = pumaDoneDisplayWidth * -0.32f;
		float vertShiftAmount = pumaDoneDisplayHeight * 0.05f;


		//********************
		// BACKGROUND CONTENT
		//********************

		// panel background
		GUI.color = new Color(1f, 1f, 1f, 0.8f * backgroundPanelOpacity);
		GUI.Box(new Rect(pumaDoneDisplayX, pumaDoneDisplayY + pumaDoneDisplayHeight * 0.06f, pumaDoneDisplayWidth, pumaDoneDisplayHeight * 1.2f - pumaDoneDisplayHeight * 0.06f), "");
		GUI.color = new Color(1f, 1f, 1f, 0.3f * backgroundPanelOpacity);
		GUI.Box(new Rect(pumaDoneDisplayX, pumaDoneDisplayY + pumaDoneDisplayHeight * 0.06f, pumaDoneDisplayWidth, pumaDoneDisplayHeight * 1.2f - pumaDoneDisplayHeight * 0.06f), "");
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
		float title1Offset = pumaDoneDisplayWidth * -0.215f;
		float title2Offset = pumaDoneDisplayWidth * 0.06f;
		float backgroundOffset = pumaDoneDisplayWidth * 0f;
		
		float leftLabelX;
		float leftLabelY1;
		float leftLabelY2;
		float leftLabelY3;
		float leftLabelY4;
		float leftLabelY5;
		float leftLabelW;
		float leftLabelH;
		
		float rightLabelX;
		float rightLabelY1;
		float rightLabelY2;
		float rightLabelY3;
		float rightLabelY4;
		float rightLabelY5;
		float rightLabelW;
		float rightLabelH;

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

		
		float fontRef = pumaDoneDisplayHeight * 0.5f;
		style.fontStyle = FontStyle.BoldAndItalic;

		// main title

		GUI.color = new Color(1f, 1f, 1f, 0.8f * backgroundPanelOpacity);
		GUI.Box(new Rect(pumaDoneDisplayX, pumaDoneDisplayY + pumaDoneDisplayHeight * 0.06f, pumaDoneDisplayWidth, pumaDoneDisplayHeight * 0.17f), "");
		GUI.color = new Color(1f, 1f, 1f, 1f * backgroundPanelOpacity);

		GUI.color = new Color(1f, 1f, 1f, 0.9f * backgroundPanelOpacity);
		GUI.Box(new Rect(pumaDoneDisplayX + pumaDoneDisplayWidth * 0.22f + backgroundOffset, pumaDoneDisplayY + pumaDoneDisplayHeight * 0.1f, pumaDoneDisplayWidth * 0.56f - backgroundOffset * 02f, pumaDoneDisplayHeight * 0.11f), "");
		GUI.color = new Color(1f, 1f, 1f, 1f * backgroundPanelOpacity);

		//GUI.color = new Color(1f, 1f, 1f, 0.1f * backgroundPanelOpacity);
		//GUI.Box(new Rect(pumaDoneDisplayX + pumaDoneDisplayWidth * 0.23f + backgroundOffset, pumaDoneDisplayY + pumaDoneDisplayHeight * 0.1f, pumaDoneDisplayWidth * 0.54f - backgroundOffset * 02f, pumaDoneDisplayHeight * 0.11f), "");



		// background box
		boxX = pumaDoneDisplayX + pumaDoneDisplayWidth * (0.665f * sourcePercent + 0.3f * destPercent);
		boxY = pumaDoneDisplayY + pumaDoneDisplayHeight * (0.3f * sourcePercent + 0.3f * destPercent);
		boxW = pumaDoneDisplayWidth * (0.3f * sourcePercent + 0.4f * destPercent);
		boxH = pumaDoneDisplayHeight * (0.62f * sourcePercent + 0.8f * destPercent);
		GUI.color = new Color(1f, 1f, 1f, 0.8f * backgroundPanelOpacity);
		GUI.Box(new Rect(boxX, boxY, boxW, boxH), "");
		GUI.color = new Color(1f, 1f, 1f, 0.5f * backgroundPanelOpacity);
		GUI.Box(new Rect(boxX, boxY, boxW, boxH), "");
		GUI.color = new Color(1f, 1f, 1f, 1f * backgroundPanelOpacity);

		// puma head
		GUI.color = (scoringSystem.GetPumaHealth(guiManager.selectedPuma) >= 1f) ? new Color(1f, 1f, 1f, 1f * backgroundPanelOpacity) : new Color(0.9f, 0.2f, 0.2f, 1f * backgroundPanelOpacity);
		textureX = pumaDoneDisplayX + pumaDoneDisplayWidth * 0.77f + leftShiftAmount;
		textureY = pumaDoneDisplayY + pumaDoneDisplayHeight * (0.42f + panelOffsetY) + vertShiftAmount;
		textureWidth = pumaDoneDisplayHeight * 0.39f;
		textureHeight = headshotTexture.height * (textureWidth / headshotTexture.width);
		GUI.DrawTexture(new Rect(textureX, textureY, textureWidth, textureHeight), headshotTexture);
		GUI.color = new Color(1f, 1f, 1f, 1f * backgroundPanelOpacity);

		// puma name
		float nameX = pumaDoneDisplayX + pumaDoneDisplayWidth * 0.767f + leftShiftAmount;
		float nameY = pumaDoneDisplayY + pumaDoneDisplayHeight * (0.79f + panelOffsetY) + vertShiftAmount;
		float nameW = pumaDoneDisplayWidth * 0.1f;
		float nameH = pumaDoneDisplayHeight * 0.03f;
		style.normal.textColor = new Color(0.55f, 0.55f, 0.55f, 1f);
		style.fontSize = (int)(fontRef * 0.16f);
		GUI.Button(new Rect(nameX, nameY, nameW, nameH), pumaName, style);
		
		// health bar
		float barX = pumaDoneDisplayX + pumaDoneDisplayWidth * 0.670f + pumaDoneDisplayHeight * 0.03f + leftShiftAmount;
		float barY = pumaDoneDisplayY + pumaDoneDisplayHeight * 0.81f + vertShiftAmount;
		float barW = pumaDoneDisplayWidth * 0.29f - pumaDoneDisplayHeight * 0.06f;
		float barH = pumaDoneDisplayHeight * 0.11f;
		guiComponents.DrawPumaHealthBar(guiManager.selectedPuma, backgroundPanelOpacity, barX, barY, barW, barH, true);
		


		
		//************************
		// CAR COLLISION CONTENT
		//************************
					
		GUI.color = new Color(1f, 1f, 1f, 1f * carCollisionOpacity);

		if (carCollisionOpacity > 0f) {
		
			// header title
			titleX = pumaDoneDisplayX + pumaDoneDisplayWidth * 0.3f;
			titleY = pumaDoneDisplayY + pumaDoneDisplayHeight * 0.136f;
			titleW = pumaDoneDisplayWidth * 0.4f;
			titleH = pumaDoneDisplayHeight * 0.03f;
			style.fontSize = (int)(fontRef * 0.22f);
			style.normal.textColor =  new Color(0.66f, 0f, 0f, 1f);
			style.fontStyle = FontStyle.Bold;
			style.fontSize = (int)(fontRef * 0.18f);
			GUI.Button(new Rect(titleX, titleY, titleW, titleH), "KILLED BY A VEHICLE!", style);
			
			// crossbones
			GUI.color = new Color(0.9f, 0.9f, 0.9f, 1f * carCollisionOpacity);
			textureY = pumaDoneDisplayY + pumaDoneDisplayHeight * (0.5f + panelOffsetY) + vertShiftAmount;
			textureWidth = pumaDoneDisplayHeight * 0.3f;
			textureHeight = pumaCrossbonesRedTexture.height * (textureWidth / pumaCrossbonesRedTexture.width);
			textureX = pumaDoneDisplayX + pumaDoneDisplayWidth/2  - textureWidth/2 - pumaDoneDisplayWidth * 0.13f;
			GUI.DrawTexture(new Rect(textureX, textureY, textureWidth, textureHeight), pumaCrossbonesRedTexture);
			GUI.color = new Color(1f, 1f, 1f, 1f * carCollisionOpacity);
			textureX = pumaDoneDisplayX + pumaDoneDisplayWidth/2  - textureWidth/2 + pumaDoneDisplayWidth * 0.13f;
			GUI.DrawTexture(new Rect(textureX, textureY, textureWidth, textureHeight), pumaCrossbonesRedTexture);
			GUI.color = new Color(1f, 1f, 1f, 1f * carCollisionOpacity);
			
			// left and right label boxes
			boxY = pumaDoneDisplayY + pumaDoneDisplayHeight * 0.30f;
			boxW = pumaDoneDisplayWidth * 0.22f;
			boxH = pumaDoneDisplayHeight * (0.62f * sourcePercent + 0.8f * destPercent);
			boxX = pumaDoneDisplayX + pumaDoneDisplayWidth/2 - boxW/2 - pumaDoneDisplayWidth * 0.35f;
			GUI.color = new Color(1f, 1f, 1f, 0.8f * carCollisionOpacity);
			GUI.Box(new Rect(boxX, boxY, boxW, boxH), "");
			GUI.color = new Color(1f, 1f, 1f, 1f * carCollisionOpacity);
			boxX = pumaDoneDisplayX + pumaDoneDisplayWidth/2 - boxW/2 + pumaDoneDisplayWidth * 0.35f;
			boxY = pumaDoneDisplayY + pumaDoneDisplayHeight * 0.30f;
			boxH = pumaDoneDisplayHeight * 0.51f;
			GUI.color = new Color(1f, 1f, 1f, 0.8f * carCollisionOpacity);
			GUI.Box(new Rect(boxX, boxY, boxW, boxH), "");
			GUI.color = new Color(1f, 1f, 1f, 1f * carCollisionOpacity);
				
			// left label
			style.alignment = TextAnchor.MiddleLeft;
			leftLabelX = pumaDoneDisplayX + pumaDoneDisplayWidth * 0.385f + leftShiftAmount;
			leftLabelY1 = pumaDoneDisplayY + pumaDoneDisplayHeight * (0.50f + panelOffsetY) + vertShiftAmount;
			leftLabelY2 = pumaDoneDisplayY + pumaDoneDisplayHeight * (0.61f + panelOffsetY) + vertShiftAmount;
			leftLabelY3 = pumaDoneDisplayY + pumaDoneDisplayHeight * (0.72f + panelOffsetY) + vertShiftAmount;
			leftLabelY4 = pumaDoneDisplayY + pumaDoneDisplayHeight * (0.83f + panelOffsetY) + vertShiftAmount;
			leftLabelY5 = pumaDoneDisplayY + pumaDoneDisplayHeight * (0.94f + panelOffsetY) + vertShiftAmount;
			leftLabelW = pumaDoneDisplayWidth * 0.1f;
			leftLabelH = pumaDoneDisplayHeight * 0.03f;
			style.normal.textColor = new Color(0.65f, 0.65f, 0.65f, 1f);
			style.fontSize = (int)(fontRef * 0.16f);
			GUI.Button(new Rect(leftLabelX, leftLabelY1, leftLabelW, leftLabelH), "Over 60 pumas", style);
			GUI.Button(new Rect(leftLabelX, leftLabelY2, leftLabelW, leftLabelH), "die each year", style);
			GUI.Button(new Rect(leftLabelX, leftLabelY3, leftLabelW, leftLabelH), "in California", style);
			GUI.Button(new Rect(leftLabelX, leftLabelY4, leftLabelW, leftLabelH), "from collisions", style);
			GUI.Button(new Rect(leftLabelX, leftLabelY5, leftLabelW, leftLabelH), "with vehicles", style);

			// right label
			rightLabelX = pumaDoneDisplayX + pumaDoneDisplayWidth * 0.765f;
			rightLabelY1 = pumaDoneDisplayY + pumaDoneDisplayHeight * (0.48f + panelOffsetY) + vertShiftAmount;
			rightLabelY2 = pumaDoneDisplayY + pumaDoneDisplayHeight * (0.59f + panelOffsetY) + vertShiftAmount;
			rightLabelY3 = pumaDoneDisplayY + pumaDoneDisplayHeight * (0.70f + panelOffsetY) + vertShiftAmount;
			rightLabelW = pumaDoneDisplayWidth * 0.1f;
			rightLabelH = pumaDoneDisplayHeight * 0.03f;
			style.normal.textColor = new Color(0.65f, 0.65f, 0.65f, 1f);
			style.fontSize = (int)(fontRef * 0.16f);
			GUI.Button(new Rect(rightLabelX, rightLabelY1, rightLabelW, rightLabelH), "Pumas need to", style);
			GUI.Button(new Rect(rightLabelX, rightLabelY2, rightLabelW, rightLabelH), "move carefully", style);
			GUI.Button(new Rect(rightLabelX, rightLabelY3, rightLabelW, rightLabelH), "to avoid cars", style);
			style.alignment = TextAnchor.MiddleCenter;

			// survival tips button
			boxY = pumaDoneDisplayY + pumaDoneDisplayHeight * 0.86f;
			boxW = pumaDoneDisplayWidth * 0.22f;
			boxH = pumaDoneDisplayHeight * 0.24f;
			boxX = pumaDoneDisplayX + pumaDoneDisplayWidth/2 - boxW/2 + pumaDoneDisplayWidth * 0.35f;
			GUI.color = new Color(1f, 1f, 1f, 0.8f * carCollisionOpacity);
			GUI.Box(new Rect(boxX, boxY, boxW, boxH), "");
			GUI.color = new Color(1f, 1f, 1f, 1f * carCollisionOpacity);
			GUI.skin = guiManager.customGUISkin;
			guiManager.customGUISkin.button.fontSize = (int)(pumaDoneDisplayHeight * 0.070);
			guiManager.customGUISkin.button.fontStyle = FontStyle.Bold;
			if (GUI.Button(new Rect(pumaDoneDisplayX + pumaDoneDisplayWidth * 0.77f,  pumaDoneDisplayY + pumaDoneDisplayHeight * 0.9f, pumaDoneDisplayWidth * 0.16f, pumaDoneDisplayHeight * 0.15f), "")) {
				guiManager.OpenInfoPanel(3);
			}
			if (GUI.Button(new Rect(pumaDoneDisplayX + pumaDoneDisplayWidth * 0.77f,  pumaDoneDisplayY + pumaDoneDisplayHeight * 0.9f, pumaDoneDisplayWidth * 0.16f, pumaDoneDisplayHeight * 0.15f), "Survival Tips")) {
				guiManager.OpenInfoPanel(3);
			}
		}		


		//********************
		// STARVED CONTENT
		//********************

		GUI.color = new Color(1f, 1f, 1f, 1f * starvedOpacity);

		if (starvedOpacity > 0f) {
		
			// header title
			titleX = pumaDoneDisplayX + pumaDoneDisplayWidth * 0.3f;
			titleY = pumaDoneDisplayY + pumaDoneDisplayHeight * 0.136f;
			titleW = pumaDoneDisplayWidth * 0.4f;
			titleH = pumaDoneDisplayHeight * 0.03f;
			style.fontSize = (int)(fontRef * 0.22f);
			style.normal.textColor =  new Color(0.70f, 0f, 0f, 1f);
			style.fontStyle = FontStyle.Bold;
			style.fontSize = (int)(fontRef * 0.18f);
			GUI.Button(new Rect(titleX, titleY, titleW, titleH), "STARVED TO DEATH!", style);

			// crossbones
			GUI.color = new Color(0.9f, 0.9f, 0.9f, 1f * starvedOpacity);
			textureY = pumaDoneDisplayY + pumaDoneDisplayHeight * (0.5f + panelOffsetY) + vertShiftAmount;
			textureWidth = pumaDoneDisplayHeight * 0.3f;
			textureHeight = pumaCrossbonesRedTexture.height * (textureWidth / pumaCrossbonesRedTexture.width);
			textureX = pumaDoneDisplayX + pumaDoneDisplayWidth/2  - textureWidth/2 - pumaDoneDisplayWidth * 0.13f;
			GUI.DrawTexture(new Rect(textureX, textureY, textureWidth, textureHeight), pumaCrossbonesRedTexture);
			GUI.color = new Color(1f, 1f, 1f, 1f * starvedOpacity);
			textureX = pumaDoneDisplayX + pumaDoneDisplayWidth/2  - textureWidth/2 + pumaDoneDisplayWidth * 0.13f;
			GUI.DrawTexture(new Rect(textureX, textureY, textureWidth, textureHeight), pumaCrossbonesRedTexture);
			GUI.color = new Color(1f, 1f, 1f, 1f * starvedOpacity);
			
			if (scoringSystem.GetPopulationHealth() > 0f) {
			
				// left and right label boxes
				boxY = pumaDoneDisplayY + pumaDoneDisplayHeight * 0.30f;
				boxW = pumaDoneDisplayWidth * 0.22f;
				boxH = pumaDoneDisplayHeight * (0.62f * sourcePercent + 0.8f * destPercent);
				boxX = pumaDoneDisplayX + pumaDoneDisplayWidth/2 - boxW/2 - pumaDoneDisplayWidth * 0.35f;
				GUI.color = new Color(1f, 1f, 1f, 0.8f * starvedOpacity);
				GUI.Box(new Rect(boxX, boxY, boxW, boxH), "");
				GUI.color = new Color(1f, 1f, 1f, 1f * starvedOpacity);
				boxX = pumaDoneDisplayX + pumaDoneDisplayWidth/2 - boxW/2 + pumaDoneDisplayWidth * 0.35f;
				boxY = pumaDoneDisplayY + pumaDoneDisplayHeight * 0.30f;
				boxH = pumaDoneDisplayHeight * 0.51f;
				GUI.color = new Color(1f, 1f, 1f, 0.8f * starvedOpacity);
				GUI.Box(new Rect(boxX, boxY, boxW, boxH), "");
				GUI.color = new Color(1f, 1f, 1f, 1f * starvedOpacity);
					
				// left label
				style.alignment = TextAnchor.MiddleLeft;
				leftLabelX = pumaDoneDisplayX + pumaDoneDisplayWidth * 0.375f + leftShiftAmount;
				leftLabelY1 = pumaDoneDisplayY + pumaDoneDisplayHeight * (0.48f + panelOffsetY) + vertShiftAmount;
				leftLabelY2 = pumaDoneDisplayY + pumaDoneDisplayHeight * (0.59f + panelOffsetY) + vertShiftAmount;
				leftLabelY3 = pumaDoneDisplayY + pumaDoneDisplayHeight * (0.70f + panelOffsetY) + vertShiftAmount;
				leftLabelY4 = pumaDoneDisplayY + pumaDoneDisplayHeight * (0.88f + panelOffsetY) + vertShiftAmount;
				leftLabelY5 = pumaDoneDisplayY + pumaDoneDisplayHeight * (0.99f + panelOffsetY) + vertShiftAmount;
				leftLabelW = pumaDoneDisplayWidth * 0.1f;
				leftLabelH = pumaDoneDisplayHeight * 0.03f;
				style.normal.textColor = new Color(0.65f, 0.65f, 0.65f, 1f);
				style.fontSize = (int)(fontRef * 0.16f);
				GUI.Button(new Rect(leftLabelX, leftLabelY1, leftLabelW, leftLabelH), "Deer = up to 80%", style);
				GUI.Button(new Rect(leftLabelX, leftLabelY2, leftLabelW, leftLabelH), "of the puma diet", style);
				GUI.Button(new Rect(leftLabelX, leftLabelY3, leftLabelW, leftLabelH), "in North America", style);
				GUI.Button(new Rect(leftLabelX, leftLabelY4, leftLabelW, leftLabelH), "Pumas help limit", style);
				GUI.Button(new Rect(leftLabelX, leftLabelY5, leftLabelW, leftLabelH), "deer populations", style);

				// right label
				rightLabelX = pumaDoneDisplayX + pumaDoneDisplayWidth * 0.775f;
				rightLabelY1 = pumaDoneDisplayY + pumaDoneDisplayHeight * (0.48f + panelOffsetY) + vertShiftAmount;
				rightLabelY2 = pumaDoneDisplayY + pumaDoneDisplayHeight * (0.59f + panelOffsetY) + vertShiftAmount;
				rightLabelY3 = pumaDoneDisplayY + pumaDoneDisplayHeight * (0.70f + panelOffsetY) + vertShiftAmount;
				rightLabelW = pumaDoneDisplayWidth * 0.1f;
				rightLabelH = pumaDoneDisplayHeight * 0.03f;
				style.normal.textColor = new Color(0.65f, 0.65f, 0.65f, 1f);
				style.fontSize = (int)(fontRef * 0.16f);
				GUI.Button(new Rect(rightLabelX, rightLabelY1, rightLabelW, rightLabelH), "Pumas need", style);
				GUI.Button(new Rect(rightLabelX, rightLabelY2, rightLabelW, rightLabelH), "to hunt smart", style);
				GUI.Button(new Rect(rightLabelX, rightLabelY3, rightLabelW, rightLabelH), "to catch deer", style);
				style.alignment = TextAnchor.MiddleCenter;
						
				// hunting tips button
				boxY = pumaDoneDisplayY + pumaDoneDisplayHeight * 0.86f;
				boxW = pumaDoneDisplayWidth * 0.22f;
				boxH = pumaDoneDisplayHeight * 0.24f;
				boxX = pumaDoneDisplayX + pumaDoneDisplayWidth/2 - boxW/2 + pumaDoneDisplayWidth * 0.35f;
				GUI.color = new Color(1f, 1f, 1f, 0.8f * starvedOpacity);
				GUI.Box(new Rect(boxX, boxY, boxW, boxH), "");
				GUI.color = new Color(1f, 1f, 1f, 1f * starvedOpacity);
				GUI.skin = guiManager.customGUISkin;
				guiManager.customGUISkin.button.fontSize = (int)(pumaDoneDisplayHeight * 0.070);
				guiManager.customGUISkin.button.fontStyle = FontStyle.Bold;
				if (GUI.Button(new Rect(pumaDoneDisplayX + pumaDoneDisplayWidth * 0.77f,  pumaDoneDisplayY + pumaDoneDisplayHeight * 0.9f, pumaDoneDisplayWidth * 0.16f, pumaDoneDisplayHeight * 0.15f), "")) {
					guiManager.OpenInfoPanel(1);
				}
				if (GUI.Button(new Rect(pumaDoneDisplayX + pumaDoneDisplayWidth * 0.77f,  pumaDoneDisplayY + pumaDoneDisplayHeight * 0.9f, pumaDoneDisplayWidth * 0.16f, pumaDoneDisplayHeight * 0.15f), "Hunting Tips")) {
					guiManager.OpenInfoPanel(1);
				}
			}
			else {
				// end of population

				// left and right label boxes
				boxY = pumaDoneDisplayY + pumaDoneDisplayHeight * 0.30f;
				boxW = pumaDoneDisplayWidth * 0.22f;
				boxH = pumaDoneDisplayHeight * (0.62f * sourcePercent + 0.8f * destPercent);
				boxX = pumaDoneDisplayX + pumaDoneDisplayWidth/2 - boxW/2 - pumaDoneDisplayWidth * 0.35f;
				GUI.color = new Color(1f, 1f, 1f, 1f * starvedOpacity);
				GUI.Box(new Rect(boxX, boxY, boxW, boxH), "");
				GUI.color = new Color(1f, 1f, 1f, 1f * starvedOpacity);
				boxX = pumaDoneDisplayX + pumaDoneDisplayWidth/2 - boxW/2 + pumaDoneDisplayWidth * 0.35f;
				GUI.color = new Color(1f, 1f, 1f, 1f * starvedOpacity);
				GUI.Box(new Rect(boxX, boxY, boxW, boxH), "");
				GUI.color = new Color(1f, 1f, 1f, 1f * starvedOpacity);

				// left label
				style.alignment = TextAnchor.MiddleLeft;
				leftLabelX = pumaDoneDisplayX + pumaDoneDisplayWidth * 0.375f + leftShiftAmount;
				leftLabelY1 = pumaDoneDisplayY + pumaDoneDisplayHeight * (0.48f + panelOffsetY) + vertShiftAmount;
				leftLabelY2 = pumaDoneDisplayY + pumaDoneDisplayHeight * (0.63f + panelOffsetY) + vertShiftAmount;
				leftLabelY3 = pumaDoneDisplayY + pumaDoneDisplayHeight * (0.74f + panelOffsetY) + vertShiftAmount;
				leftLabelY4 = pumaDoneDisplayY + pumaDoneDisplayHeight * (0.89f + panelOffsetY) + vertShiftAmount;
				leftLabelY5 = pumaDoneDisplayY + pumaDoneDisplayHeight * (0.99f + panelOffsetY) + vertShiftAmount;
				leftLabelW = pumaDoneDisplayWidth * 0.1f;
				leftLabelH = pumaDoneDisplayHeight * 0.03f;
				style.normal.textColor = new Color(0.7f, 0.7f, 0.7f, 1f);
				style.fontSize = (int)(fontRef * 0.16f);
				style.fontSize = (int)(fontRef * 0.17f);
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
				style.normal.textColor = new Color(0.75f, 0.75f, 0.75f, flashingOpacity);
				GUI.Button(new Rect(leftLabelX, leftLabelY1, leftLabelW, leftLabelH), "- GAME OVER -", style);
				style.fontSize = (int)(fontRef * 0.15f);
				style.normal.textColor = new Color(0.7f, 0.7f, 0.7f, 1f);
				GUI.Button(new Rect(leftLabelX, leftLabelY2, leftLabelW, leftLabelH), "The last puma in", style);
				GUI.Button(new Rect(leftLabelX, leftLabelY3, leftLabelW, leftLabelH), "the area has died", style);
				style.normal.textColor = new Color(0.7f, 0.6f, 0.5f, 1f);
				GUI.Button(new Rect(leftLabelX, leftLabelY4, leftLabelW, leftLabelH), "Extinction of local", style);
				GUI.Button(new Rect(leftLabelX, leftLabelY5, leftLabelW, leftLabelH), "puma population", style);
				style.normal.textColor = new Color(0.7f, 0.7f, 0.7f, 1f);

				// right label
				rightLabelX = pumaDoneDisplayX + pumaDoneDisplayWidth * 0.758f;
				rightLabelY1 = pumaDoneDisplayY + pumaDoneDisplayHeight * (0.48f + panelOffsetY) + vertShiftAmount;
				rightLabelY2 = pumaDoneDisplayY + pumaDoneDisplayHeight * (0.595f + panelOffsetY) + vertShiftAmount;
				rightLabelY3 = pumaDoneDisplayY + pumaDoneDisplayHeight * (0.695f + panelOffsetY) + vertShiftAmount;
				rightLabelY4 = pumaDoneDisplayY + pumaDoneDisplayHeight * (0.88f + panelOffsetY) + vertShiftAmount;
				rightLabelY5 = pumaDoneDisplayY + pumaDoneDisplayHeight * (0.99f + panelOffsetY) + vertShiftAmount;
				rightLabelW = pumaDoneDisplayWidth * 0.1f;
				rightLabelH = pumaDoneDisplayHeight * 0.03f;
				style.normal.textColor = new Color(0.7f, 0.7f, 0.7f, 1f);
				style.fontSize = (int)(fontRef * 0.16f);
				style.normal.textColor = new Color(0.6f, 0.55f, 0.5f, 1f);
				style.fontSize = (int)(fontRef * 0.14f);
				GUI.Button(new Rect(rightLabelX, rightLabelY1, rightLabelW, rightLabelH), "BIG WINNER:", style);
				style.fontSize = (int)(fontRef * 0.16f);
				style.normal.textColor = new Color(0.8f, 0.8f, 0.8f, 1f);
				GUI.Button(new Rect(rightLabelX, rightLabelY2, rightLabelW, rightLabelH), "The Deer", style);
				style.fontSize = (int)(fontRef * 0.13f);
				style.normal.textColor = new Color(0.7f, 0.7f, 0.7f, 1f);
				style.fontStyle = FontStyle.BoldAndItalic;
				GUI.Button(new Rect(rightLabelX, rightLabelY3, rightLabelW, rightLabelH), "can graze anywhere", style);
				style.fontStyle = FontStyle.Bold;
				style.normal.textColor = new Color(0.7f, 0.7f, 0.7f, 1f);
				style.normal.textColor = new Color(0.6f, 0.55f, 0.5f, 1f);
				style.fontSize = (int)(fontRef * 0.14f);
				GUI.Button(new Rect(rightLabelX, rightLabelY4, rightLabelW, rightLabelH), "BIG LOSER:", style);
				style.fontSize = (int)(fontRef * 0.16f);
				style.normal.textColor = new Color(0.8f, 0.8f, 0.8f, 1f);
				GUI.Button(new Rect(rightLabelX, rightLabelY5, rightLabelW, rightLabelH), "The Ecosystem", style);
				style.alignment = TextAnchor.MiddleCenter;
				
			}
		}		



		//********************
		// 'OK' BUTTON
		//********************
					
		pumaDoneDisplayX -= pumaDoneDisplayWidth * 0.02f;
		pumaDoneDisplayY += pumaDoneDisplayHeight * 1.3f;

		GUI.color = new Color(1f, 1f, 1f, 0.8f * okButtonOpacity);
		GUI.Box(new Rect(pumaDoneDisplayX + pumaDoneDisplayWidth * 0.78f, pumaDoneDisplayY + pumaDoneDisplayHeight * 0.67f, pumaDoneDisplayWidth * 0.20f, pumaDoneDisplayHeight * 0.37f), "");
		GUI.color = new Color(1f, 1f, 1f, 0.6f * okButtonOpacity);
		GUI.Box(new Rect(pumaDoneDisplayX + pumaDoneDisplayWidth * 0.78f, pumaDoneDisplayY + pumaDoneDisplayHeight * 0.67f, pumaDoneDisplayWidth * 0.20f, pumaDoneDisplayHeight * 0.37f), "");
		GUI.color = new Color(1f, 1f, 1f, 1f * okButtonOpacity);

		GUI.color = new Color(1f, 1f, 1f, 0.8f * okButtonOpacity);
		GUI.Box(new Rect(pumaDoneDisplayX + pumaDoneDisplayWidth * 0.81f,  pumaDoneDisplayY + pumaDoneDisplayHeight * 0.727f, pumaDoneDisplayWidth * 0.14f, pumaDoneDisplayHeight * 0.25f), "");
		GUI.color = new Color(1f, 1f, 1f, 0.8f * okButtonOpacity);
		GUI.Box(new Rect(pumaDoneDisplayX + pumaDoneDisplayWidth * 0.81f,  pumaDoneDisplayY + pumaDoneDisplayHeight * 0.727f, pumaDoneDisplayWidth * 0.14f, pumaDoneDisplayHeight * 0.25f), "");
		GUI.color = new Color(1f, 1f, 1f, 1f * okButtonOpacity);

		GUI.skin = guiManager.customGUISkin;
		guiManager.customGUISkin.button.fontSize = (int)(pumaDoneDisplayHeight * 0.14);
		guiManager.customGUISkin.button.fontStyle = FontStyle.Normal;
		if (GUI.Button(new Rect(pumaDoneDisplayX + pumaDoneDisplayWidth * 0.81f,  pumaDoneDisplayY + pumaDoneDisplayHeight * 0.727f, pumaDoneDisplayWidth * 0.14f, pumaDoneDisplayHeight * 0.25f), "Go")) {
			guiManager.SetGuiState("guiStateLeavingPumaDone");
			if (levelManager.CheckCarCollision() == true)
				levelManager.EndCarCollision();
			else if (levelManager.CheckStarvation() == true)
				levelManager.EndStarvation();		
			levelManager.SetGameState("gameStateLeavingGameplay");
		}	
		
		pumaDoneDisplayX += pumaDoneDisplayWidth * 0.02f;
		pumaDoneDisplayY -= pumaDoneDisplayHeight * 1.3f;
	}
	
}