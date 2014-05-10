using UnityEngine;
using System.Collections;

public class GameControllerScript : MonoBehaviour 
{
	public static GameControllerScript Instance;
	private PlayerSettingsScript psScript;
	private GameObject mainCamera;
	private GameObject ovrCamera;
    private GameObject turret;
	void Awake()
	{
		Instance = this;
		psScript = GameObject.Find("PlayerSettings").GetComponent<PlayerSettingsScript>();
		turret = GameObject.FindGameObjectWithTag("Turret");
		ovrCamera = GameObject.Find("OVRCameraController");
		if(psScript.oculusOn)
		{
			ovrCamera.SetActive(true);
			turret.SetActive(false);
		}
		else
		{
		 	turret.SetActive(true);
			ovrCamera.SetActive(false);
		}

	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
