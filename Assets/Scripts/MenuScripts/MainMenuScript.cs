using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour 
{
	public static MainMenuScript 	Instance;
	
	public Transform 				pointer;
	private float 					pointerSpeed = 3f;
	private float 					lastX = 0.0f;
	private float 					lastY = 0.0f;
	private float 					cursorX = 32.0f;
	private float 					cursorY = 32.0f;
	private GameObject				mainCamera;
	private GameObject 				ovrCamera;
	private PlayerSettingsScript	psScript;
	
	
	
	
	// Use this for initialization
	void Awake () 
	{
		Instance = this;
		mainCamera = GameObject.Find("Main Camera");
		ovrCamera = GameObject.Find("OVRCameraController");
		psScript = GameObject.Find("PlayerSettings").GetComponent<PlayerSettingsScript>();
		Screen.showCursor = false;
		lastX = Input.mousePosition.x;
		lastY = Input.mousePosition.y;
	}
	
	// Update is called once per frame
	void Update () 
	{
		CheckCameras();
		GetMovement();
	}

	void GetMovement()
	{
		float tempX;
		float tempY;
		
		if(lastX != Input.mousePosition.x || lastY != Input.mousePosition.y)
		{
			Screen.showCursor = true;
			pointer.gameObject.SetActive(false);
			lastX = Input.mousePosition.x;
			lastY = Input.mousePosition.y;
		}
		else if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
		{
			Screen.showCursor = false;
			pointer.gameObject.SetActive(true);
			tempX = Input.GetAxis("Horizontal") * pointerSpeed * Time.deltaTime;
			tempY = Input.GetAxis("Vertical") * pointerSpeed *  Time.deltaTime;

			pointer.position += new Vector3(tempX, tempY, pointer.position.z);

			if(pointer.position.x > 5)
				pointer.position = new Vector3(5, pointer.position.y, -4);
			else if(pointer.position.x < -5)
				pointer.position = new Vector3(-5, pointer.position.y, -4);
			
			if(pointer.position.y > 3.3f)
				pointer.position = new Vector3(pointer.position.x, 3.3f, -4);
			else if(pointer.position.y < - 3.3)
				pointer.position = new Vector3(pointer.position.x, -3.3f, -4);
			
			if(pointer.position.z != -4)
				pointer.position = new Vector3(pointer.position.x, pointer.position.y, -4);
		}


	}
	void CheckCameras()
	{
		ovrCamera.SetActive(psScript.oculusOn);
		mainCamera.SetActive(psScript.mainCameraOn);
	}
}
