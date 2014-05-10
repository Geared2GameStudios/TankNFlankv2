using UnityEngine;
using System.Collections;

public class OptionsScript : MonoBehaviour 
{
	public static OptionsScript Instance;
	public GUISkin MenuSkin;	
	private GUIStyle buttonStyle;   
	private GUIStyle boxSyle;	
	private MenuController mScript;
	private PlayerSettingsScript psScript;
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
		psScript = GameObject.Find("PlayerSettings").GetComponent<PlayerSettingsScript>(); 
		screenWidth = Screen.width; 
		screenHeight = Screen.height;	
		groupWidth = 420f;			
		groupHeight = 330f;			
		setWidth = (screenWidth - groupWidth);		
		setHeight = (screenHeight - groupHeight); 
	
	}
	
	
	public void OnGUI()
	{
		GUI.skin = MenuSkin;
		
		float groupX = setWidth/2;
		float groupY = setHeight/2;
		
		GUI.BeginGroup(new Rect(groupX - 18, groupY + 100, groupWidth, groupHeight));
		GUI.Box(new Rect( 0, 0, groupWidth, groupHeight), "Options");

		GUI.Label( new Rect( 20, 50, 100, 30 ), "Master Volume" );
		psScript.masterVolume = GUI.HorizontalSlider( new Rect( 125, 58, 200, 30 ), psScript.masterVolume, 0.0f, 1.0f );
		float tempMaster = psScript.masterVolume * 100f;
		GUI.Label( new Rect( 330, 50, 50, 30 ), "(" + tempMaster.ToString("f0")+ ")");
		
		GUI.Label( new Rect( 20, 110, 100, 30 ), "Effect Volume" );
		psScript.effectsVolume = GUI.HorizontalSlider(new Rect( 125, 118, 200, 30 ), psScript.effectsVolume, 0.0f, 1.0f );
		float tempsfx = psScript.effectsVolume * 100f;
		GUI.Label( new Rect( 330, 110, 50, 30 ), "(" + tempsfx.ToString("f0") + ")");

		GUI.Label( new Rect( 20, 170, 100, 30 ), "Equip Oculus" );

		string tempString;
		if(psScript.oculusOn)
			tempString = "   Click to turn off VR";
		else
			tempString = "   Click to turn on VR";

		psScript.oculusOn = GUI.Toggle(new Rect( 125, 170, 200, 30 ), psScript.oculusOn, tempString);

		if(GUI.Button(new Rect(160, 250, 100, 30), "Back", MenuSkin.button))
		{
			mScript.startClick = true;
			mScript.optionsActive = false;
			mScript.menuActive = true;
		}

		GUI.EndGroup();
	}
	
}