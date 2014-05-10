using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour 
{
	public static MenuScript Instance;
	public GUISkin MenuSkin;
	private MenuController mScript;
	private GUIStyle buttonStyle;   
	private GUIStyle boxSyle;		
	private float screenWidth;      
	private float screenHeight;		
	private float setWidth;			
	private float setHeight;		
	private float groupWidth;		
	private float groupHeight;		
	private bool activeModes;
	private bool activeOptions;
	
	public AudioClip menuClick;


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
		activeModes = false;
		activeOptions = false;
	}


	public void OnGUI()
	{
		GUI.skin = MenuSkin;

		float groupX = setWidth/2;
		float groupY = setHeight/2;

		GUI.BeginGroup(new Rect(groupX - 18, groupY + 50, groupWidth, groupHeight));
		GUI.Box(new Rect( 0, 0, groupWidth, groupHeight), "Main Menu");

		if(GUI.Button(new Rect(50, 50, 100, 30), "Game Modes", MenuSkin.button))
		{

			mScript.modesActive = true;

			if(mScript.menuActive)
			{
				mScript.startClick = true;
				mScript.menuActive = false;
			}
		}
	
		if(GUI.Button(new Rect(50, 100, 100, 30), "Options", MenuSkin.button))
		{

			mScript.optionsActive = true;
			if(mScript.menuActive)
			{
				mScript.startClick = true;
				mScript.menuActive = false;
			}

		}
		// this if exits the program for stand alone build.
		if(GUI.Button(new Rect(50, 150, 100, 30), "Exit", MenuSkin.button))
		{
			mScript.startClick = true;

			Application.Quit();
		}
		GUI.EndGroup();
	}
}
