using UnityEngine;
using System.Collections;

public class TankProjectile : MonoBehaviour {

	public float fInitVelocity;
	public float fGravity;
	public float TimeToDestroyShell;
	
	private float timeProj;
	// Use this for initialization
	void Start () {
		//Destroy the object after 5 Seconds
		Destroy(gameObject, TimeToDestroyShell);
	}
	
	// Update is called once per frame
	void Update () {
		//Gives the total time that the object has been flying to increase gravity effect over time
		//timeProj += Time.deltaTime;

		//Temp Vector3 in order to change position
		Vector3 temp = transform.position;
		//Gravity
	
		temp.y -= (-fGravity * Time.deltaTime);
		//Shoots forward
		temp+= transform.forward* fInitVelocity*Time.deltaTime;
		transform.position = temp;
	
	}
	void OnCollisionEneter(Collision other)
	{
		print (other.gameObject.name);
	}
}
