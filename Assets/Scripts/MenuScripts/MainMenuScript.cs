﻿using UnityEngine;
using System.Collections;
 
public class MainMenuScript : MonoBehaviour 
{
	public static MainMenuScript 	Instance;
	  

	public GameObject 				mainMenu;
	public GameObject				optionsMenu;
	public Transform 				pointer;
	public Transform				volSlider;
	public Transform				sfxSlider;
	public Transform 				vrOff;
	public Transform				vrOn;
	public Transform				pointerPoint;

	private float 					pointerSpeed = 3f;
	private float 					lastX = 0.0f;
	private float 					lastY = 0.0f;
	private float 					volNum = 0.0f;	
	private float 					sfxNum = 0.0f;
	private bool					movingMouse = false;
	private bool					movingController = false;
	private bool 					optionsActive = false;
	private GameObject				mainCamera;
	private GameObject 				ovrCamera;
	private PlayerSettingsScript	psScript;
	public AudioClip 				menuClick;
	
	
	
	// Use this for initialization
	void Awake () 
	{
		Instance = this;
		mainCamera = GameObject.Find("Main Camera");
		ovrCamera = GameObject.Find("OVRCameraController");
		psScript = GameObject.Find("PlayerSettings").GetComponent<PlayerSettingsScript>();
		volNum = psScript.masterVolume;
		sfxNum = psScript.effectsVolume;
		UpdateSliders();
		Screen.showCursor = false;
		lastX = Input.mousePosition.x;
		lastY = Input.mousePosition.y;
	}	

	public void PlaySound()
	{
		//this.gameObject.audio.volume = PlayerSettingsScript.Instance.effectsVolume;
		this.gameObject.audio.PlayOneShot (menuClick);
	}

