using UnityEngine;
using System.Collections;

public class PlayerSettingsScript : MonoBehaviour {
	public static PlayerSettingsScript Instance;

	public bool oculusOn;
	public float masterVolume;
	public float effectsVolume;
	private GameObject mainCamera;
	private GameObject ovrCamera;
	private OVRDevice ovrDevice;
	
	void Awake()
	{
		DontDestroyOnLoad(this);
		ovrDevice = this.GetComponent<OVRDevice>();
		mainCamera = GameObject.Find("Main Camera");
		ovrCamera = GameObject.Find("OVRCameraController");
		oculusOn = false;
		masterVolume = 1.0f;
		effectsVolume = 1.0f;

		
	}
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(ovrDevice.SenseCount > 0)
		{
			mainCamera.SetActive(false);
			ovrCamera.SetActive(true);
		}
		else
		{
			ovrCamera.SetActive(false);
			mainCamera.SetActive(true);
		}
	}
}
