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

		//destroyobject = GetComponent<destroyObject>();
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
		
		#region Other bad attempts-for notes if needed later 
		//Debug.Log ("transform.right"+transform.localRotation);
		//Debug.Log ("temp"+temp);
		//Debug.Log ("This"+ transform.position);
		//Rotation = Quaternion.LookRotation (Direction);
		//transform.rotation = Quaternion.Slerp (transform.rotation, Rotation, Time.deltaTime);
		//if(transform.eulerAngles.z < Rotation.eulerAngles.z)
		//	transform.eulerAngles += temp2;
		//temp = Cylynder.transform.position;
		//temp.z = 0;
		//temp.x = Cylynder.transform.position.x;
		//temp.y = Cylynder.transform.position.z;
		//transform.localRotation = Quaternion.Euler (0
		//transform.LookAt (temp);
		//if( transform.eulerAngles.z < temp.eulerAngles.y)
		//	transform.eulerAngles += temp2;
		//Debug.Log("Player"+Player.transform.forward);
		//temp =new Vector3(0,0,Mathf.Atan2 ((Cylynder.transform.position.z-Player.transform.position.z),(Cylynder.transform.position.x-Player.transform.position.z))*Mathf.Rad2Deg);
		//Debug.Log(temp);
		//Player.transform.forward - temp;
		//Quaternion temp = Quaternion.LookRotation (Direction, Vector3.up);
		//temp.x = Direction.x;
		//temp.y = Direction.z;
		//temp.z = Direction.y;
		//Cylynder = destroyobject.currentLightPillar;
		//
		#endregion
	}
}
