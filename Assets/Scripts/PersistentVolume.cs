using UnityEngine;
using System.Collections;

public class PersistentVolume : MonoBehaviour {

	public static PersistentVolume Instance;

	public PlayerSettingsScript playerSettings;

	public GameObject persisVol;

	public float sFX = 0.0f;
	

	// Use this for initialization
	void Start () {

		sFX = 0.0f;
	
		persisVol = GameObject.Find ("PlayerSettings");
		playerSettings = persisVol.GetComponent("PlayerSettingsScript") as PlayerSettingsScript;
		DontDestroyOnLoad (transform.gameObject);
		Debug.Log (playerSettings.effectsVolume);
	}


}
