﻿using UnityEngine;
using System.Collections;

public class PlayerSettingsScript : MonoBehaviour 
{

	public static PlayerSettingsScript 	Instance;

	public bool 						oculusOn = false;
	public bool 						mainCameraOn = false;
	public float 						masterVolume = 1.0f;
	public float						effectsVolume = 1.0f;
	public GameObject 					persisVol;
	public PersistentVolume 			persisVolScript;
	private OVRDevice 					ovrDevice;
	private int 						sensorCount = -1;


	void Awake()
	{
		DontDestroyOnLoad(this);
		oculusOn = false;
		masterVolume = 1.0f;
		effectsVolume = 1.0f;
	}

	// Use this for initialization
	void Start () 
	{
		ovrDevice = this.GetComponent<OVRDevice>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		AudioListener.volume = masterVolume;

		if(sensorCount != ovrDevice.SenseCount)
		{
			if(ovrDevice.SenseCount > 0)
			{
				mainCameraOn = false;
				oculusOn  = true;
			}
			else
			{
				mainCameraOn = true;
				oculusOn = false;
			}
			sensorCount = ovrDevice.SenseCount;
		}
	}
}
