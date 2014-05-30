using UnityEngine;
using System.Collections;


public class PowerupMini : MonoBehaviour {

	public GameObject Player;
	public GameObject PowerUp;
	public GameObject[] PowerUps;
	Vector3 Direction;

	float LastPowerUpDistance;
	public GameObject[] Powerups;
	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");
		PowerUps = GameObject.FindGameObjectsWithTag ("PowerUp");
		LastPowerUpDistance = 1000;
		PowerUp = null;
		//destroyobject = GetComponent<destroyObject>();
	}
	
	// Update is called once per frame
	void Update () {

		//Debug.Log (PowerUps[0].name);

		for(int i = 0; i < PowerUps.GetLength (0); i++)
		{	if(PowerUps[i] != null)
				if((PowerUps[i].transform.position - Player.transform.position).magnitude < 100 && (PowerUps[i].transform.position - Player.transform.position).magnitude < LastPowerUpDistance)
				{
					PowerUp = PowerUps[i];
					LastPowerUpDistance = (PowerUps[i].transform.position - Player.transform.position).magnitude;
				}
		}
		//Debug.Log (PowerUp.name);
		if(PowerUp == null || PowerUp.Equals (null))
		{
			renderer.enabled = false;
			LastPowerUpDistance = 1000;
			//Change alpha
		}
		else
		{
			Debug.Log (PowerUp == null);
			Debug.Log (PowerUp.Equals (null));
			renderer.enabled = true;
			//Get's direction, points that direction
			Direction = (PowerUp.transform.position - Player.transform.position).normalized;
			
			float temp = Vector3.Angle (Player.transform.forward, Direction);
			
			Vector3 temp2 = transform.localEulerAngles;
			if((-Player.transform.forward.x * Direction.z + Player.transform.forward.z * Direction.x)<0)
				temp2.z = 360-temp;
			else
				temp2.z = temp;
			
			transform.localEulerAngles = temp2;

		}
	}
}
