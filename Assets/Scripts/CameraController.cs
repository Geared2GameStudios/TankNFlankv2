using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{
	public GameObject turret;
	public GameObject oculusCamera;
	public GameObject playerSettingObjects;
	public PlayerSettingsScript psScript;

	// Use this for initialization
	void Awake () 
	{
		playerSettingObjects = GameObject.Find("PlayerSettings");
		psScript = playerSettingObjects.GetComponent<PlayerSettingsScript>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(psScript.oculusOn)
		{
			oculusCamera.SetActive(true);
			turret.SetActive(false);
		}
		else
		{
			turret.SetActive(true);
			oculusCamera.SetActive(false);
		}
	}
}
