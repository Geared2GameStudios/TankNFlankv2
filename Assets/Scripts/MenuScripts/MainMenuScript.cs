using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour 
{
	public static MainMenuScript 	Instance;
	
	private Transform 				pointer;
	private float 					pointerSpeed = 2.0f;
	
	
	
	
	
	// Use this for initialization
	void Awake () 
	{
		Instance = this;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
		{
			pointer.position = 	Input.mousePosition;		
		}
		
		pointer.position += new Vector3(Input.GetAxis("Horizontal") * pointerSpeed, Input.GetAxis("Vertical"), -8);
	}
}
