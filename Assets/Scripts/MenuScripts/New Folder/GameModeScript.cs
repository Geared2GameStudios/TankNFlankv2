using UnityEngine;
using System.Collections;

public class GameModeScript : MonoBehaviour
{
	public static GameModeScript Instance;
	           
	public GUISkin MenuSkin;	
	private GUIStyle buttonStyle;   
	private GUIStyle boxSyle;	
	private MenuController mScript;
	private float screenWidth;      
	private float screenHeight;		
	private float setWidth;			
	private float setHeight;		
	private float groupWidth;		
	private float groupHeight;		

	public void Start()
	{
		Instance = this;
		mScript = GameObject.Find("Main Camera").GetComponent<MenuController>();
		screenWidth = Screen.width; 
		screenHeight = Screen.height;	
		groupWidth = 200f;			
		groupHeight = 230f;			
		setWidth = (screenWidth - groupWidth);		
		setHeight = (screenHeight - groupHeight); 
	}
	
	
	public void OnGUI()
	{
		GUI.skin = MenuSkin;
		
		float groupX = setWidth/2;
		float groupY = setHeight/2;
		
		GUI.BeginGroup(new Rect(groupX - 18, groupY + 50, groupWidth, groupHeight));
		GUI.Box(new Rect( 0, 0, groupWidth, groupHeight), "Choose a Mode");

		if(GUI.Button(new Rect(50, 50, 100, 30), "Tutorial Mode", MenuSkin.button))
		{
			mScript.startClick = true;
			Application.LoadLevel(2);
		}
		
		if(GUI.Button(new Rect(50, 100, 100, 30), "Coming Soon", MenuSkin.button))
		{

		}

		if(GUI.Button(new Rect(50, 150, 100, 30), "Back", MenuSkin.button))
		{
			mScript.startClick = true;
			mScript.modesActive = false;
			mScript.menuActive = true;
		}
		GUI.EndGroup();
	}

}
