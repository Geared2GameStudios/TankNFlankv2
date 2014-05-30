using UnityEngine;
using System.Collections;

public class Compass : MonoBehaviour {

	
	public GameObject Player;
	public GameObject goCompass;

	public GameObject[] Objective;
	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");
		goCompass = GameObject.FindGameObjectWithTag ("Compass");//GameObject.GetComponent("destroyObject");

	}
	
	// Update is called once per frame
	void Update () {
		
		//Get's direction, points that direction

		float temp = Vector3.Angle (Player.transform.forward, -goCompass.transform.forward);

		
		Vector3 temp2 = transform.localEulerAngles;
		if((-Player.transform.forward.x * goCompass.transform.forward.z + Player.transform.forward.z * goCompass.transform.forward.x)<0)
			temp2.z = temp;
		else
			temp2.z = 360-temp;
		
		transform.localEulerAngles = temp2;

	}
}