	// Update is called once per frame
	void Update () 
	{
		CheckCameras();
		GetMovement();
		CheckSelection();
	}	
	void CheckSelection()
	{
		if(Input.GetMouseButtonDown(0))
		{
			GetMouse();
		}
		
		else if(Input.GetButtonDown("Action"))
		{			
			GetStick();

		
		}
	}	
	void GetMovement()
	{
		float tempX;
		float tempY;
		
		if(lastX != Input.mousePosition.x || lastY != Input.mousePosition.y)
		{
			movingMouse = true;
			movingController = false;
			Screen.showCursor = true;
			pointer.gameObject.SetActive(false);
			lastX = Input.mousePosition.x;
			lastY = Input.mousePosition.y;
		}
		
		else if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
		{
			Input.compositionCursorPos = new Vector2(0f,0f);
			movingMouse = true;
			movingController = false;
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
	void GetMouse()
	{	
		Ray ray = mainCamera.camera.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit))
		{
			print (hit.collider.name);
			if(!optionsActive)
			{
				if(hit.collider.name == "playButton")
				{
					PlaySound ();
					Application.LoadLevel(2);
				}
				else if(hit.collider.name == "optionsButton")
				{
					PlaySound ();
					optionsActive = true;
					mainMenu.SetActive(false);
					optionsMenu.SetActive(true);
					
				}
				else if(hit.collider.name == "exitButton")
				{
					PlaySound ();
					Application.Quit();
				}
			}
			
			else if(optionsMenu.activeSelf)
			{
				if(hit.collider.name == "volDown")
				{
					PlaySound ();
					volNum -= 0.1f;
				}
				
				else if(hit.collider.name == "volUp")
				{
					PlaySound ();
					volNum += 0.1f;
				}
				else if(hit.collider.name == "sfxDown")
				{
					PlaySound ();
					sfxNum -= 0.1f;
				}
				
				else if(hit.collider.name == "sfxUp")
				{
					PlaySound ();
					sfxNum += 0.1f;
				}
				
				else if(hit.collider.name == "vrOffButton" || hit.collider.name == "vrOnButton")
				{
					if(!psScript.oculusOn)
					{
						PlaySound ();
						psScript.oculusOn = true;
						psScript.mainCameraOn = false;
						vrOn.gameObject.SetActive(true);
						vrOff.gameObject.SetActive(false);
						
					}
					else if(psScript.oculusOn)
					{
						PlaySound ();
						psScript.mainCameraOn = true;
						psScript.oculusOn = false;
						vrOff.gameObject.SetActive(true);
						vrOn.gameObject.SetActive(false);
						
					}
					CheckCameras();
				}
				
				else if(hit.collider.name == "backButton")
				{
					PlaySound ();
					optionsActive = false;
					optionsMenu.SetActive(false);
					mainMenu.SetActive(true);
				}
				UpdateSliders();
			}
		}
	}
	void UpdateSliders()
	{
		if(sfxNum < 0)
			sfxNum = 0;
		else if (sfxNum > 1)
			sfxNum = 1;
		
		if(volNum < 0)
			volNum = 0;
		else if(volNum > 1)
			volNum = 1;
		
		float tempXsfx = ((sfxNum * 4) -1.5f) * -1;
		float tempXvol = ((volNum * 4) -1.5f) * -1;
 		
		volSlider.localPosition = new Vector3(tempXvol, volSlider.localPosition.y, volSlider.localPosition.z);
		sfxSlider.localPosition = new Vector3(tempXsfx, sfxSlider.localPosition.y, sfxSlider.localPosition.z);
		
		psScript.masterVolume = volNum;
		psScript.effectsVolume = sfxNum;
			
	}
	void GetStick()
	{
		//Ray ray = mainCamera.camera.ScreenPointToRay(pointerPoint.position);
		RaycastHit hit;
		Vector3 fwrd = pointerPoint.transform.TransformDirection(Vector3.down) * 200;
		Debug.DrawRay (pointerPoint.position, fwrd, Color.magenta);
		if(Physics.Raycast(pointerPoint.position, fwrd, out hit))
		{
			print (hit.collider.name);
			if(!optionsActive)
			{
				if(hit.collider.name == "playButton")
				{
					PlaySound ();
					Application.LoadLevel(2);
				}
				else if(hit.collider.name == "optionsButton")
				{
					PlaySound ();
					optionsActive = true;
					mainMenu.SetActive(false);
					optionsMenu.SetActive(true);
					
				}
				else if(hit.collider.name == "exitButton")
				{
					PlaySound ();
					print ("you have exited");
				}
			}
			
			else if(optionsMenu.activeSelf)
			{
				if(hit.collider.name == "volDown")
				{
					PlaySound ();
					volNum -= 0.1f;
					PlayerSettingsScript.Instance.masterVolume -= 0.1f;
				}
				
				else if(hit.collider.name == "volUp")
				{
					PlaySound ();
					volNum += 0.1f;
					PlayerSettingsScript.Instance.masterVolume += 0.1f;
				}
				else if(hit.collider.name == "sfxDown")
				{
					PlaySound ();
					sfxNum -= 0.1f;
					PlayerSettingsScript.Instance.effectsVolume -= 0.1f;

				}
				
				else if(hit.collider.name == "sfxUp")
				{
					PlaySound ();
					sfxNum += 0.1f;
					PlayerSettingsScript.Instance.effectsVolume += 0.1f;
				}
				
				else if(hit.collider.name == "vrOffButton" || hit.collider.name == "vrOnButton")
				{
					if(!psScript.oculusOn)
					{
						PlaySound ();
						psScript.oculusOn = true;
						psScript.mainCameraOn = false;
						vrOn.gameObject.SetActive(true);
						vrOff.gameObject.SetActive(false);
						
					}
					else if(psScript.oculusOn)
					{
						PlaySound ();
						psScript.mainCameraOn = true;
						psScript.oculusOn = false;
						vrOff.gameObject.SetActive(true);
						vrOn.gameObject.SetActive(false);
						
					}
					CheckCameras();
				}
				
				else if(hit.collider.name == "backButton")
				{
					PlaySound ();
					optionsActive = false;
					optionsMenu.SetActive(false);
					mainMenu.SetActive(true);
				}
				UpdateSliders();
			}
		}
	}
}
