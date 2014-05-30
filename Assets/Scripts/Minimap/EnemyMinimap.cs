using UnityEngine;
using System.Collections;

public class EnemyMinimap : MonoBehaviour {

	public GameObject Player;
	public GameObject Enemy;
	public GameObject[] Enemies;
	Vector3 Direction;
	
	float LastEnemyDistance;
	public GameObject[] Powerups;
	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");
		Enemies = GameObject.FindGameObjectsWithTag ("enemy");
		LastEnemyDistance = 1000;
		Enemy = null;
		//destroyobject = GetComponent<destroyObject>();
	}
	
	// Update is called once per frame
	void Update () {
		
		//Debug.Log (Enemies.GetLength (0));
		
		for(int i = 0; i < Enemies.GetLength (0); i++)
		{
			if(Enemies[i] != null)
				if((Enemies[i].transform.position - Player.transform.position).magnitude < 100 && (Enemies[i].transform.position - Player.transform.position).magnitude < LastEnemyDistance)
				{
					Enemy = Enemies[i];
					LastEnemyDistance = (Enemies[i].transform.position - Player.transform.position).magnitude;
				}
		}
		//Debug.Log (Enemy.name);
		if(Enemy == null)
		{

			renderer.enabled = false;
			LastEnemyDistance = 1000;
			//Change alpha
		}
		else
		{
			//Debug.Log (Enemy.name);
			renderer.enabled = true;
			//Get's direction, points that direction
			Direction = (Enemy.transform.position - Player.transform.position).normalized;
			
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
