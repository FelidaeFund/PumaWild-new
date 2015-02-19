using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// GuiUtils
/// Low-level GUI drawing utilities

public class GuiUtils : MonoBehaviour
{
	//===================================
	//===================================
	//		MODULE VARIABLES
	//===================================
	//===================================

	private Texture2D rectTexture;
	private GUIStyle rectStyle;

	//===================================
	//===================================
	//		INITIALIZATION
	//===================================
	//===================================

	void Start() 
	{	
		// basic rect
		rectTexture = new Texture2D(2,2);
		rectStyle = new GUIStyle();
	}

	//===================================
	//===================================
	//		UTILS
	//===================================
	//===================================

	
	public void DrawRect(Rect position, Color color)
	{
		for(int i = 0; i < rectTexture.width; i++) {
			for(int j = 0; j < rectTexture.height; j++) {
				rectTexture.SetPixel(i, j, color);
			}
		}
		rectTexture.Apply();
		rectStyle.normal.background = rectTexture;
		GUILayout.BeginArea(position, rectStyle);
		GUILayout.EndArea();		
	}

	
	public float GetAngleFromOffset(float x1, float y1, float x2, float y2)
	{
        float deltaX = x2 - x1;
        float deltaY = y2 - y1;
        float angle = Mathf.Atan2(deltaY, -deltaX) * (180f / Mathf.PI);
        angle -= 90f;
        if (angle < 0f)
			angle += 360f;
		if (angle >= 360f)
			angle -= 360f;
		return angle;
	}	
	
	
	//===================================
	// GUI ITEMS 
	//===================================
	
	// prefab gui components
	public GameObject uiPanel;
	public GameObject uiSubPanel;
	public GameObject uiRect;
	public GameObject uiText;
	public GameObject uiRawImage;
	public GameObject uiButton;
	public GameObject uiButtonSeeThru;
	public GameObject uiImageButton;

	// create
	
	public GameObject CreatePanel(GameObject parentObj, Color imageColor)
	{
		GameObject obj = (GameObject)Instantiate(uiPanel);
		obj.GetComponent<RectTransform>().SetParent(parentObj.GetComponent<RectTransform>(), false);
		obj.GetComponent<Image>().color = imageColor;
		return obj;
	}
	
	
	public GameObject CreateImage(GameObject parentObj, Texture2D texture, Color imageColor)
	{
		GameObject obj = (GameObject)Instantiate(uiRawImage);
		obj.GetComponent<RectTransform>().SetParent(parentObj.GetComponent<RectTransform>(), false);
		obj.GetComponent<RawImage>().texture = texture;
		obj.GetComponent<RawImage>().color = imageColor;
		return obj;
	}
	
	public GameObject CreateRect(GameObject parentObj, Color rectColor)
	{
		GameObject obj = (GameObject)Instantiate(uiRect);
		obj.GetComponent<RectTransform>().SetParent(parentObj.GetComponent<RectTransform>(), false);
		obj.GetComponent<Image>().color = rectColor;
		return obj;
	}
	
	public GameObject CreateText(GameObject parentObj, string text, Color textColor, FontStyle font, TextAnchor alignment = TextAnchor.MiddleCenter)
	{
		GameObject obj = (GameObject)Instantiate(uiText);
		obj.GetComponent<RectTransform>().SetParent(parentObj.GetComponent<RectTransform>(), false);
		obj.GetComponent<Text>().text = text;
		obj.GetComponent<Text>().color =  textColor;
		obj.GetComponent<Text>().fontStyle = font;
		obj.GetComponent<Text>().alignment = alignment;
		return obj;
	}
	
	
	// set offsets

	public void SetItemOffsets(GameObject gameObj, float x, float y, float width, float height)
	{
		gameObj.GetComponent<RectTransform>().offsetMin = new Vector2(x, Screen.height - (y + height));
		gameObj.GetComponent<RectTransform>().offsetMax = new Vector2(-Screen.width + (x + width), -y);
	}
	

	public void SetTextOffsets(GameObject gameObj, float x, float y, float width, float height, int fontSize)
	{
		gameObj.GetComponent<RectTransform>().offsetMin = new Vector2(x, Screen.height - (y + height));
		gameObj.GetComponent<RectTransform>().offsetMax = new Vector2(-Screen.width + (x + width), -y);
		gameObj.GetComponent<Text>().fontSize = fontSize;
	}

	
}

















