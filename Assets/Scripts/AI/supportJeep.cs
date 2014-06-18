using UnityEngine;
using System.Collections;

public class supportJeep : MonoBehaviour {
	public static supportJeep Instance;
	public GameObject drop;
	public GameObject truckMesh;
	public GameObject misselPiller;
	public bool pickedUp;
	public bool follow;
	public bool workDammit;
	public Transform player;

	NavMeshAgent npc;



	// Use this for initialization
	void Start () {
		Instance = this;
		npc = GetComponent<NavMeshAgent>();
		follow = true;
		pickedUp = false;
		workDammit = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (follow && workDammit == false && pickedUp == false) 
		{
			npc.destination = player.localPosition;
			truckMesh.SetActive(false);
			
		}


		if (follow) 
		{
			npc.destination = player.localPosition;
		}
		
		if (workDammit == true)
		{
			follow = false;
			dropPickUp ();
		}

		if (pickedUp == true) 
		{
			follow = true;
			workDammit = false;
			misselPiller.SetActive(true);
		}
	}

	void dropPickUp()
	{
		truckMesh.SetActive (true);
		npc.destination = drop.transform.position;
		

	}
}
