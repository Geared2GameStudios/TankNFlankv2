using UnityEngine;
using System.Collections;

public class IntroScript : MonoBehaviour {

	public GameObject mainCamera;
	public GameObject oculusCamera;
	private PlayerSettingsScript psScript;
	// Use this for initialization
	void Awake () 
	{
		mainCamera = GameObject.Find("Main Camera");
		oculusCamera = GameObject.Find("OVRCameraComtroller");
		psScript = GameObject.Find("PlayerSettings").GetComponent<PlayerSettingsScript>();
	}
	
	// Update is called once per frame
	void Update ()
	{

		mainCamera.SetActive(psScript.mainCameraOn);
		oculusCamera.SetActive(psScript.oculusOn);

		StartCoroutine(WaittoExit(5.0f));

	}

	private IEnumerator WaittoExit(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		Application.LoadLevel(1);
	}
}
